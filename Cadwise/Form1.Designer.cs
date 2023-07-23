namespace Cadwise
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listBoxFiles = new ListBox();
            buttonBrowse = new Button();
            buttonProcess = new Button();
            numericUpDownWordLength = new NumericUpDown();
            checkBoxRemovePunctuation = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWordLength).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 26);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Список файлов:";
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(29, 54);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(209, 289);
            listBoxFiles.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(83, 379);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 3;
            buttonBrowse.Text = "Обзор";
            buttonBrowse.UseVisualStyleBackColor = true;
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(384, 151);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(87, 23);
            buttonProcess.TabIndex = 4;
            buttonProcess.Text = "Обработать";
            buttonProcess.UseVisualStyleBackColor = true;
            // 
            // numericUpDownWordLength
            // 
            numericUpDownWordLength.Location = new Point(384, 54);
            numericUpDownWordLength.Name = "numericUpDownWordLength";
            numericUpDownWordLength.Size = new Size(134, 23);
            numericUpDownWordLength.TabIndex = 5;
            // 
            // checkBoxRemovePunctuation
            // 
            checkBoxRemovePunctuation.AutoSize = true;
            checkBoxRemovePunctuation.Location = new Point(384, 105);
            checkBoxRemovePunctuation.Name = "checkBoxRemovePunctuation";
            checkBoxRemovePunctuation.Size = new Size(134, 19);
            checkBoxRemovePunctuation.TabIndex = 6;
            checkBoxRemovePunctuation.Text = "Убрать пунктуацию";
            checkBoxRemovePunctuation.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 346);
            label2.Name = "label2";
            label2.Size = new Size(160, 30);
            label2.TabIndex = 7;
            label2.Text = "Перетащите файл \r\nлибо найдите в проводнике";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(384, 26);
            label3.Name = "label3";
            label3.Size = new Size(147, 15);
            label3.TabIndex = 8;
            label3.Text = "Длина слов для удаления";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkBoxRemovePunctuation);
            Controls.Add(numericUpDownWordLength);
            Controls.Add(buttonProcess);
            Controls.Add(buttonBrowse);
            Controls.Add(listBoxFiles);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDownWordLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBoxFiles;
        private Button buttonBrowse;
        private Button buttonProcess;
        private NumericUpDown numericUpDownWordLength;
        private CheckBox checkBoxRemovePunctuation;
        private Label label2;
        private Label label3;
    }
}