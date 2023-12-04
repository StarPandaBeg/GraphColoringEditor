
using IND_KDM.Graphs;
using IND_KDM.GUI;
using IND_KDM.StateMachine;
using IND_KDM.StateMachine.States;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace IND_KDM
{
    public partial class MainForm : Form
    {
        private readonly Graph _graph = new Graph();
        private readonly GraphRenderer _renderer;
        private readonly GraphStorage _storage;

        private readonly EditorStateMachine _stateMachine;
        private TableForm _tableForm;

        public MainForm()
        {
            InitializeComponent();
            Status.Init(statusLabel);
            Listing.Init(listing);

            saveFileDialog.FileOk += OnFileSave;
            openFileDialog.FileOk += OnFileLoad;

            _graph.OnChange += graphCanvas.Refresh;
            _renderer = new GraphRenderer(_graph);
            _storage = new GraphStorage(_graph);

            _stateMachine = new EditorStateMachine(_graph);
            _stateMachine.ChangeState(new NodeSelectState());
        }

        public void onCanvasPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            _renderer.Draw(e.Graphics);
        }

        public void onCanvasMove(object sender, MouseEventArgs e)
        {
            _stateMachine.Signal(Signals.MouseMove, e);
        }

        public void onCanvasMouseDown(object sender, MouseEventArgs e)
        {
            _stateMachine.Signal(Signals.MouseDown, e);
        }

        public void onCanvasMouseUp(object sender, MouseEventArgs e)
        {
            _stateMachine.Signal(Signals.MouseUp, e);
        }

        public void onCanvasDoubleClick(object sender, MouseEventArgs e)
        {
            _stateMachine.Signal(Signals.MouseDoubleClick, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _stateMachine.Signal(Signals.KeyboardDown, e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            switch (e.KeyCode)
            {
                case Keys.A:
                    AddNode();
                    break;
                case Keys.E:
                    SwitchToEdgeMode();
                    break;
            }

            _stateMachine.Signal(Signals.KeyboardUp, e);
        }

        private void onButtonAddClick(object sender, EventArgs e)
        {
            AddNode();
        }

        private void onButtonClearClick(object sender, EventArgs e)
        {
            _graph.Clear();
            Status.Show($"Граф очищен");
            Listing.AddLine($"Граф очищен");
        }

        private void onButtonEdgeClick(object sender, EventArgs e)
        {
            SwitchToEdgeMode();
        }

        private void onButtonTableClick(object sender, EventArgs e)
        {
            OpenTableForm();
        }

        private void OnTableFormClosed(object sender, FormClosedEventArgs e)
        {
            _tableForm.FormClosed -= OnTableFormClosed;
            _tableForm = null;

            actionPanel.Enabled = true;
            graphCanvas.Enabled = true;

            Status.Show($"Граф обновлён с учётом введенной матрицы смежности");
            Listing.AddLine($"Граф обновлён с учётом введенной матрицы смежности");
        }

        private void onSaveButtonClick(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = ".cgraph";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Graph files (.cgraph)|*.cgraph";
            saveFileDialog.ShowDialog();
        }

        private void onLoadButtonClick(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".cgraph";
            openFileDialog.Filter = "Graph files (.cgraph)|*.cgraph";
            openFileDialog.ShowDialog();
        }

        private void OnFileSave(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _storage.Save(saveFileDialog.FileName);
            Status.Show($"Граф сохранён в {saveFileDialog.FileName}");
            Listing.AddLine($"Граф сохранён в {saveFileDialog.FileName}");
        }

        private void OnFileLoad(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _storage.Load(openFileDialog.FileName);
                Status.Show($"Граф загружен из {openFileDialog.FileName}");
                Listing.AddLine($"Граф загружен из {openFileDialog.FileName}");
            } catch (InvalidDataException ex)
            {
                Status.Show($"Файл повреждён");
                Listing.AddLine($"Произошла ошибка при загрузке графа из {openFileDialog.FileName}. Файл повреждён. Текст ошибки: {ex.Message}");
            }
        }

        private void onListingButtonClick(object sender, EventArgs e)
        {
            Process.Start(Listing.FilePath);
        }

        private void onPaintButtonClick(object sender, EventArgs e)
        {
            PaintGraph();
        }

        private void onClearColorButtonClick(object sender, EventArgs e)
        {
            ClearColor();
        }

        private void AddNode() {
            _graph.AddNode(20, 20, _graph.LastValue + 1);
            Status.Show($"Добавлена вершина с номером {_graph.LastValue}");
            Listing.AddLine($"Добавлена вершина с номером {_graph.LastValue}");
        }

        private void SwitchToEdgeMode() {
            if (_graph.Count == 0)
            {
                Status.Show("Сначала добавьте хотя бы одну вершину");
                return;
            }
            _stateMachine.ChangeState(new EdgeAddState());
        }

        private void OpenTableForm() {
            if (_tableForm != null)
            {
                _tableForm.Refresh();
                _tableForm.Focus();
                return;
            }

            actionPanel.Enabled = false;
            graphCanvas.Enabled = false;

            _tableForm = new TableForm(_graph);
            _tableForm.FormClosed += OnTableFormClosed;
            _tableForm.Show(this);
        }

        private void PaintGraph() {
            if (_graph.Count == 0)
            {
                Status.Show("Сначала добавьте хотя бы одну вершину");
                return;
            }
            GraphPaint.Do(_graph);
        }

        private void ClearColor() {
            if (_graph.Count == 0)
            {
                Status.Show("Сначала добавьте хотя бы одну вершину");
                return;
            }

            foreach (var node in _graph.Nodes)
            {
                node.Color = Color.White;
            }
            _graph.Refresh();

            Status.Show("Цвета графа очищены");
            Listing.AddLine("Цвета графа очищены");
        }
    }
}
