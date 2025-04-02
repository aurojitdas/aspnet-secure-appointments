# JKL Healthcare Appointment System

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue)
![C#](https://img.shields.io/badge/C%23-10.0-brightgreen)
![MS SQL Server](https://img.shields.io/badge/MS%20SQL%20Server-2019-red)
![Azure](https://img.shields.io/badge/Azure-Deployed-blue)
![Security](https://img.shields.io/badge/Security-OWASP%20Tested-green)

A secure online system developed for JKL Healthcare to efficiently track and manage appointments and caregiver assignments. Built with ASP.NET Core and Microsoft SQL Server, this application features robust security measures and follows the Waterfall Software Development Life Cycle (SDLC) methodology.

## 📋 Project Overview

This project delivers a comprehensive healthcare management solution with:

- Secure user authentication and role-based access control
- Intuitive appointment scheduling system
- Patient and caregiver management dashboards
- Comprehensive security features to protect sensitive healthcare data
- Full compliance with GDPR and data protection regulations

## 🔐 Security Features

The security of this application was a primary concern during development. Key security implementations include:

- **HTTPS Redirection & HSTS**: Ensures all communication is secure and prevents man-in-the-middle attacks
- **ASP.NET Identity Framework**: Provides secure login and session management
- **Password Hashing**: Using PBKDF2 with salting for secure password storage
- **CSRF Protection**: Built-in protection against Cross-Site Request Forgery attacks
- **Entity Framework ORM**: Parameterized queries to prevent SQL injection
- **Role-Based Access Control**: Granular permissions based on user roles
- **Azure WAF**: Web Application Firewall for additional protection

## 🧪 Security Testing

The application underwent rigorous security testing:

- **OWASP ZAP Scan**: No critical vulnerabilities detected
- **SSL Configuration Test**: Using Immuniweb's AI-based SSL testing tool
- **GDPR Compliance Check**: Cookie scan and compliance verification
- **Penetration Testing**: Against common vulnerabilities including:
  - HTTP Downgrade Attacks
  - SQL Injection
  - Cross-Site Scripting (XSS)
  - Cross-Site Request Forgery (CSRF)

## 🏗️ Architecture

The application follows a clean architecture using the MVC pattern:

```
JKL Healthcare
├── Controllers         # Business logic and request handling
├── Models              # Data models and business entities
├── Views               # User interface components
├── Services            # Business services and logic
├── Data                # Database context and migrations
├── Middleware          # Custom middleware components
└── Security            # Security configurations
```

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core, C#
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Frontend**: HTML, CSS, JavaScript, jQuery
- **UI Components**: FullCalendar.js for appointment scheduling
- **Cloud Platform**: Microsoft Azure
- **Security Tools**: OWASP ZAP, Immuniweb SSL Scanner

## 🔍 Key Features

### User Authentication
- Role-based system with distinct permissions for administrators, patients, and caregivers
- Secure login with password hashing and protection against brute force attacks

### Appointment Scheduling
- Interactive calendar interface using FullCalendar.js
- Role-based permissions for appointment management
- API endpoints for secure AJAX interactions

### Patient Dashboard
- Secure access to personal medical information
- Role-restricted data visibility
- Form validation to ensure data integrity

### Caregiver Management
- Assignment tracking and management
- Role-based access controls
- Secure update mechanisms

## 📊 Formal Methods

The application was designed using formal methods to ensure security and reliability:

- **Finite State Representations**: Modeling application states and transitions
- **Petri Nets**: Technical specification of web application flow with properties:
  - 3-bounded
  - Live transitions
  - Complete reachability
  - Reversibility
  - Conservation
  - Deadlock-free

## 🔬 Testing Methodology

The application underwent comprehensive testing:

- **Unit Testing**: To verify individual components
- **Integration Testing**: To ensure proper module integration
- **System Testing**: To validate the entire system functionality
- **Security Testing**: To identify and address vulnerabilities

## 💡 Future Enhancements

Areas identified for future improvement:

1. **User Approval System**: Implementation of admin approval for new registrations
2. **Multi-Factor Authentication**: Additional security layer for sensitive operations
3. **Audit Logging**: Comprehensive activity tracking
4. **Performance Optimization**: For handling larger data volumes and traffic
5. **Email Notifications**: Real-time updates for appointments and assignments

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET Core SDK 8.0 or later
- SQL Server 2019 or later
- Git

### Import and Setup Instructions

1. **Clone the Repository**
   ```
   git clone https://github.coventry.ac.uk/dasa18/AppointmentScheduling.git
   cd AppointmentScheduling
   ```

2. **Open the Solution**
   - Launch Visual Studio
   - Open the solution file `AppointmentScheduling.sln`

3. **Configure Database**
   - Open `appsettings.json` and update the connection string to match your SQL Server instance
   - In the Package Manager Console, run:
     ```
     Update-Database
     ```
   - This will create the database schema and apply all migrations

4. **Setup Initial Data**
   - The application includes a database seeder for demo data
   - To initialize with demo users, run:
     ```
     dotnet run seeddata
     ```

5. **Run the Application**
   - Press F5 or click the Run button in Visual Studio
   - The application will launch in your default browser

### Demo Credentials

**Admin**
- Username: aurojitdas@hotmail.com
- Password: Aezakmiwanrltw@1

**Patient**
- Username: patient1@gmail.com
- Password: Welcome@1

**Care Givers**
- Username: caregiver1@gmail.com
- Password: Welcome@1

## 📁 Repository

The complete source code is available at: [GitHub Repository](https://github.coventry.ac.uk/dasa18/AppointmentScheduling)

## 📄 Additional Resources

- [OWASP ZAP Report](https://1drv.ms/u/s!Ag19VRUGf1U75GyX3SkguLrHySq7?e=g0WDQK)
- [SSL Scan Results](https://www.immuniweb.com/ssl/jklhealthcare.azurewebsites.net/gXJ8lHuG/)
- [Cookie Scan Results](https://www.cookiebot.com/en/compliance-test/1f628596-231d-44d9-bd69-0a7e0fc5e39c/)

---

## 👨‍💻 About the Developer

This project was developed by Aurojit Das as part of a university assignment for the 7032CEM - Secure Design and Development module. It demonstrates skills in:

- Secure web application development
- Application of SDLC methodologies
- Implementation of security best practices
- Formal methods in software design
- Cloud deployment and management

---

© 2025 Aurojit Das | Student ID: 15255886
