gen-migration:
	dotnet ef migrations add Create_Database
gen-controller:
	dotnet aspnet-codegenerator controller -name BookingDetailController -m BookingDetail -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
run:
	dotnet watch run

# indentity 
gen-indentity:
	dotnet aspnet-codegenerator identity -dc ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"
migration-indentity-db:
	dotnet ef migrations add CreateIdentitySchema
	dotnet ef database update