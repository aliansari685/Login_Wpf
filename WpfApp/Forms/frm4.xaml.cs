using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using static WpfApp.Checkup;

namespace WpfApp.Forms
{
    /// <summary>
    /// Interaction logic for frm4.xaml
    /// </summary>
    public partial class frm4 : Window, IDisposable
    {
        public string Username;
        public void Dispose() => GC.SuppressFinalize(this);
        public frm4() => InitializeComponent();
        private void Closing_Click(object sender, RoutedEventArgs e) => this.Close();
        private async void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Check_Input(OldPass_Box.Password, Password_Box.Password, RepeatPassword_Box.Password))
            {
                Print(Error.Null, null);
                return;
            }
            if (!Check_Password(Password_Box.Password, RepeatPassword_Box.Password))
            {
                Print(Error.Pass, null);
                return;
            }
            if (await new Database().Update_Pass(Username, OldPass_Box.Password, Password_Box.Password))
            {
                DialogHost.OpenDialogCommand.Execute(ChangeBtn.CommandParameter, dh);
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
                        OldPass_Box.Password = Password_Box.Password = RepeatPassword_Box.Password = null;
                    }));
                });
                Print(Error.Ok, null);
                this.Close();
            }
        }
    }
}