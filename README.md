# 🍽️ Arriba Eats - Delivery Management System

A comprehensive **C# console application** designed to manage food delivery operations with support for three distinct user roles: Customers, Clients (Restaurant Owners), and Deliverers.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [User Roles](#user-roles)
- [Project Structure](#project-structure)
- [Technology Stack](#technology-stack)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Class Hierarchy](#class-hierarchy)

---

## 🎯 Overview

Arriba Eats is a multi-role delivery management system that enables seamless coordination between customers placing orders, restaurants managing inventory, and deliverers fulfilling orders. Built with **Object-Oriented Programming (OOP)** principles, the application emphasizes encapsulation, inheritance, and polymorphism for maintainability and scalability.

---

## ✨ Features

- **🔐 User Authentication** - Secure login and account creation for all user types
- **📦 Order Management** - Create, track, and manage orders with real-time status updates
- **🍴 Restaurant Management** - Clients can manage menu items and incoming orders
- **🚚 Delivery Tracking** - Deliverers can view assigned orders and update delivery status
- **⭐ Rating System** - Customers can submit ratings and feedback for completed orders
- **👥 Multi-Role Support** - Role-based access with tailored functionality per user type
- **💾 Data Persistence** - Orders and user data are managed through the ArribaEatsData system
- **📋 Menu Management** - Create and manage restaurant menus with items
- **🗺️ Location Management** - Track delivery locations and restaurant addresses
- **📊 Order Status Tracking** - Real-time order status from placement to delivery

---

## 🏗️ Architecture

The application follows **Object-Oriented Design Patterns** with:

- **Inheritance**: User base class with specialized Customer, Client, and Deliverer subclasses
- **Encapsulation**: Properties with controlled access through getters/setters
- **Polymorphism**: Virtual methods for role-specific functionality
- **Data Management**: Centralized ArribaEatsData class managing all business entities
- **User Management**: UserManager class handling authentication and user operations
- **UI Layer**: CmdLineUI class providing consistent command-line interface

---

## 👤 User Roles

| Role | Responsibilities |
|------|-----------------|
| **Customer** 🛒 | Browse restaurants and menus<br>📝 Place orders<br>⭐ Rate orders and deliveries<br>📊 Track order status<br>👤 Manage account |
| **Client** 🍽️ | Manage restaurant menu and items<br>📥 Receive and accept orders<br>⏱️ Update order preparation status<br>📈 Monitor incoming orders<br>👥 Manage restaurant details |
| **Deliverer** 🚚 | View assigned deliveries<br>✅ Mark orders as picked up and delivered<br>📍 Update delivery status<br>📞 Contact customers<br>📊 Track delivery history |

---

## 📁 Project Structure

```
Arriba_Eats/
├── Program.cs                 # Application entry point
├── ArribaEatsData.cs         # Central data management system
│
├── User Management/
├── User.cs                   # Base user class
├── Customer.cs               # Customer role implementation
├── Client.cs                 # Restaurant owner role implementation
├── Deliverer.cs              # Deliverer role implementation
├── UserManager.cs            # Authentication and user management
│
├── Business Entities/
├── Order.cs                  # Order entity
├── OrderStatus.cs            # Order status enumeration
├── Restaurant.cs             # Restaurant entity
├── Menu.cs                   # Menu management
├── Item.cs                   # Menu item entity
├── Location.cs               # Location/address entity
├── Rating.cs                 # Rating/review entity
│
├── UI Layer/
├── CmdLineUI.cs              # Command-line interface utilities
├── CustomerMenu.cs           # Customer interface
├── ClientMenu.cs             # Client/Restaurant interface
├── DelivererMenu.cs          # Deliverer interface
│
├── Configuration/
├── A3.csproj                 # C# project file (targets .NET 9.0)
├── metadata.yml              # Project metadata
└── README.md                 # This file
```

---

## 🛠️ Technology Stack

- **Language**: C# 
- **Framework**: .NET 9.0
- **Paradigm**: Object-Oriented Programming (OOP)
- **Interface**: Console-based Command Line UI
- **SDK**: Microsoft.NET.Sdk
- **Features**: Implicit Usings enabled, Nullable enabled

### Project Configuration
```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>net9.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
    </PropertyGroup>
</Project>
```

---

## 🚀 Getting Started

### Prerequisites
- **.NET 9.0 SDK** or later installed on your system
- A terminal/command prompt
- Git (for cloning the repository)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/saalssall/Arriba_Eats.git
   cd Arriba_Eats
   ```

2. **Navigate to the project directory**
   ```bash
   cd Arriba_Eats
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Build the project**
   ```bash
   dotnet build
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

### Running in Development Mode

For development with watch mode:
```bash
dotnet watch run
```

---

## 💻 Usage

### Starting the Application

Upon running the application, you'll be presented with the main menu:

```
===== ARRIBA EATS =====
1. Register
2. Login
3. Exit
```

### Customer Workflow

```
LOGIN AS CUSTOMER
↓
Browse Restaurants
↓
Select Restaurant & View Menu
↓
Add Items to Order
↓
Place Order
↓
Track Order Status
↓
Rate Order Once Delivered
```

**Customer Actions:**
- Create and manage account
- Browse available restaurants
- View menu items and prices
- Place and track orders
- Submit ratings and reviews
- View order history

### Client (Restaurant Owner) Workflow

```
LOGIN AS CLIENT
↓
Access Restaurant Dashboard
↓
Manage Menu Items
↓
View Incoming Orders
↓
Accept/Reject Orders
↓
Update Order Status
↓
View Order History
```

**Client Actions:**
- Manage restaurant profile
- Add/remove/edit menu items
- Set item prices and availability
- Accept customer orders
- Update order preparation status
- View incoming orders queue
- Track order fulfillment

### Deliverer Workflow

```
LOGIN AS DELIVERER
↓
View Available Deliveries
↓
Accept Delivery Assignment
↓
Pick Up Order from Restaurant
↓
Deliver to Customer
↓
Mark as Delivered
```

**Deliverer Actions:**
- View assigned orders
- Accept delivery requests
- Update pickup status
- Navigate to delivery locations
- Mark orders as delivered
- View delivery history
- Track earnings/statistics

---

## 🎓 Class Hierarchy

### User Class Inheritance

```
User (Abstract Base Class)
├── Customer
│   └── Properties: customerID, loyalty points
│   └── Methods: placeOrder(), rateOrder(), trackOrder()
│
├── Client (Restaurant Owner)
│   └── Properties: restaurantID, restaurantName
│   └── Methods: addMenuItem(), acceptOrder(), updateOrderStatus()
│
└── Deliverer
    └── Properties: vehicleType, deliveryArea
    └── Methods: viewAssignedOrders(), updateDeliveryStatus(), completeDelivery()
```

### Supporting Classes

```
Order
├── orderID (auto-incremented)
├── customer (Customer ref)
├── items (List<Item>)
├── restaurant (Restaurant ref)
├── deliverer (Deliverer ref)
├── status (OrderStatus enum)
└── timestamp

Restaurant
├── restaurantID
├── name
├── location (Location ref)
├── menu (Menu ref)
├── owner (Client ref)
└── rating (average)

Menu
├── menuID
├── restaurant (Restaurant ref)
├── items (List<Item>)
└── dateCreated

Item
├── itemID
├── name
├── description
├── price
├── availability
└── category

Rating
├── ratingID
├── order (Order ref)
├── customer (Customer ref)
├── score (1-5)
├── comment
└── timestamp

Location
├── address
├── city
├── state
├── zipCode
└── coordinates
```

---

## 🔑 Key Classes

### **User.cs**
Base abstract class containing common user properties and methods:
- **Properties**: Name, Email, Password, PhoneNumber, Age, UserType
- **Methods**: GetUserInfo(), DisplayMessageUser(), virtual methods for customization
- **Access**: Protected to allow inheritance

### **Order.cs**
Represents a customer order with complete tracking:
```csharp
public class Order
{
    public Customer Customer { get; }
    public int OrderID { get; }
    public List<Item> Items { get; }
    public OrderStatus OrderStatus { get; set; }
    public Restaurant Restaurant { get; }
    public Deliverer Deliverer { get; set; }
}
```

### **ArribaEatsData.cs**
Central data management system:
- Manages all users, orders, restaurants, and items
- Handles data persistence
- Provides CRUD operations for all entities
- Maintains data relationships

### **UserManager.cs**
Authentication and user management:
- User login validation
- Account registration
- Password verification
- User lookup and retrieval

### **OrderStatus.cs**
Enumeration tracking order progress:
```csharp
public enum OrderStatus
{
    Ordered,        // Initial state
    Confirmed,      // Restaurant confirmed
    Preparing,      // Restaurant preparing
    Ready,          // Ready for pickup
    OutForDelivery, // In transit
    Delivered,      // Completed
    Cancelled       // Cancelled
}
```

### **CmdLineUI.cs**
Provides consistent user interface:
- Display messages and prompts
- Input validation
- Menu formatting
- Error handling

---

## 📊 Data Flow

### Order Placement Flow
```
Customer Input
    ↓
Validation (UserManager)
    ↓
Create Order (Order class)
    ↓
Add to ArribaEatsData
    ↓
Update Restaurant (Menu/Items)
    ↓
Notify Client
```

### Delivery Assignment Flow
```
Order Ready for Delivery
    ↓
Assign Deliverer (Deliverer selection)
    ↓
Update Order Status
    ↓
Notify Deliverer
    ↓
Deliverer confirms pickup
    ↓
Update Order status → OutForDelivery
    ↓
Delivery complete → Delivered
```

---

## 🔐 Security Features

- **Password Protection**: User passwords are stored securely
- **Authentication**: Login validation before access
- **Role-Based Access**: Different menu options per user type
- **Data Encapsulation**: Private fields with controlled access

---

## 🎨 UI Features

- **Menu-Driven Interface**: Easy navigation for all user types
- **Error Handling**: User-friendly error messages
- **Input Validation**: Prevents invalid data entry
- **Status Indicators**: Clear display of order status
- **Formatted Output**: Clean, organized data presentation

---

## 📈 Future Enhancements

- 💳 Payment processing integration (Stripe/PayPal)
- 📧 Email/SMS notifications
- 🗺️ GPS integration for real-time tracking
- 🗄️ Database integration (SQL Server, PostgreSQL)
- 🎨 GUI implementation (WPF/MAUI)
- 📱 Mobile application (iOS/Android)
- ⭐ Advanced recommendation engine
- 🔍 Search and filter functionality
- 📊 Analytics and reporting dashboard
- 🤖 Delivery optimization algorithm

---

## 🧪 Testing

To test the application:

1. **Customer Test Flow**
   - Register as Customer
   - Browse restaurants
   - Place an order
   - Rate the order

2. **Client Test Flow**
   - Register as Client
   - Add menu items
   - Accept incoming orders
   - Update order status

3. **Deliverer Test Flow**
   - Register as Deliverer
   - Accept delivery assignment
   - Update delivery status

---

## 📝 Coding Standards

- **Naming Conventions**: PascalCase for classes/methods, camelCase for variables
- **Documentation**: XML comments for all public members
- **Organization**: Related classes grouped by functionality
- **Error Handling**: Try-catch blocks for exception handling
- **Code Comments**: Clear comments for complex logic

---

## 🤝 Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is open source and available under the MIT License.

---

## 👨‍💻 Author

**saalssall** - [GitHub Profile](https://github.com/saalssall)

---

## 📞 Support & Troubleshooting

### Common Issues

**Issue**: Application won't run
- **Solution**: Ensure .NET 9.0 SDK is installed: `dotnet --version`

**Issue**: Build fails
- **Solution**: Run `dotnet clean` then `dotnet build`

**Issue**: Dependencies not found
- **Solution**: Run `dotnet restore`

For more help, please open an issue on the [GitHub repository](https://github.com/saalssall/Arriba_Eats/issues).

---

## 🎯 Project Goals

- ✅ Implement multi-role delivery management system
- ✅ Apply OOP principles (Encapsulation, Inheritance, Polymorphism)
- ✅ Create user-friendly console interface
- ✅ Manage complex data relationships
- 🔄 Expand to web/mobile platforms
- 🔄 Implement persistent database storage

---

## 📚 Learning Outcomes

This project demonstrates:
- Object-Oriented Programming (OOP) principles
- Class inheritance and polymorphism
- Encapsulation and data hiding
- Collection management (Lists, Dictionaries)
- User interface design for console applications
- Multi-role system architecture
- Data validation and error handling

---

## 🔗 Related Links

- [GitHub Repository](https://github.com/saalssall/Arriba_Eats)
- [.NET 9.0 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)
- [C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [OOP Principles](https://en.wikipedia.org/wiki/Object-oriented_programming)

---

**Last Updated**: June 2026  
**Project Status**: Active Development  
**Repository**: [saalssall/Arriba_Eats](https://github.com/saalssall/Arriba_Eats)

---

### Quick Reference

| Command | Purpose |
|---------|---------|
| `dotnet build` | Build the project |
| `dotnet run` | Run the application |
| `dotnet clean` | Clean build artifacts |
| `dotnet restore` | Restore dependencies |
| `dotnet watch run` | Run with file watch |

---

**Made with ❤️ for food delivery excellence**
