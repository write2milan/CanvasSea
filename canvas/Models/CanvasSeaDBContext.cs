using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace canvas.Models
{
    public class CanvasSeaDBContext : DbContext
    {
        public DbSet<FoodModel> food { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CanvasSeaDBContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FoodModel>().ToTable(""); 
            modelBuilder.Entity<FoodModel>().HasKey(x => x.ID);
        }
    }
}