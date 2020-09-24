using BitPazari.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace BitPazari.Core.Map
{
  public  class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName("Status").IsRequired();

            Property(x => x.CreatedComputerName).HasMaxLength(255).IsOptional();
            Property(x => x.ModifiedComputerName).HasMaxLength(255).IsOptional();
            Property(x => x.CreatedUserName).HasMaxLength(150).IsOptional();
            Property(x => x.ModifiedUserName).HasMaxLength(150).IsOptional();
            Property(x => x.CreatedIp).HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedIp).HasMaxLength(50).IsOptional();
                            
        }

    }
}
