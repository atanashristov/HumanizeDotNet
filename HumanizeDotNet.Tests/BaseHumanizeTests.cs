using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace HumanizeDotNet.Tests
{
    public abstract class BaseHumanizeTests
    {
        private class TimeMachineStub : TimeMachine
        {
            private readonly DateTime _dt = new DateTime(2012, 09, 22, 14, 51, 05);
            public override DateTime Now { get { return new DateTime(_dt.Ticks); } }
        }

        protected ITimeMachine TimeMachine { get; set; }
        protected Humanize Humanize { get; set; }
        private CultureInfo OriginalCultureInfo { get; set; }

        [SetUp]
        public void SetUp()
        {
            TimeMachine = new TimeMachineStub();
            Humanize = new Humanize(TimeMachine);
            OriginalCultureInfo = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = TestCultureInfo;
        }

        [TearDown]
        public void TearDown()
        {
            Humanize = null;
            Thread.CurrentThread.CurrentUICulture = OriginalCultureInfo;
        }


        protected abstract CultureInfo TestCultureInfo { get; }
        protected abstract Dictionary<int, string> TestOrdinalData { get; }
        protected abstract Dictionary<double, string> TestIntWordData { get; }
        protected abstract Dictionary<double, string> TestAPNumberData { get; }
        protected abstract Dictionary<DateTime, string> TestNaturalDayData { get; }
        protected abstract Dictionary<DateTime, string> TestNaturalTimeData { get; }
        protected abstract Dictionary<DateTime, string> TestNaturalDayOrTimeData { get; }

        
        [Test]
        public void TestOrdinal()
        {
            var tests = TestOrdinalData;
            foreach (var test in tests)
            {
                Console.Write("Ordinal({0}) == \"{1}\"?", test.Key, test.Value);
                Assert.AreEqual(test.Value, Humanize.Ordinal(test.Key));
                Console.WriteLine(" OK.");
            }
        }

        [Test]
        public void TestIntWord()
        {
            var tests = TestIntWordData;
            foreach (var test in tests)
            {
                Console.Write("IntWord({0}) == \"{1}\"?", test.Key, test.Value);
                Assert.AreEqual(test.Value, Humanize.IntWord(test.Key));
                Console.WriteLine(" OK.");
            }
        }

        [Test]
        public void TestAPNumber()
        {
            var tests = TestAPNumberData;
            foreach (var test in tests)
            {
                Console.Write("APNumber({0} == \"{1}\"?", test.Key, test.Value);
                Assert.AreEqual(test.Value, Humanize.APNumber(test.Key));
                Console.WriteLine(" OK.");
            }
        }

        [Test]
        public void TestNaturalDay()
        {
            var tests = TestNaturalDayData;
            foreach (var test in tests)
            {
                Console.Write("NaturalDay(\"{0}\") == \"{1}\"?", test.Key, test.Value);
                Assert.AreEqual(test.Value, Humanize.NaturalDay(test.Key));
                Console.WriteLine(" OK.");
            }
        }

        [Test]
        public void TestNaturalTime()
        {
            var tests = TestNaturalTimeData;
            foreach (var test in tests)
            {
                Console.Write("NaturalTime(\"{0}\") == \"{1}\"?", test.Key, test.Value);
                Assert.AreEqual(test.Value, Humanize.NaturalTime(test.Key));
                Console.WriteLine(" OK.");
            }
        }

        [Test]
        public void TestNaturalDayOrTime()
        {
            Console.WriteLine("Now is: {0}", TimeMachine.Now.ToString());

            var tests = TestNaturalDayOrTimeData;
            foreach (var test in tests)
            {
                Console.Write("NaturalTime(\"{0}\") == \"{1}\"?", test.Key, test.Value);
                Assert.AreEqual(test.Value, Humanize.NaturalDayOrTime(test.Key, 1));
                Console.WriteLine(" OK.");
            }
        }


    }
}
