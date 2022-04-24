using Microsoft.AspNetCore.Mvc;

namespace MyMicroservice.Controllers;

/// <summary>
/// 订单信息控制器
/// </summary>
public class OrderInfoController : BaseController
{
    
    private readonly ILogger<OrderInfoController> _logger;

    public OrderInfoController(ILogger<OrderInfoController> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// 获取订单
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public OrderInfo GetOrder()
    {
        var list= new List<OrderDetail>();
        list.Add(new OrderDetail{ContactName="131",PhoneNumber="12231231243",Amount=17.4d,ProductName="GB2103"});
        return new OrderInfo(Guid.NewGuid().ToString("N2"),list);
    }
    /// <summary>
    /// 删除订单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public string DeleteOrder(string id)
    {
        return $"del {id}";
    }

}