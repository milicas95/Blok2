﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBparam
{
    public class DBParam
    {

        public DBParam() { }

        public int CNT { get; set; }

        public int Id { get; set; }

        public string Region { get; set; }

        public string City
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;
        }
        public string Month
        {
            get;
            set;
        }
        public int ElEnergySpent
        {
            get;
            set;
        }
    }
}
