using LevelLinkCore.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LevelLinkCore.Domain.Model
{
    [Table("provinces")]
    public partial class Province:AggregateRoot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "the length of name must less than 50")]
        public string Name { get; set; }

        [Column("city_count")]
        public int CityCount { get; set; }

        public string Unique { get; set; }
    }
}
