using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exercício_3B
{
    public class Temperatura
    {
        public string tmin { get; set; }
        public string tmax { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}
