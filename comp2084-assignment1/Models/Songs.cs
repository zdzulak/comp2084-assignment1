using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comp2084_assignment1.Models
{
    public partial class Songs
    {
        [Key]
        [Column("Song_Id")]
        public int SongId { get; set; }
        [Column("Album_Art")]
        [StringLength(255)]
        public string AlbumArt { get; set; }
        [Required]
        [Column("Song_Name")]
        [StringLength(255)]
        public string SongName { get; set; }
        [StringLength(255)]
        public string Artist { get; set; }
        [Required]
        [Column("Track_Length")]
        [StringLength(255)]
        public string TrackLength { get; set; }
        [Required]
        [Column("Spotify_Link")]
        [StringLength(255)]
        public string SpotifyLink { get; set; }
        [Column("Album_Id")]
        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        [InverseProperty("Songs")]
        public virtual Albums Album { get; set; }
    }
}
