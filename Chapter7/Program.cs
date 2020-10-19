using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
	class Abbreviations : IEnumerable<KeyValuePair<string, string>> {
		static void Main(string[] args) {
            string moji = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1_1(moji); //問題7.1.1
            Console.WriteLine();
            Exercise1_2(moji); //問題7.1.2
            Console.WriteLine();


            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            // インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names) {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}は見つかりません", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0} は見つかりません", japanese);
            else
                Console.WriteLine("「{0}」の略語は {1} です", japanese, abbreviation);
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach (var item in abbrs.FindAll("国際")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();

            //7-2-3
            //Countプロパティを呼び出して数を出力させる
            Console.WriteLine(abbrs.Count);
            //削除する
            Console.WriteLine(abbrs.Remove(abbreviation));
            //削除した時の数を出力させる
            Console.WriteLine(abbrs.Count);

            //7-2-4
            foreach (var item in abbrs.Where(x => x.Key.Length == 3)) {
                Console.WriteLine($"{item.Key}={item.Value}");
            }
        }
        #region 7.1.1

        static void Exercise1_1(string moji){
            var dict = new Dictionary<Char, int>();
            foreach (var c in moji) {
                var conversion = char.ToUpper(c);
                if ('A' <= conversion && conversion <= 'Z') {
                    if (dict.ContainsKey(conversion)) {
                        //既に登録済み
                        dict[conversion]++;
                    } else {
                        //未登録
                        dict[conversion] = 1;
                    }                   
                }
            }

            dict.OrderBy(x => x.Key).ToList().ForEach(x=> Console.WriteLine($"{x.Key}:{x.Value}"));

        }
        #endregion

        #region 7.1.2
        static void Exercise1_2(string moji) {
            var Sortdict = new SortedDictionary<Char, int>();
            foreach (var c in moji) {
                var conversion = char.ToUpper(c);
                if ('A' <= conversion && conversion <= 'Z') {
                    if (Sortdict.ContainsKey(conversion))
                        Sortdict[conversion]++;
                    else
                        Sortdict[conversion] = 1;
                }
            }
            foreach (var item in Sortdict) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }

        }
        #endregion

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return ((IEnumerable<KeyValuePair<string, string>>)_dict).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<KeyValuePair<string, string>>)_dict).GetEnumerator();
        }
        
    }
}

