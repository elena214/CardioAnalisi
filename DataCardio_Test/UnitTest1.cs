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
            int et� = 16;
            int battiti = 79;
            string risultato_aspettato = "La tua frequenza cardiaca � sotto controllo!!";
            string risultato_effettivo = DataCardio.FrequenzaCardiaca(et�, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiaca2()
        {
            int et� = 75;
            int battiti = 170;
            string risultato_aspettato = "Rilassati!! Hai la frequenza cardiaca troppo alta";
            string risultato_effettivo = DataCardio.FrequenzaCardiaca(et�, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaPalestra1()
        {
            int et� = 16;
            int battiti = 150;
            string risultato_aspettato = "L'allenamento � efficace";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaPalestra(et�, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }

        [TestMethod]
        public void FrequenzaCardiacaPalestra2()
        {
            int et� = 16;
            int battiti = 200;
            string risultato_aspettato = "L'allenamento non � efficace";
            string risultato_effettivo = DataCardio.FrequenzaCardiacaPalestra(et�, battiti);
            Assert.AreEqual(risultato_aspettato, risultato_effettivo);
        }
    }
}
