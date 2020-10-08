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
            //整数の例
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24, };

            var strings = numbers.Select(n => n.ToString("0000")).Distinct().ToArray();
            foreach (var str in strings) {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            numbers.Select(n => n.ToString("0000")).Distinct().ToList().ForEach(s=> Console.Write(s + " "));


            //並べ替え
            Console.WriteLine();
            var sortedNumbers = numbers.OrderBy(n => n);
            foreach (var nums in sortedNumbers) {
                Console.Write(nums + " ");
            }
            
            //文字列の例
            Console.WriteLine("\n\n----------");
            var words = new List<string> {
                "Microsoft","Apple","Google","Oracle","Facebook", 
            };
            //小文字にする ToArrya　=　即時実行
            var lower = words.Select(name => name.ToLower().ToArray());


            //オブジェクトの例
            Console.WriteLine("\n\n----------");
            var books = Books.GetBooks();
            //タイトルリスト
            var titles = books.Select(name => name.Title);

            foreach (var title in titles) {
                Console.Write(title + " ");
            }

            //ページ数の多い順に並べかえ(または金額の高い順)
            Console.WriteLine();
            Console.Write("ページ数の多い順:");
            books.OrderByDescending(n => n.Pages).Take(3).ToList().ForEach(x=> Console.Write(x.Pages + " "));
            Console.WriteLine();
            Console.Write("金額の高い順:");
            books.OrderByDescending(n => n.Price).ToList().ForEach(x => Console.Write(x.Price + " "));
        }
    }
}
