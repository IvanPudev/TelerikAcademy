﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebApi.Models
{
    public class LoggedUserModel
    {
        public string Nickname { get; set; }

        public string SessionKey { get; set; }
    }
}