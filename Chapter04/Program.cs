using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04 {
    class Program {
        static void Main(string[] args) {
            #region null合体演算子
            //    string code = "12345";

            //    var message = GetMessage(code) ?? DefaultMessage();
            //    Console.WriteLine(message);
            //}

            ////スタブ
            //private static object DefaultMessage() {
            //    return "DefaultMessage";
            //}

            ////スタブ
            //private static object GetMessage(string code) {
            //    return code;
            #endregion

            #region null条件演算子
            Console.WriteLine(GetProdcut());
            #endregion

        }
        private static string  GetProdcut() {
            Sale sale = new Sale() {
                ShopName = "pet store",
                Amount = 10000,
                Product = "food",
            };
            sale = null;
            return sale?.Product;
        }
    }

    class Sale {
        //店舗名
        public string ShopName { get; set; }
        //売上高
        public int Amount { get; set; }
        public string Product { get; set; }
    }
}
