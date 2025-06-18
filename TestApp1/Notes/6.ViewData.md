# ViewData in ASP.NET MVC Application

## Overview
ViewData in ASP.NET MVC is a mechanism to pass data from a controller action method to a view. It is a dictionary object that stores data in key-value pairs, where each key is a string and the value is stored as an object.

## Key Points
1. **Definition**: 
   - ViewData is a property of the `ControllerBase` class with a return type of `ViewDataDictionary`.
   - It implements the `IDictionary` interface.

2. **Usage**:
   - **Passing Data**: Data can be passed from the controller to the view using ViewData.
   - **Retrieving Data**: Data must be typecast when retrieved (except for string values).

3. **Example**:
   - **Controller Code**:
     ```csharp
     public ActionResult Index()
     {
         EmployeeBusinessLayer employeeBL = new EmployeeBusinessLayer();
         Employee employee = employeeBL.GetEmployeeDetails(102);
         ViewData["Employee"] = employee;
         ViewData["Header"] = "Employee Details";
         return View();
     }
     ```
   - **View Code**:
     ```html
     @{
         var employee = ViewData["Employee"] as FirstMVCDemo.Models.Employee;
     }
     <h2>@ViewData["Header"]</h2>
     <table>
         <tr>
             <td>Employee ID:</td>
             <td>@employee.EmployeeId</td>
         </tr>
         <!-- Other employee details -->
     </table>
     ```

4. **Characteristics**:
   - **Dynamic Resolution**: ViewData is resolved at runtime, so it lacks compile-time error checking and IntelliSense support.
   - **Scope**: Valid only during the current request.

## When to Use ViewData
ViewData is suitable for passing small amounts of data from the controller to the view. For complex scenarios, consider using ViewBag, TempData, Session, or strongly-typed views.

## Limitations
- Requires explicit typecasting for non-string values.
- No compile-time error checking for key names.
- Short-lived (only for the current request).