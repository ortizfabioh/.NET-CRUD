using System;
using System.Collections.Generic;
using dotnet_proj01.interfaces;

namespace dotnet_proj01
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();
        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public void Insert(Serie entity)
        {
            seriesList.Add(entity);
        }

        public List<Serie> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Serie ReturnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }
    }
}