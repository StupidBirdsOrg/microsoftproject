using Microsoft.AspNetCore.Mvc;

namespace MyMicroservice.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly IOrderInfoApi _api;
    public ValuesController(IOrderInfoApi api)
    {
        this._api = api;
    }

    // GET api/values
    [HttpGet]
    public async Task<OrderInfo> GetAsync()
    {
        var result= await _api.GetOrderInfosAsync();   
        return result;                         
    }

}