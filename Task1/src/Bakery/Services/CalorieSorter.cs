﻿using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Services
{
    /// <summary>
    /// Class to compare bakes by calorie value.
    /// </summary>
    public class CalorieSorter: IComparer<Bake>
    {
        public int Compare(Bake bake1, Bake bake2)
        {
            if (bake1.Calorie > bake2.Calorie)
                return 1;
            else if (bake1.Calorie < bake2.Calorie)
                return -1;
            else
                return 0;
        }
    }
}
