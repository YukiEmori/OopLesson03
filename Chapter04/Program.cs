using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04 {
    class Program {
        static void Main(string[] args) {
            #region null合体演算子
            string code = "12345";

            var message = GetMessage(code) ?? DefaultMessage();
            Console.WriteLine(message);
        }

        //スタブ
        private static object DefaultMessage() {
            return "DefaultMessage";
        }

        //スタブ
        private static object GetMessage(string code) {
            return code;
            #endregion

            #region null条件演算子

            #endregion
        }
    }
}
