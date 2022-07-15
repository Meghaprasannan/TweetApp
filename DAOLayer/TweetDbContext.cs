using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using test.DAOLayer.Entities;

namespace test.DAOLayer
{
    public class TweetDbContext : DbContext
    {
        public DbSet<UserDetails> Users { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserLogin> LoginDetails { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=CTSDOTNET514;Database=TweetTestDb;Trusted_Connection=True;MultipleActiveResultSets=True;uid=sa;password=pass@word1;Integrated Security=False");
        }
    }
}
