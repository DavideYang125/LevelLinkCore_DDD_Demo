using LevelLinkCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Infrastructure
{
    public class LevelLinkContext:DbContext
    {
        public IConfiguration Configuration { get; }
        public LevelLinkContext()
           : base()
        {
        }
        private static ILoggerFactory Mlogger => new LoggerFactory();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<CityInfo> ProvinceInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //配置连接字符串
            optionsBuilder.UseMySql("server=;user id=root;password=;database=level_link_core_dev;");
        }
    }
}
