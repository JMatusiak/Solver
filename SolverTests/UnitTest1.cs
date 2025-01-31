using System;
using Xunit;
using QuadraticEquation;

namespace QuadraticEquationTests
{
    public class EquationSolverTests
    {
        [Theory]
        [InlineData(1, 0, 1)]
        public void Test_NoRealRoots(double a, double b, double c)
        {
            var result = EquationSolver.ComputeRoots(a, b, c);
            Assert.Empty(result.Roots);
            Assert.Equal("Brak rzeczywistych pierwiastków.", result.Message);
        }

        [Theory]
        [InlineData(1, -2, 1)]
        public void Test_OneRealRoot(double a, double b, double c)
        {
            var result = EquationSolver.ComputeRoots(a, b, c);
            Assert.Single(result.Roots);
            Assert.Equal("Jedno rozwiązanie rzeczywiste.", result.Message);
            Assert.Equal(1, result.Roots[0], 5);
        }

        [Theory]
        [InlineData(1, -3, 2)] 
        public void Test_TwoRealRoots(double a, double b, double c)
        {
            var result = EquationSolver.ComputeRoots(a, b, c);
            Assert.Equal(2, result.Roots.Length);
            Assert.Equal("Dwa rozwiązania rzeczywiste.", result.Message);
            Assert.Contains(2, result.Roots);
            Assert.Contains(1, result.Roots);
        }

        [Fact]
        public void Test_InvalidInput()
        {
            Assert.Throws<ArgumentException>(() => EquationSolver.ComputeRoots(0, 1, 1));
        }
    }
}
