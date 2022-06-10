using FluentResultTests.Models;

namespace FluentResultTests.Fakers
{
    public class ProdutoFaker : BaseFaker<Produto>
    {
        public ProdutoFaker()
        {
            // Para não usar o CustomInstatiator basta usar o pacote AutoBogus que é uma upgrade do Bogus (https://github.com/nickdodd79/AutoBogus)
            CustomInstantiator(f => new Produto(
                f.Commerce.ProductName(),
                f.Commerce.ProductDescription(),
                f.Image.PicsumUrl(),
                f.Finance.Amount(1, 1000, 2),
                f.Random.Bool()
            ));
        }

        public ProdutoFaker ComNome(string valor)
        {
            RuleFor(p => p.Nome, valor);
            return this;
        }
        
        public ProdutoFaker ComDescricao(string valor)
        {
            RuleFor(p => p.Descricao, valor);
            return this;
        }
        
        public ProdutoFaker ComValor(decimal valor)
        {
            RuleFor(p => p.Valor, valor);
            return this;
        }
    }
}