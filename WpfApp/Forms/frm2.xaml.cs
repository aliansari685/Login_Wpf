using HandyControl.Tools.Extension;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfApp.Model;
using static WpfApp.Checkup;

namespace WpfApp.Forms
{
    /// <summary>
    /// Interaction logic for frm2.xaml
    /// </summary>
    public partial class frm2 : Window, IDisposable
    {
        public int id;
        private Database db;
        private frm3 frm3;
        public void Dispose() => GC.SuppressFinalize(this);
        public frm2() => InitializeComponent();
        public void Form_Loaded(object sender, RoutedEventArgs e)
        {
            Config();
            InitializeTimer();
        }
        public void Timer1_Tick(object sender, EventArgs e) => lbl_time.Content = Shamsi_Date();
        private async void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (!Check_Input(searchbox.Text))
            {
                DataView1.ItemsSource = await db.Search_Query(searchbox.Text);
                DataView1.Columns[0].Visibility = Visibility.Hidden;
            }
            else Print(Error.Null, null);
        }

        private void Searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchbox.Text)) Form_Loaded(this, null);
        }

        private void checkBox_Row_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox checkbox = (System.Windows.Controls.CheckBox)sender;
            int colindex = int.Parse(checkbox.Tag.ToString());
            DataView1.Columns[colindex].Visibility = (bool)checkbox.IsChecked ? Visibility.Visible : Visibility.Hidden;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (Print("آیا از کار خود اطمینان دارید ؟ " + "\n تعداد انتخاب شده : " + DataView1.SelectedItems.Count) && DataView1.SelectedItems.Count > 0)
            {
                DataView1.SelectedItems.Cast<User>().ForEach(item => db.DeleteInDB(item.ID));
                Print(Error.Ok, "\n تعداد حذف شده : " + DataView1.SelectedItems.Count);
                Form_Loaded(this, null);
            }
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            using (frm3 = new frm3()) frm3.ShowDialog();
            Form_Loaded(this, null);
        }
        private void Btn_EditRow_Click(object sender, RoutedEventArgs e)
        {
            if (DataView1.SelectedItems.Count == 1)
            {
                User item = DataView1.SelectedItem as User;
                using (frm3 = new frm3())
                {
                    frm3.Insert_update = item.ID;
                    frm3.write_radio.IsEnabled = true;
                    frm3.RegisterBTN.Content = "Update";
                    frm3.ShowDialog();
                    Form_Loaded(this, null);
                    if (item.ID == id) lbl_username.Content = new LoginDBEntities().Users.Find(id).Username;
                }
            }
            else Print(Error.Other, "لطفا یک ردیف را انتخاب کنید");
        }
        private void DataView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (btn_edit.IsEnabled) Btn_EditRow_Click(this, null);
        }

        private void Btn_editPass_Click(object sender, RoutedEventArgs e)
        {
            using (frm4 f4 = new frm4())
            {
                f4.Username = lbl_username.Content.ToString();
                f4.ShowDialog();
            }
            Form_Loaded(this, null);
        }
        private void Config()
        {
            checkBox_Birth.IsChecked = checkBox_RegisterDate.IsChecked = checkBox_Modify.IsChecked = checkBox_Pass.IsChecked = checkBox_Mail.IsChecked = checkBox_User.IsChecked = checkBox_Last.IsChecked = checkBox_First.IsChecked = checkBox_Row.IsChecked = true;
            db = new Database();
            DataView1.ItemsSource = db.Fill_Tabel();
            DataView1.Columns[0].Visibility = Visibility.Hidden;
        }
        private void InitializeTimer()
        {
            Timer timer = new Timer { Enabled = true };
            timer.Tick += Timer1_Tick;
        }
    }
}