namespace TextNormalization
{
    partial class Form1
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
            this.startText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endText = new System.Windows.Forms.RichTextBox();
            this.normalizationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startText
            // 
            this.startText.Location = new System.Drawing.Point(12, 36);
            this.startText.Name = "startText";
            this.startText.Size = new System.Drawing.Size(320, 292);
            this.startText.TabIndex = 0;
            this.startText.Text = "Введите текст";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Исходный текст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(575, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Нормализованный текст";
            // 
            // endText
            // 
            this.endText.Location = new System.Drawing.Point(468, 36);
            this.endText.Name = "endText";
            this.endText.Size = new System.Drawing.Size(320, 292);
            this.endText.TabIndex = 3;
            this.endText.Text = "";
            // 
            // normalizationButton
            // 
            this.normalizationButton.Location = new System.Drawing.Point(338, 67);
            this.normalizationButton.Name = "normalizationButton";
            this.normalizationButton.Size = new System.Drawing.Size(124, 21);
            this.normalizationButton.TabIndex = 5;
            this.normalizationButton.Text = "Нормализовать";
            this.normalizationButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.normalizationButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startText);
            this.Name = "Form1";
            this.Text = "Нормализация текста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox startText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox endText;
        private System.Windows.Forms.Button normalizationButton;
    }
}

