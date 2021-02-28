using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorblueTechTask4;

namespace RazorblueTechTaskTests.Task4
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void FizzBuzzTestMethod()
        {
            List<string> expected = new List<string>();
            List<string> result = new List<string>();

            Enumerable.Range(1, 100).ToList()
                .ForEach(x =>
                {
                    expected.Add(FizzBuzzHelper(x));
                    result.Add(x.FizzBuzzValidation());
                });

            int i = 0;
            expected.ForEach(e =>
            {
                Assert.AreEqual(e, result[i]);
                i++;
            });
        }

        private string FizzBuzzHelper(int number)
        {
            return number % 3 == 0 && number % 5 == 0
                ? "FizzBuzz" : number % 5 == 0
                    ? "Buzz" : number % 3 == 0 
                        ? "Fizz" : $"{number}";
        }
    }
}
