namespace mysqltry1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mtest.athathlete")]
    public partial class athathlete
    {
        public int athAthleteID { get; set; }

        [StringLength(250)]
        public string athAthleteName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? athAthleteHmGennisis { get; set; }

        public int? athGenderID { get; set; }

        public decimal? athAthleteEtiProponisis { get; set; }

        [StringLength(250)]
        public string athAthleteAgonisma { get; set; }

        public int? athFootID { get; set; }

        [StringLength(250)]
        public string athAthleteAddress { get; set; }

        [StringLength(20)]
        public string athAthleteTelephone1 { get; set; }

        [StringLength(20)]
        public string athAthleteTelephone2 { get; set; }

        [StringLength(150)]
        public string athAthleteEmail { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string athAthleteTraumatismoi { get; set; }
    }
}
