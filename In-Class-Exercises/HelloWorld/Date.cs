﻿using System;


namespace HelloWorld.Date
{
    public class Date
    {
        public static bool IsLeap(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 != 0)
                {
                    return true;
                }
                else if (year % 400 == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
