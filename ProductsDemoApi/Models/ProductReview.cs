namespace ProductsDemoApi.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }

        
        public Product Product { get; set; }

    }
}
