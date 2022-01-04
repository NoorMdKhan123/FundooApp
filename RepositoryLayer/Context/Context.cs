using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public class Context:DbContext
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


    }
}

    
