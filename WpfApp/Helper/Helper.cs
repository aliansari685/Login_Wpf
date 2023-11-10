using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WpfApp
{
    internal class Helper
    {
        public static string Shamsi_Date()
        {
            System.Globalization.PersianCalendar pr = new System.Globalization.PersianCalendar();
            string datenow =
                string.Format("{0}/{1}/{2}-{3}", pr.GetYear(DateTime.Now),
                pr.GetMonth(DateTime.Now), pr.GetDayOfMonth(DateTime.Now),
                DateTime.Now.ToLongTimeString());
            return datenow;
        }
        public static void SwitchTheme() //Switch Theme Dark And Light
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(theme.Background.IsLightColor() ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }
    }
    internal class Helper_Checking
    {
        public static bool Check_Input(params string[] str) => str.Any(x => string.IsNullOrWhiteSpace(x) || Regex.IsMatch(x, @"\s"));
        public static bool Check_Password(string str, string str1) => (str == str1) && (str.Length >= 5) && !(string.IsNullOrWhiteSpace(str));
        public static bool Check_Mail(string str)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)";
            return Regex.IsMatch(str, pattern);
        }
    }
}