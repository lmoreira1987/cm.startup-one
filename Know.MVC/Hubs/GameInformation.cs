using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.Hubs
{
    public class GameInformation
    {
        public string OpponentName { get; set; }

        public string Winner { get; set; }

        public int MarkerPosition { get; set; }
    }
}