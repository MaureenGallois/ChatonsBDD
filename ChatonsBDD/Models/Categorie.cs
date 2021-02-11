using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatonsBDD.Models
{
    public class Categorie
    {
        //reconnait que c'est la clé grâce au nom Id
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [MaxLength(50)]
        [Required(ErrorMessage ="Le champ est obligatoire")]
        public string Libelle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Chaton> Chatons { get; set; }
    }
}
