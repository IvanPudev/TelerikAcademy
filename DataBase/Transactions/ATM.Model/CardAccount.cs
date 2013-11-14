﻿using System;
using System.Linq;

namespace ATM.Model
{
    public class CardAccount
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CardPIN { get; set; }
        public decimal CardCash { get; set; }
    }
}