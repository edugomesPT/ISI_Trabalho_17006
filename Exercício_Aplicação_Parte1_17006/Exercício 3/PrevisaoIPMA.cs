/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 3 a)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_3
{
    public class PrevisaoIPMA
    {
        public string owner { get; set; }
        public string country { get; set; }
        public PrevisaoDia[] data { get; set; }
        public int globalIdLocal { get; set; }
        public DateTime dataUpdate { get; set; }

        // ---- 
        public string local { get; set; }
    }
}
