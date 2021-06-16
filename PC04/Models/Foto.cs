using System;
using System.Collections;

namespace PC04.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string URL { get; set; }
        public string Usuario { get; set; }
        public string Fecha { get; set; }
        public string IdComentarios { get; set; }
    }
}