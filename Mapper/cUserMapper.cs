using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using BusinessLogicLayer;

namespace Mapper {
	public	class cUserMapper :EntityTypeConfiguration<cUser> {

		public cUserMapper()
		{
			this.ToTable("tUsers");
			this.HasKey(x => x.Id);
			this.Property(x => x.Email)
				.IsOptional()
				.HasMaxLength(50)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(new[] {new IndexAttribute("Index") {IsUnique = true},}));
			this.Property(x => x.Username)
				.IsRequired()
				.HasMaxLength(30)
				.HasColumnAnnotation("Index2", 
					new IndexAnnotation(new[] {new IndexAttribute("Index") {IsUnique = true},}));

			this.Property(x => x.Password)
				.IsRequired();
			
		}
	}
}
