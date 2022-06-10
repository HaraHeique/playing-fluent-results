namespace FluentResultTests.Models
{
    public class Produto : Entity
    {
        public Produto(string nome, string descricao, string imagem, decimal valor, bool ativo) : base()
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Imagem = imagem;
            this.Valor = valor;
            this.Ativo = ativo;
            this.DataCadastro = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}
