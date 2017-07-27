﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.ComponentModel;

namespace FilmCollection
{
    /// <summary>Класс управления коллекцией фильмотеки, состоящей из фильмов (CombineList) и актеров (ActorList)</summary>
    public class RecordCollection //: ICloneable
    {
        [XmlElement]
        public RecordOptions Options { get; set; } = new RecordOptions();


        private static RecordCollection _recordCollection;
        public static RecordCollection GetInstance()
        {
            if (_recordCollection == null)
                _recordCollection = Load();
            return _recordCollection;
        }

        public RecordCollection()
        {
            ActorList = new List<Actor>();      // Создание списка актеров
            CombineList = new List<Combine>();  // Создание смешанного списка Record & Media
        }

        public void Clear()
        {
            try
            {
                ClearActor();
                ClearCombine();
                ResetMediaID();
            }
            catch (ApplicationException ex) { MessageBox.Show(ex.Message); }
        }


        public List<Combine> CombineList { get; }
        public void Add(Combine cm) => CombineList.Add(cm);
        public void Remove(Combine cm) => CombineList.Remove(cm);
        public void ClearCombine() => CombineList.Clear();


        public List<Actor> ActorList { get; }                  // Объявление списка        
        public void Add(Actor actor) => ActorList.Add(actor);
        public void Remove(Actor actor)
        {
            foreach (var cm in CombineList)
            {
                if (cm.media.ActorList.Exists(x => x == actor))
                {
                    cm.media.ActorList.Remove(actor);
                }

                if (cm.media.ActorListID.Exists(x => x == actor.id))
                {
                    cm.media.ActorListID.Remove(actor.id);
                }
            }
            ActorList.Remove(actor);
        }

        public void ClearActor() => ActorList.Clear();              // Очистить коллекцию


        private static int MediaID { get; set; }               // Идентификатор Media


        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public int GetMediaID { get { return ++MediaID; } } 
        public static int GetMediaID() => ++MediaID;           // создание следующего номера


        public static void ResetMediaID() => MediaID = 0;      // обнуление идентификатора
        public static void SetMediaID(int value) => MediaID = value;


        private static int ActorID { get; set; }               // Идентификатор актеров

        /// <summary>Метод создает и присваивает следующий номер.</summary>
        /// 

        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public int GetActorID { get { return ++ActorID; } } 
        public static int GetActorID() => ++ActorID;        // Генерация идентификатора  // return ++ActorID;          


        public static void ResetActorID() => ActorID = 0;      // обнуление идентификатора
        public static void SetActorID(int value) => ActorID = value;



        #region Сериализация

        /// <summary>Сохранение (Сериализация) коллекции в MemoryStream</summary>
        public void Save() => XmlSerializeHelper.SerializeAndSaveToMemory(this);

        /// <summary>Сохранение (Сериализация) коллекции в файл XML</summary>
        public void SaveToFile() => XmlSerializeHelper.FromMemoryToSaveToFile();




        /// <summary>Загрузка (деСериализация) объектов из файла XML</summary>
        /// <returns>Возвращает коллекцию RecordCollection</returns>
        public static RecordCollection Load(bool fromFile = false)
        {
            RecordCollection result;
            try
            {
                if (fromFile)
                {
                    result = RecordOptions.BaseName.LoadAndDeserialize<RecordCollection>();
                }
                else
                {
                    result = XmlSerializeHelper.LoadAndDeserializeMemory<RecordCollection>();
                }

                Dictionary<int, Combine> combineDic = new Dictionary<int, Combine>();

                foreach (Combine com in result.CombineList)
                {
                    combineDic.Add(com.media.Id, com);
                    foreach (var record in com.recordList)
                        record.combineLink = com;           // привязываем record.combineLink к родителю
                }

                Dictionary<int, Actor> actorDic = new Dictionary<int, Actor>();
                //result.ActorList.ForEach(act => actorDic.Add(act.id, act));  

                foreach (Actor actor in result.ActorList)
                {
                    actorDic.Add(actor.id, actor);
                    foreach (int videoID in actor.VideoID)
                    {
                        if (combineDic.ContainsKey(videoID))
                        {
                            actor.CombineList.Add(combineDic[videoID]);
                            combineDic[videoID].media.ActorList.Add(actor);
                        }
                    }
                }

                if (actorDic.Count > 0) SetActorID(actorDic.Keys.Max());
                if (combineDic.Count > 0) SetMediaID(combineDic.Keys.Max());

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка на этапе загрузки файла базы. \n" + ex.Message);
                //return new RecordCollection();
            }

            _recordCollection = result;
            return result;
        }

        //RecordCollection VideoCollection = (RecordCollection)videoCollection.Clone();
        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        #endregion



