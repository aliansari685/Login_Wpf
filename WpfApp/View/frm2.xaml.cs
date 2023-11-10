using HandyControl.Tools.Extension;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfApp.Classes;
using WpfApp.Model;

namespace WpfApp.Forms
{
    /// <summary>
    /// Interaction logic for frm2.xaml
    /// </summary>
    public partial class Frm2 : Window, IDisposable
    {
        private BindingList<User> Temp;
        private Change _Change;
        public int ID;
        private GetData Fill;
        private Frm3 Frm3;
        public void Dispose() => GC.SuppressFinalize(this);
        public Frm2() => InitializeComponent();
        public void Form_Loaded(object sender, RoutedEventArgs e)
        {
            Config();
            InitializeTimer();
        }
        public void Timer1_Tick(object sender, EventArgs e) => lbl_time.Content = Helper.Shamsi_Date();
        private async void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (!Helper_Checking.Check_Input(searchbox.Text))
            {
                DataView1.ItemsSource = await Fill.GetBySearch(searchbox.Text);
                DataView1.Columns[0].Visibility = Visibility.Hidden;
            }
            else Helper_ShowMessage.Print(Helper_ShowMessage.Error.Null, null);
        }

        private void Searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //  if (string.IsNullOrEmpty(searchbox.Text)) Form_Loaded(this, null);
            if (string.IsNullOrEmpty(searchbox.Text))
            {
                this.DataView1.ItemsSource = Temp;
                DataView1.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void CheckBox_Row_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox checkbox = (System.Windows.Controls.CheckBox)sender;
            int colindex = int.Parse(checkbox.Tag.ToString());
            DataView1.Columns[colindex].Visibility = (bool)checkbox.IsChecked ? Visibility.Visible : Visibility.Hidden;
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (Helper_ShowMessage.Print("آیا از کار خود اطمینان دارید ؟ " + "\n تعداد انتخاب شده : " + DataView1.SelectedItems.Count) && DataView1.SelectedItems.Count > 0)
            {
                DataView1.SelectedItems.Cast<User>().ForEach(item => _Change.Delete_TBL(item.ID));
                Config();
                Helper_ShowMessage.Print(Helper_ShowMessage.Error.Ok, "\n تعداد حذف شده : " + DataView1.SelectedItems.Count.ToString());
                // Form_Loaded(this, null);
            }
        }

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            using (Frm3 = new Frm3()) Frm3.ShowDialog();
            //  Form_Loaded(this, null);
            Config();

        }
        private void Btn_EditRow_Click(object sender, RoutedEventArgs e)
        {
            if (DataView1.SelectedItems.Count == 1)
            {
                User item = DataView1.SelectedItem as User;
                using (Frm3 = new Frm3())
                {
                    Frm3.Insert_update = item.ID;
                    Frm3.write_radio.IsEnabled = true;
                    Frm3.RegisterBTN.Content = "Update";
                    Frm3.ShowDialog();
                    Config();
                    if (item.ID == ID) lbl_username.Content = new LoginDBEntities().Users.Find(ID).Username;
                }
            }
            else Helper_ShowMessage.Print(Helper_ShowMessage.Error.Other, "لطفا یک ردیف را انتخاب کنید");
        }
        private void DataView1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (btn_edit.IsEnabled) Btn_EditRow_Click(this, null);
        }

        private void Btn_editPass_Click(object sender, RoutedEventArgs e)
        {
            using (Frm4 f4 = new Frm4())
            {
                f4.Username = lbl_username.Content.ToString();
                f4.ShowDialog();
            }
            Config();
        }
        private void Config()
        {
            _Change = new Change(); Fill = new GetData();
            DataView1.ItemsSource = Fill.GetAll();
            DataView1.Columns[0].Visibility = Visibility.Hidden;
            Temp = DataView1.ItemsSource as BindingList<User>;
            checkBox_Birth.IsChecked = checkBox_RegisterDate.IsChecked = checkBox_Modify.IsChecked = checkBox_Pass.IsChecked = checkBox_Mail.IsChecked = checkBox_User.IsChecked = checkBox_Last.IsChecked = checkBox_First.IsChecked = checkBox_Row.IsChecked = true;
        }
        private void InitializeTimer()
        {
            Timer timer = new Timer { Enabled = true };
            timer.Tick += Timer1_Tick;
        }
    }
}