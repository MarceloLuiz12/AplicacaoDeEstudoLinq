namespace EstudoLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var produto = new Produtos().BuscarTodos();
            var mercadoria = new Mercadorias().BuscarTodasMercadorias();
            var setores = Setores.BuscarTodosSetores();

            //Console.WriteLine("\nLinq com Filtro:\n");
            //LinqFiltrar(produto);

            //Console.WriteLine("\nLinq com Agrupamento:\n");
            //LinqAgrupar(produto);

            //Console.WriteLine("\nLinq com Single:\nInforme o Id do produto");
            //LinqSingle(int.Parse(Console.ReadLine()), produto);

            //Console.WriteLine("\nLinq com First:\nInforme o Id do produto");
            //LinqFirstOrDefault(int.Parse(Console.ReadLine()), produto);

            //Console.WriteLine("\nLinq com Last:\nInforme o Id do produto");
            //LinqLastOrDefault(int.Parse(Console.ReadLine()), produto);

            //Console.WriteLine("\nLinq com Max:");
            //LinqMax(produto);

            //Console.WriteLine("\nLinq com Min:");
            //LinqMin(produto);

            //Console.WriteLine("\nLinq com Count:");
            //LinqCount(produto);

            //Console.WriteLine("\nLinq com Sum:");
            //LinqSum(produto);

            //Console.WriteLine("\nLinq com Average:");
            //LinqAverage(produto);

            //Console.WriteLine("\nLinq com Skip:");
            //var listaSkip = LinqSkip(produto, 3);
            //foreach (var i in listaSkip)
            //    Console.WriteLine(string.Join(" ", i.Descricao, "Valor Unitário:", i.ValorUnitario));

            //Console.WriteLine("\nLinq com Take:");
            //var listaTake = LinqTake(produto, 3);
            //foreach (var i in listaTake)
            //    Console.WriteLine(string.Join(" ", i.Descricao, "Valor Unitário:", i.ValorUnitario));


            //Console.WriteLine("\nLinq com TakeWhile:");
            //var listaTake = LinqTakeWhile(produto, 18);
            //foreach (var i in listaTake)
            //    Console.WriteLine(string.Join(" ", "ID:", i.Id, i.Descricao, "Valor Unitário:", i.ValorUnitario));

            //Console.WriteLine("\nLinq com Any:");
            //if (LinqAny(produto, 2))
            //    Console.WriteLine($"Produto com ID {2} encontrado");
            //else
            //    Console.WriteLine("Produto não encontrado");

            //Console.WriteLine("\nLinq com Contains:");
            //LinkContains();

            //Console.WriteLine("\nLinq com Distinct exemplo 1:");
            //LinkDistinctExemplo1();

            //Console.WriteLine("\nLinq com Distinct exemplo 2:");
            //LinkDistinctExemplo2(produto);

            //Console.WriteLine("\nLinq com Union");
            //LinkUnion();

            //Console.WriteLine("\nLinq com Intersect");
            //LinkIntersect();

            //Console.WriteLine("\nLinq com OrderBy");
            //LinqOrderby(produto);

            //Console.WriteLine("\nLinq com ThenBy");
            //LinqThenByComReverse(produto);

            //Console.WriteLine("\nLinq com InnerJoin");
            //LinqInnerJoin(mercadoria, setores);

            //Console.WriteLine("\nLinq com GroupJoin");
            //LinqGroupJoin(mercadoria, setores);

            //Console.WriteLine("\nLinq com LeftJoin");
            //LinqLeftJoin(mercadoria, setores);
        }

        #region LeftJoin
        public static void LinqLeftJoin(List<Mercadorias> mercadorias, List<Setores> setores)
        {
            //Sintaxe de método
            //var listaMercadoria = setores.GroupJoin(
            //                                       mercadorias,
            //                                       setor => setor.Id,
            //                                       mercadoria => mercadoria.Setor,
            //                                       (setor, mercadoria) => new
            //                                       {
            //                                           setor,
            //                                           mercadoria
            //                                       }).SelectMany(
            //                                            x => x.mercadoria.DefaultIfEmpty(), (setores, mercadoria) => new { setores, mercadoria }
            //                                        );

            //Sintaxe de consulta
            var listaMercadoria = from setor in setores
                                  join merc in mercadorias
                                  on setor.Id equals merc.Setor
                                  into setorGroup
                                  from mercadoria in setorGroup.DefaultIfEmpty()
                                  select new { setor, mercadoria };

            var msg = string.Empty;
            foreach (var item in listaMercadoria)
                msg += "\n" + item.mercadoria?.Id + " " + item.mercadoria?.Descricao + " " + item.setor.Descricao; ;

            Console.WriteLine(msg);

        }
        #endregion

        #region GroupJoin
        public static void LinqGroupJoin(List<Mercadorias> mercadorias, List<Setores> setores)
        {
            ////Sintaxe de método
            //var listaMercadoria = setores.GroupJoin(
            //                                       mercadorias,
            //                                       setor => setor.Id,
            //                                       mercadoria => mercadoria.Setor,
            //                                       (setor, mercadoria) => new
            //                                       {
            //                                           setor,
            //                                           mercadoria
            //                                       });

            //Sintaxe de consulta
            var listaMercadoria = from setor in setores
                                  join merc in mercadorias
                                  on setor.Id equals merc.Setor
                                  into mercadoria
                                  select new { setor, mercadoria };

            var msg = string.Empty;
            foreach (var item in listaMercadoria)
            {
                msg += "\n" + item.setor.Id + " " + item.setor.Descricao;

                foreach (var merc in item.mercadoria)
                    msg += "\n --> " + merc.Id + " " + merc.Descricao + " " + merc.ValorUnitario + " " + merc.Setor;
            }

            Console.WriteLine(msg);

        }
        #endregion

        #region Join(inner)
        public static void LinqInnerJoin(List<Mercadorias> mercadorias, List<Setores> setores)
        {
            //Sintaxe de método
            //var listaMercadoria = mercadorias.Join(
            //                                       setores,
            //                                       mercadorias => mercadorias.Setor,
            //                                       setor => setor.Id, (mercadoria, setor) => new
            //                                       {
            //                                           mercadoria.Id,
            //                                           mercadoria.Descricao,
            //                                           mercadoria.ValorUnitario,
            //                                           mercadoria.Setor,
            //                                           NomeSetor = setor.Descricao
            //                                       }).OrderBy(x => x.Setor).ToList();


            //Sintaxe de consulta
            var listaMercadoria = (from m in mercadorias
                                   join s in setores
                                   on m.Setor equals s.Id
                                   select new
                                   {
                                       m.Id,
                                       m.Descricao,
                                       m.ValorUnitario,
                                       m.Setor,
                                       NomeSetor = s.Descricao
                                   }).OrderBy(x => x.Setor).ToList();

            foreach (var item in listaMercadoria)
                Console.WriteLine(item);
        }
        #endregion

        #region OrderBy, ThenBy e Reverse
        public static void LinqOrderby(List<Produtos> listaProdutos)
        {
            var listaProdutosFiltrada =
                from produto in listaProdutos
                orderby produto.ValorUnitario ascending, produto.Descricao ascending
                select produto;

            foreach (var item in listaProdutosFiltrada)
                Console.WriteLine($"Produtos filtrados: {item.Descricao} \nValor: R${item.ValorUnitario}");
        }

        public static void LinqThenByComReverse(List<Produtos> listaProdutos)
        {
            var listaProdutosFiltrada = listaProdutos.OrderBy(x => x.ValorUnitario)
                                                     .ThenBy(y => y.Descricao)
                                                     .ToList();

            listaProdutosFiltrada.Reverse();

            foreach (var item in listaProdutosFiltrada)
                Console.WriteLine($"Produtos filtrados: {item.Descricao} \nValor: R${item.ValorUnitario}");
        }

        #endregion

        #region Intersect
        public static void LinkIntersect()
        {
            var paises1 = new List<string>() { "Argentina", "França", "Brasil", "Chile" };
            var paises2 = new List<string>() { "Argentina", "Alemanha", "Brasil", "Paraguai", "Itália", "Japão" };

            var paises3 = paises1.Intersect(paises2).ToList();

            foreach (var pais in paises3)
                Console.WriteLine(pais);
        }


        #endregion

        #region Union
        public static void LinkUnion()
        {
            var paises1 = new List<string>() { "Argentina", "França", "Brasil", "Chile" };
            var paises2 = new List<string>() { "Argentina", "Alemanha", "Brasil", "Paraguai", "Itália", "Japão" };

            var paises3 = paises1.Union(paises2).ToList();

            foreach (var pais in paises3)
                Console.WriteLine(pais);
        }
        #endregion

        #region Distinct
        public static void LinkDistinctExemplo1()
        {
            var paisesComDuplicacao = new List<string>()
            {"Argentina", "França","frança", "Brasil", "Chile", "Alemanha", "Paraguai", "Itália", "Japão", "Japão"};

            var listaDistinct = paisesComDuplicacao.Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (var pais in listaDistinct)
                Console.WriteLine(pais);
        }

        public static void LinkDistinctExemplo2(List<Produtos> produtos)
        {
            var listaProdutos = produtos.Select(p => p.Descricao).Distinct().ToList();
            foreach (var produto in listaProdutos)
                Console.WriteLine(produto);
        }
        #endregion

        #region Contains
        public static void LinkContains()
        {
            var paises = new List<string>()
            {"Argentina", "França", "Brasil", "Chile", "Alemanha", "Paraguai", "Itália", "Japão"};

            Console.WriteLine("Informe o País que deseja verificar se existe na lista:\n");
            bool existe = paises.Contains(Console.ReadLine());
            if (existe)
                Console.WriteLine("País existe");
            else
                Console.WriteLine("País não existe");

        }
        #endregion

        #region Any
        public static bool LinqAny(List<Produtos> listaProdutos, int id)
        {
            var result = (from produto in listaProdutos
                          select produto).Any(p => p.Id == id);

            return result;
        }
        #endregion

        #region Take e TakeWhile
        public static List<Produtos> LinqTake(List<Produtos> listaProdutos, int qtdItens)
        {
            var lista = (from produto in listaProdutos
                         select produto).Take(qtdItens).ToList();

            return lista;
        }

        public static List<Produtos> LinqTakeWhile(List<Produtos> listaProdutos, int id)
        {
            var lista = (from produto in listaProdutos
                         select produto).TakeWhile(p => p.Id < id).ToList();

            return lista;
        }


        #endregion

        #region Skip
        public static List<Produtos> LinqSkip(List<Produtos> listaProdutos, int qtdItens)
            => (from produto in listaProdutos
                select produto).Skip(qtdItens).ToList();
        #endregion

        #region Average
        public static void LinqAverage(List<Produtos> listaProdutos)
        {
            double result = (from produto in listaProdutos
                             select produto.Quantidade).Average();

            Console.WriteLine($"Média aritmética:{result:N2}");
        }

        #endregion

        #region Sum
        public static void LinqSum(List<Produtos> listaProdutos)
        {
            decimal result = (from produto in listaProdutos
                              select (produto.Quantidade * produto.ValorUnitario)).Sum();

            Console.WriteLine($"Valor total em estoque: R${result}");
        }

        #endregion

        #region Count
        public static void LinqCount(List<Produtos> listaProdutos)
        {
            int result = (from produto in listaProdutos
                          where produto.Setor == "Alimento"
                          select produto).Count();

            Console.WriteLine($"Contém {result} produtos dentro desta lista\n");
        }

        #endregion

        #region Max e Min
        public static void LinqMax(List<Produtos> listaProdutos)
        {
            decimal result = (from produto in listaProdutos
                              select produto.ValorUnitario).Max();

            Console.WriteLine($"Maior valor :{result}\n");
        }

        public static void LinqMin(List<Produtos> listaProdutos)
        {
            decimal result = (from produto in listaProdutos
                              select produto.ValorUnitario).Min();

            Console.WriteLine($"Menor valor :{result}\n");
        }

        #endregion

        #region Last e LastOrDefault
        //retorna o ultimo
        public static void LinqLast(int id, List<Produtos> listaProdutos)
        {
            var produto = listaProdutos.Last(p => p.Id >= id);
            if (produto != null)
                Console.WriteLine($"{produto.Id} - {produto.Descricao}");
            else
                Console.WriteLine("Produto não encontrado para o Id Informado");
        }

        public static void LinqLastOrDefault(int id, List<Produtos> listaProdutos)
        {
            var produto = listaProdutos.LastOrDefault(p => p.Id == id);
            if (produto != null)
                Console.WriteLine($"{produto.Id} - {produto.Descricao}");
        }

        #endregion

        #region First e FirstOrDefault
        public static void LinqFirst(int id, List<Produtos> listaProdutos)
        {
            var produto = listaProdutos.First(p => p.Id >= id);
            if (produto != null)
                Console.WriteLine($"{produto.Id} - {produto.Descricao}");
            else
                Console.WriteLine("Produto não encontrado para o Id Informado");
        }
        public static void LinqFirstOrDefault(int id, List<Produtos> listaProdutos)
        {
            var produto = listaProdutos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
                Console.WriteLine($"{produto.Id} - {produto.Descricao}");
        }

        #endregion

        #region Single e SingleOrDefault
        public static void LinqSingle(int id, List<Produtos> listaProdutos)
        {
            try
            {
                var produto = listaProdutos.Single(p => p.Id == id);
                Console.WriteLine($"{produto.Id} - {produto.Descricao}");
            }
            catch
            {
                Console.WriteLine("Produto não encontrado para o Id Informado");
            }
        }

        public static void LinqSingleOrDefault(int id, List<Produtos> listaProdutos)
        {
            var produto = listaProdutos.SingleOrDefault(p => p.Id == id);
            if (produto != null)
                Console.WriteLine($"{produto.Id} - {produto.Descricao}");
            else
                Console.WriteLine("Produto não encontrado para o Id Informado");
        }
        #endregion

        #region Filtro
        public static void LinqFiltrar(List<Produtos> listaProdutos)
        {
            var listaProdutosFiltrada =
                from produto in listaProdutos
                where produto.Id < 15
                orderby produto.ValorUnitario descending
                select produto;

            foreach (var item in listaProdutosFiltrada)
                Console.WriteLine($"Produtos filtrados: {item.Descricao} \nValor: R${item.ValorUnitario}");
        }
        #endregion

        #region Agrupamento
        public static void LinqAgrupar(List<Produtos> listaProdutos)
        {
            var listaProdutosAgrupada =
                from produto in listaProdutos
                group produto by produto.Setor into setorGrupo
                orderby setorGrupo.Key ascending
                select setorGrupo;

            foreach (var grupo in listaProdutosAgrupada)
            {
                var nomeGrupo = string.Join(" ", "Grupo:", grupo.Key);
                foreach (var produto in grupo)
                    Console.WriteLine($"{nomeGrupo}, {produto.Id}  {produto.Descricao}");
            }
        }
        #endregion
    }
}