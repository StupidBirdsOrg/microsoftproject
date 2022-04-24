namespace MyMicroservice;

/// <summary>
/// 订单明细
/// </summary>
//[Serializable]
public class OrderDetail
{
    /// <summary>
    /// 联系人
    /// </summary>
    public string ContactName { get; set; }
    /// <summary>
    /// 手机号
    /// </summary>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// 金额
    /// </summary>
    public double Amount { get; set; }
    /// <summary>
    /// 产品名称
    /// </summary>
    public string ProductName { get; set; }

}