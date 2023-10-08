using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Interop;
using MaterialDesignColors.Recommended;
using System.Net.NetworkInformation;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors.ColorManipulation;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfApp.Forms;

namespace WpfApp
{
    public class View
    {
        /// <summary>
        /// Change Base Theme Dark And Light
        /// </summary>
        public void switchTheme()
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(theme.Background.IsLightColor() ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

    }
}
