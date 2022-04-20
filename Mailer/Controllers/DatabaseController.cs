using Mailer.Data;
using Mailer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Controllers
{
    class DatabaseController
    {
        protected static async Task<bool> FindByEmail(string email)
        {
            using (var db = new SqliteDbContext())
            {
                var current = from user in db.Mails
                              where user.Email == email
                              select user;
                if (await current.FirstOrDefaultAsync() == null)
                {
                    return false;
                }
                return true;
            }
        }
        public static async Task AddAllEmails(List<MailModel> obj)
        {
            using (var db = new SqliteDbContext())
            {
                foreach (var email in obj)
                {
                    if (!await FindByEmail(email.Email))
                    {
                        await db.Mails.AddAsync(email);
                    }
                }
                await db.SaveChangesAsync();
            }
        }
        public static List<MailModel> FindUnsendedEmail()
        {
            using (var db = new SqliteDbContext())
            {
                var current = from user in db.Mails
                              where user.IsEmailConfirmed == false
                              select user;
                return current.ToList();
            }
        }
        public static async Task UpdateEmail(int Id)
        {
            using(var db = new SqliteDbContext())
            {
                var current = from user in db.Mails
                              where user.Id == Id
                              select user;
                if(await current.FirstOrDefaultAsync() != null)
                {
                    current.FirstOrDefault().IsEmailConfirmed = true;
                    await db.SaveChangesAsync();
                }
            }
        }
        public static async Task DeleteAllData()
        {
            using(var db = new SqliteDbContext())
            {
                foreach(var email in db.Mails)
                {
                    db.Remove(email);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
