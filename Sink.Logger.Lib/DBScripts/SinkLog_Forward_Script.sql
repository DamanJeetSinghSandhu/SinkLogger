Create Database LogDb

Use LogDb

Create Table LogMessage
(ID int Identity(1,1) Not Null Primary Key,
Content varchar(200) Null,
[Level] varchar(20) Not Null,
[Namespace] varchar(20) Not Null,
CreatedAt DATETIME DEFAULT GETDATE()
)


Select * from LogMessage