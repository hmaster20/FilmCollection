using FC.Provider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FilmCollection
{
    public static class DownloadDetails
    {
        private const string SERIES = "https://afisha.mail.ru/search/?ent=20&q=";
        private const string FILMS = "https://afisha.mail.ru/search/?ent=1&q=";

        static Media _media { get; set; }

        public static void GetInfo(Record record, MainForm mainForm)
        {
            if (record == null) return;

            Media media = record.combineLink.media;
            _media = (Media)media.Clone();

            string webQuery = (_media.Category == CategoryVideo.Series) ? SERIES : FILMS;
            string htmlPage = GetHtml(webQuery + media.Name);

            //MatchCollection mc = Regex.Matches(htmlPage, "(<a href=.*?searchitem__item__pic__img.*?>)", RegexOptions.IgnoreCase);
            //MatchCollection mc = Regex.Matches(htmlPage, "(<a class=.*?p-poster__img.*?</a>)", RegexOptions.IgnoreCase);
            MatchCollection mc = Regex.Matches(htmlPage, "(p-poster__img.*?</a>)", RegexOptions.IgnoreCase);

            if (mc.Count > 1)
            {
                List<Media> MList = new List<Media>();

                for (int i = 0; i < mc.Count; i++)
                {
                    _media = new Media();
                    _media.Name = media.Name;
                    _media.Pic = "" + media.Name + "_" + i;

                    List<string> arrayPath = new List<string>(mc[i].ToString().Split('"', '(', ')'));

                    string Link_txt = arrayPath.FindLast(p => p.StartsWith("/cinema/") && p.EndsWith("/"));

                    if (Link_txt == null)
                        Link_txt = arrayPath.FindLast(p => p.StartsWith("/series") && p.EndsWith("/"));

                    if (!string.IsNullOrEmpty(Link_txt))
                    {
                        DownloadModule(Link_txt);
                    }
                    MList.Add(_media);
                }
                OpenFormSelectMedia(MList, record);
            }
            else if (mc.Count == 1)
            {
                List<string> arrayPath = new List<string>(mc[0].ToString().Split('"', '(', ')'));

                string PicWeb = arrayPath.FindLast(p => p.StartsWith("https://"));
                string Link_txt = arrayPath.FindLast(p => p.StartsWith("/cinema/") && p.EndsWith("/"));
                if (Link_txt == null)
                {
                    Link_txt = arrayPath.FindLast(p => p.StartsWith("/series") && p.EndsWith("/"));
                }

                if (!string.IsNullOrEmpty(PicWeb) && !string.IsNullOrEmpty(Link_txt)) // для более полного соответствия искомому фильму
                {
                    DownloadModule(Link_txt);
                }
            }

            if (_media != null)
            {
                ApproveActors();
                ApprovePic();
                _media.Id = record.combineLink.media.Id;
                record.combineLink.media = _media;
                mainForm.BeginInvoke((MethodInvoker)(() => { mainForm.AfterUpdateRefresh(record); }));
            }
        }


        private static void ApprovePic()
        {
            Debug.Print(_media.GetFilename);

            if (File.Exists(_media.GetFilename))
            {
                string oldName = _media.GetFilename;
                _media.Pic = _media.Name;
                string newName = _media.GetFilename;
                File.Move(@oldName, @newName);
            }

            string[] files = Directory.GetFiles(_media.GetDirectory, _media.Name + "_*");
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }

        private static void ApproveActors()
        {
            if (_media != null)
            {
                RecordCollection _videoCollection = RecordCollection.GetInstance();
                List<string> Actors = new List<string>();
                _media.ActorList.ForEach(act => Actors.Add(act.FIO));
                _media.ActorList.Clear();
                _media.ActorListID.Clear();

                foreach (string actorFIO in Actors)
                {
                    if (_videoCollection.ActorList.Exists(x => x.FIO == actorFIO))
                    {
                        Actor _actor = null;
                        _actor = _videoCollection.ActorList.First(x => x.FIO == actorFIO);
                        _actor.Country = _media.Country;
                        _actor.VideoID_Add(_media.Id);
                        _media.ActorList.Add(_actor);
                        _media.ActorListID.Add(_actor.id);
                    }

                    if (!(_videoCollection.ActorList.Exists(x => x.FIO == actorFIO)) && !(_media.ActorList.Exists(x => x.FIO == actorFIO)))
                    {
                        Actor actor = new Actor();
                        actor.id = RecordCollection.GetActorID();
                        actor.FIO = actorFIO;
                        actor.Country = _media.Country;
                        actor.VideoID_Add(_media.Id);
                        _media.ActorList.Add(actor);
                        _media.ActorListID.Add(actor.id);
                        _videoCollection.Add(actor);
                    }
                }
            }
        }


        private static void DownloadModule(string Link_txt)
        {
            string sourcestring = GetHtml("https://afisha.mail.ru" + Link_txt);
            DownloadCountry(sourcestring);
            DownloadYear(sourcestring);
            DownloadGenre(sourcestring);
            DownloadDescription(sourcestring);
            DownloadActor(sourcestring);
            DownloadPic(sourcestring);
        }


        private static void OpenFormSelectMedia(List<Media> MList, Record record)
        {
            using (formSelectMedia form = new formSelectMedia(MList, record))
            {
                switch (form.ShowDialog())
                {
                    case DialogResult.OK:
                        if (form.media != null) _media = (Media)form.media.Clone();
                        break;
                    case DialogResult.Cancel: _media = null; break;
                    default: break;
                }
            }
        }

        /// <summary>получение веб-страницы</summary><param name="url"></param><returns></returns>
        private static string GetHtml(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (StreamReader reader = new StreamReader(client.OpenRead(url)))
                    {
                        if (reader != null)
                        {
                            return reader.ReadToEnd();
                        }
                    }
                    //Необработанное исключение типа "System.IO.IOException" в System.dll
                    //Дополнительные сведения: Неожиданный EOF или 0 байт из транспортного потока.
                }
            }
            catch (WebException ex) { Logs.Log("В интернете отсутствует запрошенная информация (WebException).\n", ex); }
            catch (ApplicationException ex) { Logs.Log("В интернете отсутствует запрошенная информация (ApplicationException).\n", ex); }
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

        private static void DownloadName(string sourcestring)
        {
            MatchCollection mcName = Regex.Matches(sourcestring, "(movieabout__name.*?</h1>)", RegexOptions.IgnoreCase);
            foreach (Match m in mcName)
            {
                string strt = m.ToString();
                strt = strt.Remove(0, strt.IndexOf('>') + 1);
                strt = strt.Remove(strt.IndexOf('<'), (strt.Length - strt.IndexOf('<')));
                _media.Name = strt;
                break;
            }

            //string pattern = "(.*)(movieabout__name\".*?>)(.*)(</h1>)(.*)";
            //string input = sourcestring;
            //MatchCollection matches = Regex.Matches(input, pattern);

            //foreach (Match match in matches)
            //{
            //    _media.Name = match.Groups[3].Value;
            //}
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
                        {   // может несколько стран
                            //_media.Country = (Country_Rus)Enum.Parse(typeof(Country_Rus), strt);

                            Country_Rus country;
                            if (Enum.TryParse(strt, out country))
                            {
                                _media.Country = (Country_Rus)country;
                            }

                            flag = true;
                            break;// оставляем одну страну и выходим
                        }
                        catch (ApplicationException ex) { MessageBox.Show(ex.Message); }
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
            if (!string.IsNullOrEmpty(year))
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
                        {   // может несколько жанров
                            if (strt == "мультфильмы")
                            {
                                _media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), "Детский", true);
                                _media.Category = (CategoryVideo)Enum.Parse(typeof(CategoryVideo_Rus), "Мультфильм", true);
                            }
                            else
                            {
                                // _media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), strt, true);

                                GenreVideo_Rus newGenre;
                                if (Enum.TryParse(strt, out newGenre))
                                {
                                    _media.GenreVideo = (GenreVideo)newGenre;
                                }
                            }
                            break;  // оставляем одну страну и выходим
                        }
                        catch (ApplicationException ex) { MessageBox.Show(ex.Message); }
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
                catch (ApplicationException ex) { MessageBox.Show(ex.Message); }

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

            if (mcDesc.Count == 0)
            {
                //mcDesc = Regex.Matches(sourcestring, "(class=\"js-show-more\".*?</div>)", RegexOptions.IgnoreCase);
                mcDesc = Regex.Matches(sourcestring, "(<th>В ролях</th>.*?</div>)", RegexOptions.IgnoreCase);
            }

            foreach (Match m in mcDesc)
            {
                string ActorsFragment = m.ToString();
                if (ActorsFragment.IndexOf("<a href") != -1)
                {
                    ActorsFragment = ActorsFragment.Substring(ActorsFragment.IndexOf("<a href"));
                }

                List<string> ActorsPrep = ActorsFragment.Split(new string[] { ">", "</a>", }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ActorsPrep.RemoveAll(x => !StringIsValid2(x));
                if (ActorsPrep.Count >0)
                {
                    _media.ActorList.Clear();
                    ActorsPrep.ForEach(x => _media.ActorList.Add(new Actor(x)));
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
                if (!string.IsNullOrEmpty(PicPath))
                {
                    try
                    {
                        string tmp = _media.Pic;
                        _media.Pic = _media.Name;

                        if (File.Exists(_media.GetFilename)) File.Delete(_media.GetFilename);

                        _media.Pic = tmp;

                        if (PicPath.StartsWith("http"))                //if (PicWeb.Contains("http"))
                        {
                            using (WebClient webClient = new WebClient())
                                webClient.DownloadFile(PicPath, _media.GetFilename);
                        }

                        break;
                    }
                    catch (Exception ex)
                    {
                        //break;
                        //throw new ArgumentNullException(ex.Message + "\nПричина: " + ex.InnerException.Message);
                        throw new ApplicationException(ex.Message + "\nПричина: " + ex.InnerException.Message);
                    }
                }
            }
        }
    }
}
