namespace Core.Helpers;

public static class Calculator
{
  public static double TotalPrice(int quantity, double price) => quantity * price;
  public static double DiscountPrice(double price, int discount)
  {
    double discountPercent = discount / 100;
    return price * discountPercent;
  }
}