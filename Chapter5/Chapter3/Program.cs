using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {

        static void Main(string[] args)
        {
            #region 5文字以下の国
            /* var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            };

            IEnumerable<string> query = names.Where(s => s.Length <= 5);
            foreach (string s in query) {
                Console.WriteLine(s);
            }*/
            #endregion

            #region 大文字に変換(すべて出力)
            /* var list = new List<string>
            {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            };

             //list.ForEach(s => Console.WriteLine(s));

              list.ConvertAll(s => s.ToUpper()).ForEach(s => Console.WriteLine(s));*/
            #endregion

            #region 遅延実行と即時実行
            /* var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            };
            //遅延実行
            var query = names.Where(s => s.Length <= 5);
            //即時実行
            //var query = names.Where(s => s.Length <= 5).ToList;
            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");

            names[0] = "Osaka";
            foreach (var item in query) {
                Console.WriteLine(item);
                //本当にデータが必要な時にクエリが実行される
            }*/
            #endregion

            #region 問題3-1-1 p99
            var numbers = new List<int> {
                12,87,94,14,53,20,40,35,76,91,31,17,48,
            };

            Console.WriteLine("\n-----3.1.1-----");

            var exists = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);
            Console.WriteLine(exists);

            #endregion

            #region 問題3-1-2 p99

            Console.WriteLine("\n-----3.1.2-----");

            numbers.ConvertAll(s => s / 2.0).ForEach(s => Console.WriteLine(s));

            #endregion

            #region 問題3-1-3 p99

            Console.WriteLine("\n-----3.1.3-----");

            var query = numbers.Where(s => s >= 50);
            foreach (int n in query) {
                Console.WriteLine(n);
            }

            #endregion

            #region 問題3-1-4 p99

            Console.WriteLine("\n-----3.1.4-----");

            List<int> lists = numbers.Select(s => s * 2).ToList();

            foreach (int n in lists) {
                Console.WriteLine(n);
            }

            #endregion

            #region 問題3-2-1 p100
            var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            };

            Console.WriteLine("\n-----3.2.1-----");

            Console.Write("都市名をを入力してください:");
            var line = Console.ReadLine();
            while (line.Length > 0) {
                var index = names.FindIndex(s => s == line);
                Console.WriteLine($"{index}番目");
                line = Console.ReadLine();

            }

            #endregion

            #region 問題3-2-2 p100

            Console.WriteLine("\n-----3.2.2-----");

            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);

            #endregion

            #region 問題3-2-3 p100

            Console.WriteLine("\n-----3.2.3-----");

             var selected = names.Where(s => s.Contains('o')).ToArray();

            foreach (var lines in selected) {
                Console.WriteLine(lines);
            }

            #endregion

            #region 問題3-2-4 p100

            Console.WriteLine("\n-----3.2.4-----");

            //var length = names.Where(s => s.Contains('B')).Select(s=> s.Length);

            var length = from s in names
                         where s.Contains('B')
                         select s.Length;
            foreach (int s in length) {
                Console.WriteLine(s);
            }

            #endregion

        }
    }
}
