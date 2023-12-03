gen-migration:
	dotnet ef migrations add Create_Database
gen-controller:
	dotnet aspnet-codegenerator controller -name BookingDetailController -m BookingDetail -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
run:
	dotnet watch run