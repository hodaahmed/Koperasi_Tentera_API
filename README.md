# Koperasi Tentera API

This project provides RESTful APIs for managing customer operations and OTP (One-Time Password) validation in a cooperative management system. It includes features for customer validation, registration, and OTP verification.

---

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [API Endpoints](#api-endpoints)
  - [Customer API](#customer-api)
  - [OTP API](#otp-api)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Customer Management**: Validate, register, and update customer details.
- **OTP Validation**: Verify one-time passwords securely.
- **Error Handling**: Clear and consistent error messages.

---

## Technologies Used

- **Framework**: ASP.NET Core 6.0
- **Language**: C#
- **Database**: SQL Server (if applicable for persistence)
- **Tools**: Dependency Injection, Swagger for API documentation

---

## API Endpoints

### Customer API

#### 1. Validate IC Number
- **Endpoint**: `POST /api/customers/validate`
- **Description**: Validates a customer's IC (Identity Card) number.and if it is exist will geneate mobile and email OTP
- **Request Body**:
  ```json
  "icNumber": "string"
  ```
- **Responses**:
  - **200 OK**:
    ```json
    {
        "message": "OTP sent successfully , customerId : customer.Id ,mobile otp: mobileOtp  , email otp:  mobileOtp;" 
    }
    ```
  - **400 Bad Request**:
    ```json
    {
        "message": "IC Number already exists"
    }
    ```

#### 2. Register or Validate Customer
- **Endpoint**: `POST /api/customers/register-or-validate`
- **Description**: Registers a new customer and return generated Email and Mobile OTP code or validates if an existing customer meets specific criteria(Email , Mobile) 
- **Request Body**:
  ```json
  {
      "customerId": "string",
      "name": "string",
      "email": "string",
      "mobile": "string",
      "icNumber": "string",
      ...
  }
  ```
  *(Structure depends on the `Customer` model.)*
- **Responses**:
  - **200 OK**:
    ```json
    {
        "message": "OTP sent successfully , customerId : customer.Id ,mobile otp: mobileOtp , email otp: mobileOtp;"
    }
    ```
  - **400 Bad Request**:
    ```json
    {
        "message": "Customer already exists"
    }
    ```

#### 3. Update Customer
- **Endpoint**: `POST /api/customers/update-customer`
- **Description**: Updates customer information.specially for update PIN Code
- **Request Body**:
  ```json
  {
      "customerId": "string",
      "name": "string",
      "email": "string",
      "mobile": "string",
      ...
  }
  ```
  *(Structure depends on the `Customer` model.)*
- **Responses**:
  - **200 OK**:
    ```json
    {
        "message": "Customer updated successfully"
    }
    ```
  - **400 Bad Request**:
    ```json
    {
        "message": "Customer update failed"
    }
    ```

---

### OTP API

#### 1. Validate OTP
- **Endpoint**: `POST /api/OTP/validate-otp`
- **Description**: Validates a customer's OTP (One-Time Password).
- **Request Body**:
  ```json
  {
      "customerId": "string",
      "OTP": "string",
      "OTPType": "string"
  }
  ```
- **Responses**:
  - **200 OK**:
    ```json
    {
        "message": "OTP validated successfully."
    }
    ```
  - **400 Bad Request**:
    ```json
    {
        "message": "Invalid OTP." || "OTP not found." || "OTP has expired."
    }
    ```

---

## Getting Started

### Prerequisites

- .NET 6.0 SDK
- SQL Server (if required for persistence)
- Postman or similar API testing tool

### Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd Koperasi_Tentera_API
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Update the `appsettings.json` file with your configuration (e.g., database connection string).

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API documentation at `http://localhost:<port>/swagger`.

---

## Contributing

1. Fork the repository.
2. Create a new branch for your feature or bug fix:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Description of changes"
   ```
4. Push the branch:
   ```bash
   git push origin feature-name
   ```
5. Open a pull request.

---

## License

This project is licensed under the [MIT License](LICENSE).

---

Let me know if you need additional details or modifications!

