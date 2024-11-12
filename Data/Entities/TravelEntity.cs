using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using programowanieASP.NET.Models;

namespace Data.Entities
{
    [Table(name: "Travel")]
    public class TravelEntity
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę!")]
        [MaxLength(100, ErrorMessage = "Nazwa nie może mieć więcej niż 100 znaków.")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Proszę podać datę rozpoczęcia!")]
        [DataType(DataType.Date)]
        public DateTime DataRozpoczecia { get; set; }

        [Required(ErrorMessage = "Proszę podać datę zakończenia!")]
        [DataType(DataType.Date)]
        public DateTime DataZakonczenia { get; set; }

        [Required(ErrorMessage = "Proszę podać miejsce początkowe!")]
        [MinLength(3, ErrorMessage = "Miejsce początkowe musi mieć co najmniej 3 litery!")]
        [MaxLength(100, ErrorMessage = "Miejsce początkowe nie może mieć więcej niż 100 znaków.")]
        public string MiejscePoczatkowe { get; set; }

        [Required(ErrorMessage = "Proszę podać miejsce końcowe!")]
        [MinLength(3, ErrorMessage = "Miejsce końcowe musi mieć co najmniej 3 litery!")]
        [MaxLength(100, ErrorMessage = "Miejsce końcowe nie może mieć więcej niż 100 znaków.")]
        public string MiejsceKoncowe { get; set; }

        [Required(ErrorMessage = "Uczestnicy są wymagani!")]
        public List<string> Uczestnicy { get; set; }

        [Required(ErrorMessage = "Przewodnik jest wymagany!")]
        [MaxLength(100, ErrorMessage = "Nazwa przewodnika nie może mieć więcej niż 100 znaków.")]
        public string Przewodnik { get; set; }
    }
}
