using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Utilities
{
    public static class Convertor
    {
        public static string ElapsedTimeNotification(this DateTime value)
        {
            var now = DateTime.Now;
            var elapsed = now.Subtract(value);

            string result;
            if (elapsed.Days < 1)
            {
                if (elapsed.Minutes < 1)
                {
                    result = Math.Round(elapsed.TotalSeconds) + " ثانیه قبل";
                }
                else if (elapsed.Hours < 1)
                {
                    result = Math.Round(elapsed.TotalMinutes) + " دقیقه قبل";
                }
                else
                {
                    result = Math.Round(elapsed.TotalHours) + " ساعت قبل";
                }
            }
            else
            {
                result = Math.Round(elapsed.TotalDays) + " روز قبل";
            }

            return result;
        }
    }
}
