﻿using System.Windows.Input;

namespace RemoteCommander.Server.Events
{
    public class MouseEventArguments
    {
        public object Sender { get; set; }

        public MouseEventArgs E { get; set; }

        public MouseEventArguments(object sender, MouseEventArgs e)
        {
            this.Sender = sender;
            this.E = e;
        }
    }
}
