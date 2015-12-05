using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.SancionesJugador
{
    public class SancionesJugador
    {
        [Display(Name = "idSancionJugador")]
        public int idSancionJugador { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "idJugador")]
        public int idJugador { get; set; }
        [StringLength(50)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "multa")]
        public decimal multa { get; set; }
        [Display(Name = "idCategoria_Sancion")]
        public int? idCategoria_Sancion { get; set; }
        [Display(Name = "idArbitro")]
        public int? idArbitro { get; set; }
    }
}