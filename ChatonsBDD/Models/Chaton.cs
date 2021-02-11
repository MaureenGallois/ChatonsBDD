using System;
using System.ComponentModel.DataAnnotations;

namespace ChatonsBDD.Models
{
    public class Chaton
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }

        //int? c'est un Nullable<int>
        [Display(Name = "Année de naissance")]
        [Range(2000,2031)]
        public int? AnneeDeNaissance { get; set; }

        [Required]
        [Display(Name = "Catégorie")]
        public virtual Categorie Categorie { get; set; }
    }
}
