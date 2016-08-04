using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;


namespace FilmCollection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.MinimumSize = new Size(800, 600);   // Установка минимального размера формы
            InitializeComponent();                  // Создание и отрисовка элементов
            dgvTable.AutoGenerateColumns = false;   // Отключение автоматического заполнения таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона
            dgvTable.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста
            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию

            // Создание списка на основе перечисления
            foreach (var item in Enum.GetValues(typeof(CategoryVideoRus)))
            {
                cBoxTypeVideo.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(GenreVideoRus)))
            {
                cBoxGenre.Items.Add(item);
            }

            smth = new BackgroundWorker();
            smth.DoWork += Smth_DoWork;
            smth.RunWorkerCompleted += Smth_RunWorkerCompleted;
            smth.ProgressChanged += Smth_ProgressChanged;
            smth.ReportProgress(12);
            smth.WorkerReportsProgress = true;
        }

        private void Smth_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgressBar.Value = e.ProgressPercentage;
        }

        private void Smth_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _videoCollection.Save();
            FormLoad();
        }


        private void Smth_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo directory = (DirectoryInfo)e.Argument;

            if (directory.Exists)
            {
                int count = 0;

                ////int[] mylnts = new int[10];             // массив значений на каждые 10%
                //ArrayList myAL = new ArrayList();
                ////for (int i = 0; i < mylnts.Length; i++) // проходимся по элементам массива
                ////{
                ////    mylnts[i] = Convert.ToInt32(Math.Floor(fCount*0.1*(i+1)));  // Вычисляем значение и присваиваем
                ////}
                //for (int i = 0; i < 10; i++)
                //{
                //    myAL.Add(Convert.ToInt32(Math.Floor(fCount * 0.1 * (i + 1))));
                //}



                _videoCollection.Options.Source = directory.FullName;   // Сохранение каталога фильмов
                char[] charsToTrim = { '.' };
                foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                {
                    count++;
                    // if (count == fCount/100*)
                    //foreach (int i in mylnts)
                    //{
                    //    if (count == i)
                    //    { 
                    //        int index = Array.IndexOf(mylnts, i);
                    //    }
                    //}


                    smth.ReportProgress(count);

                    record = new Record();

                    record.Name = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length);  // название без расширения (film)
                    record.FileName = file.Name;                            // полное название файла (film.avi)
                    record.Extension = file.Extension.Trim(charsToTrim);    // расширение файла (avi)
                    record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
                    record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                            // if (-1 != file.DirectoryName.Substring(dlinna).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                    _videoCollection.Add(record);
                }
            }
        }

        private void Main_FormLoad(object sender, EventArgs e)      // Загрузка формы
        {
            FormLoad();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)    // обработка закрытия формы или выхода
        {
            FormClose(e);
        }


        #region Главное меню

        private void CreateBase_Click(object sender, EventArgs e)
        {
            CreateBase();
        }

        private void UpdateBase_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void BackupBase_Click(object sender, EventArgs e)    // Создание копии базы
        {
            BackupBase();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Сформировать отчет в формате html и открыть его в браузере по умолчанию 
        }

        private void Exit_Click(object sender, EventArgs e)   //Выход
        {
            Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        #endregion


        #region Контекстное меню для DataGridView
        private void Filter(object sender, EventArgs e)     // При выборе фильтра выполняется сброс фильтра по дереву и таблице
        {
            dgvTable.ClearSelection();
            RefreshTable("");
        }

        private void AddRec_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            NewRecord();
        }

        private void EditRec_Click(object sender, EventArgs e)                 // Изменение записи
        {
            panelEdit.BringToFront();
        }

        private void Test_Add_rec(object sender, EventArgs e)                 // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Add(form.rec);
                _videoCollection.Save();
                RefreshTable("");
            }
        }

        private void Test_Change_rec(object sender, EventArgs e)          // Изменить запись
        {
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                RefreshTable("");      //Должно быть обновление вместо фильтра
            }
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)    // Проверка селекта строки перед открытием меню
        {
            //contextMenu.Items[4].Enabled = false;
            contextMenu.Enabled = false;    // Блокировка меню

            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                //contextMenu.Items[4].Enabled = true;
                contextMenu.Enabled = true; // Разблокировка меню
            }
        }

        private void cFind_Click(object sender, EventArgs e)    // Поиск
        {
            panelFind.BringToFront();
        }
        #endregion


        private void FileNameEdit_Unlock(object sender, EventArgs e)  // Разблокировка поля имени файла
        {
            tbFileName.Enabled = true;
            btnFileNameEdit.Enabled = false;    // блокировка кнопки разблокировки :)
            UserModifiedChanged(sender, e);
        }

        private void Edit_NewRec(object sender, EventArgs e)    // Создание элемента
        {
            NewRecord();
        }
        private void Edit_SaveRec(object sender, EventArgs e)   // Сохранение нового или измененого элемента
        {
            EditSave();
        }
        private void Edit_Cancel(object sender, EventArgs e) // Отмена редактирования
        {
            EditCancel();
        }


        private void UserModifiedChanged(object sender, EventArgs e)    // Срабатывает при внесение изменения в панели редактирования
        {
            if (fsInfo == null) dgvTable.DefaultCellStyle.SelectionBackColor = Color.Red;   // подсветка редактируемой строки
            panelEditUnlock();          // разблокировка кнопок
            dgvTable.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева
        }

    }
}



