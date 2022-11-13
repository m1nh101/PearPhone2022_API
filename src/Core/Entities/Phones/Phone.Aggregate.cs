using Shared.Interfaces;

namespace Core.Entities.Phones;

public partial class Phone : IAggregateRoot
{
    public Phone AddStock(IEnumerable<Stock> stocks)
    {
        // foreach(var stock in stocks)
        // {
        //   if(stock.Id == 0)
        //     _stocks.Add(stock);
        //   else
        //   {
        //     var existStock = _stocks.First(e => e.Capacity == stock.Capacity);
        //     existStock.IncreaseQuantity(stock.Quantity);
        //   }
        // }
        //return this;
        _stocks.AddRange(stocks);
        return this;

    }

    public Phone UpdateStock(IEnumerable<Stock> stocks)
    {
        return this;
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