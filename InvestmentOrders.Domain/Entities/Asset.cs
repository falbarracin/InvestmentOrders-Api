using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrders.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
