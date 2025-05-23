﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Deneme.Domain.Common
{
	public class Customer : BaseEntity
	{
		//Min ve Max Length ve StringLength sadece string değişkenler için kullanılır

		[DisplayName("Name")]
		[StringLength(150)]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		public string Name { get; set; }

		[DisplayName("Surname")]
		[StringLength(150)]
		[MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
		[MaxLength(150, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
		public string Surname { get; set; }

        [DisplayName("Adress")]
        [StringLength(600)]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olamaz")]
        [MaxLength(600, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        public string Adress { get; set; }

		[DisplayName("FirmaAdı")]
		public string FirmaAdı { get; set; }

		[DisplayName("EMail")]
        public string EMail { get; set; }
    }
}
//firmadı
//email
