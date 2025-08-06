using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public string TableNumber { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderTime { get; set; } = DateTime.Now;

    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
}