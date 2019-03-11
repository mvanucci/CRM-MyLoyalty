using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLoyalty.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Cliente cliente { get; set; }
        public Produto pdt { get; set; }
        public ICollection<Produto> produtos { get; set; } = new List<Produto>();
        public List<SelectListItem> options { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> generos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> tipos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> tamanhos { get; set; } = new List<SelectListItem>();

    }
}
