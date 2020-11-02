/*
Exercício de Aplicação Parte 1
Autor: Eduardo Gomes
Número: 17006
Curso: LESI

Exercício 3 a)
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Exercício_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PesquisarButton_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dicLocais = LerLocais(@"../../locais.csv");

            // Apenas para mostrar o conteúdo da estrutura dicinário...
            foreach (KeyValuePair<int, string> kv in dicLocais)
            {
                // Procura do nome do distrito escrito anteriormente no textbox no dicionário
                // Caso encontre irá ao seu ficheiro json e irá aparecer no windows form as suas tags
                if (DistritoTextBox.Text.Equals(kv.Value))
                {
                    string jsonString;

                    jsonString = File.ReadAllText(@"../../Previsões/" + kv.Key + ".json");
                    PrevisaoIPMA previsoes = new PrevisaoIPMA();
                    previsoes = JsonSerializer.Deserialize<PrevisaoIPMA>(jsonString);

                    Dia1Label.Text = previsoes.data[0].forecastDate;
                    Dia2Label.Text = previsoes.data[1].forecastDate;
                    Dia3Label.Text = previsoes.data[2].forecastDate;
                    Dia4Label.Text = previsoes.data[3].forecastDate;
                    Dia5Label.Text = previsoes.data[4].forecastDate;
                    Tmin1Label.Text = (previsoes.data[0].tMin + "°C");
                    Tmin2Label.Text = (previsoes.data[1].tMin + "°C");
                    Tmin3Label.Text = (previsoes.data[2].tMin + "°C");
                    Tmin4Label.Text = (previsoes.data[3].tMin + "°C");
                    Tmin5Label.Text = (previsoes.data[4].tMin + "°C");
                    Tmax1Label.Text = (previsoes.data[0].tMax + "°C");
                    Tmax2Label.Text = (previsoes.data[1].tMax + "°C");
                    Tmax3Label.Text = (previsoes.data[2].tMax + "°C");
                    Tmax4Label.Text = (previsoes.data[3].tMax + "°C");
                    Tmax5Label.Text = (previsoes.data[4].tMax + "°C");
                    Vento1Label.Text = previsoes.data[0].predWindDir;
                    Vento2Label.Text = previsoes.data[1].predWindDir;
                    Vento3Label.Text = previsoes.data[2].predWindDir;
                    Vento4Label.Text = previsoes.data[3].predWindDir;
                    Vento5Label.Text = previsoes.data[4].predWindDir;
                    Precepitação1Label.Text = (previsoes.data[0].precipitaProb + "%");
                    Precepitação2Label.Text = (previsoes.data[1].precipitaProb + "%");
                    Precepitação3Label.Text = (previsoes.data[2].precipitaProb + "%");
                    Precepitação4Label.Text = (previsoes.data[3].precipitaProb + "%");
                    Precepitação5Label.Text = (previsoes.data[4].precipitaProb + "%");
                }

            }
        }

        // <summary>
        /// leitura do ficheiro com a informação acerca dos locais: locais.csv
        /// </summary>
        /// <param name="ficheiro"> caminho ficheiro .csv</param>
        static Dictionary<int, string> LerLocais(string ficheiro)
        {
            Dictionary<int, string> dicLocais = new Dictionary<int, string>();

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
                        string[] campos = m.Value.Split(',');
                        int codLocal = int.Parse(campos[0]);
                        string cidade = campos[5];
                        // Guardar na estrutura de dados dicionário
                        // dicLocais.Add( CHAVE ,  VALOR )
                        dicLocais.Add(codLocal, cidade);
                    }
                    else
                    {
                        Console.WriteLine($"Linha inválida: {line}");
                    }
                }
            }
            return dicLocais;
        }

        private void Tmin2Label_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
