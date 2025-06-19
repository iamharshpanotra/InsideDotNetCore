# ASP.NET MVC Views

## Overview
This article explains **ASP.NET MVC Views** with examples, covering their purpose, structure, creation, and advantages. Views are responsible for rendering the user interface in MVC applications.

---

## What are ASP.NET MVC Views?
- **Definition**:  
  Views are HTML templates with embedded **Razor syntax** that generate HTML responses.
- **Purpose**:
  - Render model data as UI
  - Handle presentation logic
  - Separate UI from business logic
- **File Extension**: `.cshtml` (for C# with Razor)

---

## Where are View Files Stored?
### Default Structure:
```
Views/
├── Home/
│   ├── Index.cshtml
│   ├── AboutUs.cshtml
│   └── ContactUs.cshtml
├── Student/
│   ├── Index.cshtml
│   ├── Details.cshtml
│   ├── Edit.cshtml
│   └── Delete.cshtml
└── Shared/
    ├── _Layout.cshtml
    └── Error.cshtml
```

### Key Rules:
1. **Controller-Specific Views**:  
   Stored in `Views/{ControllerName}/` (e.g., `Views/Home/Index.cshtml`)
2. **Shared Views**:  
   Stored in `Views/Shared/` (e.g., layouts, error pages)
3. **Naming Convention**:  
   View name must match action method name

---

## Creating Views in ASP.NET MVC

### Method 1: Using Visual Studio
1. Right-click in controller action method
2. Select **Add View**
3. Configure options:
   ```text
   View name: [Auto-filled]
   Template: Empty
   Model class: (optional)
   Create as partial view: ☐
   Use layout page: ☐ (for simple views)
   ```

### Method 2: Manual Creation
1. Add `.cshtml` file to appropriate folder
2. Basic view structure:
   ```html
   @{
       Layout = null;
   }
   <!DOCTYPE html>
   <html>
   <head>
       <title>Index</title>
   </head>
   <body>
       <h1>Welcome</h1>
   </body>
   </html>
   ```

---

## Understanding Views with Examples

### Example 1: Basic View
**Controller**:
```csharp
public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View(); // Looks for Views/Home/Index.cshtml
    }
}
```

**View (Index.cshtml)**:
```html
@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <title>Home Page</title>
</head>
<body>
    <h1>Welcome to our website!</h1>
</body>
</html>
```

### Example 2: View with Model
**Controller**:
```csharp
public ActionResult Details(int id)
{
    var student = _repository.GetStudent(id);
    return View(student); // Pass model to view
}
```

**View (Details.cshtml)**:
```html
@model Student

<h2>Student Details</h2>
<p>ID: @Model.StudentID</p>
<p>Name: @Model.Name</p>
<p>Grade: @Model.Grade</p>
```

---

## View Resolution Process
When `return View()` is called:
1. Checks in `Views/{ControllerName}/{Action}.cshtml`
2. Checks in `Views/Shared/{Action}.cshtml`
3. Throws error if not found

![View Resolution Flow](https://example.com/view-resolution.png)

---

## Advantages of MVC Views
1. **Separation of Concerns**:
   - Clean separation between UI and business logic
2. **Razor Syntax**:
   - Easy mixing of HTML and C#
   - IntelliSense support
3. **Reusability**:
   - Layouts for common templates
   - Partial views for components
4. **Testability**:
   - Views can be unit tested
5. **Performance**:
   - Compiled views for better performance

---

## Common Errors & Solutions

### Error: "View not found"
**Solution**:
1. Verify view exists in correct folder
2. Check case sensitivity
3. Ensure view name matches action name

### Error: "Model is null"
**Solution**:
```csharp
// In controller:
public ActionResult Details(int id)
{
    var model = _service.GetDetails(id);
    return View(model); // Pass model to view
}
```

---

## Complete View Example
```html
@model IEnumerable<Student>

@{
    ViewBag.Title = "Student List";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>@ViewBag.Title</h2>

<table class="table">
    <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Grade</th>
    </tr>
    
    @foreach (var student in Model)
    {
        <tr>
            <td>@student.StudentID</td>
            <td>@student.Name</td>
            <td>@student.Grade</td>
        </tr>
    }
</table>

@Html.ActionLink("Add New", "Create")
```

---

## Summary
| Concept | Description |
|---------|-------------|
| **View Location** | `Views/{Controller}/{Action}.cshtml` |
| **Razor Syntax** | `@` for C# code, `@model` for strong typing |
| **Layouts** | Master templates (`_Layout.cshtml`) |
| **View Methods** | `View()`, `PartialView()`, `View(model)` |
| **Best Practice** | Keep views focused on presentation |

### Key Takeaways:
1. Views handle **UI rendering** only
2. Follow **naming conventions** strictly
3. Use **strongly-typed views** when possible
4. Leverage **layouts** for consistent UI
5. Keep business logic out of views
```