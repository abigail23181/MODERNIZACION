using System;
using System.Collections.Generic;

namespace ESFE.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public int? BrandId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public string? ProductCode { get; set; }

    public decimal? PriceUnitSale { get; set; }

    public int? Stock { get; set; }

    public byte? ProductStatus { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<QuotationDetail> QuotationDetails { get; set; } = new List<QuotationDetail>();
}
