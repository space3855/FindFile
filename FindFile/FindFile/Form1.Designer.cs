using System;

namespace FindFile
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.textBox_StartFolder = new System.Windows.Forms.TextBox();
            this.textBox_FileSearch = new System.Windows.Forms.TextBox();
            this.textBox_DataSearch = new System.Windows.Forms.TextBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_pause = new System.Windows.Forms.Button();
            this.FileProgress = new System.Windows.Forms.Label();
            this.TimeSearch = new System.Windows.Forms.Label();
            this.CountFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(320, 88);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(1198, 730);
            this.TreeView.TabIndex = 0;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Location = new System.Drawing.Point(732, 25);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(147, 37);
            this.SelectFolderButton.TabIndex = 1;
            this.SelectFolderButton.Text = "Выбор папки";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // textBox_StartFolder
            // 
            this.textBox_StartFolder.Location = new System.Drawing.Point(45, 29);
            this.textBox_StartFolder.Name = "textBox_StartFolder";
            this.textBox_StartFolder.Size = new System.Drawing.Size(622, 26);
            this.textBox_StartFolder.TabIndex = 2;
            // 
            // textBox_FileSearch
            // 
            this.textBox_FileSearch.Location = new System.Drawing.Point(44, 88);
            this.textBox_FileSearch.Name = "textBox_FileSearch";
            this.textBox_FileSearch.Size = new System.Drawing.Size(251, 26);
            this.textBox_FileSearch.TabIndex = 3;
            this.textBox_FileSearch.TextChanged += new System.EventHandler(this.textBox_FileSearch_TextChanged);
            // 
            // textBox_DataSearch
            // 
            this.textBox_DataSearch.Location = new System.Drawing.Point(45, 148);
            this.textBox_DataSearch.Name = "textBox_DataSearch";
            this.textBox_DataSearch.Size = new System.Drawing.Size(250, 26);
            this.textBox_DataSearch.TabIndex = 4;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(44, 199);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(195, 43);
            this.button_Search.TabIndex = 5;
            this.button_Search.Text = "Поиск";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "текст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Искать в:";
            // 
            // button_pause
            // 
            this.button_pause.Enabled = false;
            this.button_pause.Location = new System.Drawing.Point(44, 257);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(195, 44);
            this.button_pause.TabIndex = 9;
            this.button_pause.Text = "Пауза";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // FileProgress
            // 
            this.FileProgress.AutoSize = true;
            this.FileProgress.Location = new System.Drawing.Point(40, 826);
            this.FileProgress.Name = "FileProgress";
            this.FileProgress.Size = new System.Drawing.Size(0, 20);
            this.FileProgress.TabIndex = 10;
            // 
            // TimeSearch
            // 
            this.TimeSearch.AutoSize = true;
            this.TimeSearch.Location = new System.Drawing.Point(40, 370);
            this.TimeSearch.Name = "TimeSearch";
            this.TimeSearch.Size = new System.Drawing.Size(118, 20);
            this.TimeSearch.TabIndex = 11;
            this.TimeSearch.Text = "Время поиска:";
            // 
            // CountFile
            // 
            this.CountFile.AutoSize = true;
            this.CountFile.Location = new System.Drawing.Point(44, 323);
            this.CountFile.Name = "CountFile";
            this.CountFile.Size = new System.Drawing.Size(159, 20);
            this.CountFile.TabIndex = 12;
            this.CountFile.Text = "Файлов проверено:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 855);
            this.Controls.Add(this.CountFile);
            this.Controls.Add(this.TimeSearch);
            this.Controls.Add(this.FileProgress);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.textBox_DataSearch);
            this.Controls.Add(this.textBox_FileSearch);
            this.Controls.Add(this.textBox_StartFolder);
            this.Controls.Add(this.SelectFolderButton);
            this.Controls.Add(this.TreeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.TextBox textBox_StartFolder;
        private System.Windows.Forms.TextBox textBox_FileSearch;
        private System.Windows.Forms.TextBox textBox_DataSearch;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Label FileProgress;
        private System.Windows.Forms.Label TimeSearch;
        private System.Windows.Forms.Label CountFile;
    }
}

