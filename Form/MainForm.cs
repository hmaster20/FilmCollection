using System;
using System.Windows.Forms;


namespace FilmCollection
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();                  // Создание и отрисовка элементов
            dgvTable.AutoGenerateColumns = false;   // Отключение автоматического заполнения таблицы
            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию
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
            //EditForm form = new EditForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    _videoCollection.Add(form.rec);
            //    _videoCollection.Save();
            //    RefreshTables("");
            //}
            panelEdit.BringToFront();
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

    }
}



