## 📌 Key Features

- RESTful API built with ASP.NET Core
- Entity Framework Core for database access
- Authentication & Authorization (JWT-based)
- API versioning and validation
- Modular architecture with Services, Repositories, and Controllers

---

## 🛠 Tech Stack

- ASP.NET Core Web API
- ASP.NET Core Web MVC
- Entity Framework Core
- LINQ
- SQL Server
- Manual Mapping
- JWT for authentication with Identity
- Swagger (for API documentation)
---


# 🧑‍💻 Coding Standards & Naming Conventions

## 1. Fields
- Prefix: `_`
- Format: `_fieldName`
- Example: `_userManager`

## 2. Parameters
- camelCase
- Example: `userManager`

## 3. Methods
- PascalCase
- Example: `AddProduct()`

## 4. Controllers
- Must end with `Controller`
- Example: `ProductsController`

## 5. Interfaces
- Start with `I`, PascalCase
- Example: `IUserService`, `IRepository`

## 6. Classes
- PascalCase
- Example: `UserManager`, `ProductService`, `Order`

## 7. Properties
- PascalCase
- Example: `UserName`, `Email`, `CreatedDate`

## 8. Private Fields
- `_` prefix + camelCase
- Example: `_logger`, `_userRepository`

## 9. Local Variables
- camelCase
- Example: `orderList`, `productCount`

## 10. Constants
- UPPER_CASE_WITH_UNDERSCORES
- Example: `MAX_USERS`, `DEFAULT_PAGE_SIZE`

## 11. Enums
- PascalCase for both Enum Name and Values

```csharp
enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered
}
```
12. Database Tables
PascalCase (Plural)

Example: Users, Products, Orders

13. Database Columns
PascalCase

Example: FirstName, CreatedAt

14. Primary Keys
Format: {ClassName}Id

Example: StudentId
✅ EF Core will recognize it automatically as PK.

15. DTOs
PascalCase + DTO suffix

Example: StudentDTO, ProductDTO

16. Navigation Properties
PascalCase (start with capital letter)

Example:

```csharp
public ICollection<Student> Students { get; set; }
```
17. Null Validation
Always call CheckIfNull(object) after fetching from DB

Will be handled later with global exception

```csharp
var studentModel = await _studentRepository.GetByIdAsync(id);
id.CheckIfNull<Student>(studentModel); //Extension Method!
```
## ✨ Clean Code Tips

✅ **Use descriptive names** (avoid: `a`, `x`, `temp`)  
✅ **One responsibility per method**  
✅ **Avoid long methods** — prefer small, focused ones  
✅ **Always add XML comments for public methods**  
✅ **Group related files in meaningful folders**  
✅ **Prefer `async/await` with `Async` suffix**  
✅ **Avoid using magic strings/numbers** — use constants  
✅ **Use dependency injection**, don’t instantiate dependencies manually  
✅ **Use Logger** not `Console.WriteLine`  
✅ **Avoid code duplication**  
✅ **Don’t leave commented-out code in commits**  
✅ **Keep consistent formatting** (tabs/spaces, braces style...)  
✅ **Write unit tests when possible**  
✅ **Use AutoMapper** for mapping between Entities and DTOs  
✅ **Don't overuse regions** — keep code readable  
✅ **Avoid multiple returns in long methods unless necessary**  
✅ **Prefer immutability** where possible  
✅ **Use access modifiers explicitly** (`private`, `public`...)


