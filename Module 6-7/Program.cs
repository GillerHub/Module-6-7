using System;

namespace Module_7
{
    abstract class Delivery
    {
        protected string UserName;
        protected DateTime DeliveryDate;
        protected string PayType;
        protected string City;
        protected string Street;
        protected string House;
        protected basket Order;

        public virtual float TotalPrice()
        {
            float Price = 0;
            foreach (Product item in this.Order.Check)
            {
                Price += item.cost;
            }
            return Price;
        }
        public void DisplayName()
        {
            Console.WriteLine(UserName);
        }
        public void DisplayAddress()
        {
            Console.WriteLine(City + " " + Street + " " + House);
        }
        public void DisplayPayType()
        {
            Console.WriteLine(PayType);
        }

        public Delivery(string username, string city, string street, string paytype, Product[] order, string house = "")
        {
            UserName = username;
            City = city;
            Street = street;
            House = house;
            PayType = paytype;
            Order = new basket();
            foreach (Product item in order)
            {
                Order.adder(item);
            }
            DeliveryDate = DateTime.Now.AddDays(3);
        }

    }
    class basket
    {
        private int count = 0;
        private Product[] check = new Product[3];
        public void adder(Product item)
        {
            if (count == 3)
            {
                Console.WriteLine("Корзина заполнена");
            }
            else
            {
                check[count] = item;
                count++;
            }
        }
        public Product[] Check
        {
            get
            {
                if (count == 0)
                {
                    return new Product[0];
                }
                else
                    return check;
            }
        }

    }
    class Product
    {
        private int mass;
        private string Pname;
        public float cost;
        public virtual void Discunt()
        {
            cost = (float)Math.Round(cost * 0.95, 2);
        }
    }

    class HomeDelivery : Delivery
    {
        public HomeDelivery(string username, string city, string street, string paytype, Product[] order, string house = "") : base(username, city, street, paytype, order, house) { }
        protected float DelCost;
        public override float TotalPrice()
        {
            float Price = DelCost;
            foreach (Product item in this.Order.Check)
            {
                Price += item.cost;
            }
            return Price;
        }
    }
    class Courier : HomeDelivery
    {
        public Courier(string username, string city, string street, string paytype, Product[] order, string house = "") : base(username, city, street, paytype, order, house) { }
        public new float DelCost = 300;
    }
    class DeliveryService : HomeDelivery
    {
        public DeliveryService(string username, string city, string street, string paytype, Product[] order, string house = "") : base(username, city, street, paytype, order, house) { }
        public new float DelCost = 500;
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery(string username, string city, string street, string paytype, Product[] order, string house = "") : base(username, city, street, paytype, order, house) { }
    }

    class ShopDelivery : Delivery
    {
        public ShopDelivery(string username, string city, string street, string paytype, Product[] order, string house = "") : base(username, city, street, paytype, order, house) { }
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;
        private static int Count = 0;
        private int Number;
        private string Description;
        public Order()
        {
            Count++;
            Number = Count;
        }
        public void DisplayNomber()
        {
            Console.WriteLine(Number);
        }
        public void DisplayDescription()
        {
            Console.WriteLine(Description);
        }
    }

}