using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {
        static void Main(string[] args) {

            //var lines = File.ReadAllLines("sample.txt");
            //var we = new WordsExtractor(lines);
            //foreach (var word in we.Extract()) {
            //    Console.WriteLine(word);
            //}


            //var dict = new Dictionary<MonthDay, string> {
            //    {new MonthDay(3,5),"珊瑚の日" },
            //    {new MonthDay(8,4),"箸の日" },
            //    {new MonthDay(10,3),"登山の日" },
            //};

            //var md = new MonthDay(8,4);
            //var s = dict[md];
            //Console.WriteLine(s); 


            DuplicateKeySample();
        }
        static public void DuplicateKeySample() {
                // ディクショナリの初期化
                var dict = new Dictionary<string, List<string>>() {
               { "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
               { "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
            };

                // ディクショナリに追加
                var key = "EC";
                var value = "電子商取引";
                if (dict.ContainsKey(key)) {
                    dict[key].Add(value);
                } else {
                    dict[key] = new List<string> { value };
                }

                // ディクショナリの内容を列挙
                foreach (var item in dict) {
                    foreach (var term in item.Value) {
                        Console.WriteLine("{0} : {1}", item.Key, term);
                    }
                }
            }

           
        
    }
}


