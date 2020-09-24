using BitPazari.Core.Entity;
using BitPazari.Model.Entities;
using BitPazari.Model.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Model.Context
{
   public class ProjectContext:DbContext
    {
        public ProjectContext()/*:base("server=.;database=BitPazariDb;uid=sa;pwd=123")*/
        {
            Database.Connection.ConnectionString = "server=DESKTOP-3VCBFAJ;database=DbName;Trusted_Connection=True";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> UsersTable { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string Identity = WindowsIdentity.GetCurrent().Name;
            string ComputerName = Environment.MachineName;
            DateTime saveTime = DateTime.Now;
            int User = 1;
            string ip = "1";
            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item!=null)
                {
                    if (item.State==EntityState.Added)
                    {
                        entity.CreatedUserName = Identity;
                        entity.CreatedComputerName = ComputerName;
                        entity.CreatedBy = User;
                        entity.CreatedIp = ip;
                        entity.CreatedDate = saveTime;
                    }else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedUserName = Identity;
                        entity.ModifiedComputerName = ComputerName;
                        entity.ModifiedBy = User;
                        entity.ModifiedIp = ip;
                        entity.ModifiedDate = saveTime;
                    }
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
