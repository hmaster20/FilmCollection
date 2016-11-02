using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmCollection
{
    class Media
    {
        public Media()
        {
            ActorID = new List<int>();          // Создание списка ID
        }

        public int Id { get; set; }             // Уникальный идентификатор
        public string Pic { get; set; } = "";   
        public string Description { get; set; } = "";  // Описание файла (сюжет)

        private int _year;                      // Год выпуска
        public int Year
        {
            get { return _year; }
            set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
        }

        #region Список ID актеров

        private List<int> _actorID;     // Объявление ID актеров
        public List<int> ActorID
        {
            get { return _actorID; }
            set { _actorID = value; }
        }

        public void Add(int id)
        {
            ActorID.Add(id);
        }

        public void Remove(int id)
        {
            ActorID.Remove(id);
        }

        public void ClearID()
        {
            ActorID.Clear();
        }

        #endregion

    }
}
