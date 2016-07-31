using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace FilmCollection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();                  // Создание и отрисовка элементов
            dgvTable.AutoGenerateColumns = false;   // Отключение автоматического заполнения таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию


            cBoxTypeVideo.Items.AddRange(new object[] {     // Создание списка для типа записи (Фильм. Сериал, Мультфильм)
            "Фильм",
            "Сериал",
            "Мультфильм",
            "Прочее" });

            cBoxGenre.Items.AddRange(new object[] {         // Создание списка жанров
            "Боевик",
            "Вестерн",
            "Комедия",
            "Прочее"});

        }

        private void MainForm_Load(object sender, EventArgs e)      // Загрузка главное формы
        {
            FormLoad();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)    // обработка события Close() - Exit
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
            RefreshTables("");
        }

        private void AddRec_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            NewRecord();
        }

        private void EditRec_Click(object sender, EventArgs e)                 // Изменение записи
        {
            panelEdit.BringToFront();
        }



        private void Add_rec(object sender, EventArgs e)                 // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Add(form.rec);
                _videoCollection.Save();
                RefreshTables("");
            }
        }

        private void cMenuChange_Click(object sender, EventArgs e)          // Изменить запись
        {
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                RefreshTables("");      //Должно быть обновление вместо фильтра
            }
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)    // Загрузка меню и проверка селекта строки перед открытием меню
        {
            //contextMenu.Items[4].Enabled = false;
            //contextMenu.Items[3].Enabled = false;
            contextMenu.Enabled = false;

            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                //contextMenu.Items[4].Enabled = true;
                //contextMenu.Items[3].Enabled = true;
                contextMenu.Enabled = true;
            }
        }

        private void cFind_Click(object sender, EventArgs e)    // Поиск
        {
            panelFind.BringToFront();
        }

        #endregion






        private void btnFileNameEdit_Click(object sender, EventArgs e)
        {
            tbFileName.Enabled = true;
            btnFileNameEdit.Enabled = false;
        }


        private void btnEditNew_Click(object sender, EventArgs e)   // Создание нового элемента
        {
            NewRecord();
        }


        private void SaveRecordfsInfo(object sender, EventArgs e)
        {
            SaveRecordfsInfo();
        }

        private void btnEditSaveR_Click(object sender, EventArgs e)
        {
            if (fsInfo != null)
            {
                SaveRecordfsInfo();
                //fsInfo = null;

            }
            else
            {
                SaveRecord();
            }

            tbName.Modified = false;        // возвращаем назад статус изменения поля
            tbYear.Modified = false;        // возвращаем назад статус изменения поля
            tbCountry.Modified = false;     // возвращаем назад статус изменения поля
            tbDescription.Modified = false; // возвращаем назад статус изменения поля
            //tbFileName.Text = fInfo.Name;

            dgvTable.Enabled = true;
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
            RefreshTables("");
            fsInfo = null;

            panelEditLock();
        }









        // Поле для нового файла, добавляемого в базу
        //System.IO.FileInfo fsInfo = null;
        FileInfo fsInfo = null;



        private void NewRecord()
        {
            //btnEditSave.Enabled = false;    // Блокировка кнопки сохранения

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = _videoCollection.Source;
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.Filter = "Все файлы (*.*)|*.*";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(fileDialog.FileName);
                string strFilePath = fInfo.DirectoryName;

                if (!strFilePath.StartsWith(_videoCollection.Source))
                {
                    MessageBox.Show("Файл не принадлежит базе коллекций " + _videoCollection.Source);
                    return;
                }

                Record record = new Record();
                record.FileName = fInfo.Name;
                record.Path = fInfo.DirectoryName;

                foreach (Record item in _videoCollection.VideoList)
                {
                    if (item.Equals(record))
                    {
                        MessageBox.Show("Файл " + record.FileName + " уже есть!");
                        return;
                    }
                }

                //MessageBox.Show("Работа выполнена!");

                // выполнить блокировку таблицы и дерева
                tbName.Text = fInfo.Name.Remove(fInfo.Name.LastIndexOf(fInfo.Extension), fInfo.Extension.Length);
                tbYear.Text = "";
                tbCountry.Text = "";
                numericTime.Value = 0;
                tbDescription.Text = "";
                tbFileName.Text = fInfo.Name;
                cBoxGenre.SelectedIndex = 0;
                cBoxTypeVideo.SelectedIndex = 0;

                // если все хорошо передаем объект
                fsInfo = fInfo;

                panelEdit.BringToFront();
                panelEditUnlock();
            }
        }



        private void SaveRecordfsInfo()
        {
            Record record = new Record();

            CategoryVideo category;
            GenreVideo genre;

            switch (cBoxGenre.SelectedIndex)
            {
                case 0: genre = GenreVideo.Action; break;
                case 1: genre = GenreVideo.Vestern; break;
                case 2: genre = GenreVideo.Comedy; break;
                case 3: genre = GenreVideo.Unknown; break;
                default: genre = GenreVideo.Unknown; return;
                //default: MessageBox.Show("Не выбран тип"); return;
            }

            switch (cBoxTypeVideo.SelectedIndex)
            {
                case 0: category = CategoryVideo.Film; break;
                case 1: category = CategoryVideo.Series; break;
                case 2: category = CategoryVideo.Cartoon; break;
                case 3: category = CategoryVideo.Unknown; break;
                default: category = CategoryVideo.Unknown; return;
                    //default: MessageBox.Show("Не выбран тип"); return;
            }

            record.FileName = fsInfo.Name;
            record.Path = fsInfo.DirectoryName;

            record.Name = tbName.Text;
            record.Year = tbYear.Text;
            record.Country = tbCountry.Text;
            record.Time = (int)numericTime.Value;
            record.Category = category;
            record.GenreVideo = genre;
            record.Description = tbDescription.Text;

            _videoCollection.Add(record);
            _videoCollection.Save();


            dgvTable.Enabled = true;
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
            RefreshTables("");      //Должно быть обновление вместо фильтра
        }


        private void SaveRecord()
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                CategoryVideo category;
                GenreVideo genre;

                switch (cBoxGenre.SelectedIndex)
                {
                    case 0: genre = GenreVideo.Action; break;
                    case 1: genre = GenreVideo.Vestern; break;
                    case 2: genre = GenreVideo.Comedy; break;
                    case 3: genre = GenreVideo.Unknown; break;
                    default: genre = GenreVideo.Unknown; return;
                        //default: MessageBox.Show("Не выбран тип"); return;
                }

                switch (cBoxTypeVideo.SelectedIndex)
                {
                    case 0: category = CategoryVideo.Film; break;
                    case 1: category = CategoryVideo.Series; break;
                    case 2: category = CategoryVideo.Cartoon; break;
                    case 3: category = CategoryVideo.Unknown; break;
                    default: category = CategoryVideo.Unknown; return;
                        //default: MessageBox.Show("Не выбран тип"); return;
                }

                record.Name = tbName.Text;
                record.Year = tbYear.Text;
                record.Country = tbCountry.Text;
                record.Time = (int)numericTime.Value;
                record.Category = category;
                record.GenreVideo = genre;
                record.Description = tbDescription.Text;

                _videoCollection.Save();

                dgvTable.Enabled = true;
                dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
                RefreshTables("");      //Должно быть обновление вместо фильтра
            }
        }






        private void UserModifiedChanged(object sender, EventArgs e)
        {
            panelEditUnlock();


            dgvTable.Enabled = false;
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Red;
        }



        private void btnEditCancel_Click(object sender, EventArgs e)
        {

            tbName.Modified = false;// возвращаем назад статус изменения поля
            tbYear.Modified = false;// возвращаем назад статус изменения поля
            tbCountry.Modified = false;// возвращаем назад статус изменения поля
            tbDescription.Modified = false;// возвращаем назад статус изменения поля
            //tbFileName.Text = fInfo.Name;


            dgvTable.Enabled = true;
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
            RefreshTables("");
            fsInfo = null;

            panelEditLock();    // Блокируем кнопки
        }


    }
}



