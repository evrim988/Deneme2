using System.ComponentModel.DataAnnotations;

namespace Registalaser.Domain.Enums
{
    public enum TicketStatus
    {
        [Display(Name = "Değerlendiriliyor")]
        Evaluation = 0,

        [Display(Name = "Başlamadı")]
        NotStart = 1,

        [Display(Name = "Devam Ediyor")]
        Continued = 2,

        [Display(Name = "Tamamlandı")]
        Completed = 3,

        [Display(Name = "İptal")]
        Cancel = 4,
    }
}
