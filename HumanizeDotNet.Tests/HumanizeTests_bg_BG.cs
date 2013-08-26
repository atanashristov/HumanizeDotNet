using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace HumanizeDotNet.Tests
{
    [TestFixture]
    public class HumanizeTests_bg_BG : BaseHumanizeTests
    {
        protected override CultureInfo TestCultureInfo
        {
            get
            {
                return new CultureInfo("bg-BG");
            }
        }

        protected override Dictionary<int, string> TestOrdinalData
        {
            get
            {
                return new Dictionary<int, string> 
                {
                    {1, "1."}, {2, "2."}, {3, "3."}, {4, "4."}, 
                    {11, "11."}, {12, "12."}, {13, "13."}, 
                    {101, "101."}, {102, "102."}, {103, "103."},
                    {111, "111."}, {112, "112."}, {113, "113."},
                };
            }
        }

        protected override Dictionary<double, string> TestIntWordData
        {
            get
            {
                return new Dictionary<double, string>
                {
                    {100, "100"},
                    {1000000.123, "1.0 милиона"},
                    {1200000.123, "1.2 милиона"},
                    {1250000.123, "1.3 милиона"},
                    {1290000, "1.3 милиона"},
                    {1000000000, "1.0 милиарда"}, 
                    {2000000000, "2.0 милиарда"}, 
                    {6000000000000, "6.0 трилиона"},
                    {1300000000000000, "1.3 квадрилиона"},
                    {3500000000000000000000d, "3.5 секстилиона"},
                    {8100000000000000000000000000000000d, "8.1 децилиона"},
                };
            }
        }

        protected override Dictionary<double, string> TestAPNumberData
        {
            get
            {
                return new Dictionary<double, string>
                {
                    {1.001, "едно"},
                    {2.222, "две"},
                    {3, "три"},
                    {4, "четири"},
                    {5, "пет"},
                    {6, "шест"},
                    {7, "седем"},
                    {8, "осем"},
                    {9, "девет"},
                    {9.5, "9.5"},
                    {9.5678956789, "9.5678956789"},
                };
            }
        }

        protected override Dictionary<DateTime, string> TestNaturalDayData
        {
            get
            {
                var today = TimeMachine.Now;
                var yesterday = today.AddDays(-1);
                var tomorrow = today.AddDays(+1);
                var someday = today.AddDays(20);

                var tests = new Dictionary<DateTime, string>
                {
                    {today, "днес"},
                    {yesterday, "вчера"},
                    {tomorrow, "утре"},
                    {someday, "12.10.2012 г."},
                };

                return tests;
            }
        }

        protected override Dictionary<DateTime, string> TestNaturalTimeData
        {
            get
            {
                var now = TimeMachine.Now;

                return new Dictionary<DateTime, string>()
                {
                    {now, "сега"},

                    {now.AddSeconds(-1), "преди една секунда"},
                    {now.AddSeconds(-30), "преди 30 секунди"},
                    {now.AddMinutes(-1).AddSeconds(-30), "преди една минута"},
                    {now.AddMinutes(-2), "преди 2 минути"},
                    {now.AddHours(-1).AddMinutes(-30).AddSeconds(-30), "преди един час"},
                    {now.AddHours(-23).AddMinutes(-50).AddSeconds(-50), "преди 23 часа"},
                    {now.AddDays(-1), "преди един ден"},
                    {now.AddDays(-500), "преди 500 дни"},

                    {now.AddSeconds(+1), "след една секунда"},
                    {now.AddSeconds(+30), "след 30 секунди"},
                    {now.AddMinutes(+1).AddSeconds(+30), "след една минута"},
                    {now.AddMinutes(+2), "след 2 минути"},
                    {now.AddHours(+1).AddMinutes(+30).AddSeconds(+30), "след един час"},
                    {now.AddHours(+23).AddMinutes(+50).AddSeconds(+50), "след 23 часа"},
                    {now.AddDays(+1), "след един ден"},
                    {now.AddDays(+500), "след 500 дни"},
                };
            }
        }

        protected override Dictionary<DateTime, string> TestNaturalDayOrTimeData
        {
            get
            {
                var now = TimeMachine.Now;

                return new Dictionary<DateTime, string>
                {
                    {now, "сега"},

                    {now.AddSeconds(-1), "преди една секунда"},
                    {now.AddSeconds(-2), "преди 2 секунди"},
                    {now.AddSeconds(-30), "преди 30 секунди"},
                    {now.AddSeconds(-60), "преди една минута"},
                    {now.AddSeconds(-120), "преди 2 минути"},
                    {now.AddMinutes(-59), "преди 59 минути"},
                    {now.AddHours(-1), "преди един час"},
                    {now.AddHours(-2), "днес"},
                    {now.AddHours(-23), "вчера"},
                    {now.AddHours(-24), "вчера"},
                    {now.AddDays(-2), "20.9.2012 г."},

                    {now.AddSeconds(1), "след една секунда"},
                    {now.AddSeconds(2), "след 2 секунди"},
                    {now.AddSeconds(30), "след 30 секунди"},
                    {now.AddSeconds(60), "след една минута"},
                    {now.AddSeconds(120), "след 2 минути"},
                    {now.AddMinutes(59), "след 59 минути"},
                    {now.AddHours(1), "след един час"},
                    {now.AddHours(2), "днес"},
                    {now.AddHours(23), "утре"},
                    {now.AddHours(24), "утре"},
                    {now.AddDays(2), "24.9.2012 г."},

                };
            }
        }

    }
}
