using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest
{
    [TestFixture]
    public class CepTest
    {
        [Test]
        public void DeveSerNull()
        {
            Cep cep;
            Assert.IsNull(cep.ToString());
        }

        [Test]
        public void DeveSerInvalido()
        {
            Assert.Throws<CepInvalidoException>(() =>
            {
                Cep cep = "";
            });

            Assert.Throws<CepInvalidoException>(() =>
            {
                //Cep com menos de 8 caracteres
                Cep cep = "5433221";
            });

            Assert.Throws<CepInvalidoException>(() =>
            {
                //Cep com mais de 8 caracteres
                Cep cep = "543322144";
            });

            Assert.Throws<CepInvalidoException>(() =>
            {
                Cep cep = "54dasd1";
            });
        }

        [Test]
        public void Comparando()
        {
            Cep cepUm = "01001000";
            var cepDois = cepUm;

            Assert.AreEqual(cepUm.CompareTo(cepDois), 0);
        }

        [Test]
        public void DevemSerIguais()
        {
            Cep cepUm = "01001000";
            var cepDois = cepUm;

            Assert.AreEqual(cepUm, cepDois);

            Cep cepTres = "01001-000";
            Assert.AreEqual(cepUm, cepTres);
        }

        [Test]
        public void DeveEstarVazio()
        {
            Assert.True(new Cep().IsEmpty);
        }
    }
}