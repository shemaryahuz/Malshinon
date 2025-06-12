# Malshinon - Community Intel Reporting System

[![Author: Shemaryahu Zalmanov](https://img.shields.io/badge/Author-Shemaryahu%20Zalmanov-blue?style=flat-square)](https://github.com/shemaryahuz)

---

## Overview

**Malshinon** is a Community Intel Reporting System for gathering and analyzing reports about potential threats within an organization. The system supports managers (who can review and analyze data), reporters (who can submit reports), and targets (who may also act as reporters).

---

## Folder Structure

```
Malshinon/
├── .gitignore
├── MalshinonApp/
│   ├── MalshinonApp.csproj
│   ├── MalshinonApp.sln
│   ├── Program.cs
│   ├── Data/
│   │   ├── DatabaseContext.cs
│   │   ├── PersonRepository.cs
│   │   └── ReportRepository.cs
│   ├── Models/
│   │   ├── Manager.cs
│   │   ├── Person.cs
│   │   ├── Reporter.cs
│   │   ├── Target.cs
│   │   └── Report.cs
│   ├── Services/
│   │   ├── LoginService.cs
│   │   ├── ManagerService.cs
│   │   └── ReportService.cs
│   └── UI/
│       ├── ConsoleManager.cs
│       ├── LoginDisplayer.cs
│       ├── ManagerMenu.cs
│       └── ReporterMenu.cs
├── MalshinonDB/
│   └── malshinon_db.sql
```

---

## Architecture Explanation

### a. Malshinon Database

- **Setup:**  
  The database is created with the SQL script `MalshinonDB/malshinon_db.sql`. You need a local SQL environment (install if needed).
- **Database:**  
  The database is called `malshinon_db` and is initialized with sample data for testing the app.
- **Tables:**  
  - `people`: Stores all users (managers, reporters, targets).
  - `intel_reports`: Stores reports with columns: `reporterId`, `targetId`, `text`, and `time`.

---

### b. Malshinon Application Layers

- **Layer 1: Data**
  - Handles the database connection and access to the repositories for `people` and `reports`.
  - Includes: `DatabaseContext`, `PersonRepository`, `ReportRepository`.
- **Layer 2: Services**
  - Handles business logic and features for login, manager operations, and reporter operations.
  - Includes: `LoginService`, `ManagerService`, `ReportService`.
- **Layer 3: UI**
  - Manages user interaction via the console, including login, menus, and navigation.
  - Includes: `ConsoleManager`, `LoginDisplayer`, `ManagerMenu`, `ReporterMenu`.
- **Models Folder**
  - Contains the main classes used throughout the program:
    - `Person` (base class), `Manager`, `Reporter`, `Target` (all inherit from `Person`)
    - `Report`

---

## Program Flow

```
1. Startup:
   - Welcome message is displayed.
   - Database connection is opened (via DatabaseContext).

2. Login:
   - User is prompted for their full name (LoginDisplayer).
   - If user is new, a code is generated. If user chooses exit, program ends.

3. Menu Selection:
   - If user is a Manager: Manager menu is displayed with options to view/analyze data.
   - If user is a Reporter or Reporter & Target: Reporter menu is displayed with option to submit a report.

4. Reporting:
   - Reporter enters target's full name and report text.
   - Report is saved in the database.

5. Shutdown:
   - Database connection is closed.
   - Exit message is displayed.
```

### Program Flow (ASCII Diagram)

```
+-------------------+
|  Welcome Message  |
+-------------------+
          |
          v
+-------------------+
| Open DB Connection|
+-------------------+
          |
          v
+-------------------+
|   Login Prompt    |
+-------------------+
          |
   +------|------+
   |             |
   v             v
Manager      Reporter
  |             |
  v             v
Manager     Reporter
Menu        Menu
  |             |
  |      +------+
  |      |
  v      v
[Data Review] [Submit Report]
          |
          v
+-------------------+
|  Save to DB       |
+-------------------+
          |
          v
+-------------------+
| Close Connection  |
+-------------------+
          |
          v
+-------------------+
|   Exit Message    |
+-------------------+
```

---

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/shemaryahuz/Malshinon.git
   cd Malshinon
   ```

2. **Set up the Database:**
   - Install an SQL environment if needed.
   - Run `MalshinonDB/malshinon_db.sql` to create the `malshinon_db` with sample data.

3. **Build and Run the Application:**
   - Open the solution in Visual Studio or another C# IDE.
   - Build and run the application from the `MalshinonApp` folder.

---

## Author

[Shemaryahu Zalmanov](https://github.com/shemaryahuz)
