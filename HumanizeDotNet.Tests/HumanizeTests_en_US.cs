using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HumanizeDotNet.Tests
{
    [TestFixture]
    public class HumanizeTests_en_US : BaseHumanizeTests
    {
        protected override CultureInfo TestCultureInfo
        {
            get
            {
                return new CultureInfo("en-US");
            }
        }

        protected override Dictionary<int, string> TestOrdinalData
        {
            get
            {
                return new Dictionary<int, string> 
                {
                    {1, "1st"}, {2, "2nd"}, {3, "3rd"}, {4, "4th"}, 
                    {11, "11th"}, {12, "12th"}, {13, "13th"}, 
                    {101, "101st"}, {102, "102nd"}, {103, "103rd"},
                    {111, "111th"}, {112, "112th"}, {113, "113th"},
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
                    {1000000.123, "1.0 million"},
                    {1200000.123, "1.2 million"},
                    {1250000.123, "1.3 million"},
                    {1290000, "1.3 million"},
                    {1000000000, "1.0 billion"}, 
                    {2000000000, "2.0 billion"}, 
                    {6000000000000, "6.0 trillion"},
                    {1300000000000000, "1.3 quadrillion"},
                    {3500000000000000000000d, "3.5 sextillion"},
                    {8100000000000000000000000000000000d, "8.1 decillion"},
                };
            }
        }

        protected override Dictionary<double, string> TestAPNumberData
        {
            get
            {
                return new Dictionary<double, string>
                {
                    {1.001, "one"},
                    {2.222, "two"},
                    {3, "three"},
                    {4, "four"},
                    {5, "five"},
                    {6, "six"},
                    {7, "seven"},
                    {8, "eight"},
                    {9, "nine"},
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
                    {today, "today"},
                    {yesterday, "yesterday"},
                    {tomorrow, "tomorrow"},
                    {someday, "10/12/2012"},
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
                    {now, "now"},

                    {now.AddSeconds(-1), "a second ago"},
                    {now.AddSeconds(-30), "30 seconds ago"},
                    {now.AddMinutes(-1).AddSeconds(-30), "a minute ago"},
                    {now.AddMinutes(-2), "2 minutes ago"},
                    {now.AddHours(-1).AddMinutes(-30).AddSeconds(-30), "an hour ago"},
                    {now.AddHours(-23).AddMinutes(-50).AddSeconds(-50), "23 hours ago"},
                    {now.AddDays(-1), "1 day ago"},
                    {now.AddDays(-500), "500 days ago"},

                    {now.AddSeconds(+1), "a second from now"},
                    {now.AddSeconds(+30), "30 seconds from now"},
                    {now.AddMinutes(+1).AddSeconds(+30), "a minute from now"},
                    {now.AddMinutes(+2), "2 minutes from now"},
                    {now.AddHours(+1).AddMinutes(+30).AddSeconds(+30), "an hour from now"},
                    {now.AddHours(+23).AddMinutes(+50).AddSeconds(+50), "23 hours from now"},
                    {now.AddDays(+1), "1 day from now"},
                    {now.AddDays(+500), "500 days from now"},
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
                    {now, "now"},

                    {now.AddSeconds(-1), "a second ago"},
                    {now.AddSeconds(-2), "2 seconds ago"},
                    {now.AddSeconds(-30), "30 seconds ago"},
                    {now.AddSeconds(-60), "a minute ago"},
                    {now.AddSeconds(-120), "2 minutes ago"},
                    {now.AddMinutes(-59), "59 minutes ago"},
                    {now.AddHours(-1), "an hour ago"},
                    {now.AddHours(-2), "today"},
                    {now.AddHours(-23), "yesterday"},
                    {now.AddHours(-24), "yesterday"},
                    {now.AddDays(-2), "9/20/2012"},

                    {now.AddSeconds(1), "a second from now"},
                    {now.AddSeconds(2), "2 seconds from now"},
                    {now.AddSeconds(30), "30 seconds from now"},
                    {now.AddSeconds(60), "a minute from now"},
                    {now.AddSeconds(120), "2 minutes from now"},
                    {now.AddMinutes(59), "59 minutes from now"},
                    {now.AddHours(1), "an hour from now"},
                    {now.AddHours(2), "today"},
                    {now.AddHours(23), "tomorrow"},
                    {now.AddHours(24), "tomorrow"},
                    {now.AddDays(2), "9/24/2012"},

                };
            }
        }

    }
}
