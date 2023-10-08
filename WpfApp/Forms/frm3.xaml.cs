using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp.Model;
using static WpfApp.Checkup;

namespace WpfApp.Forms
{
    /// <summary>
    /// Interaction logic for frm3.xaml
    /// </summary>
    /// 
    public partial class frm3 : Window, IDisposable
    {
        private readonly Database db;
        private List<string> Items;
        private User U;
        private int? IU;
        public int? Insert_update
        {
            get => IU;
            set
            {
                using (var context = new LoginDBEntities())
                    if (context.Users.Any(x => x.ID == value))
                    {
                        IU = value;
                        U = context.Users.Find(value);
                        Replace();
                    }
            }
        }
        public frm3()
        {
            InitializeComponent();
            db = new Database();
            datepicker1.Text = Shamsi_Date().Remove(Shamsi_Date().IndexOf('-'));
            Firstname_Box.Focus();
        }
        private async void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            string mdfy = (bool)(write_radio.IsChecked) ? "write" : "read";
            if (Check_Input(Firstname_Box.Text, Lastname_Box.Text, Username_Box.Text, Mail_Box.Text))
            {
                Print(Error.Null, null);
                return;
            }
            if (!Check_Mail(Mail_Box.Text) || !(IsEnglishText(Firstname_Box.Text)) || !(IsEnglishText(Lastname_Box.Text)))
            {
                Print(Error.Format, null);
                return;
            }
            if (IU != null) //Update:
            {
                int id = (int)IU;
                Items = new List<string> { Firstname_Box.Text, Lastname_Box.Text, Username_Box.Text, Mail_Box.Text, mdfy, datepicker1.Text };
                if (db.UpdateTBL(id, Items))
                {
                    Print(Error.Ok, null);
                    this.Close();
                }
            }
            else   //Insert:
            {
                if (!Check_Password(Password_Box.Password, Password_Box2.Password))
                {
                    Print(Error.Pass, null);
                    return;
                }
                Items = new List<string> { Firstname_Box.Text, Lastname_Box.Text, Username_Box.Text, Mail_Box.Text, Password_Box.Password, "read", datepicker1.Text };
                if (await db.InsertToDB(Items))
                {
                    Print(Error.Ok, "");
                    this.Close();
                }
            }
        }
        private void datepicker1_CalendarClosed(object sender, RoutedEventArgs e) => Print(Error.Other, "توجه : تاریخ تولد انتخاب شده باید افراد متولدین بیشتر از 15 سال باشند\r\nدر غیر اینصورت در پایگاه داه خالی ثبت خواهد شد ");
        public void Dispose() => GC.SuppressFinalize(this);
        private void Closing_Click(object sender, RoutedEventArgs e) => this.Close();
        private void Replace()
        {
            Firstname_Box.Text = U.Firstname;
            Lastname_Box.Text = U.Lastname;
            Username_Box.Text = U.Username;
            Mail_Box.Text = U.Mail;
            datepicker1.Text = U.Birth;
            write_radio.IsChecked = U.Modify == "write";
            Password_Box.IsEnabled = Password_Box2.IsEnabled = false;
        }
    }
}