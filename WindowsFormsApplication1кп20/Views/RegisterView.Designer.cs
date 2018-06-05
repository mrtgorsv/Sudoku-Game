namespace WindowsFormsApplication1кп20.Views
{
    partial class RegisterView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.RulesButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.Location = new System.Drawing.Point(72, 145);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(262, 31);
            this.NameTextBox.TabIndex = 2;
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(355, 145);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(161, 31);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = false;
            // 
            // ContinueButton
            // 
            this.ContinueButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ContinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContinueButton.Location = new System.Drawing.Point(260, 194);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(155, 36);
            this.ContinueButton.TabIndex = 4;
            this.ContinueButton.Text = "Продолжить";
            this.ContinueButton.UseVisualStyleBackColor = false;
            // 
            // RulesButton
            // 
            this.RulesButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RulesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RulesButton.Location = new System.Drawing.Point(12, 413);
            this.RulesButton.Name = "RulesButton";
            this.RulesButton.Size = new System.Drawing.Size(155, 36);
            this.RulesButton.TabIndex = 5;
            this.RulesButton.Text = "Правила игры";
            this.RulesButton.UseVisualStyleBackColor = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(490, 413);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(155, 36);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(657, 461);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RulesButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Игра \"Судоку\"";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Button RulesButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

