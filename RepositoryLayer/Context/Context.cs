using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users
        {
            get; set;
        }
        public DbSet<Notes> notesTable
        {
            get; set;
        }

        public DbSet<Collaborator> Collaborator
        {
            get;
            set;
        }

        public DbSet<Label> Labels
        {
            get; set;
        }
         //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Collaborator>()
        //        .HasKey(x => new {  x.NotesId, x.Id });
        //    modelBuilder.Entity<Collaborator>()
        //        .HasOne(x => x.notes)
        //        .WithMany(x => x.collaborators)
        //        .HasForeignKey(x => x.NotesId);
        //    modelBuilder.Entity<Collaborator>()
        //        .HasOne(x => x.User)
        //        .WithMany(x => x.collaborators)
        //        .HasForeignKey(x => x.Id);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborator>()
                .HasKey(e => new { e.NotesId, e.Id });
            modelBuilder.Entity<Collaborator>()
                .HasOne(e => e.notes)
                .WithMany(e => e.collaborators)
                .HasForeignKey(e => e.NotesId);
            modelBuilder.Entity<Collaborator>()
                .HasOne(e => e.User)
                .WithMany(e => e.collaborators)
                .HasForeignKey(e => e.Id);



        }
    }
}

    
