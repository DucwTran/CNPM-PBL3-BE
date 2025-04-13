using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace api.Mappers
{

    public static class StockMappers
    {

        public static StockDto ToStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                lastDiv = stock.lastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }

        public static List<StockDto> ToDto(this List<Stock> stocks)
        {
            return stocks.Select(stock => stock.ToStockDto()).ToList();
        }
        public static Stock ToModel(this StockDto stockDto)
        {
            return new Stock
            {
                Id = stockDto.Id,
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                lastDiv = stockDto.lastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}