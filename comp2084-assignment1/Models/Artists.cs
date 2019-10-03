using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comp2084_assignment1.Models
{
    public partial class Artists
    {
        public Artists()
        {
            Albums = new HashSet<Albums>();
        }

        [Key]
        [Column("Artist_Id")]
        public int ArtistId { get; set; }
        [Required]
        [Column("Artist_Name")]
        [StringLength(100)]
        public string ArtistName { get; set; }

        [InverseProperty("ArtistNavigation")]
        public virtual ICollection<Albums> Albums { get; set; }
    }
}
