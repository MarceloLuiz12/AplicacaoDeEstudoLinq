namespace EstudoLinq
{
    public class Mercadorias
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public int Setor { get; set; }

        public Mercadorias()
        { }

        public Mercadorias(int id, string descricao, decimal valorUnitario, int setor)
        {
            Id = id;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            Setor = setor;
        }

        public List<Mercadorias> BuscarTodasMercadorias()
        {
            var listaMercadorias = new List<Mercadorias>()
            {
                new Mercadorias(2, "Café em pó 250 gramas", 10.83M, 1),
                new Mercadorias(4, "Sabão em pó 500 gramas", 16.50M, 2),
                new Mercadorias(7, "Óleo de soja 1 litro", 7.23M, 1),
                new Mercadorias(13, "Café em pó 500 gramas", 19.99M, 1),
                new Mercadorias(18, "Óleo de girassol 1 litro", 9.96M, 1),
                new Mercadorias(21, "Sabão em pedra 250 gramas", 4.12M, 2),
                new Mercadorias(27, "Suco de uva 350 ml", 3.89M, 1),
            };

            return listaMercadorias;
        }
    }
}
