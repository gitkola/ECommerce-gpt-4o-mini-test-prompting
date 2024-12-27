# Завдання

Розробити ASP.NET Solution "ECommerce".
"ECommerce" - це мікросервісна система для інтернет-магазину, яке складається з чотирьох мікросервісів для керування замовленнями (Orders), продуктами (Products), покупцями (Customers) та пошуком (Search).
Мікросервіси Customers, Products та Orders повинні управляти власними даними, які мають зберігати в окремих базах даних MySQL.
Мікросервіс Search повинен взаємодіяти з мікросервісами Customers, Products та Orders для отримання даних про усі замовлення користувача по CustomerId.
Мікросервіс Search на звичайний GET запит має повертати web-сторінку (SPA) яка має відображати поле вводу CustomerId, кнопку "Submit" для відправки запиту з введеним CustomerId до API Search про усі замовлення користувача, та відображати відповідь на запит за допомогою `JSON.stringify(data, null, 2);`.
Мікросервіс Search повинен повертати об'єднані дані у JSON об'єкті наступної форми:

```json
{
  "customer": {
    "id": "0c5b94b1-35ad-49bb-b118-8e8fc24abf80",
    "name": "John Doe",
    "email": "john.doe@email.com"
  },
  "orders": [
    {
      "id": "1c5b94b1-35ad-49bb-b118-8e8fc24abf80",
      "customerId": "0c5b94b1-35ad-49bb-b118-8e8fc24abf80",
      "orderDateTime": "2021-01-01T00:00:00Z",
      "orderItems": [
        {
          "id": "2c5b94b1-35ad-49bb-b118-8e8fc24abf80",
          "orderId": "1c5b94b1-35ad-49bb-b118-8e8fc24abf80",
          "productId": "9c5b94b1-35ad-49bb-b118-8e8fc24abf80",
          "quantity": 1,
          "price": 100.0
        }
      ]
    }
  ],
  "products": {
    "9c5b94b1-35ad-49bb-b118-8e8fc24abf80": {
      "id": "9c5b94b1-35ad-49bb-b118-8e8fc24abf80",
      "name": "Product 1",
      "price": 100.0,
      "description": "Description 1"
    }
  }
}
```

## Вимоги до ASP.NET Solution "ECommerce"

TargetFramework: net8.0
Необхідно створити ASP.NET Solution "ECommerce.sln" до якого мають входити наступні проєкти:

- ECommerce.Api.Customers
- ECommerce.Api.Orders
- ECommerce.Api.Products
- ECommerce.Api.Search

Усі проєкти повинні мати файл Program.cs у якості точки входу.
Усі проєкти повинні застосовувати Dependency Injection для керування залежностями.

## Вимоги до моделей даних

- Усі моделі повинні мати властивість Id типу UUID
- Customer: Id, Name (required), Email (required, valid email, unique)
- Order: Id, CustomerId (required), OrderItems (required, OrderItem.ProductId should not repeat in the list)
- OrderItem: Id, OrderId (related to Order.Id), ProductId (required), Quantity (required, greater then 0), Price (required, greater then 0)
- Product: Id, Name (required), Price (required, greater then 0), Description

## Вимоги до підключення до бази даних MySQL

1. Проєкти ECommerce.Api.Customers, ECommerce.Api.Products та ECommerce.Api.Orders повинні підключатися до відповідних баз даних `CustomersDb`, `ProductsDb` та `OrdersDb`
2. Для роботи з MySQL використовувати залежність `Pomelo.EntityFrameworkCore.MySql`
3. Потрібно застосовувати інтерфейси для простішої заміни баз даних
4. Потрібно застосовувати патерн Data Access Object
5. Конфігурація підключення до локальної бази даних MySQL має бути у файлі `appsettings.json`, наприклад для ECommerce.Api.Customers:

```json
{
  "DatabaseProvider": "MySQL",
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=CustomersDb;user=root;password=rootroot"
  }
}
```

## Вимоги до контролерів

- Для кожного вхідного запит у потрібно реалізувати відповідну валідацію вхідних параметрів
- Потрібно застосовувати залежність `AutoMapper.Extensions.Microsoft.DependencyInjection`
- У кожній відповіді на запит крім основних даних мають бути властивості - nullable `ErrorString` та boolean `isSuccessful`
- CustomersController: GET, GET by Id, POST, PUT, DELETE
- OrdersController: GET, GET by CustomerId, POST, PUT, DELETE
- ProductsController: GET, GET by ProductId, POST, PUT, DELETE
- SearchController: GET by CustomerId

## Вимоги до сервісів

- Кожен сервіс повинен додавати до усіх відповідей властивості - nullable `ErrorString` та boolean `isSuccessful`
- Потрібно застосовувати інтерфейси для простішої заміни сервісів
- Потрібно застосовувати патерн Data Transfer Object
- CustomersService: GetAllAsync, GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync
- OrdersService: GetAllAsync, GetByCustomerIdAsync, CreateAsync, UpdateAsync, DeleteAsync
- ProductsService: GetAllAsync, GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync
- SearchService: GetByCustomerIdAsync

## Бізнес вимоги

- Перед створенням нового замовлення (Order) потрібна перевірка, що в параметрах вказані CustomerId та ProductId існують в базах даних

## Вимоги до документації

- Створити документацію для кожного проєкту
- Використати Swagger для документування API

## Вимоги до відповіді та її оформлення

Відповідь має містити лише код, описи чи пояснення доавати не потрібно.
ВАЖЛИВО - надай повний код для УСІХ НЕОБХІДНИХ ФАЙЛІВ ДЛЯ КОЖНОГО ПРОЄКТУ (ECommerce.Api.Customers, ECommerce.Api.Orders, ECommerce.Api.Products, ECommerce.Api.Search). Кожен файл має бути в окремому 'code snippet' з закоментованим відносним шляхом до відповідного файлу у першому рядку.
