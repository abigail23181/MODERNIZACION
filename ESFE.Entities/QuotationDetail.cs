using System;
using System.Collections.Generic;

namespace ESFE.Entities;

public partial class QuotationDetail
{
    public int QuotationDetailId { get; set; }

    public int? QuotationId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Quotation? Quotation { get; set; }
}
