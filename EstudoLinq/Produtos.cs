namespace EstudoLinq
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public string Setor { get; set; }

        public Produtos()
        { }

        public Produtos(int id, string descricao, decimal valorUnitario, int quantidade, string setor)
        {
            Id = id;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            Setor = setor;
        }

        public List<Produtos> BuscarTodos()
        {
            var listaProdutos = new List<Produtos>
            {
                new Produtos(2, "Café em pó 250 gramas", 10.83M, 15, "Alimento"),
                new Produtos(4, "Sabão em pó 500 gramas", 16.50M, 12, "Limpeza"),
                new Produtos(7, "Óleo de soja 1 litro", 7.23M, 26, "Alimento"),
                new Produtos(13, "Café em pó 500 gramas", 19.99M, 8, "Alimento"),
                new Produtos(18, "Óleo de girassol 1 litro", 9.96M, 32, "Alimento"),
                new Produtos(21, "Sabão em pedra 250 gramas", 4.12M, 63, "Limpeza"),
                new Produtos(27, "Suco de uva 350 ml", 3.89M, 79, "Alimento"),
                new Produtos(28, "Suco de uva 350 ml", 3.89M, 79, "Alimento")
            };

            return listaProdutos;
        }
    }
}
