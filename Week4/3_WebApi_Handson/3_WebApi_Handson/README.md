# 3_WebApi_Handson
👨‍💻 Developer
> ✅ Week 4 Assignment – Cognizant Digital Nurture 4.0  
> 👤 Author: Dhruv Kushwaha  
> 🆔 Superset ID: 6363396 

## ✅ Objective
Demonstrate:
- Returning a list of custom class entities via Web API
- Use of `FromBody` for complex objects
- Implementing custom filters for Authorization and Exception handling

---

## 📁 Project Structure

3_WebApi_Handson/
│
├── Controllers/
│ └── EmployeeController.cs
│
├── Filters/
│ ├── CustomAuthFilter.cs
│ └── CustomExceptionFilter.cs
│
├── Models/
│ └── Employee.cs
│
├── Logs/
│ └── exceptions.txt (generated at runtime)
│
├── Program.cs
└── 3_WebApi_Handson.csproj


---

## 🧩 Features Implemented

### 1️⃣ Custom Entity with GET Endpoint
- Model: `Employee`, `Department`, `Skill`
- Endpoint: `GET /api/Employee/GetStandard`
- Attributes: `[AllowAnonymous]`, `[HttpGet]`, `[ProducesResponseType(200)]`

### 2️⃣ Usage of `[FromBody]`
- POST and PUT methods accept complete Employee object using:
  ```csharp
  [HttpPost]
  public ActionResult Post([FromBody] Employee employee)
3️⃣ Custom Authorization Filter
Validates Authorization header:

Rejects if missing

Rejects if "Bearer" is not present

Filter class: CustomAuthFilter

Applied using [ServiceFilter(typeof(CustomAuthFilter))]

4️⃣ Custom Exception Filter
Catches unhandled exceptions

Logs details to Logs/exceptions.txt

Filter class: CustomExceptionFilter

Globally registered in Program.cs

🔧 Swagger Testing
Method	URL	Status	Auth Required
GET	/api/Employee/GetStandard	500 (exception)	❌ (Anonymous)
POST	/api/Employee	400 (if no Auth)	✅ Yes
PUT	/api/Employee/{id}	400 (if no Auth)	✅ Yes

Use Swagger UI to test each endpoint. Provide "Authorization" header with a value like:
Bearer sample-token
Exception Handling Example
GetStandard() method intentionally throws an exception

Result:

500 Internal Server Error

Log generated in /Logs/exceptions.txt

Required NuGet Packages
Microsoft.AspNetCore.Mvc.WebApiCompatShim
Swashbuckle.AspNetCore

Completed Checklist
 Model class creation

 HttpGet with custom object list

 AllowAnonymous attribute

 FromBody usage

 Custom Auth filter (with validation)

 Custom Exception filter (with logging)

 Swagger test for all methods
