using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WpfApp.Forms;
using static WpfApp.Classes.Helper_ShowMessage;

namespace WpfApp.Model
{
    public abstract class Base
    {
        protected LoginDBEntities Context = new LoginDBEntities();
        protected User _User;
        public Operation _OP;
        string _info;
        internal string Information
        {
            get => _info;
            set
            {
                _info = value;
                Setter();
            }
        }
        public void Login(string user, string pass)
        {
            try
            {
                using (Context = new LoginDBEntities())
                {
                    _User = new User();
                    pass = Helper_Text.Hash(pass, pass);
                    _User = Context.Users.SingleOrDefault(x => x.Username == user && x.Password == pass);
                    if (!(_User is null))
                    {
                        Information = _User.Modify.ToLower();
                    }
                    else
                    {
                        Print(Error.Login, null);
                    }
                }
            }
            catch (Exception e)
            {
                Print(Error.DataBase, "\n" + e.InnerException.Message);
            }
        }
        private void Setter()
        {
            using (Frm2 f2 = new Frm2())
            {
                if (Information == "read") f2.btn_delete.IsEnabled = f2.btn_edit.IsEnabled = f2.btn_insert.IsEnabled = false;
                f2.ID = _User.ID;
                f2.lbl_username.Content = _User.Username;
                f2.ShowDialog();
            }
        }
    }
    sealed internal class GetData : Base
    {
        public BindingList<User> GetAll()
        {
            using (Context = new LoginDBEntities())
            {
                Context.Users.Load();
                return Context.Users.Local.ToBindingList();
            }
        }
        public async Task<List<User>> GetBySearch(string str)
        {
            str = str.Replace("ئ", "ی");
            await Task.Delay(500);
            using (Context = new LoginDBEntities())
            {
                var query = Helper_Text.IsPersianText(str) ? (from row in Context.Users
                                                              where row.Firstname.Contains(str) || row.Lastname.Contains(str)
                                                              select row).ToList() :
                                              (from row in Context.Users
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