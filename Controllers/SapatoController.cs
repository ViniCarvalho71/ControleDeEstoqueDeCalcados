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
            var sapatos = _context.Sapatos.ToList();
            return View(sapatos);
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
            var sapato = _context.Sapatos.Find(id);
            if (sapato == null){
                return RedirectToAction(nameof(Index));
            }
            return View(sapato);
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

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            // Verifica se o sapato existe no banco de dados
            var sapatoBanco = _context.Sapatos.Find(id);
            if (sapatoBanco == null)
            {
                TempData["ErrorMessage"] = "Sapato não encontrado!";
                return RedirectToAction("Index"); // Redireciona para a página principal
            }

            // Atualiza o status para 0 (baixado do estoque)
            sapatoBanco.Status = 0;
            sapatoBanco.DataAtualizacao = DateTime.Now;
            _context.SaveChanges();

            // Salva uma mensagem de sucesso
            TempData["SuccessMessage"] = "Sapato baixado do estoque com sucesso!";
            return RedirectToAction("Index"); // Redireciona para a página principal
        }

        [HttpPost]
        public IActionResult Desfazer(int id)
        {
            // Verifica se o sapato existe no banco de dados
            var sapatoBanco = _context.Sapatos.Find(id);
            if (sapatoBanco == null)
            {
                TempData["ErrorMessage"] = "Sapato não encontrado!";
                return RedirectToAction("Index"); // Redireciona para a página principal
            }

            // Atualiza o status para 0 (baixado do estoque)
            sapatoBanco.Status = 1;
            sapatoBanco.DataAtualizacao = DateTime.Now;
            _context.SaveChanges();

            // Salva uma mensagem de sucesso
            TempData["SuccessMessage"] = "Sapato baixado do estoque com sucesso!";
            return RedirectToAction("Index"); // Redireciona para a página principal
        }
    }
}