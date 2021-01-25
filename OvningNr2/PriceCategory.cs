using System;
using System.Collections.Generic;
using System.Text;

namespace OvningNr2
{
    //public enum PriceCategory
    //{
    //        Teen = 80,
    //        Standard = 120,
    //        Senior=90
    //}

    public class PriceCategory
    {
        public static int SenoirPrice { get; } = 90;
        public static int TeenPrice { get; } = 80;
        public static int StandardPrice { get; } = 120;
        public static int FreePrice { get; } = 0;
        public static int TotalPrice { get; set; }
        // These are the properties used to tell the price category for each person on the menu "1" 
        // the ones that have " get " only are the ones that has a constant value that we wanna summon in the main program.
        // and the ones that have " get" and "set" are the ones we can assign a value to when we summon them.
        public static bool right { get; set; } = true;


    }
}
