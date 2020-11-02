/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 1
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections;

namespace Exercício_Aplicação_Parte1_17006
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList dicLocais = LerLocais(@"../../locais.csv");

            for(int i =0;i<dicLocais.Count;i++)
            {
                PrevisaoIPMA previsaoIPMA = LerFicheiroPrevisao(((Descriçao)dicLocais[i]).globalIdLocal);

                // Depois de dessarializar um ficheiro json encontrado, vai-se atribuir valores aos objetos da classe PrevisaoIPMA graças ao ArrayList diclocais
                previsaoIPMA.local = ((Descriçao)dicLocais[i]).Local;
                previsaoIPMA.idRegiao = ((Descriçao)dicLocais[i]).idRegiao;
                previsaoIPMA.idDistrito = ((Descriçao)dicLocais[i]).idDistrito;
                previsaoIPMA.idConcelho = ((Descriçao)dicLocais[i]).idConcelho;
                previsaoIPMA.idAreaAviso = ((Descriçao)dicLocais[i]).idAreaAviso;

                // Caso for encontrado o globalIdLocal, vai ser serializado pela classe PrevisaoIPMA para um ficheiro json
                if (previsaoIPMA.globalIdLocal.Equals(1110600))
                {
                    string aux = Newtonsoft.Json.JsonConvert.SerializeObject(previsaoIPMA, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(@"../../1110600-detalhe.json", aux);
                }
            }

        }

        // <summary>
        /// leitura do ficheiro com a informação acerca dos locais: locais.csv
        /// </summary>
        /// <param name="ficheiro"> caminho ficheiro .csv</param>
        static ArrayList LerLocais(string ficheiro)
        {
            ArrayList dicLocais = new ArrayList();

            // Expressão Regular para instanciar objeto Regex
            String erString = @"^[0-9]{7},[123],([1-9]?\d,){2}[A-Z]{3},([^,\n]*)$";

            // Processar o conteúdo do ficheiro
            // Depois de ler o conteúdo do ficheiro para uma stream, vai acedendo "linha-a-linha"
            Regex g = new Regex(erString);
            using (StreamReader r = new StreamReader(ficheiro))
            {
                string line;

                while ((line = r.ReadLine()) != null)
                {
                    // Tenta correspondência (macthing) da ER com cada linha do ficheiro
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        // estrutura de cada linha com correspondência:
                        // globalIdLocal,idRegiao,idDistrito,idConcelho,idAreaAviso,local
                        // separar pelas vírgulas...
                        Descriçao descriçao = new Descriçao();
                        string[] campos = m.Value.Split(',');
                        int codLocal = int.Parse(campos[0]);
                        int idRegiao = int.Parse(campos[1]);
                        int idDistrito = int.Parse(campos[2]);
                        int idConcelho = int.Parse(campos[3]);
                        string idAreaAviso = campos[4];
                        string cidade = campos[5];
                        descriçao.globalIdLocal = codLocal;
                        descriçao.idRegiao = idRegiao;
                        descriçao.idDistrito = idDistrito;
                        descriçao.idConcelho = idConcelho;
                        descriçao.idAreaAviso = idAreaAviso;
                        descriçao.Local = cidade;
                        // Adicionar no ArrayList a descrição de um dado local
                        dicLocais.Add(descriçao);
                    }
                    else
                    {
                        Console.WriteLine($"Linha inválida: {line}");
                    }
                }
            }
            return dicLocais;
        }

        // <summary>
        /// Para cada globalIdLocal do ArrayList diclocais vai ao respetivo ficheiro json com o objetivo desserializar para a classe PrevisaoIPMA
        /// </summary>
        static PrevisaoIPMA LerFicheiroPrevisao(int globalIdLocal)
        {
            String jsonString = null;
            using (StreamReader reader =
                       new StreamReader(@"../../Previsões/" + globalIdLocal + ".json"))
            {
                jsonString = reader.ReadToEnd();
            }
            PrevisaoIPMA obj = JsonSerializer.Deserialize<PrevisaoIPMA>(jsonString);
            return obj;
        }

    }    
}
