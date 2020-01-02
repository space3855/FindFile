using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FindFile
{


    public partial class Form1 : Form
    {


        public string StartPatch;
        private string FileSearch;
        private string TextSearch;
        List<string> FilesFaund = new List<string>();
        FileSeach fileSeach;



        public Form1()
        {
            InitializeComponent();
            textBox_StartFolder.Text = Properties.Settings.Default.StartFolder;
            textBox_FileSearch.Text = Properties.Settings.Default.FileSearch;
            textBox_DataSearch.Text = Properties.Settings.Default.DataSearch;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {

                StartPatch = fbd.SelectedPath;
                textBox_StartFolder.Text = StartPatch;
            }
        }

        private void textBox_FileSearch_TextChanged(object sender, EventArgs e)
        {
            //
            button_Search.Enabled = CheckFileSearch();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            button_Search.Text = "Новый поиск";
            button_pause.Text = "Пауза";
            button_pause.Enabled = true;
            TreeView.Nodes.Clear();
            if (fileSeach != null)
            {
                fileSeach.pause = true;
                //fileSeach.stop = true;
                fileSeach.StopThread();
            }

            StartPatch = textBox_StartFolder.Text;
            FileSearch = textBox_FileSearch.Text;
            TextSearch = textBox_DataSearch.Text;

            //проверяем начальную папку
            if (StartPatch == "")
            {
                //пустой путь, открываем окно выбора папки
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    StartPatch = fbd.SelectedPath;
                    textBox_StartFolder.Text = StartPatch;
                }
            }
            else
            {
                //пробуем открыть
                try
                {
                    DirectoryInfo[] dir = new DirectoryInfo(StartPatch).GetDirectories();

                    if (FileSearch == "")
                    {
                        textBox_FileSearch.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox_FileSearch.BackColor = Color.White;
                        Properties.Settings.Default.StartFolder = textBox_StartFolder.Text;
                        Properties.Settings.Default.FileSearch = textBox_FileSearch.Text;
                        Properties.Settings.Default.DataSearch = textBox_DataSearch.Text;
                        Properties.Settings.Default.Save();

                        fileSeach = new FileSeach(StartPatch, FileSearch, TextSearch, this);
                    }

                }
                catch (DirectoryNotFoundException ex)
                {
                    //такой директории нет
                    FileProgress.Text = ex.Message;
                }
            }

            

        }

        public void AddNodeInTree(string PathToFile)
        {
            //добавляем найденый файл в дерево
            char PathSeparator = '\\';
            TreeNode LastNode = null;

            string SubPathAgg = string.Empty;

            foreach (string SubPath in PathToFile.Split(PathSeparator))
            {
                SubPathAgg += SubPath + PathSeparator;

                TreeNode[] Nodes = TreeView.Nodes.Find(SubPathAgg, true);

                if (Nodes.Length == 0)
                {
                    if (LastNode == null)
                    {
                        LastNode = TreeView.Nodes.Add(SubPathAgg, SubPath);
                    }
                    else
                    {
                        LastNode = LastNode.Nodes.Add(SubPathAgg, SubPath);
                    }
                }
                else
                {
                    LastNode = Nodes[0];
                }
            }
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            fileSeach.pause = !fileSeach.pause;
            if (fileSeach.pause)
            {
                button_pause.Text = "Возобновить";
            }
            else
            {
                button_pause.Text = "Пауза";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fileSeach != null)
            {
                //fileSeach.stop = true;
                fileSeach.StopThread();
            }
        }

        public void SetFileProgress(string file)
        {
            FileProgress.Text = file;
        }

        public void SetTimeSearch(string time)
        {
            TimeSearch.Text = "Время поиска: " + time+"  c.";
        }

        public void CountFileSet(string count)
        {
            CountFile.Text = "Файлов проверено: " + count;
        }

        public void ErrorInSearch(string message)
        {
            EndSearch();
            FileProgress.Text = message;
        }

        public void EndSearch()
        {
            FileProgress.Text = "Поиск завершён";
            button_Search.Text = "Новый поиск";
            button_pause.Enabled = false;
        }

        bool CheckFileSearch()
        {
            //проверяем доступность символов
            if (FileSearch == "")
            {
                textBox_FileSearch.BackColor = Color.Red;
                return false;
            }
            else
            {

                foreach (char s in textBox_FileSearch.Text)
                {
                    foreach (char inv in Path.GetInvalidPathChars())
                    {
                        if (s == inv)
                        {
                            textBox_FileSearch.BackColor = Color.Red;
                            return false;
                        }
                    }
                }

            }
            textBox_FileSearch.BackColor = Color.White;
            return true;
        }
    }


}
