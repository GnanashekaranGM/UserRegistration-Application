using System;
using System.Text;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using UserRegitration.Model;
using System.IO;
using Xamarin.Essentials;

namespace UserRegitration
{
	public class SQLiteHelp
	{
		static SQLiteAsyncConnection db;

        public static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "UserData.db");
            db = new SQLiteAsyncConnection(databasePath);

            //System.Diagnostics.Debug.WriteLine($"Database Path: {databasePath}");

            await db.CreateTableAsync<UserDetails>();
        }

        public static Task<int> AddUser(UserDetails user)
        {
            return db.InsertAsync(user);
        }

        public static Task<UserDetails> GetUserByEmail(string email)
        {
            return db.Table<UserDetails>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public static Task<UserDetails> Login(string email, string password)
        {
            return db.Table<UserDetails>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }
    }
}

