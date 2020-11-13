using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        public ConfigWindow() {
            InitializeComponent();
        }

        //初期値反映
        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstance()).getDefalutStatus() ;
            //Config defaultData = config.getDefalutStatus();
            tbSmtp.Text = cf.Smtp;
            tbSender.Text = tbUserName.Text = cf.MailAddres;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;

        }

        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {

           
            if (tbUserName.Text == "" || tbSmtp.Text == "" ||
                tbPassWord.Password == "" || tbPort.Text == "0") {

                MessageBox.Show("未入力なところがあります。");
            } else {
                (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false); //更新処理を呼び出す
            }

        }
        
        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            btApply_Click(sender,e);
            this.Close();
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            //if (Config.GetInstance() != ) {
            //    DialogResult dr = MessageBox.Show("変更が反映されていません", "確認", MessageBoxButtons.OKCancel);
            //    if (dr == System.Windows.Forms.DialogResult.OK) {
            //        MessageBox.Show("キャンセルしました。");
            //        this.Close();
            //    }
            


            //}
            
            
        }

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config cf = Config.GetInstance();
            tbSmtp.Text = cf.Smtp;
            tbUserName.Text = cf.MailAddres;
            tbSender.Text = cf.MailAddres;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;

        }
    }
}
