using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMAPLUS.Models
{
    public class Empleado
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public int Hours { get; set; }
        public int Sal { get; set; }
        public Boolean Estadia { get; set; }
        public List<Cita> Citas { get; set; }
    }
}