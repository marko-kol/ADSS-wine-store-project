namespace MarkoWineStore.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public Wine Wine { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }
    }
}
