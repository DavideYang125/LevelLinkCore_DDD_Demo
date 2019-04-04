using LevelLinkCore.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LevelLinkCore.Domain.Model
{
    [Table("regions")]
    public partial class Region:AggregateRoot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int CityId { get; set; }

        [StringLength(50, ErrorMessage = "the length of name must less than 50")]
        public string Name { get; set; }

        public string Unique { get; set; }
    }
}
