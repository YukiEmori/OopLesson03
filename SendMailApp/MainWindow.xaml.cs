using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        SmtpClient sc = new SmtpClient();
        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        //送信完了イベント
        private void Sc_SendCompleted(object sender, AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました。");
            } else {
                MessageBox.Show(e.Error?.Message ?? "送信完了!");
            }
        }

        //メール送信処理
        private void btOk_Click(object sender, RoutedEventArgs e) {
            Config cc = Config.GetInstance();
                try {

                MailMessage msg = new MailMessage(cc.MailAddres ,tbTo.Text);



                if (tbCc.Text != "") {
                    string[] arrcc = tbCc.Text.Split(',');
                    foreach (var item in arrcc) {
                        msg.CC.Add(item);
                    }
                }
                //msg.CC.Add(tbCc.Text);

                if(tbBcc.Text != "") {
                    string[] arrbcc = tbBcc.Text.Split(',');
                    foreach (var item in arrbcc) {
                        msg.Bcc.Add(item);
                    }
                }
                //msg.Bcc.Add(tbBcc.Text);

                //追加したデータをmsgに格納する
                foreach (var item in addfile.Items) {
                    msg.Attachments.Add(new Attachment(item.ToString()));
                }
                //string jpgname = addfile.Items.ToString();
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(jpgname);
                //msg.Attachments.Add(attachment);

                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbBody.Text; //本文

                sc.Host =cc.Smtp; //SMTPサーバーの設定
                sc.Port = cc.Port;
                sc.EnableSsl = cc.Ssl;
                sc.Credentials = new NetworkCredential(cc.MailAddres, cc.PassWord);
                

                sc.SendMailAsync(msg); //送信

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
            

            
        }
        //送信キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            sc.SendAsyncCancel();
        }

        private static void ConfigWindowShow() {
            ConfigWindow configWindow = new ConfigWindow();  //設定画面のインスタンスを生成
            configWindow.ShowDialog();  //表示
        }

        //設定画面表示
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindowShow();
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config.GetInstance().DeSerialise();
        }

        private void Window_Closed(object sender, EventArgs e) {
            Config.GetInstance().Serialise();
        }

        //ファイルを追加する
        private void addfileBT_Click(object sender, RoutedEventArgs e) {
            var fod = new OpenFileDialog();
            if(fod.ShowDialog() == true) {
                addfile.Items.Add(fod.FileName);
            }
        }

        //選択した要素を削除する
        private void deletefileBT_Click(object sender, RoutedEventArgs e) {
            addfile.Items.Remove(addfile.SelectedItem);
        }
    }
}
