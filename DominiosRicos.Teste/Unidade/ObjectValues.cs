using DominiosRicos.Dominio.ValueObjects;
using System;
using Xunit;

namespace DominiosRicos.Teste.Unidade
{
    public class ObjectValues
    {
        [Fact]
        public void DataValida()
        {
            Data data = new Data(new DateTime(2009, 6, 13));
            Console.WriteLine(data.Notifications);
            Assert.True(data.Valid);
        }

        [Fact]
        public void DataForaDePeriodo()
        {
            Data data = new Data(new DateTime(1991, 6, 13));
            Console.WriteLine(data.Notifications);
            Assert.False(data.Valid);
        }

        [Fact]
        public void DataString()
        {
            Data data = new Data("31/12/2019");
            Console.WriteLine(data.Notifications);
            Assert.True(data.Valid);
        }

        [Fact]
        public void DataConvertida()
        {
            Data data = new Data(new DateTime(1991, 6, 13));
            Console.WriteLine(data.Notifications);
            Assert.Equal("13/06/1991", data.ToString());
        }

        [Fact]
        public void DocumentoCPF()
        {
            var documeto = new Documento("10467469601");
            Console.WriteLine(documeto.Notifications);
            Assert.Equal(Dominio.Enumerados.TipoDocumento.CPF, documeto.Tipo); ;
        }

        [Fact]
        public void DocumentoOutros()
        {
            var documeto = new Documento("MG14577537");
            Console.WriteLine(documeto.Notifications);
            Assert.Equal(Dominio.Enumerados.TipoDocumento.Outros, documeto.Tipo); ;
        }

        [Fact]
        public void DocumentoNulo()
        {
            var documeto = new Documento(default);
            Console.WriteLine(documeto.Notifications);
            Assert.Equal(default, documeto.NRegistro); ;
        }

        [Fact]
        public void EmailVazio()
        {
            var email = new Email("");
            Assert.Equal(default, email.Endereco);
        }

        [Fact]
        public void EmailInvalido()
        {
            var email = new Email("phrmorais.com.br");
            Assert.True(email.Invalid);
        }

        [Fact]
        public void EmailValido()
        {
            var email = new Email("phrmorais@hotmail.com");
            Assert.True(email.Valid);
        }

        [Fact]
        public void ComissaoValido()
        {
            //Mock<Comissao> chk = new Mock<Comissao>();
            ////chk.Setup(x => x.TipoComissao).Returns(Dominio.Enumerados.TipoComissao.Percentual);

            //var teste = chk.Object;
            //var json = JsonConvert.SerializeObject(chk.Object);
            //Comissao obje = new Comissao();
            //Assert.AreEqual(obje.insertEmployee(chk.Object), true);
        }
    }
}