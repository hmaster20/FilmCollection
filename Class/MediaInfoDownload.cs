using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FilmCollection
{
    public static class MediaInfoDownload
    {
        static RecordCollection _videoCollection { get; set; }     // Доступ к коллекции

        private static string GetHtml(string url)       //получение веб-страницы
        {
            try
            {
                WebClient client = new WebClient();
                using (Stream data = client.OpenRead(url))
                using (StreamReader reader = new StreamReader(data))
                    return reader.ReadToEnd();
            }
            catch (WebException exc) { MessageBox.Show("Сетевая ошибка: " + exc.Message + "\nКод состояния: " + exc.Status); }
            return "";
        }

        public static bool GetInfo(Media media, RecordCollection videoCollection)
        {
            bool flag = false;

            _videoCollection = videoCollection;

            string webQuery;

            if (media.Category == CategoryVideo.Series)
            {
                webQuery = "https://afisha.mail.ru/search/?ent=20&q=";
            }
            else
            {
                webQuery = "https://afisha.mail.ru/search/?ent=1&q=";
            }

            //string htmlPage = GetHtml("https://afisha.mail.ru/search/?q=" + media.Name);

            string htmlPage = GetHtml(webQuery + media.Name);

            //MatchCollection mc = Regex.Matches(htmlPage, "(<a href=.*?searchitem__item__pic__img.*?>)", RegexOptions.IgnoreCase);
            //MatchCollection mc = Regex.Matches(htmlPage, "(<a class=.*?p-poster__img.*?</a>)", RegexOptions.IgnoreCase);

            MatchCollection mc = Regex.Matches(htmlPage, "(p-poster__img.*?</a>)", RegexOptions.IgnoreCase);

            for (int i = 0; i < mc.Count; i++)
            {
                //string[] subStrings = mc[i].ToString().Split('"', '(', ')');
                List<string> arrayPath = new List<string>(mc[i].ToString().Split('"', '(', ')'));

                string PicWeb = arrayPath.FindLast(p => p.StartsWith("https://"));
                string Link_txt = arrayPath.FindLast(p => p.StartsWith("/cinema/") && p.EndsWith("/"));
                if (Link_txt == null)
                {
                    Link_txt = arrayPath.FindLast(p => p.StartsWith("/series") && p.EndsWith("/"));
                }

                if (PicWeb != "" && PicWeb != null && Link_txt != "") // для более полного соответствия искомому фильму
                {
                    DownloadAddon("https://afisha.mail.ru" + Link_txt, media);
                    //return true;
                    flag = true;
                }
            }

            _videoCollection = null;
            return flag;


            //for (int y = 0; y < subStrings.Length; y++)
            //{
            //    //if (subStrings[y] == "background-image:url")
            //        if (subStrings[y] == "background-image: url")
            //        {
            //        ++y;
            //        if (subStrings[y].Contains("http"))
            //        {
            //            PicWeb = subStrings[y];         //"https://pic.afisha.mail.ru/2536415/"
            //            //Link_txt = subStrings[y - 5];   //"/cinema/movies/432352_stalker/"
            //            Link_txt = subStrings[y - 3];   //"/cinema/movies/432352_stalker/"
            //            string tt = arrayPath.FindLast(p => p.StartsWith ("/cinema/") && p.EndsWith("/"));
            //            string ts = arrayPath.FindLast(p => p.StartsWith("https://"));

            //            break;
            //        }
            //    }
            //}

        }

        private static void DownloadAddon(string link, Media media)
        {
            string sourcestring = GetHtml(link);

            DownloadCountry(media, sourcestring);

            DownloadYear(media, sourcestring);

            DownloadGenre(media, sourcestring);

            DownloadDescription(media, sourcestring);

            DownloadActor(media, sourcestring);

            DownloadPic(media, sourcestring);
        }

        private static bool StringIsValid(string str)
        {
            //return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"[^a-zA-z\d_]");
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, "^[А-Яа-я]+$");
        }

        private static bool StringIsValid2(string str)   // учитывает наличие пробела
        {
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, "^[А-Яа-я ]+$");
        }

        private static void DownloadCountry(Media media, string sourcestring)
        {
            // Обработка страны
            MatchCollection mcCountries = Regex.Matches(sourcestring, "(itemevent__head__info.*?<a href=.*?>[0-9]{4}</a>)", RegexOptions.IgnoreCase);

            bool flag = false;
            foreach (Match m in mcCountries)
            {
                MatchCollection mcCountry = Regex.Matches(m.ToString(), "(>.*?<)", RegexOptions.IgnoreCase);
                foreach (Match mm in mcCountry)
                {
                    string strt = mm.ToString();
                    strt = strt.Remove(0, strt.IndexOf('>') + 1);
                    strt = strt.Remove(strt.IndexOf('<'), 1);
                    if (StringIsValid(strt))
                    {
                        try
                        { // может несколько стран
                            media.Country = (Country_Rus)Enum.Parse(typeof(Country_Rus), strt);
                            flag = true;
                            break;// оставляем одну страну и выходим
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                if (flag) break;
            }
        }

        private static void DownloadYear(Media media, string sourcestring)
        {
            // Обработка года
            MatchCollection mcYear = Regex.Matches(sourcestring, "(itemevent__head__sep.*?<a href=.*?>[0-9]{4})", RegexOptions.IgnoreCase);

            string year = "";
            foreach (Match m in mcYear)
            {
                year = m.ToString();
                year = year.Remove(0, m.Length - 4);
                break;
            }
            if (year != "")
            {
                media.Year = Convert.ToInt32(year);
            }
        }

        private static void DownloadGenre(Media media, string sourcestring)
        {
            // Обработка жанра
            //MatchCollection mcGenre = Regex.Matches(sourcestring, "(itemevent__head__genre.*?<a href=.*?>[0-9]{4}</a>)", RegexOptions.IgnoreCase);
            MatchCollection mcGenre = Regex.Matches(sourcestring, "(itemevent__head__genre.*?</a>)", RegexOptions.IgnoreCase);

            // Value = "itemevent__head__genre\" itemprop=\"genre\"><a href=\"/cinema/all/drama/\">драма</a> <a href=\"/cinema/all/detektiv/\">детектив</a> <a href=\"/cinema/all/kriminal/\">криминал</a> <a href=\"/cinema/all/fentezi/\">фэнтези</a></div><div class=\"movieabout__sl...

            foreach (Match m in mcGenre)
            {
                //MatchCollection mcCountry = Regex.Matches(m.ToString().Trim(), "(>.*?<)", RegexOptions.IgnoreCase);
                //MatchCollection mcCountry = Regex.Matches(m.ToString().Replace(" ", string.Empty), "(>.*?<)", RegexOptions.IgnoreCase);
                MatchCollection mcCountry = Regex.Matches(m.ToString(), "(>.*?<)", RegexOptions.IgnoreCase);

                int arrayCount = (mcCountry.Count > 10) ? 10 : mcCountry.Count;

                for (int i = 0; i < arrayCount; i++)
                {
                    if (mcCountry[i].ToString().Replace(" ", string.Empty) == "><") continue;

                    string strt = mcCountry[i].ToString().Replace(" ", string.Empty);
                    strt = strt.Remove(0, strt.IndexOf('>') + 1);
                    strt = strt.Remove(strt.IndexOf('<'), 1);
                    if (StringIsValid(strt))
                    {
                        try
                        { // может несколько жанров
                            if (strt == "мультфильмы")
                            {
                                media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), "Детский", true);
                                media.Category = (CategoryVideo)Enum.Parse(typeof(CategoryVideo_Rus), "Мультфильм", true);
                            }
                            else
                            {
                                media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), strt, true);
                            }
                            break;// оставляем одну страну и выходим
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                break;
            }
        }

        private static void DownloadDescription(Media media, string sourcestring)
        {
            // Обработка описания
            // MatchCollection mcDesc = Regex.Matches(sourcestring, @"(<div class=\""movieabout__info__descr__tx.*?>.*?</p>)", RegexOptions.IgnoreCase);
            MatchCollection mcDesc = Regex.Matches(sourcestring, @"(movieabout__info__descr__txt.*?</div>)", RegexOptions.IgnoreCase);

            /*
             * {<div class="movieabout__info__descr__txt" itemprop="description">
             */

            foreach (Match m in mcDesc)
            {
                string str = m.ToString();

                try
                {
                    if (-1 != str.IndexOf("<p"))
                    {
                        str = str.Remove(0, str.IndexOf("<p"));
                        if (-1 != str.IndexOf(">"))
                            str = str.Remove(0, str.IndexOf(">") + 1);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                str = Regex.Replace(str, "&nbsp;", " ");
                str = Regex.Replace(str, "&mdash;", "-");
                str = Regex.Replace(str, "&laquo;", "\"");
                str = Regex.Replace(str, "&raquo;", "\"");
                str = Regex.Replace(str, "&bdquo;", "\"");
                str = Regex.Replace(str, "&ldquo;", "\"");
                str = Regex.Replace(str, "<span>", "");
                str = Regex.Replace(str, "</span>", "");
                str = Regex.Replace(str, "<br/>", "");
                str = Regex.Replace(str, "<br />", "");
                str = Regex.Replace(str, "<span class=\"_reachbanner_\">", "");
                str = Regex.Replace(str, "&hellip;", "...");
                str = Regex.Replace(str, "<p>", "");
                str = Regex.Replace(str, "</p>", "");
                str = Regex.Replace(str, "</div>", "");

                media.Description = str.Trim();
            }
        }

        private static void DownloadActor(Media media, string sourcestring)
        {
            // Обработка описания
            MatchCollection mcDesc = Regex.Matches(sourcestring, "(itemprop=\"actors\".*?</div>)", RegexOptions.IgnoreCase);

            /* 1 строка
             * {itemprop="actors">
             * <a href="/person/631361_aishwarya_rai/" itemprop="name">Айшвария Рай Баччан</a>, <a href="/person/457275_irfan_khan/" itemprop="name">Ирфан Кхан</a>, <a href="/person/544254_shabana_azmi/" itemprop="name">Шабана Азми</a>, <a href="/person/459400_jackie_shroff/" itemprop="name">Джеки Шрофф</a>, <a href="/person/537746_atul_kulkarni/" itemprop="name">Атул Кулкарни</a>, <a href="/person/613371_chandan_roy_sanyal/" itemprop="name">Чандан Рой Саньял</a>, <a href="/person/575658_abhimanyu_singh/" itemprop="name">Синг Амбхимани Шехар</a>, <a href="/person/743763_taran_bajaj/" itemprop="name">Таран Баджадж</a>, <a href="/person/743764_priya_banerjee/" itemprop="name">Прия Банерджи</a>, <a href="/person/667870_siddhant_kapoor/" itemprop="name">Сиддхант Капур</a></div>}
             */

            string ssss = "";

            if (mcDesc.Count == 0)
            {
                //mcDesc = Regex.Matches(sourcestring, "(class=\"js-show-more\".*?</div>)", RegexOptions.IgnoreCase);
                mcDesc = Regex.Matches(sourcestring, "(<th>В ролях</th>.*?</div>)", RegexOptions.IgnoreCase);
                // 1 строка
                //
                // {<th>В ролях</th><td><div class="js-show-more"><a href="/person/437937_petr_veljaminov/">Петр Вельяминов</a>, <a href="/person/460439_ada_rogovceva/">Ада Роговцева</a>, <a href="/person/630781_vadim_spiridonov/">Вадим Спиридонов</a>, <a href="/person/455898_tamara_semina/">Тамара Семина</a>, <a href="/person/455523_nikolaj_ivanov/">Николай Иванов</a>, <a href="/person/462498_ivan_lapikov/">Иван Лапиков</a>, <a href="/person/501181_vladlen_birjukov/">Владлен Бирюков</a>, <a href="/person/630476_valerij_hlevinskij/">Валерий Хлевинский</a>, <a href="/person/438527_efim_kopeljan/">Ефим Копелян</a>, <a href="/person/438578_andrej_martynov/">Андрей Мартынов</a>, <a href="/person/703060_vladimir_ivanov/">Владимир Иванов</a></div>} 

                //ssss = mcDesc[0].ToString();
                //if (ssss.IndexOf("<a href") != -1)
                //{
                //    ssss = ssss.Substring(ssss.IndexOf("<a href"));
                //}       

            }



            foreach (Match m in mcDesc)
            {

                ssss = m.ToString();
                if (ssss.IndexOf("<a href") != -1)
                {
                    ssss = ssss.Substring(ssss.IndexOf("<a href"));
                }
                string[] mArray = ssss.Split(new string[] { ">", "</a>", }, StringSplitOptions.RemoveEmptyEntries);


                // string[] mArray = m.ToString().Split(new string[] { "\"name\">", "</a>", }, StringSplitOptions.RemoveEmptyEntries);

                // получение ссылки на страницу актеров
                //for (int i = 0; i < strs.Length; i++)
                //{
                //    if (StringIsValid2(strs[i]))
                //    {
                //        string st = strs[i - 1];

                //        st = st.Substring(st.LastIndexOf("/"));
                //        st = st.Substring(st.IndexOf("/person/"));
                //        MessageBox.Show(st);
                //    }
                //}

                foreach (string item in mArray)
                {
                    if (StringIsValid2(item))
                    {
                        Actor actor;

                        if (!(_videoCollection.ActorList.Exists(act => act.FIO == item)))
                        {
                            actor = new Actor();
                            actor.id = RecordCollection.GetActorID();
                            actor.FIO = item;
                            actor.Country = media.Country;
                            actor.VideoID_Add(media.Id);
                            media.ActorListID_Add(actor.id);

                            _videoCollection.ActorList.Add(actor);
                        }
                        else
                        {
                            actor = _videoCollection.ActorList.FindLast(act => act.FIO == item);
                            if (!actor.VideoID.Contains(media.Id))
                            {
                                actor.VideoID_Add(media.Id);
                                media.ActorListID_Add(actor.id);
                            }
                        }
                    }
                }
            }
        }

        private static void DownloadPic(Media media, string sourcestring)
        {
            // Обработка картинки
            MatchCollection Pics = Regex.Matches(sourcestring, "(<img src=.*?class=\"movieabout__pic__img\")", RegexOptions.IgnoreCase);

            foreach (Match Pic in Pics)
            {
                string PicPath = Pic.ToString();
                PicPath = PicPath.Remove(0, PicPath.IndexOf('"') + 1);
                PicPath = PicPath.Remove(PicPath.IndexOf('"'), PicPath.Length - PicPath.IndexOf('"'));
                if (PicPath != "")
                {
                    try
                    {
                        //if (File.Exists(GetFilename(media.Pic))) File.Delete(GetFilename(media.Pic));
                        if (File.Exists(media.GetFilename)) File.Delete(media.GetFilename);
                        //DownloadPicBig(PicPath, media.Name);
                        DownloadPicBig(PicPath, media.GetFilename);
                        media.Pic = media.Name;
                        break;
                    }
                    catch (Exception ex)
                    {
                        break;
                        throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message);
                    }
                }
            }
        }

        private static void DownloadPicBig(string PicWeb, string PicFilename)
        {
            try
            {
                if (PicWeb.StartsWith("http"))                //if (PicWeb.Contains("http"))
                {
                    using (WebClient webClient = new WebClient())
                        webClient.DownloadFile(PicWeb, PicFilename);
                }
            }
            catch (Exception Ex) { MessageBox.Show("Загрузить изображение не удалось: " + Ex.Message); }
        }

   

        public static string GetTime(Record record)
        {
            string value = "";
            //Record record = GetSelectedRecord();
            if (record != null)
            {
                Shell shell = new Shell();
                Folder folder = shell.NameSpace(record.Path);
                foreach (FolderItem2 _file in folder.Items())
                {
                    if (_file.Name == record.FileName.Remove(record.FileName.LastIndexOf(record.Extension) - 1, record.Extension.Length + 1))
                    {
                        double nanoseconds;
                        double.TryParse(Convert.ToString(_file.ExtendedProperty("System.Media.Duration")), out nanoseconds);
                        if (nanoseconds > 0)
                        {
                            value = TimeSpan.FromSeconds(nanoseconds / 10000000).ToString();

                            //string oldvalue = mtbTime.Text;
                            //mtbTime.Text = TimeSpan.FromSeconds(nanoseconds / 10000000).ToString();
                            //if (mtbTime.Text != oldvalue)
                            //    Modified();
                        }
                    }
                }
                Marshal.ReleaseComObject(folder);
                Marshal.ReleaseComObject(shell);
            }
            return value;
        }

    }
}
