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
    public class HumanizeTests_de_DE : BaseHumanizeTests
    {
        protected override CultureInfo TestCultureInfo
        {
            get
            {
                return new CultureInfo("de-DE");
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
                    {1000000.123, "1.0 Millionen"},
                    {1200000.123, "1.2 Millionen"},
                    {1250000.123, "1.3 Millionen"},
                    {1290000, "1.3 Millionen"},
                    {1000000000, "1.0 Milliarden"}, 
                    {2000000000, "2.0 Milliarden"}, 
                    {6000000000000, "6.0 Billionen"},
                    {1300000000000000, "1.3 Billiarden"},
                    {3500000000000000000000d, "3.5 Trilliarden"},
                    {8100000000000000000000000000000000d, "8.1 Quintilliarden"},
                };
            }
        }

        protected override Dictionary<double, string> TestAPNumberData
        {
            get
            {
                return new Dictionary<double, string>
                {
                    {1.001, "eins"},
                    {2.222, "zwei"},
                    {3, "drei"},
                    {4, "vier"},
                    {5, "fünf"},
                    {6, "sechs"},
                    {7, "sieben"},
                    {8, "acht"},
                    {9, "neun"},
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
                    {today, "heute"},
                    {yesterday, "gestern"},
                    {tomorrow, "morgen"},
                    {someday, "12.10.2012"},
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
                    {now, "jetzt"},

                    {now.AddSeconds(-1), "vor eine Sekunde"},
                    {now.AddSeconds(-30), "vor 30 Sekunden"},
                    {now.AddMinutes(-1).AddSeconds(-30), "vor eine Minute"},
                    {now.AddMinutes(-2), "vor 2 Minuten"},
                    {now.AddHours(-1).AddMinutes(-30).AddSeconds(-30), "vor eine Stunde"},
                    {now.AddHours(-23).AddMinutes(-50).AddSeconds(-50), "vor 23 Stunden"},
                    {now.AddDays(-1), "vor ein Tag"},
                    {now.AddDays(-500), "vor 500 Tage"},

                    {now.AddSeconds(+1), "in eine Sekunde"},
                    {now.AddSeconds(+30), "in 30 Sekunden"},
                    {now.AddMinutes(+1).AddSeconds(+30), "in eine Minute"},
                    {now.AddMinutes(+2), "in 2 Minuten"},
                    {now.AddHours(+1).AddMinutes(+30).AddSeconds(+30), "in eine Stunde"},
                    {now.AddHours(+23).AddMinutes(+50).AddSeconds(+50), "in 23 Stunden"},
                    {now.AddDays(+1), "ein Tag ab jetzt"},
                    {now.AddDays(+500), "in 500 Tage"},
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
                    {now, "jetzt"},

                    {now.AddSeconds(-1), "vor eine Sekunde"},
                    {now.AddSeconds(-2), "vor 2 Sekunden"},
                    {now.AddSeconds(-30), "vor 30 Sekunden"},
                    {now.AddSeconds(-60), "vor eine Minute"},
                    {now.AddSeconds(-120), "vor 2 Minuten"},
                    {now.AddMinutes(-59), "vor 59 Minuten"},
                    {now.AddHours(-1), "vor eine Stunde"},
                    {now.AddHours(-2), "heute"},
                    {now.AddHours(-23), "gestern"},
                    {now.AddHours(-24), "gestern"},
                    {now.AddDays(-2), "20.09.2012"},

                    {now.AddSeconds(1), "in eine Sekunde"},
                    {now.AddSeconds(2), "in 2 Sekunden"},
                    {now.AddSeconds(30), "in 30 Sekunden"},
                    {now.AddSeconds(60), "in eine Minute"},
                    {now.AddSeconds(120), "in 2 Minuten"},
                    {now.AddMinutes(59), "in 59 Minuten"},
                    {now.AddHours(1), "in eine Stunde"},
                    {now.AddHours(2), "heute"},
                    {now.AddHours(23), "morgen"},
                    {now.AddHours(24), "morgen"},
                    {now.AddDays(2), "24.09.2012"},

                };
            }
        }

    }
}
