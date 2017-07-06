using MosaicoSolutions.ViaCep.Modelos;
using NUnit.Framework;

namespace ViaCepTest.MosaicoSolutions.ViaCep.Teste.Modelos
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
            #pragma warning disable 219
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
            #pragma warning restore 219
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
            
            Assert.True(cepUm.Equals(cepTres));
        }

        [Test]
        public void DeveEstarVazio() => Assert.True(new Cep().IsEmpty);

        [Test]
        public void CepDeveEstarFormatado() => Assert.AreEqual(Cep.Of("01001000").Formatado(), "01001-000");

        [Test]
        public void TestandoARegex()
        {
            var pattern = Cep.Pattern;

            Assert.True(pattern.IsMatch("00000000"));
            Assert.True(pattern.IsMatch("00000-000"));
            Assert.False(pattern.IsMatch("0=0000000"));
        }
    }
}