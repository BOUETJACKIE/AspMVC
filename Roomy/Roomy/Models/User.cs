using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class User:BaseModel

    {
        [Required(ErrorMessage ="le champs {0} est obligatoire")]
        [Display(Name ="nom")]
        [StringLength(50,MinimumLength =2,
            ErrorMessage ="le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "le champs {0} est obligatoire")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "L'adresse mail n'est pas au bon format")] 
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "le champs {0} est obligatoire")]
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="le champ {0} est obligatoire")]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "le champs {0} est obligatoire")]
        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Erreur de la confirmation du {0}")]
        public string ConfirmedPassword { get; set; }
    }
}