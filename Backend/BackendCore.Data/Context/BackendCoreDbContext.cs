﻿using BackendCore.Data.Configuration;
using BackendCore.Data.DataInitializer;
using BackendCore.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendCore.Data.Context
{
    public class BackendCoreDbContext : DbContext
    {
        private readonly IDataInitializer _dataInitializer;
        public BackendCoreDbContext(DbContextOptions<BackendCoreDbContext> options, IDataInitializer dataInitializer) : base(options)
        {
            _dataInitializer = dataInitializer;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Gateway> Gateways { get; set; }
        public virtual DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuration
            modelBuilder.ApplyConfiguration(new GatewayConfig());
            modelBuilder.ApplyConfiguration(new DeviceConfig());
            #endregion

            #region Seed

            modelBuilder.Entity<Role>().HasData(_dataInitializer.SeedRoles());
            modelBuilder.Entity<User>().HasData(_dataInitializer.SeedUsers());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
