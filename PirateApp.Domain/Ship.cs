using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PirateApp.Domain
{
    [Table("Ship")]
    public class Ship
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public int Power { get; set; }

        public int HowManyPeopleCanTake { get; set; }

        [NotMapped]
        public bool Notneeded { get; set; }
    }
}
