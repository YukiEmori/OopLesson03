using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SendMailApp {
    class Config {
        public string Smtp { get; set; }    //SMTPサーバ
        public string MailAddres { get; set; }  //自メールアドレス(送信元)
        public string PassWord { get; set; }    //パスワード
        public int Port { get; set; }       //ポート番号
        public bool Ssl { get; set; }       //SSL設定

        //初期値
        public void DefaultSet() {
            Smtp = "smtp.gmail.com";
            MailAddres = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }
    }
}
