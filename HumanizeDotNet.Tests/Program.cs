using HumanizeDotNet.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HumanizeDotNet;
using System.Globalization;
using System.Threading;

namespace HumanizeDotNet.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            DoDemo(new CultureInfo("en-US"));
            DoDemo(new CultureInfo("de-DE"));
            DoDemo(new CultureInfo("bg-BG"));

            var tests = new HumanizeTests_en_US();
            tests.SetUp();
            tests.TestAPNumber();
            tests.TestNaturalDayOrTime();

            Console.WriteLine("<Enter>");
            Console.ReadLine();
        }


        public static void DoDemo(CultureInfo ci)
        {
            var originalCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = ci;
            double i = 1;

            Console.WriteLine("===================[Begin {0} demo]=====================", ci.Name);

            Console.Write(i++.Ordinal());
            Console.WriteLine("NaturalDay: {0}, {1}, {2}, {3}, {4}",
                DateTime.Now.AddDays(-2).NaturalDay(),
                DateTime.Now.AddDays(-1).NaturalDay(),
                DateTime.Now.NaturalDay(),
                DateTime.Now.AddDays(1).NaturalDay(),
                DateTime.Now.AddDays(2).NaturalDay());

            Console.Write(i++.Ordinal());
            Console.WriteLine("NaturalTime: {0}, {1}, {2}, {3}",
                DateTime.Now.AddDays(-2).NaturalTime(),
                DateTime.Now.AddDays(-1).NaturalTime(),
                DateTime.Now.AddHours(-2).NaturalTime(),
                DateTime.Now.AddHours(-1).NaturalTime());

            Console.Write(i++.Ordinal());
            Console.WriteLine("NaturalTime: {0}, {1}, {2}, {3}, {4}",
                DateTime.Now.AddMinutes(-35).NaturalTime(),
                DateTime.Now.AddMinutes(-2).NaturalTime(),
                DateTime.Now.AddMinutes(-1).NaturalTime(),
                DateTime.Now.AddSeconds(-2).NaturalTime(),
                DateTime.Now.AddSeconds(-1).NaturalTime());

            Console.Write(i++.Ordinal());
            Console.WriteLine("NaturalDayOrTime: {0}, {1}, {2}, {3}",
                DateTime.Now.AddDays(-2).NaturalDayOrTime(1),
                DateTime.Now.AddDays(-1).NaturalDayOrTime(1),
                DateTime.Now.AddHours(-2).NaturalDayOrTime(1),
                DateTime.Now.AddHours(-1).NaturalDayOrTime(1));

            Console.Write(i++.Ordinal());
            Console.WriteLine("NaturalDayOrTime: {0}, {1}, {2}, {3}, {4}",
                DateTime.Now.AddMinutes(-35).NaturalDayOrTime(1),
                DateTime.Now.AddMinutes(-2).NaturalDayOrTime(1),
                DateTime.Now.AddMinutes(-1).NaturalDayOrTime(1),
                DateTime.Now.AddSeconds(-2).NaturalDayOrTime(1),
                DateTime.Now.AddSeconds(-1).NaturalDayOrTime(1));

            Console.WriteLine("===================[End {0} demno]=====================", ci.Name);

            Thread.CurrentThread.CurrentUICulture = originalCultureInfo;
        }
    }
}
