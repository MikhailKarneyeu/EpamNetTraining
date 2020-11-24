﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    public class PriceSorter: IComparer<Bake>
    {
        public int Compare(Bake bake1, Bake bake2)
        {
            if (bake1.Price > bake2.Price)
                return 1;
            else if (bake1.Price < bake2.Price)
                return -1;
            else
                return 0;
        }
    }
}
