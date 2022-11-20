using Shared.Enums;
using Shared.Interfaces;

namespace Core.Entities.Phones;

public partial class Phone : IAggregateRoot
{
    public Phone UpdateStock(IEnumerable<Stock> stock)
    {
        foreach (var x in stock)
        {
            if (x.Id == 0)
              _stocks.Add(x);
            else
            {
              var existStock = _stocks.First(e => e.Id == x.Id);
              existStock.IncreaseQuantity(x.Quantity);
              existStock.Detail!.Update(x.Detail!);
            }
        }
        return this;
    }

    public void DeleteStock()
    {
        Status = Status.Inactive;
    }
    
    public Phone AddImage(IEnumerable<Image> images)
    {
        _images.AddRange(images);
        return this;
    }

    public Phone WithStocks(IEnumerable<Stock> stocks)
    {
        _stocks.AddRange(stocks);
        return this;
    }

    public Phone WithImages(IEnumerable<Image> images)
    {
        _images.AddRange(images);
        return this;
    }

    public Phone WithImages(IEnumerable<string> images)
    {
        _images.AddRange(images.Select(c => new Image(c)));
        return this;
    }
}