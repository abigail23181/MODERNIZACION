using System;
using System.Collections.Generic;

namespace ESFE.Entities;

public partial class Quotation
{
    public int QuotationId { get; set; }

    public int? UserId { get; set; }

    public string? ClientName { get; set; }

    public string? QuotationNumber { get; set; }

    public DateTime? QuotationRegistration { get; set; }

    public decimal? Total { get; set; }

    public string? QuotationStatus { get; set; }

    public virtual ICollection<QuotationDetail> QuotationDetails { get; set; } = new List<QuotationDetail>();

    public virtual User? User { get; set; }
}
