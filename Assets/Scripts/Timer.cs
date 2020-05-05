using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class DateTimeExtension
{
    public static long ToMilliseconds(this TimeSpan moment)
    {
        return moment.Milliseconds + moment.Seconds * 1000 + moment.Minutes * 60000 + moment.Hours * 320000;
    }
}
class Timer
{
    public Timer()
    {
        start = DateTime.Now;
    }
    DateTime start;

    public float Time
    {
        get
        {
            return Convert.ToSingle(DateTime.Now.Subtract(start).TotalMilliseconds);
        }
    }
}
