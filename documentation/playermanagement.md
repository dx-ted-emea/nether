# Player Management

Player Management functionality, implementing Nether [Player Management APIs](api/players), using SQL Database as a data store.

> WARNING: The player management implementation in still under development

## Prerequisites
* SQL Database - [learn how to create a SQL Database](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-get-started)
  > To test locally, you may use an on prem installation of SQL Server database
* Microsoft SQL Server Management Studio or Visual Studio - to query against the SQL tables

## Setup

1. Create the Player Management schema:
     
   **SQL Query:**
   
   ```sql
	
    CREATE TABLE [dbo].[Players]
    (
        [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
        [PlayerId] VARCHAR(50) NOT NULL , 
        [Gamertag] VARCHAR(50) NOT NULL, 
        [Country] VARCHAR(50) NULL, 
        [CustomTag] VARCHAR(50) NULL, 
        [PlayerImage] VARBINARY(50) NULL, 
        PRIMARY KEY ([Id]), 
        CONSTRAINT [AK_Players_PlayerId] UNIQUE ([PlayerId])
    )


    GO

    CREATE INDEX [IX_Players_Gamertag] ON [dbo].[Players] ([Gamertag])

    GO

    CREATE INDEX [IX_Players_PlayerId] ON [dbo].[Players] ([PlayerId])

    GO
    
    CREATE TABLE [dbo].[PlayersExtended]
    (
	[Gamertag] VARCHAR(50) NOT NULL, 
        [UserId] VARCHAR(50) NOT NULL, 
        [ExtendedInformation] NVARCHAR(MAX) NULL,
	PRIMARY KEY ([Gamertag]), 
        CONSTRAINT [AK_PlayersExtended_PlayerId] UNIQUE ([Gamertag])
    )
    GO

    CREATE INDEX [IX_PlayersExtended_Gamertag] ON [dbo].[PlayersExtended] ([Gamertag])
    GO

    CREATE INDEX [IX_PlayersExtended_UserId] ON [dbo].[PlayersExtended] ([UserId])
    GO

    CREATE TABLE [dbo].[Groups]
    (
        [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
        [Name] VARCHAR(50)  NOT NULL, 
        [CustomType] VARCHAR(50) NULL, 
        [Description] VARCHAR(50) NULL, 
        [Image] VARBINARY(50) NULL, 
        PRIMARY KEY ([Id]), 
        CONSTRAINT [CK_Groups_Name] UNIQUE([Name])
    )

    GO

    CREATE INDEX [IX_Groups_Name] ON [dbo].[Groups] ([Name])

    GO

    CREATE TABLE [dbo].[PlayerGroups]
    (
        [Gamertag] varchar(50) NOT NULL, 
        [GroupName] varchar(50) NOT NULL, 
        CONSTRAINT [FK_PlayerGroups_Players] FOREIGN KEY ([Gamertag]) REFERENCES [Players](Gamertag), 
        CONSTRAINT [FK_PlayerGroups_Groups] FOREIGN KEY ([GroupName]) REFERENCES [Groups]([Name])
    )
    GO

    CREATE INDEX [IX_PlayerGroups_Gamertag] ON [dbo].[PlayerGroups] ([Gamertag])

    GO

    CREATE INDEX [IX_PlayerGroups_GroupName] ON [dbo].[PlayerGroups] ([GroupName])

   ```
   **Deploy from Visual Studio**
   
    - Open Nether solution in Visual Studio
	- Right click on project Nether.Data.Sql.Schema	and select **Publish** to the SQL Database

2. Get connection string from Azure portal:
   [How to get sql database connection string?](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-develop-dotnet-simple)

3. Update connection string in appsetting.json file:
   ```json
    "PlayerManagement": {
      "Store": {
         "wellknown": "sql",
         "properties": {
            "ConnectionString": "<connection string>",            
         }
      }
   }
   ```     
   Follow the [configuration](configuration.md) section in this repo for more details.


