using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace SQBlog.Web.SignalR
{
    public class ChatHub:Hub
    {
        public void Send(string msg)
        {
            Clients.All.addMessage(msg);
        }
    }
}