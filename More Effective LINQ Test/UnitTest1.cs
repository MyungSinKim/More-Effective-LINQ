using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace More_Effective_LINQ_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SortByAgeDemo()
        {
            var players =
                "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            var c = players
                .Split(';')
                .Select(n => n.Split(','))
                .Select(n => new
                {
                    Name = n[0].Trim(),
                    Aniversario = DateTime.ParseExact(n[n.Length].Trim(), "d/M/yyyy", CultureInfo.CurrentUICulture)
                })
                .OrderByDescending(n => n.Aniversario)
                .Select(p => (DateTime.Today - p.Aniversario).TotalDays / 365.24);
        }

        [TestMethod]
        public void ExpandNumbers()
        {
            var numbers = "2,5,7-12,17-22";

            var r =
                numbers.Split(',')
                    .Select(n => n.Split('-'))
                    .Select(n => new { Primeiro = int.Parse(n.First()), Ultimo = int.Parse(n.Last()) })
                    .OrderBy(i => i.Primeiro)
                    .Select(i => Enumerable.Range(i.Primeiro, i.Ultimo - i.Primeiro + 1))
                    .SelectMany(i => i, (i, l) => l);
        }
    }
}
