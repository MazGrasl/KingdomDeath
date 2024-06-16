# Kingdom Death API + WebClient

This is a project I've started to remove the need for settlement gear and resource storage sheets (which always seem to run out of space), as well as to show a list of craftable gear with your current resources.
Other features might be added as I see fit.

# How to run
## Requirements
.NET v6+
Node v18+/NPM v9+
SQL Express (or similar SQL DB)
## First installation
If you don't have dotnet ef installed already:
* run "dotnet tool install --global dotnet-ef"
* run "dotnet restore KingdomDeathAPI"
* run "dotnet ef database update"
* run "npm i KingdomDeathClient"

## Run in debug
* run "dotnet watch KingdomDeathAPI"
* run "npm start KingdomDeathClient"
* Open browser to "http://localhost:4200"
* (Optional) open browser to "http://localhost:5020/swagger" to see API endpoints

# Tech stack
## Backend/API:
ASP.NET with Entity Framework
SQL express on localhost (but can be exchanged for any other SQL server - just modify appsettings.json)

## Client:
Angular with Material
NgRx (Angular Redux)
