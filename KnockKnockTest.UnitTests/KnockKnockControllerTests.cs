using KnockKnockTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace KnockKnockTest.UnitTests
{
    public class KnockKnockControllerTests
    {
        private readonly KnockKnockController knockKnockController;
        public KnockKnockControllerTests()
        {
            knockKnockController = new KnockKnockController();          
        }

        [Theory]
        [InlineData(22, 17711)]
        [InlineData(-22, -17711)]
        [InlineData(0, 0)]
        [InlineData(-1, 1)]
        public void FibonacciShouldReturnNthFibonacci(long input, long expectedOutcome)
        {
            var result = knockKnockController.Fibonacci(input);

            var actionResult = Assert.IsType<ActionResult<long>>(result);
            var returnValue = Assert.IsType<long>(actionResult.Value);

            Assert.Equal(expectedOutcome, returnValue);
        }

        [Theory]
        [InlineData("Reverse Words", "esreveR sdroW")]
        [InlineData("&%", "%&")]
        [InlineData(" ", "")]
        public void ReverseWordsShouldReverseWords(string input, string expectedOutcome)
        {
            var result = knockKnockController.ReverseWords(input);

            var actionResult = Assert.IsType<JsonResult>(result.Result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal(expectedOutcome, returnValue);
        }

        [Theory]
        [InlineData(-1,2,2)]
        [InlineData(6, 2, 2)]
        [InlineData(int.MaxValue, 2, 2)]
        public void TriangleTypeShouldValidateTriangleRules(int a, int b, int c)
        {
            var result = knockKnockController.TriangleType(a, b, c);

            var actionResult = Assert.IsType<JsonResult>(result.Result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Error", returnValue);
        }

        [Theory]
        [InlineData(2, 2, 3, "Isosceles")]
        [InlineData(3, 2, 4, "Scalene")]
        [InlineData(int.MaxValue, int.MaxValue, int.MaxValue, "Equilateral")]
        public void TriangleTypeShouldReturnTriangleType(int a, int b, int c, string expectedTriangleType)
        {
            var result = knockKnockController.TriangleType(a, b, c);

            var actionResult = Assert.IsType<JsonResult>(result.Result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal(expectedTriangleType, returnValue);
        }
    }
}
