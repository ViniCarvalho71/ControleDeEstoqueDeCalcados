using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoqueDeCalcados.Context;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueDeCalcados.Controllers
{
    public class SapatoController : Controller
    {
        private readonly FabricaContext _context;

        public SapatoController(FabricaContext context){
            _context = context;
        }
    }
}