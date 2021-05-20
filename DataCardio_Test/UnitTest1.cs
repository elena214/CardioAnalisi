using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardioLibrary;

namespace DataCardio_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FrequenzaCardiaca1()
        {
            int et‡ = 16;
            int battiti = 79;
            string risultato_aspettato = "La tua frequenza cardiaca Ë sotto controllo!!";
            string risultato_effettivo = DataCardio.FrequenzaCardiaca(et‡, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiaca2()
        {
            int et‡ = 75;
            int battiti = 170;
            string risultato_aspettato = "Rilassati!! Hai la frequenza cardiaca Ë troppo alta";
            string risultato_effettivo = DataCardio.FrequenzaCardiaca(et‡, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaPalestra1()
        {
            int et‡ = 16;
            int battiti = 150;
            string risultato_aspettato = "In base alla tua frequenza cardiaca, l'allenamento Ë efficace";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaPalestra(et‡, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaPalestra2()
        {
            int et‡ = 16;
            int battiti = 200;
            string risultato_aspettato = "In base alla tua frequenza cardiaca, l'allenamento non Ë efficace";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaPalestra(et‡, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaMinMax1()
        {
            int et‡ = 18;
            string risultato_aspettato = "I battiti minimi sono: 141,4; mentre quelli massimi sono: 181,8";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaMaxMin(et‡);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaARiposo1()
        {
            int battiti = 85;
            string risultato_aspettato = "La tua frequenza cardiaca Ë normale";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaARiposo(battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaARiposo2()
        {
            int battiti = 50;
            string risultato_aspettato = "Sei bradicardico/a";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaARiposo(battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaARiposo3()
        {
            int battiti = 150;
            string risultato_aspettato = "Sei tachicardiaco/a";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaARiposo(battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }
        [TestMethod]
        public void SpesaEnergetica1()
        {
            double km = 8;
            double peso = 70;
            string tipologia = "camminata";
            string risultato_aspettato = "Hai speso 280 kcal";
            string risultato_effettivo = DataCardio.SpesaEnergetica(tipologia, peso, km);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }
        [TestMethod]
        public void SpesaEnergetica2()
        {
            double km = 7;
            double peso = 68;
            string tipologia = "corsa";
            string risultato_aspettato = "Hai speso 428,4 kcal";
            string risultato_effettivo = DataCardio.SpesaEnergetica(tipologia, peso, km);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }
        [TestMethod]
        public void CalorieBruciate1()
        {
            int et‡ = 17;
            double peso = 68;
            string categoria = "donna";
            double tempo = 30;
            string risultato_aspettato = "Le tue calorie bruciate sono 41,79";
            string risultato_effettivo = DataCardio.CalorieBruciate(peso, et‡, tempo, categoria);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void CalorieBruciate2()
        {
            int et‡ = 50;
            double peso = 90;
            string categoria = "uomo";
            double tempo = 30;
            string risultato_aspettato = "Le tue calorie bruciate sono 122,33";
            string risultato_effettivo = DataCardio.CalorieBruciate(peso, et‡, tempo, categoria);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void MediaBattiti()
        {
            double risultato_aspettato = 90;
            double risultato_effettivo = DataCardio.MediaBattiti();
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void BattitoCardiacoRiposo1()
        {
            string risultato_aspettato = "Il battito cardiaco a riposo Ë 68";
            string risultato_effettivo = DataCardio.BattitoCardiacoRiposo();
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void Variabilit‡BattitoCardiaco1()
        {
            string risultato_aspettato = "La variabilit‡ del battito cardiaco Ë 54";
            string risultato_effettivo = DataCardio.Variabilit‡BattitoCardiaco();
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }
    }
}
