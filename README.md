# Malshinon - Community Intel Reporting System

[![Author: Shemaryahu Zalmanov](https://img.shields.io/badge/Author-Shemaryahu%20Zalmanov-blue?style=flat-square)](https://github.com/shemaryahuz)

---

## Overview

**Malshinon** is a Community Intel Reporting System designed for hostile environments or organizations, where a community of *enemies* is tracked with the help of *reporters* and *targets*.  
Reporters submit intelligence about potential threats, dangerous targets, and possible agent candidates.  
Managers can analyze reports to identify dangerous targets and spot potential agents among reporters or targets.

---

## Program Flow Explanation

The Malshinon system follows a structured flow that handles user authentication, role-based access, and intelligence operations:

### 1. Application Initialization
- **Start Application**: The system begins by initializing the console interface and establishing database connections
- **Display Login Screen**: Users are presented with a login interface to enter their credentials

### 2. Authentication Process
- **User Enters Credentials**: Users input their username and password
- **Validate Credentials**: The LoginService communicates with the Business Logic layer to verify user credentials against the database
- **Login Successful?**: The system checks if authentication was successful
  - **No**: Returns to the login screen for retry
  - **Yes**: Proceeds to role determination

### 3. Role-Based Access Control
- **Check User Role**: After successful authentication, the system determines the user's role (Reporter or Manager)

### 4. Reporter Workflow
If the user is identified as a **Reporter**:
- **Display Reporter Menu**: Shows reporter-specific options and interface
- **Reporter Actions**: Reporters can perform the following operations:
  - **Submit Report**: Create and submit intelligence reports about targets
  - **Fetches User Data**: Access personal information and submission history

### 5. Manager Workflow
If the user is identified as a **Manager**:
- **Display Manager Menu**: Shows manager-specific options and administrative interface
- **Manager Actions**: Managers can perform the following operations:
  - **Analyze Reports**: Review and analyze submitted intelligence reports
  - **Submit Report**: Create reports (managers can also act as reporters)

### 6. Data Processing Layer
- **Business Logic (Services)**: Handles core application logic including:
  - **LoginService**: Manages authentication and session handling
  - **ReportService**: Processes report submissions and retrievals
  - **ManagerService**: Handles manager-specific operations and analytics

### 7. Data Access Layer
- **Data Access Layer**: Manages database operations through:
  - **ReportRepository**: Handles CRUD operations for intelligence reports
  - **PersonRepository**: Manages user data and role assignments

### 8. Database Operations
- **Database**: The underlying SQL database that:
  - **Saves Report**: Stores submitted intelligence reports
  - **Fetches Data**: Retrieves user information, reports, and analytics data

### 9. Session Management
- **Logout**: Users can terminate their session, returning to the login screen for new authentication

### Key Flow Features:
- **Role Segregation**: Different user types (Reporter/Manager) have access to different functionalities
- **Secure Authentication**: All operations require valid credentials
- **Data Persistence**: All intelligence reports and user data are stored in the database
- **Bidirectional Data Flow**: Information flows both ways between the UI and database layers
- **Service-Oriented Architecture**: Business logic is separated into dedicated service classes

---

## Folder Structure

```plaintext
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

## Program Architecture & Flow

> **Program Flow Diagram**  
> ![Program Flow Diagram](./Docs/program-flow.png)  

The application follows a layered architecture pattern:
- **Presentation Layer**: Console-based UI components for user interaction
- **Business Logic Layer**: Service classes that handle core application logic
- **Data Access Layer**: Repository pattern for database operations
- **Database Layer**: SQL database for persistent data storage

---

## Database

- **Setup:**  
  - The database is initialized using the SQL script (`MalshinonDB/malshinon_db.sql`).
  - Requires a local SQL environment.
- **Tables:**
  - `people`: Contains all users (managers, reporters, targets).
  - `intel_reports`: Stores intelligence reports (`reporterId`, `targetId`, `text`, `time`).
- **Initialization:**  
  - The database comes with sample data for testing.

---

## Author

[Shemaryahu Zalmanov](https://github.com/shemaryahuz)

---

## Getting Started

1. **Clone the repository**  
   ```bash
   git clone https://github.com/shemaryahuz/Malshinon.git
   cd Malshinon
   ```
2. **Set up the Database**  
   - Install a SQL environment if needed.
   - Run `MalshinonDB/malshinon_db.sql` to create and initialize `malshinon_db`.

3. **Build and Run the Application**  
   - Open the solution in Visual Studio or another C# IDE.
   - Build and run the application from the `MalshinonApp` folder.