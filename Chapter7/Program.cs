using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
	class Program {
		static void Main(string[] args) {

			string n = "";
			var dict = new Dictionary<string, List<string>>() {
				//{ "PC", new List<string> { "パーソナル コンピュータ", "プログラム カウンタ", } },
				//{ "CD", new List<string> { "コンパクト ディスク", "キャッシュ ディスペンサー", } },
			};

			Console.WriteLine("**********************\n* 辞書登録プログラム *\n**********************");
			do {
				Console.WriteLine("1.登録 2.内容表示 3.終了");
				Console.Write(">");
				n = Console.ReadLine();
				DuplicateKeySample();
				Console.WriteLine();
				Console.WriteLine();
			}
			while (n == "1" || n == "2");

			void DuplicateKeySample() {
				// ディクショナリに追加
				if (n == "1") {
					Console.Write("KEYを入力:");
					var key = Console.ReadLine();
					Console.Write("VALUEを入力:");
					var value = Console.ReadLine();
					Console.WriteLine("登録しました!");
					if (dict.ContainsKey(key)) {
						dict[key].Add(value);
					} else {
						dict[key] = new List<string> { value };
					}
				}

				// ディクショナリの内容を列挙
				if (n == "2") {
					foreach (var item in dict) {
						foreach (var term in item.Value) {
							Console.WriteLine("{0} : {1}", item.Key, term);
						}
					}
				}
			}

		}

	}
}

