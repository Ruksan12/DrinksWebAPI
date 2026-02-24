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

- individual property mapping in the `DrinkDetail` model.
- required careful design of the `InputHelper` class with retry logic.

### What Was Easy?

- .NET's HttpClient and System.Text.Json made consuming the REST API easy
- Separating of concerns followed natural patterns and kept the codebase organized.

### What I Learned

- How to consume external REST APIs using `HttpClient` and deserialize JSON responses
- Implementing clean separation between API logic and presentation
- Building reusable input validation helpers for console applications
- Proper error handling for network requests with `try-catch` blocks
