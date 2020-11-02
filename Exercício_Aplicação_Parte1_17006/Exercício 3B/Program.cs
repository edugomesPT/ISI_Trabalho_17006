/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 3 b)
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Collections;

namespace Exercício_3B
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> dicLocais = LerLocais(@"../../Descriçao.json");

            // Apenas para mostrar o conteúdo da estrutura dicinário...
            foreach (KeyValuePair<int, string> kv in dicLocais)
            {
                // para cada linha do ficheiro CSV ... 
                PrevisaoIPMA previsaoIPMA = LerFicheiroPrevisao(kv.Key);

                previsaoIPMA.local = kv.Value;

                Console.WriteLine("Local: " + previsaoIPMA.local);
            }

            Console.ReadKey();
        }

        // <summary>
        /// leitura do ficheiro com a informação acerca dos locais: locais.csv
        /// </summary>
        /// <param name="ficheiro"> caminho ficheiro .csv</param>
        static Dictionary<int,string> LerLocais(string ficheiro)
        {
            Dictionary<int,string> dicLocais = new Dictionary<int, string>();

            string jsonString = null;

            using (StreamReader reader = new StreamReader(ficheiro))
            {
                jsonString = reader.ReadToEnd();
            }

            Previsao obj = System.Text.Json.JsonSerializer.Deserialize<Previsao>(jsonString);

            for(int i =0;i<29;i++)
            {
                dicLocais.Add(obj.data[i].globalIdLocal, obj.data[i].local);
            }

            return dicLocais;
        }

        static PrevisaoIPMA LerFicheiroPrevisao(int globalIdLocal)
        {
            String jsonString = null;
            using (StreamReader reader =
                       new StreamReader(@"../../Previsoes/" + globalIdLocal + ".json"))
            {
                jsonString = reader.ReadToEnd();
            }
            PrevisaoIPMA obj = JsonSerializer.Deserialize<PrevisaoIPMA>(jsonString);
            return obj;
        }
    }
}
