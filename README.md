## Setup

This project uses SQL Server in Docker because LocalDB is only available on Windows.

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- EF Core CLI: `dotnet tool install --global dotnet-ef`

### 1. Start SQL Server

Choose your own password. It must be at least 8 characters and contain three of the following: uppercase letters, lowercase letters, numbers and symbols.

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=<your-password>' -p 1433:1433 --name sql_server_2025 -d mcr.microsoft.com/mssql/server:2025-latest
```

### 2. Configure the connection string

Run this from the repository root and use the same password as above:

```bash
cd src/ui
dotnet user-secrets set "ConnectionStrings:Flashcards" "Server=localhost,1433;Database=FlashcardsDB;User Id=sa;Password=<your-password>;TrustServerCertificate=True;"
```

### 3. Create the database

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

## Troubleshooting

- **Cannot connect:** Run `docker ps` to check that the container is running. If it is stopped, run `docker start sql_server_2025`.
- **The container stops immediately:** Run `docker logs sql_server_2025`. The password may not meet the requirements.
- **Port 1433 is already in use:** Stop the other SQL Server instance, or change the port in both the `docker run` command and the connection string.
