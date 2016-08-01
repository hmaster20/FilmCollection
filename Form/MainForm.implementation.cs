﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;

namespace FilmCollection
{
    public partial class MainForm
    {
        RecordCollection _videoCollection = new RecordCollection(); // Доступ к коллекции
        Record record = null;       // Доступ к записи
        FileInfo fsInfo = null;     // Поле для нового файла, добавляемого в базу


        #region Загрузка формы
        private void FormLoad()     // Загрузка формы
        {
            if (File.Exists(RecordCollection.BaseName))     // Если база создана, то выполняем
            {
                _videoCollection = RecordCollection.Load();
                if (_videoCollection.VideoList.Count > 0)
                {
                    tssLabel.Text = "Коллекция из " + _videoCollection.VideoList.Count.ToString() + " элементов";
                    RefreshTable("");
                    CreateTree();
                }
                timerLoad.Enabled = true;                   // Исключение раннего селекта treeFolder и фильтра dataGridView1

                #region Восстановление состояния сплиттеров
                scMain.SplitterDistance = _videoCollection.scMainSplitter;
                scTabFilm.SplitterDistance = _videoCollection.scTabFilmSplitter;
                #endregion

                //#region Восстановление состояния ширины колонок
                //DataGridViewColumnCollection columns = dgvTable.Columns;
                //char[] delimiterChars = { ',' };
                //string text = _videoCollection.ColumnsWidth;
                //string[] words = text.Split(delimiterChars);
                //for (int i = 0; i < words.Length; i++)
                //{
                //    columns[i].Width = Convert.ToInt32(words[i]);
                //}
                //#endregion

                #region Восстановление состояния главной формы
                string switch_on = _videoCollection.FormState;
                switch (switch_on)
                {
                    case "Normal": WindowState = FormWindowState.Normal; break;
                    case "Minimized": WindowState = FormWindowState.Minimized; break;
                    case "Maximized": WindowState = FormWindowState.Maximized; break;
                    default: WindowState = FormWindowState.Maximized; break;
                }
                #endregion

            }
        }

        private void T_Tick(object sender, EventArgs e)     // таймер для селекта MainForm_Load
        {
            timerLoad.Enabled = false;
            treeFolder.SelectedNode = null;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }
        #endregion


