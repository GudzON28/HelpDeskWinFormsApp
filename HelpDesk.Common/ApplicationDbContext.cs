using HelpDesk.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace HelpDesk.Common
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TrubleTicket> TrubleTickets => Set<TrubleTicket>();

        public ApplicationDbContext() { }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int MessageBox(IntPtr hwnd, String text, String caption, uint type);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                var client = JsonProvider.Load();

                if (client != null)
                {
                    if (client.IsDemoMode)
                    {
                        optionsBuilder.UseSqlite("Data Source=Demo.db");
                    }
                    else
                    {
                        optionsBuilder.UseMySql($"" +
                            $"server={client.ServerIp[0]}.{client.ServerIp[1]}.{client.ServerIp[2]}.{client.ServerIp[3]};" +
                            $"port={client.ServerPort};" +
                            $"user={client.User};" +
                            $"password={client.Password};" +
                            $"database={client.NameDb};",
                            new MySqlServerVersion(new Version(client.VersionDb[0], client.VersionDb[1], client.VersionDb[2]))
                            );
                    }
                }
                else
                {
                    FileProvider.Delete("cnf.dat");
                    FileProvider.Put("error.log", "Config Error, file deleted");

                    MessageBox(new IntPtr(0), "Config Error, file deleted. Pleace restart App", "Error", (int)0x00001010L);

                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                FileProvider.Put("error.log", ex.Message);

                MessageBox(new IntPtr(0), ex.Message, "Error", (int)0x00001010L);

                Environment.Exit(1);
            }

        }
    }
}