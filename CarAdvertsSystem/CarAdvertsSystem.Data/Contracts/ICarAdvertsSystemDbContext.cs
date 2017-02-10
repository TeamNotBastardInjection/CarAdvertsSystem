﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Contracts
{
    public interface ICarAdvertsSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
