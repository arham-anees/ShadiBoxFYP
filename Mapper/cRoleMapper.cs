using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public class cRoleMapper :EntityTypeConfiguration<cRole> {
	    public cRoleMapper()
	    {
		    this.ToTable("tRoles");
			this.HasKey(x => x.Id);
			this.HasIndex(x => x.Name)
				.IsUnique(true);

			this.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(20);
			this.Property(x => x.Description)
				.IsOptional()
				.HasMaxLength(100);


			this.HasMany(x => x.Users)
				.WithRequired(x=>x.Role)
				.HasForeignKey(x=>x.RoleId)
				.WillCascadeOnDelete(false);
	    }
	}
}