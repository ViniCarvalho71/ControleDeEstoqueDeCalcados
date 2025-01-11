using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeEstoqueDeCalcados.Models;

namespace ControleDeEstoqueDeCalcados.Context
{
    public class FabricaContext : DbContext
    {
        public FabricaContext(DbContextOptions<FabricaContext> options) : base(options){

        }

        public DbSet<Sapato> Sapatos {get; set;}
    }
}