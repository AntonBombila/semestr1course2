using System;

namespace WindowsFormsApptask21.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Name} | {Manufacturer} | {Price:C} | В наличии: {Stock}";
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRegular { get; set; }
        public decimal TotalSpent { get; set; }

        public override string ToString()
        {
            return $"{Name} | Постоянный: {(IsRegular ? "Да" : "Нет")} | Потрачено: {TotalSpent:C}";
        }
    }

    public class Sale
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }

        public override string ToString()
        {
            return $"{Date:dd.MM.yyyy} | Клиент: {ClientId} | Сумма: {Total:C} | Скидка: {Discount:C}";
        }
    }

    public class SaleItem
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get { return Product.Price * Quantity; }
        }

        public override string ToString()
        {
            return $"{Product.Name} x{Quantity} = {TotalPrice:C}";
        }
    }
}