cd ServiceBricks.Work.Postgres
dotnet ef migrations add WorkV1 --context WorkPostgresContext --startup-project ../Tests/MigrationsHost
cd ..\ServiceBricks.Work.Sqlite
dotnet ef migrations add WorkV1 --context WorkSqliteContext --startup-project ../Tests/MigrationsHost
cd ..\ServiceBricks.Work.SqlServer
dotnet ef migrations add WorkV1 --context WorkSqlServerContext --startup-project ../Tests/MigrationsHost
