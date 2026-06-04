using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FinanceBilling.MVC.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetAsync(
        string endpoint,
        string? token = null)
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        return await _httpClient.GetAsync(endpoint);
    }

    public async Task<HttpResponseMessage> PostAsync<T>(
        string endpoint,
        T data,
        string? token = null)
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        var json =
            JsonSerializer.Serialize(data);

        var content =
            new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

        return await _httpClient.PostAsync(
            endpoint,
            content);
    }

    public async Task<HttpResponseMessage> PutAsync<T>(
        string endpoint,
        T data,
        string? token = null)
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        var json =
            JsonSerializer.Serialize(data);

        var content =
            new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

        return await _httpClient.PutAsync(
            endpoint,
            content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(
        string endpoint,
        string? token = null)
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        return await _httpClient.DeleteAsync(endpoint);
    }
}