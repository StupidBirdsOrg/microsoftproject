using Refit;

namespace MyMicroservice;

public interface IOrderInfoApi
{
    [Get("/OrderInfo")]
    Task<OrderInfo> GetOrderInfosAsync();
    [Put("/OrderInfo")]
    Task<string> PutOrderAsync(string id);

    [Delete("/OrderInfo/Delete/{id}")]
    Task<string> DeleteOrderAsync(string id);

}