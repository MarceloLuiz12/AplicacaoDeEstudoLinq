namespace EstudoLinq
{
    public class Setores
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Setores()
        { }

        public Setores(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public static List<Setores> BuscarTodosSetores()
            => new()
                {
                    new Setores(1,"Alimentos"),
                    new Setores(2,"Limpeza"),
                    new Setores(3,"Doces"),
                    new Setores(4,"Padaria"),
                };

    }
}
