
# 🐳 .NET Order API — Dockerized Microservice

A simple .NET API project for order management, using Docker, Entity Framework Core, and Swagger for API exploration.

---

## 📦 Running with Docker Compose

Make sure Docker and Docker Compose are installed on your machine.

1. Open your terminal.
2. Navigate to the project root folder.
3. Run this command:

```bash
docker-compose up --build
```

This will download dependencies, build the containers, and start the services.

---

## 💾 Applying EF Core Migrations

Once the container is running, open a terminal and execute:

```bash
docker exec -it {your-api-container-name} dotnet ef database update
```

Replace `{your-api-container-name}` with the name of your running API container.

This will apply any pending Entity Framework Core migrations to your database.

---

## 🔍 Accessing Swagger UI

After your container is up and running, open this URL in your browser:

```
http://localhost:{your_port}/swagger
```

Example:
```
http://localhost:5000/swagger
```

This will open the Swagger page where you can explore and test your endpoints.

---

## 📬 Sample Data for `/api/v1/order/create`

When using Swagger or Postman to test your API, send a POST request to:

```
/api/v1/order/create
```

With the following JSON:

```json
{
  "id": "49fd4749-cce4-416c-8c11-33fad86d0308",
  "createdAt": "2025-04-15T19:13:59.462Z",
  "updatedAt": "2025-04-15T19:13:59.462Z",
  "company": {
    "id": "4e70cc6d-b139-4e26-9d8d-ecce10614531",
    "createdAt": "2025-04-15T19:13:59.462Z",
    "updatedAt": "2025-04-15T19:13:59.462Z",
    "cnpj": "04252011000110",
    "companyName": "Serious Business",
    "tradeName": "Monkey Business",
    "addresses": [
      {
        "id": "7985a109-c93c-4f24-b9ad-ebb7bade6b35",
        "createdAt": "2025-04-15T19:13:59.462Z",
        "updatedAt": "2025-04-15T19:13:59.462Z",
        "streetName": "Main Street",
        "number": 123,
        "city": "Sample City",
        "neighborhood": "Central",
        "postalCode": "12345",
        "companyId": "4e70cc6d-b139-4e26-9d8d-ecce10614531"
      }
    ],
    "phones": [
      {
        "id": "1472184c-06fb-4a91-912c-43f1d284b516",
        "createdAt": "2025-04-15T19:13:59.462Z",
        "updatedAt": "2025-04-15T19:13:59.462Z",
        "number": "+55988888888"
      }
    ],
    "contactUser": [
      {
        "id": "e310b670-d6fe-4999-9b0a-639a8b925e9b",
        "createdAt": "2025-04-15T19:13:59.462Z",
        "updatedAt": "2025-04-15T19:13:59.462Z",
        "firstName": "John",
        "lastName": "Doe",
        "email": "johndoe@email.com",
        "password": "S3cur3P4$$w0rD",
        "phone": "+55988888888"
      }
    ]
  },
  "orderProducts": [
    {
      "id": "8fb440fe-65b6-4bb0-96a6-07a0f5c669ec",
      "createdAt": "2025-04-15T19:13:59.462Z",
      "updatedAt": "2025-04-15T19:13:59.462Z",
      "orderId": "49fd4749-cce4-416c-8c11-33fad86d0308",
      "product": {
        "id": "c746784f-4289-4cce-9a87-bd6c4469a767",
        "createdAt": "2025-04-15T19:13:59.462Z",
        "updatedAt": "2025-04-15T19:13:59.462Z",
        "name": "Sample Product",
        "description": "A sample product description",
        "isAvailable": true,
        "price": 99.99
      },
      "quantity": 1,
      "totalAmount": 99.99
    }
  ],
  "address": {
    "id": "842857f5-2e09-40a3-9c35-8832fcc62e0f",
    "createdAt": "2025-04-15T19:13:59.462Z",
    "updatedAt": "2025-04-15T19:13:59.462Z",
    "streetName": "Secondary Street",
    "number": 456,
    "city": "Another City",
    "neighborhood": "Uptown",
    "postalCode": "67890",
    "companyId": "4e70cc6d-b139-4e26-9d8d-ecce10614531"
  }
}
```

---

✅ **Now you're ready to run and test your Order API!**
