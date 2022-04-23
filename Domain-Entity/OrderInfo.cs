using System;

namespace MyMicroservice;
[Serializable]
public class OrderInfo
{
    public OrderInfo(string id,List<OrderDetail> details)
    {
        this.Id=id;
        this.Details=details;
    }
    public string? Id{get;set;}
    public List<OrderDetail> Details{get;set;}

}
[Serializable]
public class OrderDetail
{
    public string? ContactName{get;set;}
    public string? PhoneNumber{get;set;}
    public double Amount{get;set;}
    public string? ProductName{get;set;}

}