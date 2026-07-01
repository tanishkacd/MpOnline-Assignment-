//WAP to show shopping experience for the user who can be a customer or a delivery agent . Also if he is a customer he will be placing an order and going for a payment. Using combination of all type of inheritance
using System;
using System.Collections.Generic;

namespace ShoppingExperience
{
    // ========== 1. SINGLE INHERITANCE ==========
    // Base class for all orders – will be inherited by Order class
    public class OrderBase
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "Pending";

        public virtual void DisplayOrderInfo()
        {
            Console.WriteLine($"Order ID: {OrderId}, Date: {OrderDate}, Status: {Status}");
        }
    }

    // Single inheritance: Order inherits from OrderBase
    public class Order : OrderBase
    {
        public List<string> Items { get; set; } = new List<string>();
        public decimal TotalAmount { get; set; }

        public override void DisplayOrderInfo()
        {
            base.DisplayOrderInfo();
            Console.WriteLine($"Items: {string.Join(", ", Items)}");
            Console.WriteLine($"Total Amount: ${TotalAmount}");
        }
    }

    // ========== 2. MULTILEVEL INHERITANCE ==========
    // Level 1: Person
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual void Introduce()
        {
            Console.WriteLine($"Person: {Name} (ID: {Id})");
        }
    }

    // Level 2: User inherits from Person
    public class User : Person
    {
        public string Email { get; set; }

        public User(int id, string name, string email) : base(id, name)
        {
            Email = email;
        }

        public override void Introduce()
        {
            base.Introduce();
            Console.WriteLine($"Email: {Email}");
        }
    }

    // ========== 3. INTERFACES FOR MULTIPLE INHERITANCE EFFECT ==========
    public interface IOrderPlacer
    {
        void PlaceOrder();
    }

    public interface IPaymentProcessor
    {
        void MakePayment();
    }

    public interface IDelivery
    {
        void UpdateDeliveryStatus(string status);
    }

    // ========== 4. HIERARCHICAL INHERITANCE ==========
    // Both Customer and DeliveryAgent inherit from User
    // Customer also implements IOrderPlacer and IPaymentProcessor (multiple inheritance via interfaces)
    public class Customer : User, IOrderPlacer, IPaymentProcessor
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        private Order currentOrder;

        public Customer(int id, string name, string email) : base(id, name, email) { }

        public void CreateOrder(List<string> items, decimal total)
        {
            currentOrder = new Order
            {
                OrderId = new Random().Next(1000, 9999),
                OrderDate = DateTime.Now,
                Items = items,
                TotalAmount = total
            };
            Console.WriteLine("\n[Order Created Successfully]");
            currentOrder.DisplayOrderInfo();
        }

        public void PlaceOrder()
        {
            if (currentOrder != null)
            {
                currentOrder.Status = "Placed";
                Orders.Add(currentOrder);
                Console.WriteLine($"\nOrder {currentOrder.OrderId} has been PLACED.");
            }
            else
            {
                Console.WriteLine("\nNo order to place. Please create an order first.");
            }
        }

        public void MakePayment()
        {
            if (currentOrder != null && currentOrder.Status == "Placed")
            {
                Console.WriteLine($"\nProcessing payment of ${currentOrder.TotalAmount}...");
                Console.WriteLine("Payment successful! Order confirmed.");
                currentOrder.Status = "Paid";
            }
            else
            {
                Console.WriteLine("\nCannot make payment. Either no order or order not placed yet.");
            }
        }
    }

    // DeliveryAgent inherits from User and implements IDelivery
    public class DeliveryAgent : User, IDelivery
    {
        public List<Order> AssignedOrders { get; set; } = new List<Order>();

        public DeliveryAgent(int id, string name, string email) : base(id, name, email) { }

        public void AssignOrder(Order order)
        {
            AssignedOrders.Add(order);
            Console.WriteLine($"\nOrder {order.OrderId} assigned to delivery agent {Name}.");
        }

        public void UpdateDeliveryStatus(string status)
        {
            if (AssignedOrders.Count > 0)
            {
                foreach (var order in AssignedOrders)
                {
                    order.Status = status;
                    Console.WriteLine($"\nDelivery status for Order {order.OrderId} updated to: {status}");
                }
            }
            else
            {
                Console.WriteLine("\nNo assigned orders.");
            }
        }

        public void ShowAssignedOrders()
        {
            if (AssignedOrders.Count == 0)
            {
                Console.WriteLine("\nNo orders assigned.");
                return;
            }
            Console.WriteLine("\n--- Assigned Orders ---");
            foreach (var order in AssignedOrders)
            {
                order.DisplayOrderInfo();
                Console.WriteLine("------------------------");
            }
        }
    }

    // ========== MAIN PROGRAM ==========
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== SHOPPING EXPERIENCE SYSTEM =====");
            Console.WriteLine("Demonstrating ALL types of inheritance:");
            Console.WriteLine("1. Single Inheritance  (OrderBase -> Order)");
            Console.WriteLine("2. Multilevel Inheritance (Person -> User -> Customer/DeliveryAgent)");
            Console.WriteLine("3. Hierarchical Inheritance (User -> Customer, User -> DeliveryAgent)");
            Console.WriteLine("4. Multiple Inheritance via Interfaces (Customer implements IOrderPlacer + IPaymentProcessor)\n");

            Console.Write("Are you a (1) Customer or (2) Delivery Agent? Enter 1 or 2: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Customer experience
                Customer customer = new Customer(101, "Alice Johnson", "alice@email.com");
                customer.Introduce();

                Console.WriteLine("\n--- Shopping Experience (Customer) ---");
                // Simulate adding items to cart
                List<string> cart = new List<string> { "Laptop", "Mouse", "Keyboard" };
                decimal total = 1250.99m;
                customer.CreateOrder(cart, total);

                // Customer places order and makes payment
                customer.PlaceOrder();
                customer.MakePayment();

                Console.WriteLine("\nFinal Order Status:");
                customer.Orders[0].DisplayOrderInfo();
            }
            else if (choice == "2")
            {
                // Delivery Agent experience
                DeliveryAgent agent = new DeliveryAgent(202, "Bob Carter", "bob@delivery.com");
                agent.Introduce();

                // Simulate an existing order (created by some customer)
                Order sampleOrder = new Order
                {
                    OrderId = 5001,
                    OrderDate = DateTime.Now,
                    Items = new List<string> { "Smartphone", "Charger" },
                    TotalAmount = 699.99m,
                    Status = "Ready for Delivery"
                };

                agent.AssignOrder(sampleOrder);
                agent.ShowAssignedOrders();

                // Update delivery status
                agent.UpdateDeliveryStatus("Out for Delivery");
                agent.UpdateDeliveryStatus("Delivered");

                Console.WriteLine("\nUpdated Order Info:");
                sampleOrder.DisplayOrderInfo();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            // Additional demonstration: Polymorphism using base class reference (Hierarchical inheritance)
            Console.WriteLine("\n\n=== DEMONSTRATING HIERARCHICAL INHERITANCE (User references) ===");
            User user1 = new Customer(301, "Charlie", "charlie@shop.com");
            User user2 = new DeliveryAgent(302, "Diana", "diana@delivery.com");

            user1.Introduce();
            user2.Introduce();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
