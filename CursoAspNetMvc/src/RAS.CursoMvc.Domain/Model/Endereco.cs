using System;

namespace RAS.CursoMvc.Domain.Model
{
    public class Endereco : Entity
    {
        public Endereco()
        {
            Id = Guid.NewGuid();
        }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }


        //Chave estrangeira
        // vai virar coluna no banco
        public Guid ClienteId { get; set; }

        // Propriedade de navegação do EF
        // LazyLoad vem ativado e colocamos como virtual, assim o EF sobescreve a property 
        //de endereços e transforma em um proxy, sendo assim ao chamar o objeto o EF vai ao banco
        public virtual Cliente Cliente { get; set; }
    }    
}