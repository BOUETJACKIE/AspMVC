﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Models
{
    public class Room:BaseModel
    {
        [Required(ErrorMessage ="le champ {0} est obligatoire")]
        [StringLength(50)]
        [Display(Name ="Libellé")]
        public string Name { get; set; }

        [Required(ErrorMessage = "le champ {0} est obligatoire")]
        [Display(Name ="Nombre de place")]
        [Range(0,50)]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "le champ {0} est obligatoire")]
        [Display(Name = "Tarif")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }


        [Required(ErrorMessage = "le champ {0} est obligatoire")]
        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dddd dd MMMM yyyy}")]
        public DateTime CreatedAt { get; set; }


        [Display(Name="Utilisateur")]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [Display(Name = "Categorie")]
        public int CategorieID { get; set; }

        [ForeignKey("CategorieID")]
        public Categorie Categorie { get; set; }

        public ICollection <RoomFile> Files { get; set; }

    }
}