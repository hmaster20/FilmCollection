using FC.Provider;
using FC.Provider.Class.Main.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FC.Provider.Class.Main.Collection
{
    /// <summary>Класс обслуживания базы фильмотеки</summary>
    public class CollectionService
    {
        /// <summary>Запрашиваем новый каталог с коллекцией</summary>
        public DialogResult NewBase(FolderBrowserDialog fbDialog)
        {
            if (File.Exists(Generic.GetBaseName()) && (CollectionRecord.status())) // Если база есть, то запрашиваем удаление
            {
                DialogResult result = MessageBox.Show("Выполнить удаление текущей базы ?", "Удаление базы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) BackupBase();

                // Возможно не стоит удалять, а делать *.bak файл ?
                File.WriteAllText(Generic.GetBaseName(), string.Empty); // Затираем содержимое файла базы
                if (CollectionRecord.status())
                    CollectionRecord.CurrentInstance().Clear();  // очищаем коллекцию                    
            }
            else
            {
                // Если базы нет, то создаем файл и закрываеи дескриптор (Объект FileStream)
                File.Create(Generic.GetBaseName()).Close();
            }

            DialogResult dialogStatus = fbDialog.ShowDialog();
            if (dialogStatus == DialogResult.OK)// Запрашиваем новый каталог с коллекцией видео
            {
                string folderName = fbDialog.SelectedPath;  // Извлечение имени папки

                DialogResult CheckfolderName = MessageBox.Show(
                    "Источником фильмотеки выбран каталог: " + folderName, 
                    "Создание фильмотеки (" + folderName + ")",
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Information, 
                    MessageBoxDefaultButton.Button1);

                if (CheckfolderName == DialogResult.Cancel) NewBase(fbDialog);

                DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки
                if (directory.Exists)
                {
                    CollectionRecord rc = new CollectionRecord();
                    CollectionRecord.SetInstance(rc);
                    int id = CollectionRecord.CurrentInstance().AddSource(directory.FullName);// Сохранение каталога фильмов

                    foreach (FileInfo file in GetFilesFrom(directory))
                        CreateCombine(file, id);
                }

                CollectionRecord.CurrentInstance().Save();
                CollectionRecord.CurrentInstance().SaveToFile();
                //main.FormLoad();
            }
            return dialogStatus;
        }


        public void PreUpdate()
        {
            //try
            //{
            //    if (RecordCollection.CurrentInstance().SourceList.Count < 1)
            //    {
            //        MessageBox.Show("Перед обновлением необходимо создать базу данных!", "Обновление коллекции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return 0;
            //    }
            //    else
            //    {
            //        //foreach (Sources source in CurrentRC().SourceList)
            //        //   Update(CurrentRC(), source);

            //        foreach (var src in RecordCollection.CurrentInstance().SourceList)
            //        {
            //            if (RecordCollection.CurrentInstance().CombineList.Count < 1)
            //                return 0;

            //            DirectoryInfo directory = new DirectoryInfo(src.Source);

            //            if (directory.Exists)
            //            {
            //                return RecordCollection.CurrentInstance().CombineList.Count;
            //            }
            //            else
            //            {
            //                return 0;
            //            }
            //        }
            //        return 0;
            //    }
            //}
            //catch (ApplicationException ex) { Logs.Log("При обновлении базы произошла ошибка:", ex); }
        }



        public void Update(CollectionRecord RC, Sources src)
        {

            //if (RC.CombineList.Count < 1)
            //    return;

            //DirectoryInfo directory = new DirectoryInfo(src.Source);

            //if (directory.Exists)   // проверяем доступность каталога
            //{
            //    main.BeginInvoke((MethodInvoker)(() =>
            //    {   // Инициализация прогресс бара
            //        main.tsProgressBar.Visible = true;
            //        main.tsProgressBar.Maximum = RC.CombineList.Count;
            //    }));

            //    for (int i = 0; i < RC.CombineList.Count; i++)
            //    {
            //        RC.CombineList[i].invisibleRecord(); // скрываем файлы
            //        main.BeginInvoke((MethodInvoker)(() =>
            //        {
            //            if (i <= main.tsProgressBar.Maximum)    // Обработка возможной ошибки
            //            {
            //                main.tsProgressBar.Value = i;
            //                main.FindStatusLabel.Text = i.ToString() + " из " + RC.CombineList.Count.ToString();
            //            }
            //        }));
            //    }

            //    IEnumerable<FileInfo> AllMediaFiles = GetFilesFrom(directory);

            //    main.BeginInvoke((MethodInvoker)(() =>
            //    {
            //        main.tsProgressBar.Value = 0;
            //        main.tsProgressBar.Maximum = AllMediaFiles.Count();
            //        main.FindStatusLabel.Text = AllMediaFiles.Count().ToString();
            //    }));

            //    List<FileInfo> files = AllMediaFiles.ToList();

            //    int findCount = 0;

            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        main.BeginInvoke((MethodInvoker)(() =>
            //        {
            //            main.tsProgressBar.Value = i;
            //            main.FindStatusLabel.Text = i.ToString() + " из " + files.Count.ToString();
            //        }));

            //        FileInfo file = files[i];
            //        Record record = new Record();
            //        record.FileName = file.Name;                            // полное название файла (film.avi)
            //        //record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
            //        record.FilePath = file.DirectoryName.Remove(0, src.Source.Length);
            //        record.SourceID = src.Id;

            //        if (!RecordExist(record))
            //        {
            //            findCount++;
            //            CreateCombine(file, src.Id); // если файла нет в коллекции, создаем
            //        }
            //    }

            //    main.BeginInvoke((MethodInvoker)(() =>
            //    {
            //        main.tsProgressBar.Value = 0;
            //        main.tsProgressBar.Enabled = false;
            //        main.tsProgressBar.Visible = false;
            //        main.FindStatusLabel.Text = "";
            //    }));

            //    DialogResult result = MessageBox.Show("Сведения в каталоге обновлены. Применить обновление ?", "Обновление каталога", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (result != DialogResult.OK)
            //    {
            //        return;
            //    }

            //    CurrentRC().Save();
            //    CurrentRC().SaveToFile();

            //    string message = (findCount > 0)
            //        ? ("Обновлены сведения в каталоге \"" + directory + "\" для " + findCount + " файла(-ов)!")
            //        : ("Сведения о файлах в каталоге \"" + directory + "\" обновлены!");
            //    MessageBox.Show(message);

            //    main.BeginInvoke((MethodInvoker)(() => main.FormLoad(true)));
            //}
            //else
            //    MessageBox.Show("Каталог " + directory + " не обнаружен!");
        }

        public static IEnumerable<FileInfo> GetFilesFrom(DirectoryInfo directory)
        {
            //return directory.GetFiles("*.*", SearchOption.AllDirectories).Where(file => RecordOptions.getFormat().Contains(Path.GetExtension(file.ToString())));
            return directory.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(file => CollectionOptions.getFormat().Contains(Path.GetExtension(file.ToString())));
        }

        public bool RecordExist(Record record)
        {
            List<Record> list = new List<Record>();
            CollectionRecord.CurrentInstance().CombineList.ForEach(combine => list.AddRange(combine.recordList));

            foreach (Record rec in list)    // проверка наличия файла
            {
                if (rec.Equals(record))
                {
                    CollectionRecord.CurrentInstance().CombineList.FindLast(x => x.media == rec.combineLink.media).recordList.FindLast(y => y == rec).Visible = true;
                    return true;    // если файл есть
                }
            }
            return false;           // иначе файла нет файл есть
        }

        public void CreateCombine(FileInfo file, int id)
        {
            Combine cm = new Combine();

            Record record = CreateRecord(file, id);

            record.combineLink = cm;
            cm.recordList.Add(record);
            cm.media.Name = record.Name;
            cm.media.Id = CollectionRecord.GetMediaID();

            CollectionRecord.CurrentInstance().Add(cm);
        }

        public Record CreateRecord(FileInfo file, int id)
        {
            Record record = new Record();
            record.Name = getRecordName(file);
            record.FileName = file.Name;        // полное название файла (film.avi)
            record.FilePath = file.DirectoryName;   // полный путь (C:\Folder)
            record.Visible = true;              // видимость
            record.FileExt = file.Extension.Trim('.');            // расширение файла (avi)
                                                                  //record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
                                                                  //record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                  // if (-1 != file.DirectoryName.Substring(dlina).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                                                                  //record.Path = file.DirectoryName.Remove(0, CurrentRC().SourceList.First(x => x.Id == id).Source.Length + 1);
                                                                  //  
                                                                  //int dlina = CurrentRC().SourceList[0].Source.Length;
                                                                  //string sss = CurrentRC().SourceList[0].Source;
                                                                  //if (-1 != file.DirectoryName.Substring(dlina).IndexOf('\\')) record.Path = file.DirectoryName.Substring(dlina + 1);
            record.FilePath = file.DirectoryName.Remove(0, CollectionRecord.CurrentInstance().SourceList.First(x => x.Id == id).Source.Length);
            record.SourceID = id;
            return record;
        }

        private static string getRecordName(FileInfo file)
        {
            string name_1 = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length); // название без расширения (film)
            string name_2 = Regex.Replace(name_1, @"[0-9]{4}", string.Empty);       // название без года
            string name_f = Regex.Replace(name_2, @"[a-zA-Z_.'()]", string.Empty);  // название без символов
            name_f = name_f.Trim();                         // название без пробелов вначале и конце
            return (!string.IsNullOrEmpty(name_f)) ? name_f : name_1;
        }

        public static void BackupBase()
        {
            if (File.Exists(Generic.GetBaseName())) // если есть, что резервировать...
            {
                try
                {   // создаем резервную копию
                    string FileBase = Path.GetFileNameWithoutExtension(Generic.GetBaseName())
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss")
                        + Path.GetExtension(Generic.GetBaseName());

                    File.Copy(Generic.GetBaseName(), FileBase);

                    MessageBox.Show("Создана резервная копия базы:\n" + FileBase + " ");
                }
                catch (IOException ex) { Logs.Log("Произошла ошибка при создании резервной копии базы:", ex); }
            }
        }

        public static void CrashBase()
        {
            if (File.Exists(Generic.GetBaseName()))
            {
                try
                {
                    string FileBase = Path.GetFileNameWithoutExtension(Generic.GetBaseName())
                        + DateTime.Now.ToString("-Error-ddMMyyyy-HHmmss")
                        + Path.GetExtension(Generic.GetBaseName());

                    File.Move(Generic.GetBaseName(), FileBase);
                }
                catch (IOException ex) { Logs.Log("Произошла ошибка при переименовании сбойного файла базы:", ex); }
            }
        }

        public static int RecoveryFilesExist()
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directory.GetFiles("VideoList_*.xml", SearchOption.AllDirectories);
            return files.Length;
        }

        public static void RecoveryBase(string recoverBase)
        {
            try
            {
                if (File.Exists(Generic.GetBaseName())) // если файл базы существует, то создаем копию испорченной базы
                {
                    string BadFileBase = Path.GetFileNameWithoutExtension(Generic.GetBaseName())
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss_BAD")
                        + Path.GetExtension(Generic.GetBaseName());
                    File.Copy(Generic.GetBaseName(), BadFileBase);
                }
                File.Copy(recoverBase, Generic.GetBaseName(), true);
            }
            catch (IOException ex) { Logs.Log("Произошла ошибка при восстановлении файла базы:", ex); }

            //using (RecoveryForm form = new RecoveryForm())
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            if (File.Exists(RecordOptions.BaseName)) // если файл базы существует, то создаем копию испорченной базы
            //            {
            //                string BadFileBase = Path.GetFileNameWithoutExtension(RecordOptions.BaseName)
            //                    + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss_BAD")
            //                    + Path.GetExtension(RecordOptions.BaseName);
            //                File.Copy(RecordOptions.BaseName, BadFileBase);
            //            }
            //            File.Copy(form.recoverBase, RecordOptions.BaseName, true);
            //        }
            //        catch (IOException ex) { Logs.Log("Произошла ошибка при восстановлении файла базы:", ex); }

            //        MessageBox.Show("База восстановлена из резервной копии:\n" + form.recoverBase + " ");
            //        main.BeginInvoke((MethodInvoker)(() => main.FormLoad(true)));
            //    }
            //}
        }

        public void CleanBase()   // очистка базы путем удаления старых файлов видео
        {
            for (int i = 0; i < CollectionRecord.CurrentInstance().CombineList.Count; i++)
            {
                CollectionRecord.CurrentInstance().CombineList[i].DeleteOldRecord();
                if (CollectionRecord.CurrentInstance().CombineList[i].recordList.Count == 0)
                {
                    CollectionRecord.CurrentInstance().CombineList.Remove(CollectionRecord.CurrentInstance().CombineList[i]);
                }
            }

            CollectionRecord.CurrentInstance().Save();
            //main.BeginInvoke((MethodInvoker)(() =>
            //{
            //    // main.treeFolder.Nodes.Clear();       // очищаем иерархию (добавить обработку очистки дерева)
            //    main.TableRec.ClearSelection();      // выключаем селекты таблицы
            //    main.PrepareRefresh();               // сбрасываем старые значения таблицы
            //}));
            //MessageBox.Show("Очистка выполнена!");
        }
    }
}