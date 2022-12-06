using System;
using System.Collections.Generic;

namespace AppEmergencia.Models.ML
{
    public class emergencia_resumenModel
    {        
        public int id { get; set; }
        public long idFechaHora { get; set; }
        public decimal Ambulancia { get; set; }
        public decimal Bomberos { get; set; }
        public decimal Emergencia { get; set; }
        public decimal Policia { get; set; }
        public decimal Ruido { get; set; }
        public decimal Transito { get; set; }
        public string MoyorLabel { get; set; }
        public decimal MayorValor { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
    }

    public class Dataemergencia_resumenModel
    {
        public List<emergencia_resumenModel> data { get; set; }
    }
}
