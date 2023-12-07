using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabSchoolAPI.Models;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Context
{
    public class LabSchoolContext : DbContext
    {
        public LabSchoolContext(DbContextOptions<LabSchoolContext> options) : base(options) { }

        // DbSets para cada modelo
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<AtendimentoModel> Atendimentos { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }
        public DbSet<WhiteLabelModel> WhiteLabels { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações para o modelo Usuario
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.Endereco)
                .WithMany()
                .HasForeignKey(u => u.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.WhiteLabel)
                .WithMany(wl => wl.Usuarios)
                .HasForeignKey(u => u.WhiteLabelId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Atendimento
            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(a => a.Aluno)
                .WithMany()
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(a => a.Pedagogo)
                .WithMany()
                .HasForeignKey(a => a.PedagogoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Avaliacao
            modelBuilder.Entity<AvaliacaoModel>()
                .HasOne(av => av.Aluno)
                .WithMany()
                .HasForeignKey(av => av.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Exercicio
            modelBuilder.Entity<ExercicioModel>()
                .HasOne(ex => ex.Aluno)
                .WithMany()
                .HasForeignKey(ex => ex.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Log
            modelBuilder.Entity<LogModel>()
                .HasOne(l => l.Usuario)
                .WithMany()
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição
        }


    }
}
