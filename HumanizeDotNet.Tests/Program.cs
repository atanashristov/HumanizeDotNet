using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanizeDotNet.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new HumanizeTests();
            tests.SetUp();
            tests.TestNaturalTime();
        }
    }
}
