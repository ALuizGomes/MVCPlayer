using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCPlayer.Models;

    public class MVCPlayerContext : DbContext
    {
        public MVCPlayerContext (DbContextOptions<MVCPlayerContext> options)
            : base(options)
        {
        }

        public DbSet<MVCPlayer.Models.Movie>? Movie { get; set; }

        public DbSet<MVCPlayer.Models.Studio>? Studio { get; set; }
    }
