# ASP.NET MVC File and Folder Structure

## Overview
This article explains the **auto-generated file and folder structure** of an ASP.NET MVC 5 application, detailing the purpose of each component. Understanding this structure is crucial for efficient development.

---

## Default Folders and Files
When creating a new ASP.NET MVC 5 application, Visual Studio generates the following folders and files:

### 1. **App_Data**
- **Purpose**: Stores application data files (e.g., `.mdf`, LocalDB, XML).
- **Key Point**:  
  - IIS does **not serve files** from this folder.  
  - Typically empty initially; used later for databases or file storage.

### 2. **App_Start**
- **Purpose**: Contains configuration classes executed at application startup.
- **Key Files**:  
  - `BundleConfig.cs`: Configures CSS/JS bundling and minification.  
  - `FilterConfig.cs`: Registers global filters (e.g., error handling).  
  - `RouteConfig.cs`: Defines URL routing rules.  
  - `IdentityConfig.cs`: Manages authentication settings (if using Identity).

### 3. **Content**
- **Purpose**: Stores **static files** (CSS, images, icons).
- **Default Files**:  
  - `bootstrap.css` / `bootstrap.min.css`: Bootstrap framework styles.  
  - `Site.css`: Custom application styles.

### 4. **Controllers**
- **Purpose**: Contains controller classes (inheriting from `Controller`).
- **Naming Convention**:  
  - Class names **must end** with `"Controller"` (e.g., `HomeController`).  
  - Handles HTTP requests and returns responses.

### 5. **Fonts**
- **Purpose**: Stores custom font files (e.g., `.ttf`, `.woff`) for UI styling.

### 6. **Models**
- **Purpose**: Holds classes for **domain/business data** and logic.
- **Example**:  
  - `Student.cs`: Represents student data.  
  - `StudentBusinessLayer.cs`: Manages data operations (e.g., DB queries).

### 7. **Scripts**
- **Purpose**: Contains JavaScript files (e.g., jQuery, Bootstrap, custom scripts).
- **Default Files**:  
  - `jquery-{version}.js`: jQuery library.  
  - `bootstrap.js`: Bootstrap JavaScript.  
  - Custom scripts should be placed here for maintainability.

### 8. **Views**
- **Purpose**: Stores `.cshtml` files (Razor views) for UI rendering.
- **Subfolders**:  
  - **`/Home`**: Views for `HomeController`.  
  - **`/Shared`**: Shared views (e.g., `_Layout.cshtml`, error pages).  
- **Key Files**:  
  - `_ViewStart.cshtml`: Sets default layout.  
  - `_ViewImports.cshtml`: Imports namespaces for views.

---

## Configuration Files

### 1. **Global.asax**
- **Purpose**: Handles **application-level events**:
  - `Application_Start`: Runs when the app starts.  
  - `Application_Error`: Global error handling.  
  - `Session_Start`/`Session_End`: Manages session lifecycle.

### 2. **Packages.config**
- **Purpose**: Managed by **NuGet** to track installed packages and versions.

### 3. **Web.config**
- **Purpose**: Stores **application-level configurations**:
  - Connection strings.  
  - Global variables.  
  - Authentication/authorization settings.  
  - Custom HTTP modules/handlers.

---

## Summary
| Folder/File       | Purpose                                                                 |
|-------------------|-------------------------------------------------------------------------|
| **App_Data**      | Stores data files (IIS-protected).                                      |
| **App_Start**     | Configuration classes for startup (routes, bundles, filters).           |
| **Content**       | Static files (CSS, images).                                             |
| **Controllers**   | Handles HTTP requests/responses.                                        |
| **Fonts**         | Custom font files.                                                      |
| **Models**        | Domain data and business logic classes.                                 |
| **Scripts**       | JavaScript files (jQuery, custom scripts).                              |
| **Views**         | Razor views (`.cshtml`) for UI rendering.                               |
| **Global.asax**   | Application-level event handlers.                                       |
| **Packages.config**| NuGet package tracking.                                                |
| **Web.config**    | Application configurations (connection strings, settings).              |

### Key Takeaways:
- **Separation of Concerns**: Clear division between data (Models), logic (Controllers), and UI (Views).  
- **Conventions**: Follows naming and placement rules (e.g., `HomeController` → `Views/Home`).  
- **Extensibility**: Easy to add/modify components (e.g., custom scripts in `Scripts`).