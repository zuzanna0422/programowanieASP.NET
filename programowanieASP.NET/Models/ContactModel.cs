using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace programowanieASP.NET.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz podac imie!")]
    [MaxLength(length: 20, ErrorMessage = "Imie nie moze byc dluzsze niz 20 znakow")]
    [MinLength(length: 2)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz podac imie!")]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko nie moze byc dluzsze niz 50 znakow")]
    [MinLength(length: 2)]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    [Phone]
    [RegularExpression(pattern:"\\d\\d\\d \\d\\d\\d \\d\\d\\d",
        ErrorMessage = "Napisz numer wedlug wzoru xxx: xxx xxx xx")]
    public string PhoneNumber { get; set; }
}