using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpBasicsAssignment;

internal class Order
{
    public int OrderId;
    public string CustomerName, ShippingCity;
    public int Quantity;
    public decimal UnitPrice, TotalPrice;
    public bool IsPaid;
    public double DiscountPercent;
    public char Priority = 'M';
    public  long ItemCode;

    public void CalculateTotal()
    {
        TotalPrice = Quantity*UnitPrice*(1m - (decimal)DiscountPercent / 100m);
    }
    
    public void PrintSummary()
    {
        Console.WriteLine(
          $"OrderId: {OrderId}, CustomerName: {CustomerName}, TotalPrice: {TotalPrice}, IsPaid: {IsPaid} "
      );
    }

}
