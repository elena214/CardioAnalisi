using System;
using System.Collections.Generic;
using System.IO;

namespace CardioLibrary
{
    public class DataCardio
    {
        private static List<string> dati = new List<string>();

        public static string FrequenzaCardiaca(int età, int battiti)
        {
            int frequeMax = 220 - età;
            
            if (battiti > frequeMax)
            {
                return "Rilassati!! Hai la frequenza cardiaca troppo alta";
            }
            else
            {
                return "La tua frequenza cardiaca è sotto controllo!!";
            }
        }

        public static string FrequenzaCardiacaPalestra(int età, int battiti)
        {
            int frequeMax = 220 - età;
            double freque70 = 0.7 * frequeMax;
            double freque90 = 0.9 * frequeMax;
            if (battiti >= freque70 && battiti <= freque90)
            {
                return "L'allenamento è efficace";
            }
            else
            {
                return "L'allenamento non è efficace";
            }
        }
        public static string FrequenzaCardiacaMaxMin(int età)
        {
            int frequeMax = 220 - età;
            double freque70 = 0.7 * frequeMax;
            double freque90 = 0.9 * frequeMax;

            freque70 = Math.Round(freque70, 1);
            freque90 = Math.Round(freque90, 1);

            return $"minimi sono: {freque70}; mentre quelli massimi sono: {freque90}";
        }
        public static string FrequenzaCardiacaARiposo(int battiti)
        {
            if (battiti < 60)
            {
                return "Sei bradicardico/a";
            }
            else if (battiti >= 60 && battiti <= 100)
            {
                return "La tua frequenza cardiaca è normale";
            }
            else
            {
                return "Sei tachicardiaco/a";
            }
        }
        public static string SpesaEnergetica(string tipologia, double peso, double km)
        {
            double corsa = (0.9 * km) * peso;
            double camminata = (0.50 * km) * peso;

            if (tipologia == "corsa")
            {
                return $"Hai speso {corsa} kcal";
            }
            else if (tipologia == "camminata")
            {
                return $"Hai speso {camminata} kcal";
            }
            else
            {
                return "La risposta non è valida";
            }
        }
        public static string CalorieBruciate(double peso, int età, double tempo, string categoria)
        {
            double kcaUomo = ((età * 0.2017) + (peso * 0.199) + (70 * 0.6309) - 55.0969) * (tempo / 4.184);
            double kcaDonna = ((età * 0.074) - (peso * 0.126) + (75 * 0.4472) - 20.4022) * (tempo / 4.184);

            if (categoria == "uomo")
            {
                return $"Le tue calorie bruciate sono {Math.Round(kcaUomo, 2)}";
            }
            else
            {
                return $"Le tue calorie bruciate sono {Math.Round(kcaDonna, 2)}";
            }
        }

        public static void LetturaFileTesto()
        {
            StreamReader streamLettura = new StreamReader(@"\DatiAnalisi.txt");
            string line;

            do
            {
                line = streamLettura.ReadLine();
                if (line != null)
                {
                    dati.Add(line);
                }

            } while (line != null);

            streamLettura.Close();
        }

        public static double MediaBattiti()
        {
            List<double> dati2 = new List<double>();

            //for (int i = 0; i < dati.Count; i++)
            //{
            //    dati2[i] = Convert.ToDouble(dati);
            //}

            foreach (string item in dati)
            {
                dati2.Add(Convert.ToDouble(item));
            }

            double somma = 0;
            foreach (var item in dati2)
            {
                somma += item;
            }
            double media = somma / dati2.Count;

            return media;
        }
    }
}
