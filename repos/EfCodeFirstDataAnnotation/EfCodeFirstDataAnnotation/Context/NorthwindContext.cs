using EfCodeFirstDataAnnotation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCodeFirstDataAnnotation.Context
{
public class NorthwindContext:DbContext
    {
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
    }
}
