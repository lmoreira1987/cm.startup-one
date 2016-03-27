using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.ViewModels.Menu
{
    public class MenuViewModel
    {
        public long id { get; set; }
        public long? idPai { get; set; }
        public string menu { get; set; }
        public string icone { get; set; }
        public string url { get; set; }

        public List<MenuViewModel> Children { get; set; }
    }
}