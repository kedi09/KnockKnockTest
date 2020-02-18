using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KnockKnockTest.Controllers
{
    [ApiController]
    public class KnockKnockController : Controller
    {
        [HttpGet("api/Fibonacci")]
        public ActionResult<long> Fibonacci(long n)
        {
            try
            {
                if (n == 0)
                    return n;

                long a = 0, b = 1, c = 0;
                checked
                {
                    if (n > 0)
                    {
                        for (int i = 1; i < n; i++)
                        {
                            c = a + b;
                            a = b;
                            b = c;
                        }
                    }
                    else
                    {
                        for (int i = -1; i > n; i--)
                        {
                            c = a - b;
                            a = b;
                            b = c;
                        }
                    }
                }

                return b;
            }
            catch (OverflowException)
            {
                return BadRequest("");
            }
        }

        [HttpGet("api/ReverseWords")]
        public ActionResult<string> ReverseWords(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return Json(string.Empty);

            var reveresedSentence = new string(sentence.Reverse().ToArray());

            var reversedWords = string.Join(" ", reveresedSentence.Split(" ").Reverse());

            return Json(reversedWords);
        }

        [HttpGet("api/Token")]
        public ActionResult<string> Token()
        {
            return Ok(new Guid("6c4b3c9f-26f0-42f6-b1da-9918935b2536"));
        }

        [HttpGet("api/TriangleType")]
        public ActionResult<string> TriangleType(int a, int b, int c)
        {
            var isTriangle = a > 0 && b > 0 && c > 0;
            var sides = new long[] { a, b, c };
            isTriangle = isTriangle && sides[0] + sides[1] > sides[2] && sides[1] + sides[2] > sides[0] && sides[2] + sides[0] > sides[1];

            if (isTriangle)
            {
                if (a == b && a == c)
                {
                    return Json("Equilateral");
                }
                else if (a != b && a != c && b != c)
                {
                    return Json("Scalene");
                }
                else
                {
                    return Json("Isosceles");
                }
            }

            return Json("Error");
        }
    }
}