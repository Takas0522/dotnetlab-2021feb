CREATE PROCEDURE [dbo].[GetUsers]
AS
Select
    U.UserId,
    U.Name
From
    [User] U