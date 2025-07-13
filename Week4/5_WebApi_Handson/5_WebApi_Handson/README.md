# 5_WebApi_Handson - JWT Authentication & CORS Enabled Web API

## ✅ Objectives Covered
> ✅ Week 4 Assignment – Cognizant Digital Nurture 4.0  
> 👤 Author: Dhruv Kushwaha  
> 🆔 Superset ID: 6363396 

### 🔐 What is CORS?
**CORS (Cross-Origin Resource Sharing)** is a security feature implemented by browsers to restrict web pages from making requests to a different domain than the one that served the web page.

#### ✅ Why Enable CORS?
In Web API development, especially for local applications or frontend-backend communication across different ports, CORS must be explicitly enabled to allow access.

#### ✅ How to Enable CORS
- Install the NuGet package: `Microsoft.AspNetCore.Cors`
- In `Program.cs`, enable CORS:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
app.UseCors("AllowAll");

🔸 JWT Authentication
JWT (JSON Web Token) is a compact token passed in the Authorization header to authenticate users.

Configuration in Program.cs:
string securityKey = "mysuperdupersecretkeythatismorethan32chars";
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "mySystem",
            ValidAudience = "myUsers",
            IssuerSigningKey = symmetricSecurityKey
        };
    });

🔸 AuthController - Token Generator
Generates a JWT token with user role (Admin) and userId claim.
[AllowAnonymous]
[HttpGet]
public IActionResult GetToken()
{
    var token = GenerateJSONWebToken(101, "Admin");
    return Ok(new { token });
}

🔸 Role-Based Authorization
Controller access restricted using:
[Authorize(Roles = "Admin,POC")]
public class EmployeeController : ControllerBase

✅ How to Test
✅ Step 1: Get Token
GET
http://localhost:<port>/api/Auth

Get a token like:
{
  "token": "eyJhbGciOiJIUzI1..."
}

✅ Step 2: Use Token in Swagger
Click "Authorize" in Swagger UI

Paste token as:
Bearer eyJhbGciOiJIUzI1...

✅ Step 3: Access Secured API
GET
/api/Employee
✅ If token valid → 200 OK
❌ If missing/expired/wrong role → 401 Unauthorized

🔒 Token Expiry Test
Token expires in 2 minutes (as configured).

Try calling /api/Employee after 2 mins — get 401 Unauthorized.

✅ Summary
 CORS enabled

 JWT token generation with role and expiry

 [Authorize(Roles = "Admin,POC")] protection

 Swagger and Postman tested
