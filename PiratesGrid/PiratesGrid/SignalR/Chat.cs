using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesGrid.SignalR
{
    public class Chat : Hub
    {
        public Task Send(string nick, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", nick, message);
        }
    }
}
