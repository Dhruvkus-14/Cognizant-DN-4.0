# 4_WebApi_Handson - ASP.NET Core Web API CRUD Operations

## ✅ Objective
To demonstrate CRUD operations using ASP.NET Core 8.0 Web API with in-memory data.
> ✅ Week 4 Assignment – Cognizant Digital Nurture 4.0  
> 👤 Author: Dhruv Kushwaha  
> 🆔 Superset ID: 6363396 
---

## 📁 Project Structure

- `EmployeeController.cs` - Handles all CRUD operations for Employee resource.
- `Employee.cs`, `Department.cs`, `Skill.cs` - Models representing the domain objects.
- `Program.cs` - Sets up controller mapping and middleware pipeline.

---

## ⚙️ Features Implemented

### ✅ 1. HTTP GET: Retrieve All Employees
**Route:** `GET /api/Employee`  
**Description:** Returns a list of hardcoded employees.

---

### ✅ 2. HTTP PUT: Update an Employee
**Route:** `PUT /api/Employee/{id}`  
**Description:** Updates the employee record by ID.

```json
Request Body Example:
{
  "id": 1,
  "name": "Jane Doe",
  "salary": 60000,
  "permanent": true,
  "department": { "id": 1, "name": "HR" },
  "skills": [{ "id": 1, "name": "C#" }],
  "dateOfBirth": "1985-01-15"
}

How to Test Using Swagger
Run the project.

Navigate to https://localhost:<port>/swagger.

Expand Employee endpoints.

Test GET /api/Employee → You should see a list of employees.

Test PUT /api/Employee/{id} with valid payload → It should update and return the modified employee

Models Used
Employee.cs
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public bool Permanent { get; set; }
    public Department Department { get; set; }
    public List<Skill> Skills { get; set; }
    public DateTime DateOfBirth { get; set; }
}
Department.cs
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}
Skill.cs
public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
}


Concepts Demonstrated
ASP.NET Core minimal hosting model (Program.cs only, no Startup.cs).

Routing and attribute-based HTTP methods.

Model binding from request body.

Use of static in-memory data to simulate persistence.

Swagger for testing APIs.

✅ Output Verification
✔ GET /api/Employee returns list of hardcoded employee(s).

✔ PUT /api/Employee/1 updates data in-memory and returns updated object.

✔ Validations for bad or invalid IDs handled with 400 response.