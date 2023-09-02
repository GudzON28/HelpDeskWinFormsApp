using System;
using System.Collections.Generic;
using System.Linq;
using HelpDesk.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Common
{
    public static class DbProvider
    {
        public static bool IsCorrectLoginPassword(string login, string password)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == Methods.GetHashMD5(password));

                return user != null ? false : true;
            }
        }

        public static User GetUser(string login)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == login);
            }
        }

        public static User GetUser(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddEmployee(Employee employee)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public static List<User> GetAllUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.ToList();
            }
        }

        public static void AddTrubleTicket(TrubleTicket trubleTicket)
        {
            using (var context = new ApplicationDbContext())
            {
                context.TrubleTickets.Add(trubleTicket);
                context.SaveChanges();
            }
        }

        public static List<TrubleTicket> GetAllTrubleTickets()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.TrubleTickets.ToList();
            }
        }

        public static TrubleTicket GetTrubleTicket(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.TrubleTickets.FirstOrDefault(t => t.Id == id);
            }
        }

        public static void ResolveTrubleTicket(int id,string status, string resolve, int resolveUserId)
        {
            using (var context = new ApplicationDbContext())
            {
                var trubleTicket = context.TrubleTickets.FirstOrDefault(t => t.Id == id);

                trubleTicket.IsSolved = true;
                trubleTicket.Status = status;
                trubleTicket.Resolve = resolve;
                trubleTicket.ResolveTime = DateTime.Now;
                trubleTicket.ResolveUser = resolveUserId;

                context.SaveChanges();
            }
        }

        public static void ChangeStatusTrubleTicket(int id, string staatus, int resolveUserId)
        {
            using (var context = new ApplicationDbContext())
            {
                var trubleTicket = context.TrubleTickets.FirstOrDefault(t => t.Id == id);

                trubleTicket.Status = staatus;
                trubleTicket.ResolveUser = resolveUserId;

                context.SaveChanges();
            }
        }

        public static void ChangeUserToEmployee(User user, string function, string department)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Users.Remove(user);
                context.SaveChanges();

                var convertedUser = new Employee();

                convertedUser.Id = user.Id;
                convertedUser.Name = user.Name;
                convertedUser.Login = user.Login;
                convertedUser.Password = user.Password;
                convertedUser.Email = user.Email;
                convertedUser.Function = function;
                convertedUser.Department = department;

                context.Employees.Add(convertedUser);
                context.SaveChanges();
            }
        }

        public static void ChangeEmployeeToUser(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Employees.Remove((Employee)user);
                context.SaveChanges();

                var convertedUser = new User();

                convertedUser.Id = user.Id;
                convertedUser.Name = user.Name;
                convertedUser.Login = user.Login;
                convertedUser.Password = user.Password;
                convertedUser.Email = user.Email;

                context.Users.Add(convertedUser);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}