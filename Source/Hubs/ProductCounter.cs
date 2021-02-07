using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_Project_WSEI.Hubs
{
    public class ProductCounter : Hub
    {
        public static int userCounter = 0;

        public override Task OnConnectedAsync()
        {
            userCounter++;
            Clients.All.SendAsync("updateUserCounter", userCounter);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            userCounter--;
            Clients.All.SendAsync("updateUserCounter", userCounter);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
