using System;

namespace CardioLibrary
{
    public class DataCardio
    {
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
    }
}
