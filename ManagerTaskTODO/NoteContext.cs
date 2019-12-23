using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ManagerTaskTODO
{
    public class NoteContext : DbContext
    {
        public NoteContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-82L5RVF8;Database=NoteDb1;Trusted_Connection=true;");
        }
    }
}
