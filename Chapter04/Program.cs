using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04 {
    class Program {
        static void Main(string[] args) {
            //4-2-1
            var YearMonthArray = new YearMonth[] {
                new YearMonth(2000,1),
                new YearMonth(2001,12),
                new YearMonth(2020,11),
                new YearMonth(2100,3),
                new YearMonth(2101,12),
            };

            //4-2-2
            Console.WriteLine("-----4-2-2-----");
            foreach (var array in YearMonthArray) {
                Console.WriteLine(array);
            }
            Console.WriteLine();

            //4-2-4
            Console.WriteLine("-----4-2-4-----");
            var Is21 = FindFirst21C(YearMonthArray);
            if (Is21 == null) 
                Console.WriteLine("21世紀のデータはありません");
            else
                Console.WriteLine(Is21);
            Console.WriteLine();

            //4-2-5
            Console.WriteLine("-----4-2-5-----");
            var arrays = YearMonthArray.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in arrays) {
                Console.WriteLine(ym);
            }

        }

        //4-2-3
        static YearMonth FindFirst21C(YearMonth[] yms) {
            foreach (var array in yms) {
                if (array.Is21Century) {
                    return array;
                }
            }
            return null;
        }


    }
    
}

