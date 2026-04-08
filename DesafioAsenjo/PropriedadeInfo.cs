using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorClasses
{
    public class PropriedadeInfo
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public PropriedadeInfo(string nome, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{Tipo} {Nome}";
        }
    }
}