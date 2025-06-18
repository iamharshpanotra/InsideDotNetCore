# ASP.NET MVC Models

## Table of Contents
1. [What are Models?](#what-are-models)
2. [Creating Models](#creating-models)
3. [Model Folder Structure](#model-folder-structure)
4. [Using Models with Controllers](#using-models-with-controllers)
5. [Model Best Practices](#model-best-practices)
6. [Complete Example](#complete-example)
7. [Advantages of MVC Models](#advantages-of-mvc-models)

---

## What are Models?
- **Purpose**: 
  - Represent business/domain data
  - Contain business logic
  - Manage application state
- **Location**: 
  - Typically stored in `Models` folder
- **Types**:
  - **Domain Models**: Represent business entities (e.g., `Employee`, `Product`)
  - **View Models**: Specialized models for views
  - **Business Logic**: Classes that operate on domain data

---

## Creating Models

### Step 1: Add Domain Model
1. Right-click `Models` folder
2. Select **Add → Class**
3. Name it (e.g., `Employee.cs`)
4. Define properties:

```csharp
namespace MyApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
```

### Step 2: Add Business Logic
```csharp
namespace MyApp.Models
{
    public class EmployeeBusinessLayer
    {
        public Employee GetEmployeeDetails(int employeeId)
        {
            // In real apps, fetch from database
            return new Employee
            {
                EmployeeId = employeeId,
                Name = "John Doe",
                Gender = "Male",
                City = "New York",
                Salary = 50000,
                Address = "123 Main St"
            };
        }
    }
}
```

---

## Model Folder Structure
```
Models/
├── Employee.cs                (Domain model)
├── EmployeeBusinessLayer.cs   (Business logic)
└── ViewModels/                (Optional)
    ├── EmployeeViewModel.cs
```

---

## Using Models with Controllers

### 1. Passing Model to Controller
```csharp
using MyApp.Models;
using System.Web.Mvc;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult EmployeeDetails(int id)
        {
            // Get data from business layer
            var employeeBL = new EmployeeBusinessLayer();
            var employee = employeeBL.GetEmployeeDetails(id);
            
            // Pass model to view
            return View(employee);
        }
    }
}
```

### 2. Using Model in View
```html
@model MyApp.Models.Employee

<h2>Employee Details</h2>
<div>
    <p>ID: @Model.EmployeeId</p>
    <p>Name: @Model.Name</p>
    <p>Salary: @Model.Salary.ToString("C")</p>
</div>
```

---

## Model Best Practices
1. **Separation of Concerns**:
   - Keep domain models pure (no business logic)
   - Put business logic in separate classes

2. **Validation**:
   ```csharp
   public class Employee
   {
       [Required]
       public string Name { get; set; }
       
       [Range(0, 100000)]
       public decimal Salary { get; set; }
   }
   ```

3. **View Models**:
   - Create specialized models for complex views
   - Avoid passing domain models directly to views

4. **Data Access**:
   - Use Repository pattern
   - Consider Entity Framework for ORM

---

## Complete Example

### 1. Model Classes
```csharp
// Employee.cs
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}

// EmployeeRepository.cs
public class EmployeeRepository
{
    public Employee GetById(int id)
    {
        // Database query would go here
        return new Employee 
        { 
            Id = id, 
            Name = "Jane Smith", 
            Department = "HR" 
        };
    }
}
```

### 2. Controller
```csharp
public class EmployeeController : Controller
{
    public ActionResult Details(int id)
    {
        var repository = new EmployeeRepository();
        var employee = repository.GetById(id);
        return View(employee);
    }
}
```

### 3. View (Details.cshtml)
```html
@model MyApp.Models.Employee

<h2>@Model.Name</h2>
<p>Department: @Model.Department</p>
```

---

## Advantages of MVC Models
1. **Separation of Concerns**:
   - Clean separation between data, logic and UI
2. **Testability**:
   - Business logic can be unit tested
3. **Maintainability**:
   - Changes to data structure don't affect UI
4. **Validation**:
   - Centralized validation logic
5. **Flexibility**:
   - Can use different data sources (DB, APIs, etc.)

---

## Common Errors & Solutions

### Error: "Model is null"
**Solution**:
```csharp
// In controller:
return View(employee); // Ensure model is passed
```

### Error: Validation not working
**Solution**:
```html
<!-- In view: -->
@Html.ValidationSummary()
@Html.EditorForModel()
```

---

## Summary
| Concept | Description |
|---------|-------------|
| **Domain Models** | Represent business entities (e.g., Employee) |
| **Business Logic** | Classes that operate on domain data |
| **View Models** | Specialized models for views |
| **Best Practice** | Keep models focused on data/behavior |

### Key Takeaways:
1. Models represent **data** and **business logic**
2. Follow **separation of concerns**
3. Use **validation attributes**
4. Consider **view models** for complex views
5. Keep controllers **thin** by moving logic to models
