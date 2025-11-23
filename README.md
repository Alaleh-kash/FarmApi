🌾 FarmApi — C# .NET 8 + SQL Server Backend

FarmApi is a simple but complete backend API built with ASP.NET Core 8, Entity Framework Core, and SQL Server.
It powers your Farm Client React app by providing endpoints for:

🐄 Animals

👨‍🌾 Farmers

🌽 Foods

All data is stored in a real SQL Server database and exposed via clean REST endpoints.

🏗 Tech Stack
Layer	Technology
Backend	ASP.NET Core 8 (Web API)
ORM	Entity Framework Core 8
Database	SQL Server / SQL Express
Language	C#
Tools	Swagger UI, EF Core Tools
📁 Project Structure
FarmApi/
 ├── Controllers/
 │    └── FarmController.cs
 ├── Data/
 │    └── FarmDbContext.cs
 ├── Models/
 │    ├── Animal.cs
 │    ├── Farmer.cs
 │    └── Food.cs
 ├── appsettings.json
 ├── Program.cs
 ├── Dockerfile
 └── README.md

🔌 SQL Server Setup

Create your database and tables manually, then insert sample data.

Animals Table
INSERT INTO Animals (Name, FarmerId, Type, Age)
VALUES
('Bella', 1, 'Cow', 4),
('Max',   2, 'Sheep', 3),
('Charlie', 3, 'Chicken', 1);

Foods Table
INSERT INTO Foods (FoodName, QuantityPerDay, AnimalId)
VALUES
('Grass', 5, 1),
('Corn',  2, 2),
('Seeds', 1, 3);

Farmers Table

Insert your farmer data here.

🔧 Configuration (appsettings.json)

Update your SQL Server connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FarmDb;Trusted_Connection=True;TrustServerCertificate=True"
}

▶ Running the API

In the project root:

dotnet restore
dotnet build
dotnet run


The server will start at:

👉 http://localhost:5258

👉 Swagger docs: http://localhost:5258/swagger

📡 API Endpoints
🐄 Animals
Method	Endpoint	Description
GET	/animals	Get all animals
🌽 Foods
Method	Endpoint	Description
GET	/foods	Get all foods
👨‍🌾 Farmers
Method	Endpoint	Description
GET	/farmers	Get all farmers
🔥 CORS Enabled for React

CORS policy is open for development:

options.AddPolicy("AllowAll",
    policy => policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

🐳 Docker Support (Optional)

If you want to run the API in Docker:

docker build -t farmapi .
docker run -p 5258:80 farmapi

🤝 License

This project is created for personal learning and portfolio purposes.

💛 Author

Developed by Alaleh Kashani
🌐 Portfolio: coming soon
📩 Email: alaleh.kashani34@gmail.com