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
    public static class DownloadDetails
    {
        private const string SERIES = "https://afisha.mail.ru/search/?ent=20&q=";
        private const string FILMS = "https://afisha.mail.ru/search/?ent=1&q=";

        static RecordCollection _videoCollection { get; set; }
        static Media _media { get; set; }
        static Media mediaOriginal { get; set; }

        public static bool GetInfo(Media media, RecordCollection videoCollection)
        {
            bool flag = false;
            string webQuery = "";

            _videoCollection = RecordCollection.GetInstance();

            mediaOriginal = media;
            _media = media;

            if (_media.Category == CategoryVideo.Series)
                webQuery = SERIES;
            else
                webQuery = FILMS;

            string htmlPage = GetHtml(webQuery + media.Name);

            //MatchCollection mc = Regex.Matches(htmlPage, "(<a href=.*?searchitem__item__pic__img.*?>)", RegexOptions.IgnoreCase);
            //MatchCollection mc = Regex.Matches(htmlPage, "(<a class=.*?p-poster__img.*?</a>)", RegexOptions.IgnoreCase);
            MatchCollection mc = Regex.Matches(htmlPage, "(p-poster__img.*?</a>)", RegexOptions.IgnoreCase);

            if (mc.Count > 1)
            {
                List<Media> MList = new List<Media>();

                for (int i = 0; i < mc.Count; i++)
                {    
                     Media m = (Media)media.Clone();

                    m.Pic = ""+ m.Name + "_" + i;
                    _media = m;

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
                        string sourcestring = GetHtml("https://afisha.mail.ru" + Link_txt);

                        DownloadCountry(sourcestring);
                        DownloadYear(sourcestring);
                        DownloadGenre(sourcestring);
                        DownloadDescription(sourcestring);
                        DownloadActor(sourcestring);
                        // DownloadPic(sourcestring);
                        DownloadPicTemp(sourcestring);

                        flag = true;
                    }

                    MList.Add(m);

                }


                formSelectMedia form = new formSelectMedia(MList);
                if (form.ShowDialog() == DialogResult.OK)
                    if (form.media != null)
                    {
                        mediaOriginal = (Media)form.media.Clone();
                    }
                }



            //if (mc.Count > 1)
            //{
            //    formSelectMedia selectMedia = new formSelectMedia();
            //    selectMedia.ShowDialog();
            //}
            //else
            //{
            //    //media = 
            //}


            return flag;
        }


        //static string GetPicDirectory()
        //{
        //    return Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"));
        //}

        //private static string TempFolder()
        //{
        //    if (!Directory.Exists(Path.Combine(GetPicDirectory(), "Temp")))
        //    {
        //        Directory.CreateDirectory("Temp");
        //    }
        //    return Path.Combine(GetPicDirectory(), "Temp");
        //}

        //private static string GetFilename(string name)
        //{
        //    return Path.Combine(TempFolder(), "" + name + ".jpg");
        //}

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

        private static bool StringIsValid(string str)
        {
            //return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"[^a-zA-z\d_]");
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, "^[А-Яа-я]+$");
        }

        private static bool StringIsValid2(string str)   // учитывает наличие пробела
        {
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, "^[А-Яа-я ]+$");
        }

        private static void DownloadCountry(string sourcestring)
        {
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
                            _media.Country = (Country_Rus)Enum.Parse(typeof(Country_Rus), strt);
                            flag = true;
                            break;// оставляем одну страну и выходим
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                if (flag) break;
            }
        }

        private static void DownloadYear(string sourcestring)
        {
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
                _media.Year = Convert.ToInt32(year);
            }
        }

        private static void DownloadGenre(string sourcestring)
        {
            //MatchCollection mcGenre = Regex.Matches(sourcestring, "(itemevent__head__genre.*?<a href=.*?>[0-9]{4}</a>)", RegexOptions.IgnoreCase);
            MatchCollection mcGenre = Regex.Matches(sourcestring, "(itemevent__head__genre.*?</a>)", RegexOptions.IgnoreCase);

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
                                _media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), "Детский", true);
                                _media.Category = (CategoryVideo)Enum.Parse(typeof(CategoryVideo_Rus), "Мультфильм", true);
                            }
                            else
                            {
                                _media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), strt, true);
                            }
                            break;// оставляем одну страну и выходим
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                break;
            }
        }

        private static void DownloadDescription(string sourcestring)
        {
            // MatchCollection mcDesc = Regex.Matches(sourcestring, @"(<div class=\""movieabout__info__descr__tx.*?>.*?</p>)", RegexOptions.IgnoreCase);
            MatchCollection mcDesc = Regex.Matches(sourcestring, @"(movieabout__info__descr__txt.*?</div>)", RegexOptions.IgnoreCase);

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

                _media.Description = str.Trim();
            }
        }

        private static void DownloadActor(string sourcestring)
        {
            // Обработка описания
            MatchCollection mcDesc = Regex.Matches(sourcestring, "(itemprop=\"actors\".*?</div>)", RegexOptions.IgnoreCase);

            string ssss = "";

            if (mcDesc.Count == 0)
            {
                //mcDesc = Regex.Matches(sourcestring, "(class=\"js-show-more\".*?</div>)", RegexOptions.IgnoreCase);
                mcDesc = Regex.Matches(sourcestring, "(<th>В ролях</th>.*?</div>)", RegexOptions.IgnoreCase);
            }

            foreach (Match m in mcDesc)
            {
                ssss = m.ToString();
                if (ssss.IndexOf("<a href") != -1)
                {
                    ssss = ssss.Substring(ssss.IndexOf("<a href"));
                }
                string[] mArray = ssss.Split(new string[] { ">", "</a>", }, StringSplitOptions.RemoveEmptyEntries);

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
                            actor.Country = _media.Country;
                            actor.VideoID_Add(_media.Id);
                            _media.ActorListID_Add(actor.id);

                            _videoCollection.ActorList.Add(actor);
                        }
                        else
                        {
                            actor = _videoCollection.ActorList.FindLast(act => act.FIO == item);
                            if (!actor.VideoID.Contains(_media.Id))
                            {
                                actor.VideoID_Add(_media.Id);
                                _media.ActorListID_Add(actor.id);
                            }
                        }
                    }
                }
            }
        }

        private static void DownloadPic(string sourcestring)
        {
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
                        _media.Pic = _media.Name;

                        if (File.Exists(_media.GetFilename))
                            File.Delete(_media.GetFilename);

                        if (PicPath.StartsWith("http"))                //if (PicWeb.Contains("http"))
                        {
                            using (WebClient webClient = new WebClient())
                                webClient.DownloadFile(PicPath, _media.GetFilename);
                        }

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


        private static void DownloadPicTemp(string sourcestring)
        {
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
                        //_media.Pic = _media.Name;

                        if (File.Exists(_media.GetFilename))
                            File.Delete(_media.GetFilename);

                        if (PicPath.StartsWith("http"))                //if (PicWeb.Contains("http"))
                        {
                            string path = _media.GetFilename;
                            using (WebClient webClient = new WebClient())
                                webClient.DownloadFile(PicPath, _media.GetFilename);
                        }

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


    }
}
