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
                connection.CreateTable<WaterHisory>();
                connection.CreateTable<SleepHistory>();
                connection.CreateTable<BloodTestHistory>();
                connection.CreateTable<CaloriesHistory>();
                connection.CreateTable<WeightHistory>();
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

        public User getUser(string username)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                var list = connection.Query<User>("select * from User where UserName=?", username);
                return list[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void changeWeight(int userID, int weight)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Query<User>("update User set UserWeight=" + weight + " where UserID=" + userID);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //Water dashboar handling
        public void changeTargetWater(int userID, float target)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Query<User>("update User set UserTargetWater=" + target + " where UserID=" + userID);
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public List<WaterHisory> getWaterHistoryByDay(int userID, string date)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                string Query = "select * from WaterHisory where UserID=" + userID + " and Date='" + date +"'";
                Console.WriteLine(Query);
                var list = connection.Query<WaterHisory>(Query);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }  
        public bool addWater(WaterHisory result)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void deleteAllWater()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.DeleteAll<WaterHisory>();
            }
            catch
            {
                return;
            }
        }

        //Sleep history handling
        public SleepHistory getLastSleep(int userID)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                var list = connection.Query<SleepHistory>("select * from SleepHistory where UserID=? order by shID desc limit 1", userID);
                return list[0];
            }
            catch
            {
                return null;
            }
        }
        public List<SleepHistory> getLastTenSleep(int userID)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                var list = connection.Query<SleepHistory>("select * from SleepHistory where UserID=? order by shID desc limit 10", userID);
                return list;
            }
            catch
            {
                return null;
            }
        }

        public bool addSleep(SleepHistory result)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Blood test history handling
        public BloodTestHistory getLastBloodTest(int userID)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                var list = connection.Query<BloodTestHistory>("select * from BloodTestHistory where UserID=? order by bthID desc limit 1", userID);
                return list[0];
            }
            catch
            {
                return null;
            }
        }

        public List<BloodTestHistory> getLastTenBloodTest(int userID)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                var list = connection.Query<BloodTestHistory>("select * from BloodTestHistory where UserID=? order by bthID desc limit 10", userID);
                return list;
            }
            catch
            {
                return null;
            }
        }
        public bool addBloodTest(BloodTestHistory result)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Calories history handling
        public List<CaloriesHistory> getCaloriesHistoryByDay(int userID, string date)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                string Query = "select * from CaloriesHistory where UserID=" + userID + " and Date='" + date + "'";
                var list = connection.Query<CaloriesHistory>(Query);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void changeTargetCalories(int userID, int target)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Query<User>("update User set UserTargetCalories=" + target + " where UserID=" + userID);
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public bool addCaloriesHistory(CaloriesHistory result)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //weight history handling
        public void changeTargetWeight(int userID, int target)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Query<User>("update User set UserTargetWeight=" + target + " where UserID=" + userID);
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public bool addWeightHistory(WeightHistory result)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<WeightHistory> getLastTenWeight(int userID)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "healthcare.db");
                var connection = new SQLiteConnection(path);
                var list = connection.Query<WeightHistory>("select * from WeightHistory where UserID=? order by weighthistoryID desc limit 10", userID);
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
