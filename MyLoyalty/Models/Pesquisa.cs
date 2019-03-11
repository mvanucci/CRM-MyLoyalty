using MyLoyalty.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLoyalty.Models
{
    public class Pesquisa
    {
        public int id { get; set; }
        [Display(Name = "Nota de Atendimento")]
        [Range(0,10, ErrorMessage = "Deve ser preenchido com os valores entre 0 e 10")]
        public int atendimento { get; set; }

        [Display(Name = "Nota para o vendedor")]
        [Range(0, 10, ErrorMessage = "Deve ser preenchido com os valores entre 0 e 10")]
        public int notaVendedor { get; set; }

        [Display(Name = "Nota da Loja")]
        [Range(0, 10, ErrorMessage = "Deve ser preenchido com os valores entre 0 e 10")]
        public int status { get; set; }

        [Display(Name = "Aceitação do produto")]
        [Range(0, 10, ErrorMessage = "Deve ser preenchido com os valores entre 0 e 10")]
        public int accProduto { get; set; }

        public int resp { get; set; }

        public Cliente cliente { get; set; }

        public Pesquisa() { }

        public Pesquisa(int id, int atendimento, int notaVendedor, int status, int accProduto, int resp ,Cliente cliente)
        {
            this.id = id;
            this.atendimento = atendimento;
            this.notaVendedor = notaVendedor;
            this.status = status;
            this.accProduto = accProduto;
            this.resp = resp;
            this.cliente = cliente;
        }
    }
}
