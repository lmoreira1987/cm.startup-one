using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.Hubs
{
    public class Client
    {
        public string ConnectionId { get; set; }

        public string Name { get; set; }

        public Client Opponent { get; set; }

        public bool IsPlaying { get; set; }

        public bool WaitingForMove { get; set; }

        public bool LookingForOpponent { get; set; }

        public DateTime GameStarted { get; set; }
    }
}