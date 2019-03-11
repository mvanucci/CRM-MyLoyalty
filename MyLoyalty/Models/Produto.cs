using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLoyalty.Models
{
    public class Produto
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string nome { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Tipo deve ser preenchido")]
        public string tipo { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código deve ser preenchido")]
        public int codigo { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "Cor deve ser preenchido")]
        public string cor { get; set; }

        [Display(Name = "Tamanho")]
        [Required(ErrorMessage = "Tamanho deve ser preenchido")]
        public int tamanho { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Genero deve ser preenchido")]
        public string genero { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        [Required(ErrorMessage = "Quantidade deve ser preenchido")]
        public int estoque { get; set; }

        public ICollection<Cliente> cliente { get; set; }

        public Produto() {}

        public Produto(int id, string nome, string tipo, int codigo, string cor, int tamanho, string genero, int estoque)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.codigo = codigo;
            this.cor = cor;
            this.tamanho = tamanho;
            this.genero = genero;
            this.estoque = estoque;
        }

        public void addClient(Cliente client) { cliente.Add(client); }
        public void dellClient(Cliente client) { cliente.Remove(client); }
    }
}
