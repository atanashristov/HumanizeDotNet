using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string[] suffixes = {"th", "st", "nd", "rd", "th", "th", "th", "th", "th", "th"};

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
                    {6, "million"},
                    {9, "billion"},
                    {12, "trillion"},
                    {15, "quadrillion"},
                    {18, "quintillion"},
                    {21, "sextillion"},
                    {24, "septillion"},
                    {27, "octillion"},
                    {30, "nonillion"},
                    {33, "decillion"},
                    {100, "googol"},
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
                return new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }[(int)number - 1].ToString();
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
            TimeSpan ts = dt - now;

            if (ts.TotalDays == -1)
                return "yesterday";
            if (ts.TotalDays == 1)
                return "tomorrow";
            if (ts.TotalDays == 0)
                return "today";

            return dt.ToShortDateString();
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
                        ? "1 day ago"
                        : string.Format("{0} days ago", delta.Days);
                }
                else if (delta.Hours > 0)
                {
                    return (delta.Hours == 1)
                        ? "an hour ago"
                        : string.Format("{0} hours ago", delta.Hours);
                }
                else if (delta.Minutes != 0)
                {
                    return delta.Minutes == 1
                        ? "a minute ago"
                        : String.Format("{0} minutes ago", delta.Minutes);
                }
                else
                {
                    if (delta.Seconds == 0)
                    {
                        return "now";
                    }
                    else
                    {
                        return delta.Seconds == 1
                            ? "a second ago"
                            : string.Format("{0} seconds ago", delta.Seconds);
                    }
                }
            }
            else
            {
                var delta = dt - now;

                if (delta.Days > 0)
                {
                    return delta.Days == 1
                        ? "1 day from now"
                        : string.Format("{0} days from now", delta.Days);
                }
                else if (delta.Hours > 0)
                {
                    return (delta.Hours == 1)
                        ? "an hour from now"
                        : string.Format("{0} hours from now", delta.Hours);
                }
                else if (delta.Minutes != 0)
                {
                    return delta.Minutes == 1
                        ? "a minute from now"
                        : String.Format("{0} minutes from now", delta.Minutes);
                }
                else
                {
                    if (delta.Seconds == 0)
                    {
                        return "now";
                    }
                    else
                    {
                        return delta.Seconds == 1
                            ? "a second from now"
                            : string.Format("{0} seconds from now", delta.Seconds);
                    }
                }

            }
        }
    }
}
