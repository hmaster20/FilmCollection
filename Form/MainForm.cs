using System;
using System.Drawing;
using System.Windows.Forms;


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
            "Мультфильм"});

            cBoxGenre.Items.AddRange(new object[] {         // Создание списка жанров
            "Боевик",
            "Вестерн",
            "Комедия"});
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

        private void btnCreateBase_Click(object sender, EventArgs e)
        {
            CreateBase();
        }

        private void btnUpdateBase_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void btnBackupBase_Click(object sender, EventArgs e)    // Создание копии базы
        {
            BackupBase();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Сформировать отчет в формате html и открыть его в браузере по умолчанию 
        }

        private void btnExit_Click(object sender, EventArgs e)   //Выход
        {
            Close();
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        #endregion


        #region Контекстное меню для DataGridView
        private void Filter(object sender, EventArgs e)     // Сброс фильтра по дереву
        {
            dgvTable.ClearSelection();
            RefreshTables("");
        }

        private void cAdd_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            //  предварительно сделать диалог для добавления файла ???
            // открыв корневую папку базы -- не давая возможность выйти из нее.
            // ==================================================================
            // ==================================================================
            // ==================================================================

            //EditForm form = new EditForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    _videoCollection.Add(form.rec);
            //    _videoCollection.Save();
            //    RefreshTables("");
            //}
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
            contextMenu.Items[4].Enabled = false;
            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                contextMenu.Items[4].Enabled = true;
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


        private void btnEditSave_Click(object sender, EventArgs e)  // Сохранение изменений
        {
            SaveRecord();
        }

        Record NewRecords = null;



        private void NewRecord()
        {
            btnEditSave.Enabled = false;    // Блокировка кнопки сохранения


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.InitialDirectory = _videoCollection.Source;
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Filter = "Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(openFileDialog1.FileName);

                string strFileName = fInfo.Name;

                string strFilePath = fInfo.DirectoryName;

                if (!strFilePath.StartsWith(_videoCollection.Source)) MessageBox.Show("Fack you");
                                MessageBox.Show(openFileDialog1.FileName);
    
                
            }


            Record record = new Record();
            NewRecords = record;

            tbName.Text = record.Name;
            tbYear.Text = record.Year;
            tbCountry.Text = record.Country;
            numericTime.Value = record.Time;
            tbDescription.Text = record.Description;
            tbFileName.Text = record.FileName;

            switch (record.Category)
            {
                case CategoryVideo.Film: cBoxTypeVideo.SelectedIndex = 0; break;
                case CategoryVideo.Series: cBoxTypeVideo.SelectedIndex = 1; break;
                case CategoryVideo.Cartoon: cBoxTypeVideo.SelectedIndex = 2; break;
            }

            switch (record.GenreVideo)
            {
                case GenreVideo.Action: cBoxGenre.SelectedIndex = 0; break;
                case GenreVideo.Vestern: cBoxGenre.SelectedIndex = 1; break;
                case GenreVideo.Comedy: cBoxGenre.SelectedIndex = 2; break;
            }
           

        }



        private void SaveRecord()
        {
            //Record record = GetSelectedRecord();


            if (NewRecords == null)
            {
                Record record = new Record();

                CategoryVideo category;
                GenreVideo genre;

                switch (cBoxGenre.SelectedIndex)
                {
                    case 0: genre = GenreVideo.Action; break;
                    case 1: genre = GenreVideo.Vestern; break;
                    case 2: genre = GenreVideo.Comedy; break;
                    default: MessageBox.Show("Не выбран тип"); return;
                }

                switch (cBoxTypeVideo.SelectedIndex)
                {
                    case 0: category = CategoryVideo.Film; break;
                    case 1: category = CategoryVideo.Series; break;
                    case 2: category = CategoryVideo.Cartoon; break;
                    default: MessageBox.Show("Не выбран тип"); return;
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
            // MessageBox.Show("изменил");
            btnEditSave.Enabled = true;
            dgvTable.Enabled = false;
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Red;
        }
    }
}



