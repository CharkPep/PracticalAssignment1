using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tests
{
    [TestClass()]
    public class TaskTests
    {
        [TestMethod()]
        public void GetMedianTriangleTest_side10()
        {
            var expected = new List<double>() { Math.Round(8.660254037844386, 9), Math.Round(8.660254037844386, 9), Math.Round(8.660254037844386, 9) };
            var actual = Task.Get_median_of_triangle(10.0, 10.0, 10.0);
            actual[0] = Math.Round(actual[0], 9);
            actual[1] = Math.Round(actual[1], 9);
            actual[2] = Math.Round(actual[2], 9);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetMedianTriangleTest_side10_side12_side13()
        {
            var expected = new List<double>() { Math.Round(8.10864, 5), Math.Round(11.24722, 5), Math.Round(12.62933, 5) };
            var actual = Task.Get_median_of_triangle(10.0, 12.0, 15.0);
            actual[0] = Math.Round(actual[0], 5);
            actual[1] = Math.Round(actual[1], 5);
            actual[2] = Math.Round(actual[2], 5);
            Debug.WriteLine($"actual[0]: {actual[0]}, actual[1]: {actual[1]}, actual[2]: {actual[2]}");
            Debug.WriteLine($"expected[0]: {expected[0]}, expected[1]: {expected[1]}, expected[2]: {expected[2]}");
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetMedianTriangleTestDoestExist()
        {
            var expected = new List<double>() { -1, -1, -1 };
            var actual = Task.Get_median_of_triangle(10.0, 9.0, 20.0);
            if (actual[0] != -1 || actual[1] != -1 || actual[2] != -1)
            {
                Assert.Fail();
            }
            actual = Task.Get_median_of_triangle(9.0, 20.0, 10.0);
            if (actual[0] != -1 || actual[1] != -1 || actual[2] != -1)
            {
                Assert.Fail();
            }
            actual = Task.Get_median_of_triangle(20.0, 9.0, 10.0);
            if (actual[0] != -1 || actual[1] != -1 || actual[2] != -1)
            {
                Assert.Fail();
            }
            return;
        }
        [TestMethod()]
        public void Get_function_value10()
        {
            var actual = Task.Get_function_value(10.0);
            var expected = 5.0 * Math.Sqrt(10.0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Get_function_value5()
        {
            try { 
                var actual = Task.Get_function_value(5.0);
            }
            catch (Exception ex)
            {
                return;
            }
            Assert.Fail();
        }
        [TestMethod()]
        public void Get_function_value2()
        {
            var actual = Task.Get_function_value(2.0);
            Assert.AreEqual(actual, 1/2.0);
        }
        [TestMethod()]
        public void Get_function_value0()
        {
            var actual = Task.Get_function_value(0.0);
            Assert.AreEqual(actual, 0);
        }
        [TestMethod()]
        public void Get_function_valueNeg4()
        {
            var actual = Task.Get_function_value(-4.0);
            Assert.AreEqual(actual, -4.0*-4.0);
        }
        [TestMethod()]
        public void Get_function_valueNeg10()
        {
            var actual = Task.Get_function_value(-10.0);
            Assert.AreEqual(actual, 10.0*-10.0);
        }
        [TestMethod()]
        public void GetSeries100_10()
        {
            var actual = Task.GetSeries(100, 10.0);
            Assert.AreEqual(Math.Round(actual,5), 1.15129);
        }
    }
}