using ShowMsg;
using static ShowMsg.ShowMessage;

namespace WpfApp.Classes
{
    public static class Helper_ShowMessage
    {
        public enum Error { Null, Tekrari, Ok, Cancel, DataBase, Pass, Format, Login, Other }
        public static bool Print(string Message) => MessageBox().Show(Message, "Result", ShowMsgButtons.YesNo, ShowMsgIcon.Warning) == ShowMsgResult.Yes;
        public static void Print(Error Foul, string Message)
        {
            switch (Foul)
            {
                case Error.Null:
                    MessageBox().Show("مقادیر ورودی خالی است" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Error);
                    break;

                case Error.Tekrari:
                    MessageBox().Show("مقدار نام کاربری تکرای است" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Error);
                    break;

                case Error.Ok:
                    MessageBox().Show("عملیات با موفقیت انجام شد" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Success);
                    break;

                case Error.Cancel:
                    MessageBox().Show("عملیات متوقف و انجام نشد" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Warning);
                    break;

                case Error.DataBase:
                    MessageBox().Show("مشکلی در پایگاه داده بوجود آمد" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Warning);
                    break;

                case Error.Pass:
                    MessageBox().Show("رمز عبور از پنج حرف کمتر یا یکسان نیست" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Error);
                    break;

                case Error.Format:
                    MessageBox().Show("فرمت مقادیر ورودی معتبر نیست" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Error);
                    break;

                case Error.Login:
                    MessageBox().Show("نام کاربری  یا رمز عبور اشتباه است" + Message, "Message", ShowMsgButtons.Ok, ShowMsgIcon.Error);
                    break;

                case Error.Other:
                    MessageBox().Show(Message, "Other", ShowMsgButtons.Ok, ShowMsgIcon.Warning);
                    break;
            }
        }
        static ShowMessage MessageBox()
        {
            var MessageBox = new ShowMessage()
            {
                FontFamily = new System.Windows.Media.FontFamily("B Badr"),
                MessageFontSize = 21,
                IconColor = "#202A44",
            };
            return MessageBox;
        }
    }
}