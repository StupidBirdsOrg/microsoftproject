using Refit;

namespace MyMicroservice;

public interface IOrderInfoApi
{
    [Get("/OrderInfo")]
    Task<OrderInfo> GetOrderInfosAsync([HeaderCollection] IDictionary<string, string> headers);
    [Put("/OrderInfo")]
    Task<string> PutOrderAsync(string id);

    [Delete("/OrderInfo/Delete/{id}")]
    Task<string> DeleteOrderAsync(string id);

}
public class AuthHeaderHandler:DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        request.Headers.Add("X-request-Id", Guid.NewGuid().ToString());

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}