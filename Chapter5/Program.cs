using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5 {
    class Program {
        static void Main(string[] args) {
            //5-1
            //Console.WriteLine("-----5 - 1-----");

            //Console.Write("文字:");
            //var str1 = Console.ReadLine();
            //Console.Write("文字:");
            //var str2 = Console.ReadLine();

            //if (string.Compare(str1,str2,true)==0) {
            //    Console.WriteLine("等しい");
            //} else {
            //    Console.WriteLine("等しくない");
            //}

            //5-2
            //Console.WriteLine("-----5 - 2-----");

            //Console.Write("数字文字列:");
            //var line = Console.ReadLine();
            //int num; //変換後の数値格納
            //if(int.TryParse(line,out num)) {
            //    Console.WriteLine(num.ToString("#,#"));
            //} else {
            //    Console.WriteLine("数値文字列ではありません");
            //}

            //5-3
            var target = "Jackdaws love my big sphinx of quartz";

            //5-3-1
            Console.WriteLine("-----5 - 3 - 1-----");
            var count = target.Count(s => s.Equals(' '));
            Console.Write("空白の数:");
            Console.WriteLine(count);

            //5-3-2
            Console.WriteLine("-----5 - 3 - 2-----");
            Console.Write("文字:");
            var result = target.Replace("big", "small");
            Console.WriteLine(result);

            //5-3-3
            Console.WriteLine("-----5 - 3 - 3-----");
            Console.Write("単語の数:");
            string [] words = target.Split(' ');
            Console.WriteLine(words.Length);

            //5-3-4 
            Console.WriteLine("-----5 - 3 - 4-----");
            Console.Write("4文字以下の単語:");
            string[] cutwords = target.Split(' ');
            var lines = cutwords.Where(s => s.Length <= 4);
            foreach (var s in lines) {
                Console.WriteLine(s);
            }

            //5-3-5 
            Console.WriteLine("-----5 - 3 - 5-----");
            string[] linewords = target.Split(' ');

            var sb = new StringBuilder();
            foreach (var word in linewords) {
                sb.Append(word);
            }

            var text = sb.ToString();
            Console.WriteLine(text);


            //5-4-
            Console.WriteLine("----- 5 - 4 ------");
            var list = new List<string>();
            string stringline = "Novelist=谷﨑潤一郎;BestWork=春琴抄;Born=1886";
            //string[] cutstringline = stringline.Split(';');
            //list.Add(cutstringline[0].Replace("Novelist=","作家  :"));
            //list.Add(cutstringline[1].Replace("BestWork=", "代表作:"));
            //list.Add(cutstringline[2].Replace("Born=", "誕生日:"));

            //foreach (var item in list) {
            //    Console.WriteLine(item);
            //}

            foreach (var item in stringline.Split(';')) {
                var word = item.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(word[0]), word[1]);
            }
        }
        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家 ";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生日";
                default:
                    return "     ";
            }
        }
    }
}
