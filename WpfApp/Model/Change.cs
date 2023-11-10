using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WpfApp.Classes;
using WpfApp.Model;
using static WpfApp.Helper;

namespace WpfApp
{
    public class Change : Base //CRUD Operation For Table
    {
        private string _Birth;
        public bool Insert_TBL(List<string> values)
        {
            try
            {
                using (Context = new LoginDBEntities())
                {
                    int row = Context.Users.Max(x => x.Row) + 1;
                    string pass = Helper_Text.Hash(values[4], values[4]);
                    _Birth = !(string.IsNullOrEmpty(values[6])) && int.Parse(values[6].Substring(0, 4)) <= (int.Parse(Shamsi_Date().Substring(0, 4)) - 15) ? values[6] : null;
                    _User = new User
                    {
                        Row = row,
                        Firstname = values[0],
                        Lastname = values[1],
                        Username = values[2],
                        Mail = values[3],
                        Password = pass,
                        RegisterDate = Shamsi_Date(),
                        Modify = values[5],
                        Birth = _Birth,
                    };
                    using (_OP = new Operation()) _OP.User_Insert(_User);
                    Update_TBL_Row();
                    return true;
                }
            }
            catch (Exception)
            {
                Helper_ShowMessage.Print(Helper_ShowMessage.Error.Tekrari, null);
                return false;
            }
        }
        public bool Update_TBL(int id, List<string> values)
        {
            try
            {
                using (Context = new LoginDBEntities())
                {
                    _Birth = !(string.IsNullOrEmpty(values[5])) && int.Parse(values[5].Substring(0, 4)) <= (int.Parse(Shamsi_Date().Substring(0, 4)) - 15) ? values[5] : null;
                    _User = Context.Users.Find(id);
                    {
                        _User.Birth = _Birth;
                        _User.Firstname = values[0];
                        _User.Lastname = values[1];
                        _User.Username = values[2];
                        _User.Mail = values[3];
                        _User.Modify = values[4];
                    }
                    using (_OP = new Operation()) _OP.User_Update(_User);
                }
                return true;
            }
            catch (Exception)
            {
                Helper_ShowMessage.Print(Helper_ShowMessage.Error.Cancel, "\n" + "احتمال وجود مورد تکراری در فیلد نام کاربری");
                return false;
            }
        }
        public void Delete_TBL(int id)
        {
            try
            {
                using (Context = new LoginDBEntities())
                {
                    _User = Context.Users.Find(id);
                    using (_OP = new Operation()) _OP.User_Remove(_User);
                    Update_TBL_Row();

                }
            }
            catch (Exception ex)
            {
                Helper_ShowMessage.Print(Helper_ShowMessage.Error.Cancel, ex.Message);
            }
        }
        public bool Update_TBL_Password(string user, string oldpass, string newpass)
        {
            try
            {
                using (Context = new LoginDBEntities())
                {
                    oldpass = Helper_Text.Hash(oldpass, oldpass);
                    newpass = Helper_Text.Hash(newpass, newpass);
                    _User = Context.Users.SingleOrDefault(x => x.Username == user && x.Password == oldpass);
                    _User.Password = newpass;
                    using (_OP = new Operation()) _OP.User_Update(_User);
                }
                return true;
            }
            catch (Exception ex)
            {
                Helper_ShowMessage.Print(Helper_ShowMessage.Error.Cancel, ex.Message);
                return false;
            }
        }
        private void Update_TBL_Row()
        {
            int j = 1, data = 0; int? Sum, Count, Num;
            //  using (Context = new LoginDBEntities())
            {
                Sum = Context.Users.Sum(x => x.Row);
                Count = Context.Users.Count();
                Num = Count * (Count + 1) / 2;
                if (Num != Sum)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        data = Context.Users.Select(d => d.Row).ToList()[i];
                        if (data != j)
                        {
                            _User = Context.Users.FirstOrDefault(x => x.Row == data);
                            _User.Row = j;
                            using (_OP = new Operation()) _OP.User_Update(_User);
                        }
                        j++;
                    }
                }
            }
        }
        ~Change() => GC.SuppressFinalize(this);
    }
}