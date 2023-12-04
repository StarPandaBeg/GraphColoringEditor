
using System.Windows.Forms;

namespace IND_KDM
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.adjacencyMatrix = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hasWeight = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyMatrix)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(141, 17);
            label1.TabIndex = 1;
            label1.Text = "Матрица смежности";
            // 
            // adjacencyMatrix
            // 
            this.adjacencyMatrix.AllowUserToAddRows = false;
            this.adjacencyMatrix.AllowUserToDeleteRows = false;
            this.adjacencyMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adjacencyMatrix.Location = new System.Drawing.Point(12, 29);
            this.adjacencyMatrix.Name = "adjacencyMatrix";
            this.adjacencyMatrix.RowHeadersWidth = 51;
            this.adjacencyMatrix.RowTemplate.Height = 24;
            this.adjacencyMatrix.Size = new System.Drawing.Size(400, 400);
            this.adjacencyMatrix.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(326, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 31);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.onCancelButtonClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(225, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 31);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.onSaveButtonClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Location = new System.Drawing.Point(-10, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 60);
            this.panel1.TabIndex = 6;
            // 
            // hasWeight
            // 
            this.hasWeight.AutoSize = true;
            this.hasWeight.Location = new System.Drawing.Point(12, 441);
            this.hasWeight.Name = "hasWeight";
            this.hasWeight.Size = new System.Drawing.Size(125, 21);
            this.hasWeight.TabIndex = 7;
            this.hasWeight.Text = "Граф взвешен";
            this.hasWeight.UseVisualStyleBackColor = true;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 532);
            this.Controls.Add(this.hasWeight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(label1);
            this.Controls.Add(this.adjacencyMatrix);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(447, 579);
            this.MinimumSize = new System.Drawing.Size(447, 579);
            this.Name = "TableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор таблиц";
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyMatrix)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView adjacencyMatrix;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel1;
        private CheckBox hasWeight;
    }
}