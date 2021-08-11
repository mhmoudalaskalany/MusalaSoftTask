# MusalaSoftTask
Musala Soft Gateways Task


# Backend Installation

- Open Solution -> got to BackendCore.Api project -> AppSettings.json -> change connection string to sql server of your machine
- Right Click On BackendCore.Api project -> build tap -> select (BackendCore.Api) from pofile drop down and (Project) from Launch drop down
- this will run the api on https://localhost:5001
- after starting the application the database will be created automatically using migrations
- to test from swagger use (username: admin , password:123456) to login and use token to test the apis


# Frontend Installation

- open project source folder
- open terminal in root directory
- run npm install
- go to assets -> config -> development.json
- change HOST_API to the url the backend is running on
- use (username:admin , password:123456) to login and start using the system


