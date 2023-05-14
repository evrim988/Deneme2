using Deneme.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deneme.Domain.Entities.Common
{
	public class User : BaseEntity
	{
		[StringLength(150)]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		public string Name { get; set; }


		[StringLength(150)]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		public string SurName { get; set; }

		public string FullName => $"{Name} {SurName}";


		[StringLength(100)]
		public string Password { get; set; }

		//Veritabanına bu alanı oluşturmazz
		[NotMapped]
		[Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
		public string PasswordRepeat { get; set; }

		[StringLength(256)]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(256, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		[EmailAddress(ErrorMessage = "Geçerli mail Adresi giriniz")]
		public string EMail { get; set; }
	}
}
