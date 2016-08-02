using System;
using System.Drawing;
using System.Windows.Forms;


namespace FilmCollection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.MinimumSize = new System.Drawing.Size(800, 600);   // Установка минимального размера формы
            InitializeComponent();                  // Создание и отрисовка элементов
            dgvTable.AutoGenerateColumns = false;   // Отключение автоматического заполнения таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
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



