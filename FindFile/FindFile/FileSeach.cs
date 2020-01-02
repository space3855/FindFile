using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFile
{
    public class FileSeach
    {


        string StartFolder;
        string MaskFile;
        string InFileText;
        public Thread thread;
        public Form1 form;
        public bool pause = false;
        public bool stop = false;
        public FileInfo[] files;
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        int countFile = 0;


        public FileSeach(string _StartFolder, string _MaskFile, string _InFileText, Form1 _form)
        {
            StartFolder = _StartFolder;
            MaskFile = _MaskFile;
            InFileText = _InFileText;
            form = _form;
            files = null;
            countFile = 0;

            thread = new Thread(run);
            thread.IsBackground = true;
            thread.Start();
        }

        void run()
        {
            sw.Start();
            DirectoryInfo di = new DirectoryInfo(StartFolder);

            getFiles(di.GetDirectories());

            sw.Stop();
            form.BeginInvoke((Action)(() => form.EndSearch()));
        }


        bool FindText(string patch)
        {
            //ищем заданный текст в файле
            try
            {
                int index = 0; //счетчик для обновление UI
                countFile++;
                form.BeginInvoke((Action)(() => form.CountFileSet(countFile.ToString())));
                StreamReader str = new StreamReader(patch, Encoding.Default);
                while (!str.EndOfStream)
                {
                    if (pause)
                    {
                        Pause();
                    }
                    else
                    {
                        sw.Start();
                    }

                    index++;
                    if (index % 100 == 0)
                    {
                        form.BeginInvoke((Action)(() => form.SetTimeSearch((sw.ElapsedMilliseconds / 1000).ToString())));
                    }
                    string st = str.ReadLine();

                    if (st.IndexOf(Properties.Settings.Default.DataSearch) != -1)
                    {
                        return true;
                    }

                }
            }
            catch
            {
                //обработка исключений: нет доступа к файлу, файл занят и т.д.
                return false;
            }

            return false;
        }

        void getFiles(DirectoryInfo[] dir)
        {
            foreach (DirectoryInfo di in dir)
            {
                try
                {
                    //палучаем список файлов соответствующих маске
                    files = di.GetFiles(MaskFile, SearchOption.TopDirectoryOnly);
                    form.BeginInvoke((Action)(() => form.SetTimeSearch((sw.ElapsedMilliseconds / 1000).ToString())));

                    foreach (FileInfo file in files)
                    {

                        form.BeginInvoke((Action)(() => form.SetFileProgress(file.FullName)));
                        if (pause)
                        {
                            Pause();
                        }
                        else
                        {
                            sw.Start();
                            if (FindText(file.FullName))
                            {

                                form.BeginInvoke((Action)(() => form.AddNodeInTree(file.FullName)));
                            }
                        }

                    }
                    getFiles(di.GetDirectories()); //рекурсия

                }
                catch (UnauthorizedAccessException e)
                {
                    //нет доступа к каталогу
                }
                catch (System.ArgumentException e)
                {
                    //маска поиска задана неверно
                    form.BeginInvoke((Action)(() => form.ErrorInSearch(e.Message)));
                    StopThread();
                }
            }
        }

        private void Pause()
        {
            //приостанавливаем поиск
            while (pause && !stop)
            {
                Thread.Sleep(500);
                sw.Stop();
            }
        }

        public void StopThread()
        {
            //завершаем поиск
            thread.Abort();
            thread.Join(500);
        }
    }
}
