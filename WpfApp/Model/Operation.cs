using System;
using System.Data.Entity.Migrations;

namespace WpfApp.Model
{
    public class Operation : Change, IDisposable
    {
        public void User_Insert(User usr)
        {
            Context.Users.Add(usr);
            Context.SaveChanges();
        }
        public void User_Update(User usr)
        {
            Context.Users.AddOrUpdate(usr);
            Context.SaveChanges();
        }
        public void User_Remove(User usr)
        {
            Context.Users.Attach(usr);
            Context.Users.Remove(usr);
            Context.SaveChanges();
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}