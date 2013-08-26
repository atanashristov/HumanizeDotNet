using HumanizeDotNet.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HumanizeDotNet
{
    public interface ITimeMachine
    {
        DateTime Now { get; }
    }

    public class TimeMachine: ITimeMachine
    {
        public virtual DateTime Now
        {
            get { return DateTime.Now; }
        }
    }

    public static class HumanizeExtensionMethods
    {
        public static string Ordinal(this double number)
        {
            return new Humanize().Ordinal(number);
        }

        public static string IntWord(this double number)
        {
            return new Humanize().IntWord(number);
        }

        public static string APNumber(this double value)
        {
            return new Humanize().APNumber(value);
        }

        public static string NaturalDay(this DateTime dt)
        {
            return new Humanize().NaturalDay(dt);
        }

        public static string NaturalTime(this DateTime dt)
        {
            return new Humanize().NaturalTime(dt);
        }

        public static string NaturalDayOrTime(this DateTime dt, int h2d)
        {
            return new Humanize().NaturalDayOrTime(dt, h2d);
        }
    }

    public class Humanize
    {
        internal virtual ITimeMachine TimeMachine { get; set; }

        public Humanize()
            : this(new TimeMachine())
        { }

        public Humanize(ITimeMachine timeMachine)
        {
            TimeMachine = timeMachine;
        }


        /// <summary>
        /// Converts an integer to its ordinal as a string. 1 is '1st', 2 is '2nd',
        /// 3 is '3rd', etc. Works for any integer.
        /// </summary>
        /// <returns></returns>
        public string Ordinal(double number)
        {
            string[] suffixes = {
                                    HumanizeResources.th, 
                                    HumanizeResources.st, 
                                    HumanizeResources.nd, 
                                    HumanizeResources.rd, 
                                    HumanizeResources.th, 
                                    HumanizeResources.th, 
                                    HumanizeResources.th, 
                                    HumanizeResources.th, 
                                    HumanizeResources.th, 
                                    HumanizeResources.th
                                };

            if (new double[] { 11, 12, 13 }.Contains(number % 100))
                return string.Format("{0}{1}", number, suffixes[0]);
            else
                return string.Format("{0}{1}", number, suffixes[(int)(number % 10)]);
        }

        /// <summary>
        /// Converts a large integer to a friendly text representation. Works best
        /// for numbers over 1 million. For example, 1000000 becomes '1.0 million',
        /// 1200000 becomes '1.2 million' and '1200000000' becomes '1.2 billion'.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string IntWord(double number)
        {
            if (number < 1000000)
                return number.ToString();

            var convs = new Dictionary<int, string>
                {
                    {6, HumanizeResources.million},
                    {9, HumanizeResources.billion},
                    {12, HumanizeResources.trillion},
                    {15, HumanizeResources.quadrillion},
                    {18, HumanizeResources.quintillion},
                    {21, HumanizeResources.sextillion},
                    {24, HumanizeResources.septillion},
                    {27, HumanizeResources.octillion},
                    {30, HumanizeResources.nonillion},
                    {33, HumanizeResources.decillion},
                    {100, HumanizeResources.googol},
                };

            foreach (var conv in convs)
            {
                double large = (double)Math.Pow(10, conv.Key);
                if (number < large * 1000)
                {
                    double newNumber = number / large;
                    return newNumber.ToString("f1") + " " + conv.Value;
                }
            }

            return number.ToString();
        }

        /// <summary>
        /// For numbers 1-9, returns the number spelled out. Otherwise, returns the
        /// number. This follows Associated Press style.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string APNumber(double value)
        {
            var number = Math.Round(value, 0);

            if (number > 0 && number < 10)
                return new string[] { 
                    HumanizeResources.one, 
                    HumanizeResources.two, 
                    HumanizeResources.three, 
                    HumanizeResources.four, 
                    HumanizeResources.five, 
                    HumanizeResources.six, 
                    HumanizeResources.seven, 
                    HumanizeResources.eight, 
                    HumanizeResources.nine 
                }[(int)number - 1].ToString();
            else
                return value.ToString();
        }

        /// <summary>
        /// For date values that are tomorrow, today or yesterday compared to
        /// present day returns representing string.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string NaturalDay(DateTime dt)
        {
            DateTime now = TimeMachine.Now;
            TimeSpan ts = dt.Date - now.Date;

            if (ts.TotalDays == -1)
                return HumanizeResources.yesterday;
            if (ts.TotalDays == 1)
                return HumanizeResources.tomorrow;
            if (ts.TotalDays == 0)
                return HumanizeResources.today;

            return dt.ToString("d", Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
        }

        /// <summary>
        /// For date and time values shows how many seconds, minutes or hours ago
        /// compared to current timestamp returns representing string.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string NaturalTime(DateTime dt)
        {
            var now = TimeMachine.Now;
            if (dt < now)
            {
                var delta = now - dt;

                if (delta.Days > 0)
                {
                    return delta.Days == 1
                        ? HumanizeResources.one_day_ago
                        : string.Format(HumanizeResources.n_days_ago, delta.Days);
                }
                else if (delta.Hours > 0)
                {
                    return (delta.Hours == 1)
                        ? HumanizeResources.an_hour_ago
                        : string.Format(HumanizeResources.n_hours_ago, delta.Hours);
                }
                else if (delta.Minutes != 0)
                {
                    return delta.Minutes == 1
                        ? HumanizeResources.a_minute_ago
                        : String.Format(HumanizeResources.n_minutes_ago, delta.Minutes);
                }
                else
                {
                    if (delta.Seconds == 0)
                    {
                        return HumanizeResources.now;
                    }
                    else
                    {
                        return delta.Seconds == 1
                            ? HumanizeResources.a_second_ago
                            : string.Format(HumanizeResources.n_seconds_ago, delta.Seconds);
                    }
                }
            }
            else
            {
                var delta = dt - now;

                if (delta.Days > 0)
                {
                    return delta.Days == 1
                        ? HumanizeResources.one_day_from_now
                        : string.Format(HumanizeResources.n_days_from_now, delta.Days);
                }
                else if (delta.Hours > 0)
                {
                    return (delta.Hours == 1)
                        ? HumanizeResources.an_hour_from_now
                        : string.Format(HumanizeResources.n_hours_from_now, delta.Hours);
                }
                else if (delta.Minutes != 0)
                {
                    return delta.Minutes == 1
                        ? HumanizeResources.a_minute_from_now
                        : String.Format(HumanizeResources.n_minutes_from_now, delta.Minutes);
                }
                else
                {
                    if (delta.Seconds == 0)
                    {
                        return HumanizeResources.now;
                    }
                    else
                    {
                        return delta.Seconds == 1
                            ? HumanizeResources.a_second_from_now
                            : string.Format(HumanizeResources.n_seconds_from_now, delta.Seconds);
                    }
                }

            }
        }

        /// <summary>
        /// For date and time values shows how many seconds, minutes or hours ago.
        /// compared to current timestamp returns representing string.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="h2d">Delta hours from to switch from NaturalTime() to NaturalDay().</param>
        /// <returns></returns>
        public string NaturalDayOrTime(DateTime dt, int h2d)
        {
            var now = TimeMachine.Now;
            var delta = now - dt;

            if (Math.Abs(delta.TotalHours) <= Math.Abs(h2d))
                return NaturalTime(dt);
            else
                return NaturalDay(dt);
        }

    }
}
