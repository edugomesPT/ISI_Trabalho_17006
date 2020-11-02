/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 1
*/
using System;

namespace Exercício_Aplicação_Parte1_17006
{
    public class PrevisaoIPMA
    {
        public string owner { get; set; }
        public string country { get; set; }
        public PrevisaoDia[] data { get; set; }
        public int globalIdLocal { get; set; }
        public DateTime dataUpdate { get; set; }
        public int idRegiao { get; set; }
        public int idConcelho { get; set; }
        public int idDistrito { get; set; }
        public string idAreaAviso { get; set; }
        public string local { get; set; }
    }
}
