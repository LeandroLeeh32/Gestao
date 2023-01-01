using System;
using System.Collections.Generic;
using Gestao.Domain.Entities;
using Gestao.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Infra.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseNpgsql("Server=localhost; Database=Gestao_unificada; user id=postgres; password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
 
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
