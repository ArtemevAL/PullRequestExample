using System.Drawing;
using System.Linq;

namespace PullRequestExamples
{
    internal class Program
    {
        public static Figure[] AllFigures = new Figure[]
        {
            new Figure(true, false, 10),
            new Figure(true, false, 15),
            new Figure(false, true, 5),
            new Figure(false, false, null)
        };

        static void Main(string[] args)
        {
            var figures = GetFigures(true, null, 10);
            Console.WriteLine($"Result: [{string.Join<Figure>("; ", figures)}]");
        }

        public static Figure[] GetFigures(
            bool? isWaitable,
            bool? isCheckable,
            int? minHeight
            )
        {
            IEnumerable<Figure> filteredFigures = AllFigures;
            if (isWaitable.HasValue)
            {
                filteredFigures = filteredFigures.Where(figure => figure.IsWaitable == isWaitable.Value);
            }
            if (isCheckable.HasValue)
            {
                filteredFigures = filteredFigures.Where(figure => figure.IsCheckable == isCheckable.Value);
            }
            if(minHeight.HasValue)
            {
                filteredFigures = filteredFigures.Where(figure => figure.Height >= minHeight.Value);
            }
            return filteredFigures.ToArray();
        }


        public class Figure
        {
            public bool IsWaitable { get; set; }
            public bool IsCheckable { get; set; }
            public int? Height { get; set; }

            public Figure()
            { }

            public Figure(bool isWaitable, bool isCheckable, int? height)
            {
                IsWaitable = isWaitable;
                IsCheckable = isCheckable;
                Height = height;
            }

            public override string ToString()
            {
                return $"{IsWaitable}:{IsCheckable}:{Height}";
            }
        }
    }
}