using System;

namespace MyMicroservice;

/// <summary>
/// 订单信息
/// </summary>
public class OrderInfo
{
    public OrderInfo(string id, IEnumerable<OrderDetail> details)
    {
        this.Id = id;
        this.Details = details;
    }
    /// <summary>
    /// ID
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 订单明细
    /// </summary>
    public IEnumerable<OrderDetail> Details { get; set; }

}