        private void CreateBase()       // Создание файла базы
        {
            if (File.Exists(RecordCollection.BaseName)) // Если база есть, то запрашиваем удаление
            {
                DialogResult result = MessageBox.Show("Выполнить удаление текущей базы ?",
                                                      "Удаление базы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // Если соглашаемся
                {
                    File.WriteAllText(RecordCollection.BaseName, string.Empty); // Затираем содержимое файла базы
                    _videoCollection.Clear();   // очищаем колелкцию
                    treeFolder.Nodes.Clear();   // очищаем иерархию
                    dgvTable.ClearSelection();  // выключаем селекты таблицы
                    RefreshTable("");          // сбрасываем старые значения таблицы
                }
            }
            else // Если базы нет, то создаем пусатой файл базы
            {
                File.Create(RecordCollection.BaseName).Close(); // создание файла и закрытие дескриптора (Объект FileStream)
            }

            DialogResult dialogStatus = FolderDialog.ShowDialog();  // Запрашиваем новый каталог с коллекцией видео
            string folderName = "";

            if (dialogStatus == DialogResult.OK)
            {
                folderName = FolderDialog.SelectedPath;                     //Извлечение имени папки
                DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки

                if (directory.Exists)
                {
                    _videoCollection.Source = directory.FullName;   // Сохранение каталога фильмов
                    char[] charsToTrim = { '.' };
                    foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                    {
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
                _videoCollection.Save();
                FormLoad();
            }
        }


        private void UpdateBase()       // Добавить обновление базы
        {
            if (_videoCollection.Source != "")  // Если есть информация о корневой папки коллекции
            {
                DirectoryInfo directory = new DirectoryInfo(_videoCollection.Source);
                if (directory.Exists)   // проверяем существование заявленной папки коллекции
                {
                    #region Формирование списка файлов в базе XML для использования при дальнейшей проверке. Нужно ли их добавлять.
                    List<string> FileNameList = new List<string>();                 // создаем пустой список типа string
                    XmlDocument doc = new XmlDocument();                            // создаем объект для доступа в xml документ
                    doc.Load(RecordCollection.BaseName);                            // загружаем файл базы
                    XmlNodeList nodeList = doc.GetElementsByTagName("FileName");    // передается название файла

                    foreach (XmlNode node in nodeList)
                    {
                        FileNameList.Add(node.ChildNodes[0].Value);
                    }
                    #endregion

                    char[] charsToTrim = { '.' };
                    foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.Name != FileNameList.Find(x => x.Contains(file.Name)))
                        {
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
                    _videoCollection.Save();    // если все прошло гладко, то сохраняем в файл базы
                    FormLoad();                 // и перегружаем главную форму
                }
            }
        }


        private void BackupBase()       // Резервная копия базы
        {
            if (File.Exists(RecordCollection.BaseName)) // если есть что бэкапить...
            {
                try
                {   // создаем бэкап
                    File.Copy(RecordCollection.BaseName, Path.GetFileNameWithoutExtension(RecordCollection.BaseName)
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss")
                        + Path.GetExtension(RecordCollection.BaseName));
                    MessageBox.Show("Создана резервная копия!");
                }
                catch (IOException copyError)
                {   // если не можем создать бэкап, то ругаемся
                    MessageBox.Show(copyError.Message);
                }
            }
        }


        private void RefreshTable(string nodeName)    // Обновление таблицы путем фильтрации элементов по полю Path
        {
            Record selected = GetSelectedRecord();  // получение выбранной строки

            List<Record> filtered = _videoCollection.VideoList;

            if (nodeName != "" && nodeName != "Фильмотека")
                filtered = filtered.FindAll(v => v.Path == _videoCollection.Source + Path.DirectorySeparatorChar + nodeName);

            int switch_filter = tscbTypeFilter.SelectedIndex;
            switch (switch_filter)  // фильтр по категориям
            {
                case 1: filtered = filtered.FindAll(v => v.Category == CategoryVideo.Film); break;
                case 2: filtered = filtered.FindAll(v => v.Category == CategoryVideo.Cartoon); break;
                case 3: filtered = filtered.FindAll(v => v.Category == CategoryVideo.Series); break;
                default: break;
            }

            int switch_sort = tscbSort.SelectedIndex;
            switch (switch_sort)  // Сортировка по столбцам
            {
                case 0: filtered.Sort(Record.CompareByName); break;
                case 1: filtered.Sort(Record.CompareByTime); break;
                case 2: filtered.Sort(Record.CompareByYear); break;
                case 3: filtered.Sort(Record.CompareByCategory); break;
                default: break;
            }

            dgvTable.DataSource = null;
            dgvTable.DataSource = filtered;

            if (selected != null)
                SelectRecord(dgvTable, selected);
        }


        private void SelectRecord(DataGridView dgv, Record record)
        {
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
                if ((row.DataBoundItem as Record).Name == record.Name)
                {
                    row.Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
        }


        private void SelectRecord_Info(object sender, EventArgs e)  // Отражение информации в карточке
        {
            // Предоставляет данные выбранной записи
            Record record = GetSelectedRecord();
            if (record != null)
            {
                // Панель описания
                tbfName.Text = record.Name;
                tbfDesc.Text = record.Description;

                // Панель редактирования
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
                    case CategoryVideo.Unknown: cBoxTypeVideo.SelectedIndex = 3; break;
                }

                switch (record.GenreVideo)
                {
                    case GenreVideo.Action: cBoxGenre.SelectedIndex = 0; break;
                    case GenreVideo.Vestern: cBoxGenre.SelectedIndex = 1; break;
                    case GenreVideo.Comedy: cBoxGenre.SelectedIndex = 2; break;
                    case GenreVideo.Unknown: cBoxGenre.SelectedIndex = 3; break;
                }
            }
        }


        private Record GetSelectedRecord()  // получение выбранной записи в dgvTable
        {
            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Record record = null;
                if (dgv.SelectedRows[0].DataBoundItem is Record)
                    record = dgv.SelectedRows[0].DataBoundItem as Record;
                if (record != null)
                    return record;
            }
            return null;
        }


        private void CreateTree()       // Построение дерева
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(RecordCollection.BaseName);                // Получения файла базы
            int SourceLength = _videoCollection.Source.Length;  // Получение длинны пути

            XmlNodeList nodeList = doc.GetElementsByTagName("Path");        // Чтение элементов "Path"

            treeFolder.Nodes.Clear();                                       // Очистка дерева
            var paths = new List<string>();                                 // Создание списка
            paths.Add("Фильмотека");

            foreach (XmlNode node in nodeList)                              // Заполнение списка для формирования дерева
            {
                try
                {
                    string temp = "";
                    if (node.ChildNodes[0].Value.Length > SourceLength)     // длинна патча, не должна превышать полного пути к дирректории
                        if (-1 != node.ChildNodes[0].Value.Substring(SourceLength).IndexOf(Path.DirectorySeparatorChar))
                        {
                            temp = node.ChildNodes[0].Value.Substring(SourceLength + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                            if (temp.Length != 0) paths.Add(node.ChildNodes[0].Value.Substring(SourceLength + 1));
                        }
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message + " " + node.Name + " - не заполен!");
                }
            }
            PopulateTreeView(treeFolder, paths, Path.DirectorySeparatorChar);
            //treeFolder.AfterSelect += treeFolder_AfterSelect;
        }


        private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)  // Построение дерева
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null;
            }
            //treeView.ExpandAll();           // развернуть дерево
        }


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e) // Команда при клике по строке
        {
            RefreshTable(e.Node.FullPath);     // обновление на основе полученной ноды
        }


        private void ResetFilter_Click(object sender, EventArgs e)
        {
            RefreshTable("");
            dgvTable.ClearSelection(); // сброс селекта

            tscbTypeFilter.SelectedIndex = 0;
            tscbSort.SelectedIndex = -1;

            tbName.Text = "";
            tbYear.Text = "";
            tbCountry.Text = "";
            numericTime.Value = 0;
            tbDescription.Text = "";
            tbFileName.Text = "";
            cBoxGenre.SelectedIndex = 0;
            cBoxTypeVideo.SelectedIndex = 0;

        }


        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при правом клике выполняется выбор строки и открывается меню
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvTable.CurrentCell = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvTable.Rows[e.RowIndex].Selected = true;
                dgvTable.Focus();
            }
        }


        private void Play_Click(object sender, EventArgs e)  // запуск файла
        {
            Record record = GetSelectedRecord();
            Process.Start(record.Path + Path.DirectorySeparatorChar + record.FileName);
        }


        private void DeleteRec_Click(object sender, EventArgs e)
        {
            Record record = GetSelectedRecord();
            _videoCollection.Remove(record);
            dgvTable.ClearSelection();
            _videoCollection.Save();
            RefreshTable("");
        }


        private void FindRec_Click(object sender, EventArgs e)  // Поиск
        {
            int switch_Find = cbTypeFind.SelectedIndex;
            switch (switch_Find)
            {
                case 0: Find(0); break; // поиск по названию
                case 1: Find(2); break; // поиск по году
                default: MessageBox.Show("Укажите критерий поиска!"); break;
            }
        }


        private void Find(int cell)
        {
            Regex regex = new Regex(tbFind.Text, RegexOptions.IgnoreCase);

            dgvTable.ClearSelection();
            dgvTable.MultiSelect = true;    // Требуется для выбора всех строк
            try
            {
                foreach (DataGridViewRow row in dgvTable.Rows)
                {
                    if (regex.IsMatch(row.Cells[cell].Value.ToString()))
                    {
                        row.Selected = true;
                        //break; //Требуется для выбора одно строки
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void FormClose(FormClosingEventArgs e)    // обработка события Close()
        {
            DialogResult dialog = MessageBox.Show("Вы уверены что хотите выйти из программы?",
                                                  "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }

            #region Сохранение состояния сплиттеров
            _videoCollection.scMainSplitter = scMain.SplitterDistance;
            _videoCollection.scTabFilmSplitter = scTabFilm.SplitterDistance;
            #endregion

            //#region Сохранение ширины колонок
            //DataGridViewColumnCollection columns = dgvTable.Columns;
            //_videoCollection.ColumnsWidth = "";
            //for (int i = 0; i < columns.Count-1; i++)
            //{
            //    if (i < columns.Count - 2)
            //    {
            //        _videoCollection.ColumnsWidth = _videoCollection.ColumnsWidth + columns[i].Width + ",";
            //    }
            //    else
            //    {
            //        _videoCollection.ColumnsWidth = _videoCollection.ColumnsWidth + columns[i].Width;
            //    }
            //}
            //#endregion

            // Сохранение состояния главной формы
            _videoCollection.FormState = this.WindowState.ToString();

            _videoCollection.Save();

        }


        private void NewRecord()    // Создание новой записи - объекта Record
        {
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
                    MessageBox.Show("Файл не принадлежит источнику коллекции " + _videoCollection.Source);
                    return; // Выходим из метода
                }

                Record record = new Record();
                record.FileName = fInfo.Name;
                record.Path = fInfo.DirectoryName;

                foreach (Record item in _videoCollection.VideoList)
                {
                    if (item.Equals(record))
                    {
                        MessageBox.Show("Файл " + record.FileName + " уже есть в базе!");
                        return; // Выходим из метода
                    }
                }

                // Заполняем поля
                tbName.Text = fInfo.Name.Remove(fInfo.Name.LastIndexOf(fInfo.Extension), fInfo.Extension.Length);
                tbYear.Text = "";
                tbCountry.Text = "";
                numericTime.Value = 0;
                tbDescription.Text = "";
                tbFileName.Text = fInfo.Name;
                cBoxGenre.SelectedIndex = 0;
                cBoxTypeVideo.SelectedIndex = 0;

                fsInfo = fInfo;             // если все хорошо, то передаем объект

                panelEdit.BringToFront();   // показываем панель редактирования

                dgvTable.Enabled = false;   // блокировка таблицы
                treeFolder.Enabled = false; // блокировка дерева

                panelEditUnlock();          // разблокировка кнопок
            }
        }


        private void EditSave()
        {
            GenreVideo genre;
            CategoryVideo category;
            switch (cBoxGenre.SelectedIndex)
            {
                case 0: genre = GenreVideo.Action; break;
                case 1: genre = GenreVideo.Vestern; break;
                case 2: genre = GenreVideo.Comedy; break;
                case 3: genre = GenreVideo.Unknown; break;
                default: genre = GenreVideo.Unknown; return;
            }
            switch (cBoxTypeVideo.SelectedIndex)
            {
                case 0: category = CategoryVideo.Film; break;
                case 1: category = CategoryVideo.Series; break;
                case 2: category = CategoryVideo.Cartoon; break;
                case 3: category = CategoryVideo.Unknown; break;
                default: category = CategoryVideo.Unknown; return;
            }

            if (fsInfo != null)
            {
                Record record = new Record();
                char[] charsToTrim = { '.' };

                record.FileName = fsInfo.Name;
                record.Path = fsInfo.DirectoryName;
                record.DirName = fsInfo.Directory.Name;
                record.Extension = fsInfo.Extension.Trim(charsToTrim);
                record.Name = tbName.Text;
                record.Year = tbYear.Text;
                record.Country = tbCountry.Text;
                record.Time = (int)numericTime.Value;
                record.Category = category;
                record.GenreVideo = genre;
                record.Description = tbDescription.Text;

                _videoCollection.Add(record);
                _videoCollection.Save();

                fsInfo = null;
            }
            else
            {
                Record record = GetSelectedRecord();
                if (record != null)
                {
                    record.Name = tbName.Text;
                    record.Year = tbYear.Text;
                    record.Country = tbCountry.Text;
                    record.Time = (int)numericTime.Value;
                    record.Category = category;
                    record.GenreVideo = genre;
                    record.Description = tbDescription.Text;

                    _videoCollection.Save();
                }
            }



            tbName.Modified = false;        // возвращаем назад статус изменения поля
            tbYear.Modified = false;        // возвращаем назад статус изменения поля
            tbCountry.Modified = false;     // возвращаем назад статус изменения поля
            tbDescription.Modified = false; // возвращаем назад статус изменения поля
                                            //tbFileName.Text = fInfo.Name;

            treeFolder.Enabled = true;  // Разблокировка дерева
            dgvTable.Enabled = true;    // Разблокировка таблиц
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;
            RefreshTable("");

            panelEditLock();    // блокировка панели
        }


        #region Панель редактирования
        private void panelEditCancel()    // Отмена редактирования в panelEdit
        {
            tbName.Modified = false;// возвращаем назад статус изменения поля
            tbYear.Modified = false;// возвращаем назад статус изменения поля
            tbCountry.Modified = false;// возвращаем назад статус изменения поля
            tbDescription.Modified = false;// возвращаем назад статус изменения поля

            treeFolder.Enabled = true;  // Разблокировка дерева
            dgvTable.Enabled = true;    // Разблокировка таблиц
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы
            RefreshTable("");  // перезагрузка таблицы
            fsInfo = null;      // удаление информации о файле

            panelEditLock();    // блокировка кнопок панели редактирования
        }

        private void panelEditLock()    //Блокировка кнопок
        {
            // Блокировать клавишу "Отмена"
            btnEditCancel.Visible = false;
            btnEditCancel.Enabled = false;
            // Блокировать клавишу "Сохранить"
            btnEditSaveR.Visible = false;
            btnEditSaveR.Enabled = false;

            panelView.BringToFront();   // показать панель сведений
        }

        private void panelEditUnlock()    //Разблокировка кнопок
        {
            // Разблокировать клавишу "Отмена"
            btnEditCancel.Visible = true;
            btnEditCancel.Enabled = true;
            // Блокировать клавишу "Сохранить"
            btnEditSaveR.Visible = true;
            btnEditSaveR.Enabled = true;
        }
        #endregion

    }
}


