using System;
using System.Collections.Generic;

namespace ExamenKevinAPI.Models
{
    public partial class Activo
    {
        public int Idactivo { get; set; }
        public string NombreActivo { get; set; } = null!;
        public string? NumeroSerie { get; set; }
        public decimal CostoActivo { get; set; }
        public string? Descripcion { get; set; }
        public string Ubicacion { get; set; } = null!;
        public string Responsable { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public bool? EstadoActivo { get; set; }
    }
}
