[![Build Status](https://h-esmaeili.visualstudio.com/TDD%20Calculator/_apis/build/status/h-esmaeili.tdd-calculator?branchName=main)](https://h-esmaeili.visualstudio.com/TDD%20Calculator/_build/latest?definitionId=2&branchName=main)

# How To Run Application
## Run the APIs
``` bash
cd src/WebApi
dotnet run
```
## Run the WPF client
``` bash
cd src/WpfClient
dotnet run
```
## Run the client app
```bash
cd src/clientapp
```
### Install Packages
```bash
npm install
```
### Run the app
``` bash
npm run serve
```


# Development Approach

I have implemented the solution with the TDD appouch. 
The source folder contains several separate projects:

- Web Api (Asp Net Core 5)
- Service (Class Library)
- Domain (Class Library)
- Unit Tests (xUnit)
- WPF Client (Net Core 5)
- Web Client (Vue Material)

I used the TDD approach for implementing the backend side.
For automation of the process of the build, I used Azure pipelines integrated with the GitHub repository.
