﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetherSDK.Models
{
    [Serializable]
    public class Player
    {
        public string gamertag;
        public string country;
        public string customTag;
    }

    [Serializable]
    public class PlayerResult
    {
        public Player player;
    }

}
