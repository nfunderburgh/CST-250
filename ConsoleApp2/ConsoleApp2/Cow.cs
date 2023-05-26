﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Noah Funderburgh
// Date: 11/12/2022
// Class: CST-250
// Teacher: Brandon Bass

namespace ConsoleApp2
{
    class Cow : Animal, IMilkable
    {
        public void MilkMe()
        {
            Console.WriteLine("I am a cow getting milked");
        }
        public new void Talk()
        {
            Console.WriteLine("Mooooo Mooooo");
        }
    }
}
