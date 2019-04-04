using LevelLinkCore.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LevelLinkCore.Domain.Model
{
    [Table("city_info")]
    public class CityInfo:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 人口
        /// </summary>
        public double Population { get; set; }

        [Column("gdp_size")]
        /// <summary>
        /// GDP大小
        /// </summary>
        public double GdpSize { get; set; }
    }
}
