﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audubon.Interface
{
    interface IClickEvent : IClickable
    {
        void ClickEvent(SteamVR_Controller.Device conntroller);
    }
}
