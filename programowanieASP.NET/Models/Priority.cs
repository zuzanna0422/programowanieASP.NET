using System.ComponentModel.DataAnnotations;

namespace programowanieASP.NET.Models
{
    public enum Priority
    {
        [Display(Name = "Niski" )]Low = 1,
        [Display(Name = "Normalny")]Normal = 2,
        [Display(Name = "Wysoki")]High = 3,
        [Display(Name = "Priorytet")]Urgent = 4
    }
}
