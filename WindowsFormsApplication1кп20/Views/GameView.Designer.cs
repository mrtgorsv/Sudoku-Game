namespace WindowsFormsApplication1кп20.Views
{
    partial class GameView
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CheckResultButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalTimeLabel = new System.Windows.Forms.Label();
            this.SudokuBoardGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.SudokuBoardGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckResultButton
            // 
            this.CheckResultButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CheckResultButton.Enabled = false;
            this.CheckResultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckResultButton.Location = new System.Drawing.Point(453, 44);
            this.CheckResultButton.Name = "CheckResultButton";
            this.CheckResultButton.Size = new System.Drawing.Size(169, 43);
            this.CheckResultButton.TabIndex = 1;
            this.CheckResultButton.Text = "Генерация поля...";
            this.CheckResultButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(453, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Время:";
            // 
            // TotalTimeLabel
            // 
            this.TotalTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalTimeLabel.Location = new System.Drawing.Point(507, 1);
            this.TotalTimeLabel.Name = "TotalTimeLabel";
            this.TotalTimeLabel.Size = new System.Drawing.Size(121, 40);
            this.TotalTimeLabel.TabIndex = 3;
            this.TotalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SudokuBoardGridView
            // 
            this.SudokuBoardGridView.AllowUserToAddRows = false;
            this.SudokuBoardGridView.AllowUserToDeleteRows = false;
            this.SudokuBoardGridView.AllowUserToResizeColumns = false;
            this.SudokuBoardGridView.AllowUserToResizeRows = false;
            this.SudokuBoardGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SudokuBoardGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SudokuBoardGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SudokuBoardGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.SudokuBoardGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.SudokuBoardGridView.Location = new System.Drawing.Point(12, 13);
            this.SudokuBoardGridView.MaximumSize = new System.Drawing.Size(435, 453);
            this.SudokuBoardGridView.MinimumSize = new System.Drawing.Size(435, 453);
            this.SudokuBoardGridView.Name = "SudokuBoardGridView";
            this.SudokuBoardGridView.RowHeadersVisible = false;
            this.SudokuBoardGridView.RowHeadersWidth = 23;
            this.SudokuBoardGridView.RowTemplate.Height = 50;
            this.SudokuBoardGridView.Size = new System.Drawing.Size(435, 453);
            this.SudokuBoardGridView.TabIndex = 4;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.SudokuBoardGridView);
            this.Controls.Add(this.TotalTimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckResultButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "GameView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.SudokuBoardGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CheckResultButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalTimeLabel;
        private System.Windows.Forms.DataGridView SudokuBoardGridView;

    }
}