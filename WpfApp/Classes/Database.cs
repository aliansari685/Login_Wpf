using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static WpfApp.Checkup;
using WpfApp.Model;
using WpfApp.Forms;
using System;

namespace WpfApp
{
    sealed class Database : Operation
    {
        private string _info;
        internal string Information //send type user
        {
            get => _info;
            set
            {
                using (frm2 f2 = new frm2())
                {
                    _info = value;
                    if (value == "read") f2.btn_delete.IsEnabled = f2.btn_edit.IsEnabled = f2.btn_insert.IsEnabled = false;
                    f2.id = _user.ID;
                    f2.lbl_username.Content = _user.Username;
                    f2.ShowDialog();
                }
            }
        }
        public async void Login(string user, string pass) //Login Check..
        {
            try
            {
                using (context = new LoginDBEntities())
                {
                    pass = await Hash(pass, pass);
                    _user = context.Users.SingleOrDefault(x => x.Username == user && x.Password == pass);
                    if (!(_user is null)) Information = _user.Modify.ToLower();
                    else
                        Print(Error.Login, null);
                }
            }
            catch (Exception e)
            {
                Print(Error.DataBase, "\n" + e.InnerException.Message);
            }

        }
        public bool Sum()
        {
            using (context = new LoginDBEntities())
            {
                int? num = context.Users.Sum(x => x.Row);
                int? num2 = context.Users.Count();
                num2 = num2 * (num2 + 1) / 2;
                return num2 == num;
            }
        }
        public BindingList<User> Fill_Tabel()
        {
            using (context = new LoginDBEntities())
            {
                context.Users.Load();
                return context.Users.Local.ToBindingList();
            }
        }
        public async Task<List<User>> Search_Query(string str)
        {
            str = str.Replace("ئ", "ی");
            await Task.Delay(500);
            using (context = new LoginDBEntities())
            {
                var query = IsPersianText(str) ? (from row in context.Users
                                                  where row.Firstname.Contains(str) || row.Lastname.Contains(str)
                                                  select row).ToList() :
                                              (from row in context.Users
                                               where row.Row.ToString().Contains(str) ||
                                               row.Firstname.Contains(str) ||
                                               row.Lastname.ToLower().Contains(str) ||
                                               row.Username.ToLower().Contains(str) ||
                                               row.Mail.ToLower().Contains(str) ||
                                               row.Modify.ToLower().Contains(str) ||
                                               row.RegisterDate.Contains(str) ||
                                               row.Birth.Contains(str)
                                               select row).ToList();
                Print(Error.Other, " تعداد رکورد پیدا شده : " + query.Count);
                return query;
            }
        }
    }
}