﻿using System;
using System.Threading.Tasks;
using Cik.CoreLibs.Domain;
using Cik.Services.Magazine.MagazineService.Model;
using Microsoft.EntityFrameworkCore;

namespace Cik.Services.Magazine.MagazineService.Repository
{
    public class CategoryRepository : IRepository<Category, Guid>
    {
        private readonly MagazineDbContext _dbContext;

        public CategoryRepository(MagazineDbContext dbContext)
        {
            Guard.NotNull(dbContext);

            _dbContext = dbContext;
        }

        public DbContext UnitOfWork => _dbContext;

        public async Task<Guid> Create(Category cat)
        {
            cat.CreatedDate = DateTime.UtcNow;
            cat.CreatedBy = "thangchung";
            _dbContext.Categories.Add(cat);
            return await Task.FromResult(cat.Id);
        }
    }
}