        public bool Update(MainForm main)
        {
            bool state = false;

            if (string.IsNullOrEmpty(Options.Source))  // Если есть информация о корневой папки коллекции
            {
                main.BeginInvoke((MethodInvoker)(() =>
                MessageBox.Show(Form.ActiveForm, "Перед обновлением необходимо создать базу данных!", "Обновление коллекции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ));
            }
            else
            {
                try
                {
                    RecordCollection RC = new RecordCollection();
                    RC = (RecordCollection)GetInstance().MemberwiseClone();


                    int findCount = 0;

                    if (Options.Source == null)
                    {
                        MessageBox.Show("Файл базы испорчен!");
                        return false;
                    }
                    DirectoryInfo directory = new DirectoryInfo(Options.Source);

                    if (directory.Exists)   // проверяем доступность каталога
                    {

                        //mainForm.BeginInvoke((Action)(() =>
                        //{
                        //    mainForm.tsProgressBar.Value = mainForm.tsProgressBar.Value + 1;
                        //}));

                        //Action action = () =>
                        //{
                        //    tsProgressBar.Value = tsProgressBar.Value + 1;
                        //};
                        //Dispatcher.BeginInvoke(action);

                        //Dispatcher.BeginInvoke((Action)(() =>
                        //{
                        //    tsProgressBar.Value = tsProgressBar.Value + 1;
                        //}));

                        //Dispatcher.BeginInvoke(new ThreadStart(delegate
                        //{
                        //    tsProgressBar.Value = tsProgressBar.Value + 1;
                        //}));

                        //this.Invoke(() => { button3.Text = DateTime.Now.ToString(); });

                        //    mainForm.BeginInvoke((Action)(() => { mainForm.tsProgressBar.Value ++;}));


                        main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Maximum = CombineList.Count));
                        //main.BeginInvoke((MethodInvoker)(() => main.FindStatusLabel.Text = CombineList.Count.ToString()));

                        for (int i = 0; i < CombineList.Count; i++)
                        {
                            CombineList[i].invisibleRecord(); // скрываем файлы
                            main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Value = i));
                            main.BeginInvoke((MethodInvoker)(() => main.FindStatusLabel.Text = i.ToString() + " из " + CombineList.Count.ToString()));
                        }


                        var myFiles = directory.GetFiles("*.*", SearchOption.AllDirectories)
                                                  .Where(s => RecordOptions.FormatAdd().Contains(Path.GetExtension(s.ToString())));


                        main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Value = 0));
                        main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Maximum = myFiles.Count()));
                        main.BeginInvoke((MethodInvoker)(() => main.FindStatusLabel.Text = myFiles.Count().ToString()));

                        List<FileInfo> ff = new List<FileInfo>();
                        ff = myFiles.ToList();

                        for (int i = 0; i < ff.Count; i++)
                        {
                            main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Value = i));
                            main.BeginInvoke((MethodInvoker)(() => main.FindStatusLabel.Text = i.ToString() + " из " + ff.Count.ToString()));
                            FileInfo file = ff[i];
                            Record record = new Record();
                            record.FileName = file.Name;                            // полное название файла (film.avi)
                            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)

                            if (!RC.RecordExist(record))
                            {
                                findCount++;
                                RC.CreateCombine(file); // если файла нет в коллекции, создаем     
                            }
                        }

                        main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Value = 0));
                        main.BeginInvoke((MethodInvoker)(() => main.tsProgressBar.Enabled = false));
                        main.BeginInvoke((MethodInvoker)(() => main.FindStatusLabel.Text = ""));

                        DialogResult result = MessageBox.Show("Сведения в каталоге обновлены. Применить обновление ?", "Обновление каталога", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result != DialogResult.OK)
                        {
                            return false;
                        }

                        _recordCollection = RC;
                        Save();
                        SaveToFile();

                        // FormLoad(true);
                        state = true;

                        if (findCount > 0)
                        {
                            MessageBox.Show("Обновлены сведения в каталоге \"" + directory + "\" для " + findCount + " файла(-ов)!");
                        }
                        else
                        {
                            MessageBox.Show("Сведения о файлах в каталоге \"" + directory + "\" обновлены!");
                        }

                        main.BeginInvoke((MethodInvoker)(() => main.FormLoad(true)));


                    }
                    else
                        MessageBox.Show("Каталог " + directory + " не обнаружен!");
                }
                catch (ApplicationException ex) { Logs.Log("При обновлении базы произошла ошибка:", ex); }
            }
            return state;
        }


        private bool RecordExist(Record record)
        {
            List<Record> list = new List<Record>();
            CombineList.ForEach(combine => list.AddRange(combine.recordList));

            foreach (Record rec in list)    // проверка наличия файла
            {
                if (rec.Equals(record))
                {
                    CombineList.FindLast(x => x.media == rec.combineLink.media).recordList.FindLast(y => y == rec).Visible = true;
                    return true;    // если файл есть
                }
            }
            return false;           // иначе файла нет файл есть
        }

        void CreateCombine(FileInfo file)
        {
            Combine cm = new Combine();

            Record record = CreateRecord(file);

            record.combineLink = cm;
            cm.recordList.Add(record);
            cm.media.Name = record.Name;
            cm.media.Id = GetMediaID();

            Add(cm);
        }

        private static Record CreateRecord(FileInfo file)
        {
            Record record = new Record();
            record.Name = getRecordName(file);
            record.FileName = file.Name;        // полное название файла (film.avi)
            record.Path = file.DirectoryName;   // полный путь (C:\Folder)
            record.Visible = true;              // видимость
            record.Extension = file.Extension.Trim('.');            // расширение файла (avi)
            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
            record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                    // if (-1 != file.DirectoryName.Substring(dlina).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
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

    }
}
