using Chapter06;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
  
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4, };
            Console.WriteLine($"平均値:{numbers.Average()}");
            Console.WriteLine($"合計値:{numbers.Sum()}");
            Console.WriteLine($"最小値:{numbers.Where(s=> s>=0).Min()}");
            Console.WriteLine($"最大値:{numbers.Max()}");

            bool exists = numbers.Any(n => n % 7 == 0);

            var results = numbers.Where(n => n > 0).Take(5);
            foreach (var result in results) {
                Console.Write(result + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            var books = Books.GetBooks();
            Console.WriteLine($"本の平均価格:{books.Average(s=> s.Price)}");
            Console.WriteLine($"本の合計価格:{books.Sum(s => s.Price)}");
            Console.WriteLine($"本のページが最大:{books.Max(s => s.Pages)}");
            Console.WriteLine($"高価な本:{books.Max(s => s.Price)}");
            Console.WriteLine($"タイトルに「物語」がある冊数:{books.Count(s => s.Title.Contains("物語"))}");

            //600ページを超える書籍があるか？(Anyメソッド)
            Console.Write("600ページを超える書籍があるか？");
            Console.WriteLine(books.Any(n => n.Pages > 600) ? "ある" : "なし");

            //すべてが200ページ以上の書籍か?(Allメソッド)""
            Console.Write("すべてが200ページ以上の書籍か？");
            Console.WriteLine(books.All(n => n.Pages >= 200)? "ある" : "なし");

            //400ページを超える本は何冊目か?(FirstOrDefaultメソッド)
            var number = books.IndexOf(books.FirstOrDefault(x => x.Pages > 400));
            Console.WriteLine($"00ページを超える本は何冊目か?{number+1}冊目です。");

            //本の値段が400円以上のものを３冊表示
            var nums = books.Where(x => x.Price >= 400).Take(3);
            foreach (var num in nums) {
                Console.Write(num.Title + " ");
            }

        }
    }
}
