using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Mostrar musicas por ano de lançamento:");
        Console.WriteLine("Digite o ano para consultar Músicas:");
        string anoLancamento = Console.ReadLine()!;
        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var listaAnoLancamento = musicaDAL.ListarPor(a => a.AnoLancamento == Convert.ToInt32(anoLancamento));
        if (listaAnoLancamento.Any())
        {
            Console.WriteLine($"\nMusicas do ano {anoLancamento}: ");
            foreach (var musica in listaAnoLancamento)
            {
                musica.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNão foi encontrada nenhuma musica do ano de {anoLancamento}");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
