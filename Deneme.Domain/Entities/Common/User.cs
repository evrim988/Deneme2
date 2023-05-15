using Deneme.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deneme.Domain.Entities.Common
{
	public class User : BaseEntity
	{
		[DisplayName("Name")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		public string Name { get; set; }

		[DisplayName("Surname")]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		public string SurName { get; set; }


		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(256, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		[EmailAddress(ErrorMessage = "Geçerli mail Adresi giriniz")]
		public string EMail { get; set; }
	}
}
