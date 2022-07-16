# Work Orders Assignment API


An API to help in creating work orders and assigning a technician to particular work order.


## Demo

![](https://github.com/chaitanya4294/WorkOrdersAssignment/blob/main/ReadMEDemoFiles/GetWorkOrdersByDateDemo.gif)


## Run Locally Using CLI

Clone the project

```bash
git clone https://github.com/chaitanya4294/WorkOrdersAssignment.git
```

Go to the project directory

```bash
cd WorkOrdersAssignment/WorkOrdersAssignmentAPI/
```
Install dependencies

```bash
dotnet restore
```
Update database with existing Migration
```bash
#From main path, move to repository layer
cd ../WorkOrdersAssignmentAPI.Repository/

#Update database
dotnet ef database update
```
Run the application
```bash
  dotnet run
```

## Run Locally Using Visual Studio

Clone the project

```bash
git clone https://github.com/chaitanya4294/WorkOrdersAssignment.git
```

Go to the project directory

```bash
cd WorkOrdersAssignment/WorkOrdersAssignmentAPI/
```

Install dependencies
- Right click on Solution and Click on 'Restore NuGet Package'

Update database with existing Migration
- Open NuGet package manager console
    - Click on Tools
    - Click on Nuget Package manager
    - Click on Packge Manager console

- Run update data base command
    ```bash
    Update-Database
    ```

Run application
- run the application using `ctrl+F5` or click on `Run` button 

## API Reference

| URL | Parameter | Description |
| :-- | :--       | :--         |
| `GET /api/WorkOrders?technicianRegNum="2022-07-15"` | `Name:date` `From:Path` `Type:DateTime` | `Get all work orders assigned to do on a date` |
| `GET /api/WorkOrders?technicianRegNum="5139cc98-1d4b-4648-94b2-f0da927318f7"` | `Name:technicianRegNum` `From:Query` `Type:string`| `Get all work orders assigned to a technician` |
| `POST /api/WorkOrders` | `Name:newWorkOrder` `From:Body` `Type:Object`| `Creates new work order` |
| `DELETE /api/WorkOrders/5139cc98-1d4b-4648-94b2-f0da927318f7` | `Name:workOrderId` `From:Path` `Type:string`| `Deletes an existing work order` |
| `PUT /api/WorkOrders/5139cc98-1d4b-4648-94b2-f0da927318f7` | `Name:workOrderId` `From:Path` `Type:string` `Name:technicianRegNum` `From:Query` `Type:string`| `Updates an existing work order technician if provided technician is active` |
| `POST /api/Technicians` | `Name:newTechnician` `From:Body` `Type:Object`| `Adds new Technician` |
| `PATCH /api/Technicians/5139cc98-1d4b-4648-94b2-f0da927318f7` | `Name:technicianRegNum` `From:Path` `Type:string`| `Deactivates an existing technician` |


## Tech Stack

**API:** .NET Core 6.0 web API

**DataBase:** MS SQL Server

**NuGet Packages:** Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools, Serilog.AspNetCore


## Authors

- [@chaitanyakumar](https://www.github.com/chaitanya4294)

