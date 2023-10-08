using WpfApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WpfApp.Checkup;
using WpfApp.Model;
using WpfApp.Forms;

namespace WpfApp
{
    abstract class Operation //CRUD Operation For DB
    {
        private string birth;
        protected LoginDBEntities context = new LoginDBEntities();
        protected User _user = new User();
        private enum Operator { Add, Update, Delete }
        private void Action(Operator opr) //مقدار دهی نوع داده شمارشی
        {
            switch (opr)
            {
                case Operator.Add:
                    context.Users.Add(_user);
                    context.SaveChanges();
                    break;

                case Operator.Update:
                    context.SaveChanges();
                    break;

                case Operator.Delete:
                    context.Users.Remove(_user);
                    context.SaveChanges();
                    break;
            }
        }
        public void Row_Ordering() //For Update User.Row Value With Idenity 1-1
        {
            if (!new Database().Sum())
            {
                using (context = new LoginDBEntities())
                {
                    int j = 1, data = 0;
                    for (int i = 0; i < context.Users.Count(); i++)
                    {
                        data = context.Users.Select(d => d.Row).ToList()[i];
                        //پیدا کردن فیلد ردیف با اندیس آی
                        if (data != j)
                        {
                            _user = context.Users.FirstOrDefault(x => x.Row == data);
                            _user.Row = j;
                            Action(Operator.Update);
                        }
                        j++;
                    }
                }
            }
        }
        public async Task<bool> InsertToDB(List<string> values)
        {
            try
            {
                using (context = new LoginDBEntities())
                {
                    int row = context.Users.Max(x => x.Row) + 1;
                    string pass = await Hash(values[4], values[4]);
                    birth = !(string.IsNullOrEmpty(values[6])) && int.Parse(values[6].Substring(0, 4)) <= (int.Parse(Shamsi_Date().Substring(0, 4)) - 15) ? values[6] : null;
                    _user = new User()
                    {
                        Row = row,
                        Firstname = values[0],
                        Lastname = values[1],
                        Username = values[2],
                        Mail = values[3],
                        Password = pass,
                        RegisterDate = Shamsi_Date(),
                        Modify = values[5],
                        Birth = birth,
                    };
                    Action(Operator.Add);
                    Row_Ordering();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Print(Error.Tekrari, ex.Message);
                return false;
            }
        }
        public bool UpdateTBL(int id, List<string> values)
        {
            try
            {
                using (context = new LoginDBEntities())
                {
                    birth = !(string.IsNullOrEmpty(values[5])) && int.Parse(values[5].Substring(0, 4)) <= (int.Parse(Shamsi_Date().Substring(0, 4)) - 15) ? values[5] : null;
                    _user = context.Users.Find(id);
                    {
                        _user.Birth = birth;
                        _user.Firstname = values[0];
                        _user.Lastname = values[1];
                        _user.Username = values[2];
                        _user.Mail = values[3];
                        _user.Modify = values[4];
                    }
                    Action(Operator.Update);
                }
                return true;
            }
            catch (Exception)
            {
                Print(Error.Cancel, "\n" + "احتمال وجود مورد تکراری در فیلد نام کاربری");
                return false;
            }
        }

        public async Task<bool> Update_Pass(string user, string oldpass, string newpass)
        {
            try
            {
                using (context = new LoginDBEntities())
                {
                    oldpass = await Hash(oldpass, oldpass);
                    newpass = await Hash(newpass, newpass);
                    _user = context.Users.SingleOrDefault(x => x.Username == user && x.Password == oldpass);
                    _user.Password = newpass;
                    Action(Operator.Update);
                }
                return true;
            }
            catch (Exception ex)
            {
                Print(Error.Cancel, ex.Message);
                return false;
            }
        }

        public void DeleteInDB(int id)
        {
            try
            {
                using (context = new LoginDBEntities())
                {
                    _user = context.Users.Find(id);
                    Action(Operator.Delete);
                    Row_Ordering();
                }
            }
            catch (Exception ex)
            {
                Print(Error.Cancel, ex.Message);
            }
        }
    }
}