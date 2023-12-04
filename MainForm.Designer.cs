
namespace IND_KDM
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolTip tooltip;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.clearColorButton = new System.Windows.Forms.Button();
            this.listingButton = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_edge = new System.Windows.Forms.Button();
            this.btn_table = new System.Windows.Forms.Button();
            this.bth_paint = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listing = new System.Windows.Forms.TextBox();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.graphCanvas = new System.Windows.Forms.PictureBox();
            tooltip = new System.Windows.Forms.ToolTip(this.components);
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
            this.actionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // clearColorButton
            // 
            this.clearColorButton.BackgroundImage = global::IND_KDM.Properties.Resources.eraser;
            this.clearColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearColorButton.FlatAppearance.BorderSize = 0;
            this.clearColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearColorButton.Location = new System.Drawing.Point(712, 3);
            this.clearColorButton.Name = "clearColorButton";
            this.clearColorButton.Size = new System.Drawing.Size(50, 50);
            this.clearColorButton.TabIndex = 14;
            tooltip.SetToolTip(this.clearColorButton, "Очистить цвета");
            this.clearColorButton.UseVisualStyleBackColor = true;
            this.clearColorButton.Click += new System.EventHandler(this.onClearColorButtonClick);
            // 
            // listingButton
            // 
            this.listingButton.BackgroundImage = global::IND_KDM.Properties.Resources.log;
            this.listingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.listingButton.FlatAppearance.BorderSize = 0;
            this.listingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listingButton.Location = new System.Drawing.Point(920, 3);
            this.listingButton.Name = "listingButton";
            this.listingButton.Size = new System.Drawing.Size(50, 50);
            this.listingButton.TabIndex = 13;
            tooltip.SetToolTip(this.listingButton, "Открыть листинг");
            this.listingButton.UseVisualStyleBackColor = true;
            this.listingButton.Click += new System.EventHandler(this.onListingButtonClick);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::IND_KDM.Properties.Resources._new;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(12, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(50, 50);
            this.btn_add.TabIndex = 1;
            tooltip.SetToolTip(this.btn_add, "Добавить вершину");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.onButtonAddClick);
            // 
            // btn_edge
            // 
            this.btn_edge.BackgroundImage = global::IND_KDM.Properties.Resources.segment;
            this.btn_edge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_edge.FlatAppearance.BorderSize = 0;
            this.btn_edge.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_edge.Location = new System.Drawing.Point(68, 3);
            this.btn_edge.Name = "btn_edge";
            this.btn_edge.Size = new System.Drawing.Size(50, 50);
            this.btn_edge.TabIndex = 3;
            tooltip.SetToolTip(this.btn_edge, "Добавить ребро");
            this.btn_edge.UseVisualStyleBackColor = true;
            this.btn_edge.Click += new System.EventHandler(this.onButtonEdgeClick);
            // 
            // btn_table
            // 
            this.btn_table.BackgroundImage = global::IND_KDM.Properties.Resources.table;
            this.btn_table.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_table.FlatAppearance.BorderSize = 0;
            this.btn_table.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_table.Location = new System.Drawing.Point(180, 3);
            this.btn_table.Name = "btn_table";
            this.btn_table.Size = new System.Drawing.Size(50, 50);
            this.btn_table.TabIndex = 7;
            tooltip.SetToolTip(this.btn_table, "Редактор таблиц");
            this.btn_table.UseVisualStyleBackColor = true;
            this.btn_table.Click += new System.EventHandler(this.onButtonTableClick);
            // 
            // bth_paint
            // 
            this.bth_paint.BackgroundImage = global::IND_KDM.Properties.Resources.brush;
            this.bth_paint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bth_paint.FlatAppearance.BorderSize = 0;
            this.bth_paint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bth_paint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bth_paint.Location = new System.Drawing.Point(656, 3);
            this.bth_paint.Name = "bth_paint";
            this.bth_paint.Size = new System.Drawing.Size(50, 50);
            this.bth_paint.TabIndex = 12;
            tooltip.SetToolTip(this.bth_paint, "Раскрасить граф");
            this.bth_paint.UseVisualStyleBackColor = true;
            this.bth_paint.Click += new System.EventHandler(this.onPaintButtonClick);
            // 
            // btn_clear
            // 
            this.btn_clear.BackgroundImage = global::IND_KDM.Properties.Resources.clear;
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_clear.FlatAppearance.BorderSize = 0;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clear.Location = new System.Drawing.Point(236, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(50, 50);
            this.btn_clear.TabIndex = 4;
            tooltip.SetToolTip(this.btn_clear, "Очистить граф");
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.onButtonClearClick);
            // 
            // btn_load
            // 
            this.btn_load.BackgroundImage = global::IND_KDM.Properties.Resources.load;
            this.btn_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_load.FlatAppearance.BorderSize = 0;
            this.btn_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_load.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_load.Location = new System.Drawing.Point(544, 3);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(50, 50);
            this.btn_load.TabIndex = 10;
            tooltip.SetToolTip(this.btn_load, "Загрузить граф");
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.onLoadButtonClick);
            // 
            // btn_save
            // 
            this.btn_save.BackgroundImage = global::IND_KDM.Properties.Resources.save;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_save.Location = new System.Drawing.Point(488, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 50);
            this.btn_save.TabIndex = 9;
            tooltip.SetToolTip(this.btn_save, "Сохранить граф");
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.onSaveButtonClick);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(770, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 17);
            label1.TabIndex = 13;
            label1.Text = "Листинг";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(115, 17);
            label2.TabIndex = 14;
            label2.Text = "Редактор графа";
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 657);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(982, 26);
            this.status.SizingGrip = false;
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(146, 20);
            this.statusLabel.Text = "Добро пожаловать.";
            // 
            // listing
            // 
            this.listing.BackColor = System.Drawing.Color.White;
            this.listing.Location = new System.Drawing.Point(770, 32);
            this.listing.Multiline = true;
            this.listing.Name = "listing";
            this.listing.ReadOnly = true;
            this.listing.Size = new System.Drawing.Size(200, 560);
            this.listing.TabIndex = 5;
            this.listing.TabStop = false;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.clearColorButton);
            this.actionPanel.Controls.Add(this.listingButton);
            this.actionPanel.Controls.Add(this.btn_add);
            this.actionPanel.Controls.Add(this.btn_edge);
            this.actionPanel.Controls.Add(this.btn_table);
            this.actionPanel.Controls.Add(this.bth_paint);
            this.actionPanel.Controls.Add(this.btn_clear);
            this.actionPanel.Controls.Add(this.btn_load);
            this.actionPanel.Controls.Add(this.btn_save);
            this.actionPanel.Location = new System.Drawing.Point(0, 598);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(982, 56);
            this.actionPanel.TabIndex = 15;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // graphCanvas
            // 
            this.graphCanvas.BackColor = System.Drawing.Color.White;
            this.graphCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphCanvas.Location = new System.Drawing.Point(12, 32);
            this.graphCanvas.Name = "graphCanvas";
            this.graphCanvas.Size = new System.Drawing.Size(750, 560);
            this.graphCanvas.TabIndex = 0;
            this.graphCanvas.TabStop = false;
            this.graphCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.onCanvasPaint);
            this.graphCanvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onCanvasDoubleClick);
            this.graphCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onCanvasMouseDown);
            this.graphCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onCanvasMove);
            this.graphCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onCanvasMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 683);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.listing);
            this.Controls.Add(this.status);
            this.Controls.Add(this.graphCanvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 730);
            this.MinimumSize = new System.Drawing.Size(1000, 730);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Раскраска - Индивидульное задание по КДМ";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphCanvas;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Button btn_edge;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox listing;
        private System.Windows.Forms.Button btn_table;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button bth_paint;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button listingButton;
        private System.Windows.Forms.Button clearColorButton;
    }
}

