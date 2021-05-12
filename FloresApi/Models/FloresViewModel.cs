using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloresApi.Models
{
    public class FloresViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public string Relleno { get; set; }
        public int Paqueteagranel { get; set; }
        public double Longituddeltallo { get; set; }
        public double Talloracimo { get; set; }
        public string Comentarios { get; set; }
        //public byte[] Picture { get; set; }
    }
}