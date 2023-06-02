namespace SPBA.Services;

internal class ContentService
{
    internal ContentService()
    {

    }

    private static ContentService _instance;
    public static ContentService Instance()
    {
        if (_instance == null)
            _instance = new ContentService();

        return _instance;
    }

    public async Task<IEnumerable<TResponse>> GetItemsAsync<TResponse>(string requestUrl)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(SmartPointConstants.SERVER_ROOT_URL);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            try
            {
                var response = await httpClient.GetStringAsync(httpClient.BaseAddress + requestUrl);
                IEnumerable<TResponse> result = JsonConvert.DeserializeObject<IEnumerable<TResponse>>(response);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public async Task<TResponse> GetItemAsync<TResponse>(string requestUrl) where TResponse : class
    {
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(SmartPointConstants.SERVER_ROOT_URL);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await httpClient.GetStringAsync(httpClient.BaseAddress + requestUrl);
                TResponse result = JsonConvert.DeserializeObject<TResponse>(response);

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
