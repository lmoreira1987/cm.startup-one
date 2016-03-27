using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Know.MVC.Models;
using Know.MVC.ViewModels.Menu;

namespace Know.MVC.Data
{
    public class MenuData
    {
        public Professor SelecionarProfessor(string email, string password)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return (from u in banco.Usuarios
                        join p in banco.Professors
                            on u.Id equals p.IdUsuario
                        where (u.Ativo && p.Ativo && u.Email == email && u.Senha == password)
                        select p).FirstOrDefault();
            }

        }

        public List<MenuViewModel> PreencherMenu(Usuario usuario)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                var idPerfil = (from u in banco.Usuarios
                                join up in banco.UsuarioPerfils
                                     on u.Id equals up.IdUsuario
                                where u.Id == usuario.Id
                                select up
                    ).FirstOrDefault().IdPerfil;

                //long idPerfil = ((UsuarioPerfil)usuarioPerfil).IdPerfil;

                return PreencherMenu(banco, idPerfil);
            }
        }

        public List<MenuViewModel> PreencherMenu(DB_KnowEntities banco, long idPerfil)
        {
            List<MenuViewModel> menus = new List<MenuViewModel>();

            if (idPerfil != 1)
            {
                menus = (from men in banco.Menus
                        join per in banco.PerfilAcessoes
                            on men.Id equals per.IdMenu
                        where (men.IdMenuPai == null && per.IdPerfil == idPerfil)
                        orderby men.Ordem
                        select new MenuViewModel
                        {
                            id = men.Id,
                            idPai = men.IdMenuPai.Value,
                            menu = men.Nome,
                            icone = men.Imagem,
                            url = men.Url
                        }).ToList();

                foreach (var item in menus)
                {
                    item.Children = new List<MenuViewModel>();
                    item.Children = (from men in banco.Menus
                                     where men.IdMenuPai == item.id
                                     select new MenuViewModel
                                     {
                                         id = men.Id,
                                         idPai = men.IdMenuPai.Value,
                                         menu = men.Nome,
                                         icone = men.Imagem,
                                         url = men.Url
                                     }).ToList();
                }
            }
            else
            {
                MenuViewModel menu = new MenuViewModel();
                menu.id = 0;
                menu.menu = "Admin";
                menu.idPai = null;
                menu.url = "#";
                menu.icone = "home";
                menus.Add(menu);

                foreach (var item in menus)
                {
                    item.Children = new List<MenuViewModel>();
                    item.Children = (from men in banco.Menus
                                     where men.IdMenuPai != null
                                     select new MenuViewModel
                                     {
                                         id = men.Id,
                                         idPai = men.IdMenuPai.Value,
                                         menu = men.Nome,
                                         icone = men.Imagem,
                                         url = men.Url
                                     }).ToList();
                }
            }

            

            return menus;
        }
    }
}