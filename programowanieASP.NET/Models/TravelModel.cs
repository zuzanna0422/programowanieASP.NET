using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using programowanieASP.NET.Controllers;

namespace programowanieASP.NET.Models {
public class TravelModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwę!")]
        public string Nazwa { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać date rozpoczęcia!")]
        public DateTime DataRozpoczecia { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać date zakończenia!")]
        public DateTime DataZakonczenia { get; set; }

        [MinLength(length:3, ErrorMessage = "Miejsce początkowe musi mieć co najmniej 3 litery!")]
        [Required(ErrorMessage = "Proszę podać miejsce początkowe!")]
        public string MiejscePoczatkowe { get; set; }

        [MinLength(length:3, ErrorMessage = "Miejsce końcowe musi miec co najmniej 3 litery!")]
        [Required(ErrorMessage = "Proszę podać nazwę końcową!")]
        public string MiejsceKoncowe {  get; set; }

        [Required(ErrorMessage = "Uczestnicy sa wymagani")]
        public List<string> Uczestnicy { get; set; }

        [Required(ErrorMessage = "Przewodnik jest wymagany")]
        public string Przewodnik { get; set; }

    }
}

