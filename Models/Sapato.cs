using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueDeCalcados.Models
{
    public class Sapato
    {
        public int Id { get; set; }
        public string CodBarras { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }

        public int Tamanho { get; set; }
        public int Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DataAtualizacao { get; set; }
    }
}