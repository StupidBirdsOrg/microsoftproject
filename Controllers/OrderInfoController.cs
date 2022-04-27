using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Domain;
using MyMicroservice.Domain;

namespace MyMicroservice.Controllers;

/// <summary>
/// 订单信息控制器
/// </summary>
public class OrderInfoController : BaseController
{

    private readonly ILogger<OrderInfoController> _logger;
    private readonly IOperation _oper;

    public OrderInfoController(ILogger<OrderInfoController> logger, IOperation operation)
    {
        _logger = logger;
        _oper = operation;
    }

    /// <summary>
    /// 获取订单
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public OrderInfo GetOrder()
    {
        var list = new List<OrderDetail>();
        list.Add(new OrderDetail { ContactName = "131", PhoneNumber = "12231231243", Amount = 17.4d, ProductName = "GB2103" });
        return new OrderInfo(Guid.NewGuid().ToString("N2"), list);
    }
    [HttpGet("{id}")]
    public OrderInfo GetOrder([FromServices] IOperation service, string id)
    {
        var list = new List<OrderDetail>();
        list.Add(new OrderDetail { ContactName = "131", PhoneNumber = "12231231243", Amount = 17.4d, ProductName = "GB2103" });
        return new OrderInfo(service.OperationAction("12"), list);
    }
    /// <summary>
    /// 新增订单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut]
    public string PutOrder(string id)
    {
        _logger.LogInformation(string.Format("add {0}", id));
        return $"Put {id}";
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