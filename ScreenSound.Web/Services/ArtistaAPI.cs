using System.Net.Http;
using System.Net.Http.Json;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;

namespace ScreenSound.Web.Services;

public class ArtistaAPI
{
	private readonly HttpClient _httpClient;
	public ArtistaAPI(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("API");
	}

	public async Task<ICollection<ArtistaResponse>?> GetArtistaAsync()
	{
		return await
		   _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>
		   ("artistas");
	}

	public async Task AddArtistaAsync(ArtistaRequest artista)
	{
		await _httpClient.PostAsJsonAsync("artistas", artista);
	}

	public async Task DeleteArtistaAsync(int id)
	{
		await _httpClient.DeleteAsync($"artista/{id}");
	}

	public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
	{
		return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artista/{nome}");
	}
}
