using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoqueDeCalcados.Context;
using ControleDeEstoqueDeCalcados.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueDeCalcados.Controllers
{
    public class SapatoController : Controller
    {
        private readonly FabricaContext _context;

        public SapatoController(FabricaContext context){
            _context = context;
        }

        public IActionResult Index(){
            var sapato = _context.Sapatos.ToList();
            return View(sapato);
        }
        public IActionResult Criar(){
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Sapato sapato){
            if(ModelState.IsValid){
                sapato.DataAtualizacao = DateTime.Now;
                _context.Sapatos.Add(sapato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sapato);
        }

         public IActionResult Editar(int id){
            var contato = _context.Sapatos.Find(id);
            if (contato == null){
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Sapato sapato){
            var sapatoBanco = _context.Sapatos.Find(sapato.Id);

            sapatoBanco.Tipo = sapato.Tipo;
            sapatoBanco.Cor = sapato.Cor;
            sapatoBanco.Preco = sapato.Preco;
            sapatoBanco.CodBarras = sapato.CodBarras;
            sapatoBanco.Tamanho = sapato.Tamanho;
            sapatoBanco.DataAtualizacao = DateTime.Now;

            _context.Sapatos.Update(sapatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}