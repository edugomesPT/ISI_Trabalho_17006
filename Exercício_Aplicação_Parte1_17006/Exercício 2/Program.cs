/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 2
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Collections;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Exercício_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList descriçoes = LerLocais(@"../../Descriçao.json");

            for(int i=0;i<descriçoes.Count;i++)
            {
                // Para cada local que se encontra no ArrayList descriçoes, vai dessarializar um ficheiro de previsao json para a classe PrevisaoIPMA, para 
                // que seja armazanada a descriçao de cada local, graças ao ArrayList descriçoes
                PrevisaoIPMA previsaoIPMA = LerFicheiroPrevisao(((Descricao)descriçoes[i]).globalIdLocal);

                previsaoIPMA.local = ((Descricao)descriçoes[i]).Local;
                previsaoIPMA.idRegiao = ((Descricao)descriçoes[i]).idRegiao;
                previsaoIPMA.idDistrito = ((Descricao)descriçoes[i]).idDistrito;
                previsaoIPMA.idConcelho = ((Descricao)descriçoes[i]).idConcelho;
                previsaoIPMA.idAreaAviso = ((Descricao)descriçoes[i]).idAreaAviso;
                previsaoIPMA.latitude = ((Descricao)descriçoes[i]).latitude;
                previsaoIPMA.longitude = ((Descricao)descriçoes[i]).longitude;

                // Caso for encontrado o globalIdLocal, vai ser serializado pela classe PrevisaoIPMA para um ficheiro json e xml
                if (previsaoIPMA.globalIdLocal.Equals(previsaoIPMA.globalIdLocal))
                {
                    string aux = Newtonsoft.Json.JsonConvert.SerializeObject(previsaoIPMA, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(@"../../Previsões Detalhe/"+previsaoIPMA.globalIdLocal+"-detalhe.json", aux);

                    XmlSerializer x = new XmlSerializer(previsaoIPMA.GetType());

                    //para ficheiro
                    TextWriter writer = new StreamWriter(@"../../Previsões Detalhe/"+ previsaoIPMA.globalIdLocal +"-detalhe.xml");
                    x.Serialize(writer, previsaoIPMA);
                }
            }

        }

        // <summary>
        /// dessarializar o ficheiro json "Descriçao.json" para a classe PrevisaoJson e armazanar num ArrayList a descriçao de cada local 
        /// </summary>
        static ArrayList LerLocais(string ficheiro)
        {
            string jsonString = null;

            using (StreamReader reader = new StreamReader(ficheiro))
            {
                jsonString = reader.ReadToEnd();
            }

            PrevisaoJson obj = System.Text.Json.JsonSerializer.Deserialize<PrevisaoJson>(jsonString);

            ArrayList descriçoes = new ArrayList();
            // for i=0 para i<29 porque encontram-se 30 locais com a sua respetiva descriçao
            for(int i = 0;i < 29;i++)
            {
                Descricao descricao = new Descricao();
                descricao.idRegiao = obj.data[i].idRegiao;
                descricao.idAreaAviso = obj.data[i].idAreaAviso;
                descricao.idConcelho = obj.data[i].idConcelho;
                descricao.globalIdLocal = obj.data[i].globalIdLocal;
                descricao.latitude = obj.data[i].latitude;
                descricao.idDistrito = obj.data[i].idDistrito;
                descricao.Local = obj.data[i].local;
                descricao.longitude = obj.data[i].longitude;

                descriçoes.Add(descricao);
            }

            return descriçoes;
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
            PrevisaoIPMA obj = System.Text.Json.JsonSerializer.Deserialize<PrevisaoIPMA>(jsonString);
            return obj;
        }
    }
}
