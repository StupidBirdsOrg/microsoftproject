using Refit;

namespace MyMicroservice;

public interface IOrderInfoApi
{
    [Get("/OrderInfo")]
    Task<OrderInfo> GetOrderInfosAsync();

    [Delete("/OrderInfo/Delete/{id}")]
    Task<string> DeleteOrderAsync(string id);
}