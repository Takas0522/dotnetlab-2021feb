CREATE TABLE [dbo].[Order]
(
    [OrderNo] INT NOT NULL PRIMARY KEY, 
    [OrderName] NVARCHAR(255) NOT NULL, 
    [SalesUserId] INT NOT NULL, 
    [SalesDate] DATETIME2 NOT NULL, 
    [UpdateDate] DATETIME2 NOT NULL
)
