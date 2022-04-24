using Microsoft.AspNetCore.Mvc;

namespace MyMicroservice.Controllers;

public class OrderInfoController : BaseController
{
    
    private readonly ILogger<OrderInfoController> _logger;

    public OrderInfoController(ILogger<OrderInfoController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("GetOrder")]
    public OrderInfo GetOrder()
    {
        List<OrderDetail> list=new List<OrderDetail>();
        list.Add(new OrderDetail{ContactName="131",PhoneNumber="12231231243",Amount=17.4d,ProductName="GB2103"});
        return new OrderInfo("123",list);
    }

    [HttpDelete("Delete/{id}")]
    public string DeleteOrder(string id)
    {
        return $"del {id}";
    }

}