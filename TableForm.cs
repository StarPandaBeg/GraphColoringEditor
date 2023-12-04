using IND_KDM.Graphs;
using IND_KDM.Graphs.Base;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IND_KDM
{
    public partial class TableForm : Form
    {
        private readonly Graph _graph;

        public TableForm(Graph graphInitial)
        {
            InitializeComponent();

            _graph = graphInitial;

            adjacencyMatrix.CellValueChanged += OnCellValueChanged;
            RefreshTable();
        }

        private void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == e.ColumnIndex)
            {
                adjacencyMatrix.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = "0";
                return;
            }
            adjacencyMatrix.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = adjacencyMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void onSaveButtonClick(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void onCancelButtonClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Save()
        {
            _graph.ClearEdges();

            for (int i = 0; i < adjacencyMatrix.ColumnCount; i++)
            {
                var nodeColumnValue = Convert.ToInt32(adjacencyMatrix.Columns[i].HeaderText);
                for (int j = 0; j < adjacencyMatrix.RowCount; j++)
                {
                    if (i == j) continue;

                    var nodeRowValue = Convert.ToInt32(adjacencyMatrix.Rows[j].HeaderCell.Value);
                    var value = Convert.ToInt32(adjacencyMatrix.Rows[j].Cells[i].Value);

                    if (value == 0) continue;

                    var nodeA = _graph.GetNode(nodeColumnValue);
                    var nodeB = _graph.GetNode(nodeRowValue);

                    if (hasWeight.Checked)
                    {
                        _graph.AddEdge(nodeA, nodeB, value);
                    } else
                    {
                        _graph.AddEdge(nodeA, nodeB);
                    }
                }
            }
        }

        private void RefreshTable()
        {
            adjacencyMatrix.Rows.Clear();
            adjacencyMatrix.Columns.Clear();

            foreach (var node in _graph.Nodes)
            {
                var column = new DataGridViewColumn();
                column.HeaderCell.Value = node.Value.ToString();
                column.Width = 50;

                adjacencyMatrix.Columns.Add(column);
            }

            foreach (var node in _graph.Nodes)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = node.Value.ToString();

                for (int i = 0; i < adjacencyMatrix.ColumnCount; i++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells[i].Value = "0";

                    var columnValue = Convert.ToInt32(adjacencyMatrix.Columns[i].HeaderText);

                    Edge edge;
                    if ((edge = node.Edges.FirstOrDefault(e => e.Node2.Value == columnValue)) != null)
                    {
                        row.Cells[i].Value = _graph.IsWeighted ? edge.Weight.ToString() : "1";
                    }
                }

                adjacencyMatrix.Rows.Add(row);
            }

            hasWeight.Checked = _graph.IsWeighted;
        }
    }
}
