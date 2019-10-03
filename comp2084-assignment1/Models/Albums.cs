using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comp2084_assignment1.Models
{
    public partial class Albums
    {
        public Albums()
        {
            Songs = new HashSet<Songs>();
        }

        [Key]
        [Column("Album_Id")]
        public int AlbumId { get; set; }
        [Column("Album_Art")]
        [StringLength(255)]
        public string AlbumArt { get; set; }
        [Required]
        [Column("Album_Name")]
        [StringLength(255)]
        public string AlbumName { get; set; }
        [Column("Artist_Id")]
        public int ArtistId { get; set; }
        [Column("Release_Year")]
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }

        [ForeignKey("ArtistId")]
        [InverseProperty("Albums")]
        public virtual Artists Artist { get; set; }
        [InverseProperty("Album")]
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
