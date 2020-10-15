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
            
            var numbers = new int[] { 5,10,17,9,3,21,10,40,21,3,35 };

            //6-1-1
            Console.WriteLine("\n6-1-1");
            var max = numbers.Max(n => n);
            Console.WriteLine($"最大値:{max}");

            //6-1-2
            Console.WriteLine("\n6-1-2");
            var index = numbers.Length - 2;
;            foreach (var number in numbers.Skip(index)) {
                Console.WriteLine(number);
            }
            //6-1-3
            Console.WriteLine("\n6-1-3");
            var str = numbers.Select(x=> x.ToString());
            foreach (var n in str) {
                Console.Write(n + " ");
            }
            //6-1-4
            Console.WriteLine("\n\n6-1-4");
            var num = numbers.OrderBy(x => x).Take(3);
            foreach (var n in num) {
                Console.Write(n + " ");
            }
            //6-1-5
            Console.WriteLine("\n\n6-1-5");
            var count = numbers.Distinct().Where(x=> x>10).Count();
            Console.WriteLine(count);

            //6-2
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識[#C", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            //6-2-1
            Console.WriteLine("\n6-2-1");
            var titles = books.Where(x => x.Title.Equals("ワンダフル・C#ライフ"));
            foreach (var item in titles) {
                Console.WriteLine($"価格:{item.Price}　ページ数:{item.Pages}");
            }
            //6-2-2
            Console.WriteLine("\n6-2-2");
            var counts = books.Where(x => x.Title.Contains("C#")).Count();
            Console.WriteLine(counts);
            //6-2-3
            Console.WriteLine("\n6-2-3");
            var avgpage = books.Where(x => x.Title.Contains("C#")).Average(x=> x.Pages);
            Console.WriteLine(avgpage);
            //6-2-4
            Console.WriteLine("\n6-2-4");
            var title = books.FirstOrDefault(x => x.Price >= 4000);
            if (title != null) {
                Console.WriteLine(title.Title);
            }
            //6-2-5
            Console.WriteLine("\n6-2-5");
            var maxpage = books.Where(x => x.Price < 4000).Max(x=> x.Pages);
            Console.WriteLine(maxpage);

            //6-2-6
            Console.WriteLine("\n6-2-6");
            var sort = books.Where(x => x.Pages >= 400).OrderByDescending(x=> x.Price);
            foreach (var item in sort) {
                Console.WriteLine($"タイトル:{item.Title} 価格:{item.Price}");
            }
            //6-2-7
            Console.WriteLine("\n6-2-7");
            var titless = books.Where(x => x.Title.Contains("C#") && x.Pages <= 500);
            foreach (var item in titless) {
                Console.WriteLine(item.Title);
            }

            //すべての書籍から[C#]の文字がいくつあるかをカウントする
            int titlecount = 0;

            foreach (var book in books.Where(b=> b.Title.Contains("C#"))) {
                for (int i = 0; i < book.Title.Length - 1; i++) {
                    if((book.Title[i] == 'C') && (book.Title[i+1]== '#')) {
                        titlecount++;
                    }
                }
            }
            Console.WriteLine($"文字列[C#]の個数は{titlecount}です");



        }
    }
}
