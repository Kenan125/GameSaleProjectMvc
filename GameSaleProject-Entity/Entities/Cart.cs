namespace GameSaleProject_Entity.Entities
{
    public class Cart
    {
        public string UserName { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
