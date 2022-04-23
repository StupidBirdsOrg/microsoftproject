using Refit;

namespace MyMicroservice;

public interface IOrderInfoApi
{
    [Get("/OrderInfo/GetOrder")]
    Task<List<OrderInfo>> GetOrderInfosAsync();

    [Delete("/OrderInfo/Delete/{id}")]
    Task<string> DeleteOrderAsync(string id);
}