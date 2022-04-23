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
    public async Task<List<OrderInfo>> GetAsync()
    {
        return await _api.GetOrderInfosAsync();                            
    }

}