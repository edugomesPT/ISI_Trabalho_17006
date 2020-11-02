/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 2
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_2
{
    public class PrevisaoJson
    {
        public string owner { get; set; }
        public string country { get; set; }
        public Data[] data { get; set; }
    }
}
