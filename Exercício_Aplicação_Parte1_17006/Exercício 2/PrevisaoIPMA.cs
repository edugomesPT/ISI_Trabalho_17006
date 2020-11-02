/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 2
*/
using System;
/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 2
*/
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_2
{
    public class PrevisaoIPMA
    {
        public string owner { get; set; }
        public string country { get; set; }
        public Previsoes[] data { get; set; }
        public int globalIdLocal { get; set; }
        public DateTime dataUpdate { get; set; }
        public int idRegiao { get; set; }
        public int idConcelho { get; set; }
        public int idDistrito { get; set; }
        public string idAreaAviso { get; set; }
        public string local { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
