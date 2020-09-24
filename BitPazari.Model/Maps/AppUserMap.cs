using BitPazari.Core.Map;
using BitPazari.Model.Entities;

namespace BitPazari.Model.Maps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.UsersTable");
            Property(x => x.Address).IsRequired().HasMaxLength(1500);
            Property(x => x.BirthDate).HasColumnType("datetime").IsRequired();
            Property(x => x.Email).HasMaxLength(150).IsRequired();
            HasIndex(x => x.Email).IsUnique();
            Property(x => x.ImagePath).IsOptional().HasMaxLength(256);
            Property(x => x.UserName).IsRequired().HasMaxLength(100);
            HasIndex(x => x.UserName).IsUnique();
            Property(x => x.Password).IsRequired().HasMaxLength(50);
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
            Property(x => x.Name).IsOptional().HasMaxLength(60);
            Property(x => x.SurName).IsOptional().HasMaxLength(60);



        }
    }
}
