//using Microsoft.EntityFrameworkCore;
//using stripe.Models;
//using System;
//using System.Collections.Generic;
////using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;

//namespace stripe.Domain
//{
//    public class DbCtx:DbContext
//    {
//        public DbCtx()  
//        {

//        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder
//                .UseSqlServer(@"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=PaymentDemo;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\PaymentDemo.mdf");
//        }
//        public DbSet<PaymentStatus> Status { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<PaymentStatus>().HasKey(p=>p.Id);
//            base.OnModelCreating(modelBuilder); 
//        }
//    }
//}
