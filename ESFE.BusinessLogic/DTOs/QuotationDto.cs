using ESFE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESFE.BusinessLogic.DTOs
{

    public class CreateQuotationRequest
    {

        public string? ClientName { get; set; }

        public string? QuotationNumber { get; set; }

        public DateTime? QuotationRegistration { get; set; }

        public decimal? Total { get; set; }

        public string? QuotationStatus { get; set; }

        public virtual ICollection<CreateQuotationDetail> QuotationDetails { get; set; } = new List<CreateQuotationDetail>();

    }

    public class CreateQuotationDetail
    {
        public int QuotationDetailId { get; set; }

        public int? QuotationId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal? Subtotal { get; set; }

    }

    public partial class QuotationResponse
    {
        public int QuotationId { get; set; }

        public int? UserId { get; set; }

        public string? ClientName { get; set; }

        public string? QuotationNumber { get; set; }

        public DateTime? QuotationRegistration { get; set; }

        public decimal? Total { get; set; }

        public string? QuotationStatus { get; set; }

        public virtual ICollection<QuotationDetailResponse> QuotationDetails { get; set; } = new List<QuotationDetailResponse>();

        public virtual User? User { get; set; }
    }

    public class QuotationDetailResponse
    {
        public int QuotationId { get; set; }

        public int? UserId { get; set; }

        public string? ClientName { get; set; }

        public string? QuotationNumber { get; set; }

        public DateTime? QuotationRegistration { get; set; }

        public decimal? Total { get; set; }

        public string? QuotationStatus { get; set; }

        public virtual ICollection<QuotationDetailResponse> QuotationDetails { get; set; } = new List<QuotationDetailResponse>();

        public virtual User? User { get; set; }
    }

}