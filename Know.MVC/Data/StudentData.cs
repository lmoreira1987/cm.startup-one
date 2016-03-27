using Know.MVC.Models;
using Know.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.Data
{
    public class StudentData
    {
        public WarSelectViewModel PreencherTelaWarSelect(long id, List<Usuario> usuarios)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                WarSelectViewModel w = new WarSelectViewModel();
                w.Disciplinas = new List<Disciplina>();
                w.Series = new List<Serie>();
                w.UsuarioBatalha = new List<UsuarioBatalhaViewModel>();

                w.Disciplinas.AddRange(banco.Disciplinas.ToList());
                w.Series.AddRange(banco.Series.ToList());

                foreach (var item in usuarios)
	            {
                    if (item.Id != id)
                    {
                        UsuarioBatalhaViewModel u = new UsuarioBatalhaViewModel();
                        u.Id = item.Id;
                        u.Nome = item.Nome;
                        w.UsuarioBatalha.Add(u);
                    }
	            }

                return w;
            }
        }
    }
}