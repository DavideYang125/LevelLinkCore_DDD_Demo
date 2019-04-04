using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Domain.Model;
using LevelLinkCore.Infrastructure;
using LevelLinkCore.InfrastructureTest.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.InfrastructureTest
{
    public class UnitOfWork :IUnitOfWork
    {
        private LevelLinkContext _context = new LevelLinkContext();
        private IProvinceRepository provinceRepository;
        private Domain.IRepositories.ICityRepository cityRepository;
        //private readonly TDbContext _dbContext;
        public IProvinceRepository ProvinceRepository
        {
            get
            {

                if (this.provinceRepository == null)
                {
                    this.provinceRepository = new ProvinceRepository(_context);
                }
                return provinceRepository;
            }
        }
        public ICityRepository CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new CityRepository(_context);
                }
                return cityRepository;
            }
        }


        //public UnitOfWork(TDbContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
