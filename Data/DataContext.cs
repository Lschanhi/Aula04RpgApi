using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models.Emuns;
using Microsoft.EntityFrameworkCore.Diagnostics;



namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Personagem> TB_PERSONAGENS { get; set; }

        public DbSet<Armas> TB_ARMAS {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");
            modelBuilder.Entity<Armas>().ToTable("TB_ARMAS");   

            modelBuilder.Entity<Personagem>().HasData
            (
                new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
                new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
                new Personagem() { Id = 3, Nome = "Galadriel", PontosVida= 110, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
                new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=105, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
                new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
                new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=150, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
                new Personagem() { Id = 7, Nome = "Radagast", PontosVida=200, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }

            ) ;

            
            modelBuilder.Entity<Armas>().HasData
            (
                new Armas (){id = 1, nome = "Anduril" , dano = 10},
                new Armas (){id = 2, nome = "Sting", dano  = 50},
                new Armas (){id = 3, nome = "Glamdring", dano = 150},
                new Armas (){id = 4, nome = "Orcrist", dano = 200},
                new Armas (){id = 5, nome = "Grond", dano =  80},
                new Armas (){id = 6, nome = "Axe of Gimli", dano = 99},
                new Armas (){id = 7, nome = "Espada Dos Nazgul", dano = 60}
            );
        }

        

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }





    }
}