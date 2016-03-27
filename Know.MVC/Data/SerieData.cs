using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.Data
{
    public class SerieData
    {
        public List<Serie> SelecionarSeries()
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return banco.Series.ToList();
            }
        }
    }
}