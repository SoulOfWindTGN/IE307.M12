using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        //Create Database
        public bool createDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.CreateTable<User>();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //User handling
        public bool checkUsername(string username)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                List<User> existed_user = connection.Query<User>("select * from User where UserName=?",username);
                if(existed_user.Count == 1)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool addUser(User user)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool checkLoginUser(string name, string pass)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                List<User> existed_user = connection.Query<User>("select * from User");
                for (int i = 0; i < existed_user.Count; i++)
                {
                    if (name == existed_user[i].UserName && pass == existed_user[i].UserPassword)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void deleteAll()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.DeleteAll<User>();
            }
            catch
            {
                return;
            }
        }
    }
}
