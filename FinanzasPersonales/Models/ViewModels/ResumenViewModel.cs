using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanzasPersonales.Models.ViewModels
{
    public class ResumenViewModel
    {
        public  Categoria Categoria{ get; set; }
        public decimal? Gasto { get; set; }
        public decimal? Ingreso { get; set; }
    }
}