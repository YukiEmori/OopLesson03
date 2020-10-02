using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04 {

    class YearMonth {
        //4.1.1
        //プロパティ
        public int Year { get; private set; }
        public int Month { get; private set; }

        //コンストラクタ
        public YearMonth(int Year, int Month) {
            this.Year = Year;
            this.Month = Month;
        }

        //4.1.2
        public bool Is21Century
        {
            get {
                return 2001 <= Year && Year <= 2100;  //p109参照 
            }
        }
                


        //4.1.3
        public YearMonth AddOneMonth() {
            if(Month == 12) {
                return new YearMonth(Year + 1 , 1);
            } else {
                return new YearMonth(Year, Month + 1);
            }
            
        }

        //4.1.4
        public override string ToString() {
            return $"{Year}年{Month}月";
        }


    }
    
}
