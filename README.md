# JKL Healthcare Appointment System

![Security](https://img.shields.io/badge/Security-OWASP%20Compliant-success)
![Vulnerabilities](https://img.shields.io/badge/Critical%20Vulnerabilities-0-brightgreen)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-orange)
![Authentication](https://img.shields.io/badge/Authentication-ASP.NET%20Identity-purple)
![Azure](https://img.shields.io/badge/Azure-Deployed-0078D4)
![SSL Rating](https://img.shields.io/badge/SSL%20Rating-A+-green)
![GDPR](https://img.shields.io/badge/GDPR-Compliant-success)
![Testing](https://img.shields.io/badge/Security%20Testing-Passed-brightgreen)
![License](https://img.shields.io/badge/License-Academic-yellow)

A secure healthcare appointment management system developed with a security-first approach, demonstrating comprehensive implementation of secure design principles and best practices in web application security.

## 🔐 Security Highlights

This project showcases my expertise in secure application development and cybersecurity best practices:

### Security Implementations
- **Defense in Depth**: Multi-layered security architecture with authentication, authorization, and data protection
- **OWASP Top 10 Mitigation**: Designed to protect against common vulnerabilities including SQL injection, XSS, and CSRF
- **Zero Trust Architecture**: Role-based access control with principle of least privilege
- **Secure Communication**: HTTPS enforcement with HSTS headers
- **Password Security**: PBKDF2 hashing with salting for secure credential storage
- **Input Validation**: Comprehensive client and server-side validation
- **Secure Session Management**: Cookie-based authentication with HttpOnly flags

### Security Testing & Validation
- **OWASP ZAP Scan**: Achieved zero critical vulnerabilities
- **SSL/TLS Configuration**: A+ rating on SSL Labs test
- **GDPR Compliance**: Cookie management and data protection compliance
- **Penetration Testing**: Successfully defended against:
  - SQL Injection attacks
  - Cross-Site Scripting (XSS)
  - Cross-Site Request Forgery (CSRF)
  - HTTP Downgrade attacks

## 🏗️ Technical Architecture

### Security-Focused Design
```
├── Authentication Layer   # ASP.NET Identity with custom user management
├── Authorization Layer    # Role-based access control (RBAC)
├── Data Protection        # Entity Framework with parameterized queries
├── API Security           # Secure RESTful endpoints with anti-forgery tokens
├── Audit & Logging        # Comprehensive activity tracking
└── Cloud Security         # Azure WAF and security configurations
```

### Technology Stack
- **Backend**: ASP.NET Core 8.0, C# 12.0
- **Database**: Microsoft SQL Server with encrypted connections
- **ORM**: Entity Framework Core (preventing SQL injection)
- **Authentication**: ASP.NET Core Identity
- **Cloud**: Microsoft Azure with WAF protection
- **Frontend Security**: Content Security Policy, XSS protection

## 🛡️ Key Security Features

### 1. **Multi-Factor Access Control**
- Role-based permissions (Admin, Doctor, Patient, Caregiver)
- Granular access controls for sensitive operations
- Session timeout and sliding expiration

### 2. **Data Protection**
- Encrypted data in transit (TLS 1.3)
- Parameterized queries preventing SQL injection
- Input sanitization and validation
- Secure API endpoints with CSRF protection

### 3. **Audit Trail**
- User activity logging
- Failed login attempt tracking
- Appointment modification history

### 4. **Compliance & Standards**
- GDPR compliant data handling
- Healthcare data protection standards
- Secure coding practices following OWASP guidelines

## 📊 Security Assessment Results

| Security Test | Tool Used | Result |
|--------------|-----------|---------|
| Vulnerability Scan | OWASP ZAP | ✅ No critical vulnerabilities |
| SSL Configuration | Immuniweb | ✅ Grade A |
| Cookie Compliance | Cookiebot | ✅ GDPR Compliant |
| Authentication | Custom Tests | ✅ Secure implementation |
| Authorization | Role Testing | ✅ Proper access controls |

## 🔍 Demonstrated Skills

### Cybersecurity
- Secure Software Development Lifecycle (SDLC)
- Threat modeling and risk assessment
- Security testing and vulnerability assessment
- Implementation of security controls
- Compliance with security standards

### Technical
- Full-stack secure web development
- Database security and encryption
- API security implementation
- Cloud security configuration
- Performance optimization with security

### Soft Skills
- Security documentation and reporting
- Risk communication
- Problem-solving in security contexts
- Attention to security details

## 🚀 Live Demo & Resources

- **Live Application**: [JKL Healthcare Services](https://jklhealthcare.azurewebsites.net/)
- **Security Report**: [OWASP ZAP Scan Results](https://1drv.ms/u/s!Ag19VRUGf1U75GyX3SkguLrHySq7?e=g0WDQK)
- **SSL Analysis**: [SSL Security Test](https://www.immuniweb.com/ssl/jklhealthcare.azurewebsites.net/gXJ8lHuG/)

### Demo Credentials
```
Admin User:
Username: aurojitdas@hotmail.com
Password: Aezakmiwanrltw@1

Test Patient:
Username: patient1@gmail.com
Password: Welcome@1
```

## 📈 Project Achievements

- **100% Security Test Pass Rate**: All planned security tests passed successfully
- **Zero Critical Vulnerabilities**: Clean OWASP ZAP scan results
- **Secure Architecture**: Implemented defense-in-depth strategy
- **Compliance Ready**: GDPR and healthcare data protection compliant
- **Production Deployed**: Successfully deployed on Azure with WAF protection

## 🔧 Installation & Setup

### Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK
- SQL Server 2019 or later
- Azure subscription (optional for deployment)

### Quick Start
```bash
# Clone the repository
git clone https://github.coventry.ac.uk/dasa18/AppointmentScheduling.git

# Navigate to project directory
cd AppointmentScheduling

# Restore dependencies
dotnet restore

# Update database connection string in appsettings.json

# Run database migrations
dotnet ef database update

# Run the application
dotnet run
```

## 📚 Documentation

- Comprehensive security design document
- Threat modeling diagrams
- Security testing reports
- API documentation with security guidelines
- Deployment security checklist

## 🎯 Future Security Enhancements

- [ ] Multi-Factor Authentication (MFA)
- [ ] Advanced threat detection with ML
- [ ] Security Information and Event Management (SIEM) integration
- [ ] Automated security testing in CI/CD pipeline
- [ ] Zero-knowledge architecture for sensitive data

## 👨‍💻 About This Project

This project was developed as part of the 7032CEM - Secure Design and Development module, demonstrating practical application of cybersecurity principles in a real-world healthcare scenario. It showcases my ability to:

- Design and implement secure systems from the ground up
- Apply security best practices throughout the SDLC
- Conduct thorough security testing and validation
- Document and communicate security measures effectively
- Balance security requirements with usability

## 📞 Contact

**Aurojit Das**  

Email: aurojit@aurojitdas.com  
LinkedIn: https://www.linkedin.com/in/aurojitdas/

---

*This project demonstrates my commitment to cybersecurity excellence and my ability to develop secure, compliant, and robust applications for sensitive environments.*
