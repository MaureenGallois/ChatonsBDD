using System;
using System.ComponentModel.DataAnnotations;

namespace ChatonsBDD.Models
{
    public class Categorie
    {
        //reconnait que c'est la clé grâce au nom Id
        public int Id { get; set; }

        [MaxLength(50)]
        public string Libelle { get; set; }
        public string Description { get; set; }
    }
}
