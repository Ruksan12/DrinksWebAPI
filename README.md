# DrinksWebAPI

A .NET 10 console application that interacts with [TheCocktailDB API](https://www.thecocktaildb.com/) 
to browse drink categories and view detailed cocktail recipes.

## 📖 Project Description

DrinksWebAPI is an interactive console application that allows users to:

- Browse available drink categories (e.g., Cocktail, Shot, Coffee/Tea)
- View drinks within a selected category
- Display detailed information about a specific drink, including:
  - Category and glass type
  - Alcoholic content
  - Preparation instructions
  - Ingredients and measurements

## 🚀 How to Build and Run

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later

### Steps
- cd DrinksWebAPI
- dotnet build
- dotnet run

### Usage

1. Select a drink category by entering its number
2. Choose a drink from the list
3. View the drink's details (ingredients, instructions, etc.)
4. Press Enter to continue browsing, or enter `0` to quit

## 🧠 Thought Process

### What Was Hard?

- **API Response Mapping**:
  TheCocktailDB API returns ingredients as separate numbered properties, requiring individual property mapping in the `DrinkDetail` model.
- **Input Validation**:
  Handling edge cases for user input while keeping the console experience smooth required careful design of the `InputHelper` class with retry logic.

### What Was Easy?

- **HTTP Client Integration**: .NET's `HttpClient` and `System.Text.Json` made consuming the REST API straightforward with minimal boilerplate.
- **Project Structure**: Separating concerns into `Models`, `Services`, and `Validation` folders followed natural patterns and kept the codebase organized.

### What I Learned

- How to consume external REST APIs using `HttpClient` and deserialize JSON responses
- Implementing clean separation between API logic (`DrinksApiService`) and presentation (`Program.cs`)
- Building reusable input validation helpers for console applications
- Proper error handling for network requests with `try-catch` blocks
