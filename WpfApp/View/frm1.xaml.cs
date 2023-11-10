using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp.Classes;
using WpfApp.Forms;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Change _Change;
        public MainWindow()
        {
            InitializeComponent();
            _Change = new Change();
        }
        private void Lbl_Dark_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => ThemeToggle_Click(null, null);
        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            Helper.SwitchTheme();
            themeToggle.IsChecked = !themeToggle.IsChecked;
        }
        private void LoginBTN_Click(object sender, RoutedEventArgs e) => Start();
        private async void Start()
        {
            if (Helper_Checking.Check_Input(L_Username_Box.Text, L_Password_Box.Password))
            {
                Helper_ShowMessage.Print(Helper_ShowMessage.Error.Null, null);
                return;
            }
            DialogHost.OpenDialogCommand.Execute(LoginBTN.CommandParameter, dh);
            await Waiting();
        }
        private async Task Waiting()
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    await Task.Delay(10);
                    Dispatcher.Invoke(new Action(() =>
                    {
                        progressBar1.Value = i;
                    }));
                }
                Dispatcher.Invoke(new Action(() =>
               {
                   DialogHost.CloseDialogCommand.Execute(dh, progressBar1);
                   _Change.Login(L_Username_Box.Text, L_Password_Box.Password);
                   L_Username_Box.Text = L_Password_Box.Password = null;
               }));
            });
        }
        private void RegisterBTN_Click(object sender, RoutedEventArgs e) => new Frm3().ShowDialog();
    }
}