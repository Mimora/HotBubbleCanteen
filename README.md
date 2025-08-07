# HotBubbleCanteen 

**A Hotpot Ordering System built with ASP.NET Core MVC + SQLite**

> A digital solution for hotpot restaurants – supports ordering, member registration, and order tracking.

## I. Preview
<img width="864" height="669" alt="01Home" src="https://github.com/user-attachments/assets/d0ee5e83-a9fd-4552-98f3-e11784313790" />
<img width="864" height="669" alt="02Menu" src="https://github.com/user-attachments/assets/12e136fe-bd59-41e6-9b80-94824718891e" />
<img width="864" height="669" alt="04Member" src="https://github.com/user-attachments/assets/414ca294-cd8b-4bb4-99c1-b8fa6cbadc58" />


## II. Features

### Ordering System
- Grouped Menu: Meat, Vegetables, Drinks
- Input table number and customer name
- Add quantities and submit order
- Apply Promo Code for discounts
- Order confirmation page with total and discount

### Order Lookup
- Search placed orders by customer name and table number

### Membership System
- Membership Registration with contact info and level
- Auto-generate 6-digit Promo Code
- Terms and Conditions agreement
- Membership Record Lookup and Deletion

## III. Tech Stack

| Layer         | Technology                       |
| ------------- | -------------------------------- |
| Frontend      | Razor Pages (.cshtml), HTML, CSS |
| Backend       | ASP.NET Core MVC                 |
| Database      | SQLite + Entity Framework Core   |
| Architecture  | MVC (Model-View-Controller)      |

## VI. Database Design (EF Code-First)

- `Dish` – stores menu items with price, image, and category
- `Order` – records customer name, table number, timestamp
- `OrderItem` – links order and dishes with quantity
- `Member` – stores member info and generated promo code

## V. Design Features

- EF Core Code-First Migration
- Database seeding for default dish entries
- Promo Code logic for member discount
- Order total + discount calculation on confirmation page

## VI. Getting Started

Clone the repo:
   ```bash
   git clone https://github.com/Mimora/HotBubbleCanteen.git
   cd HotBubbleCanteen
