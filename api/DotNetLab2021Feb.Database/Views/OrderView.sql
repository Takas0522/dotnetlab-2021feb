CREATE VIEW [dbo].[OrderView]
AS
SELECT
     O.OrderNo,
     O.OrderName,
     O.SalesUserId,
     U.[Name] SalesUserName,
     O.SalesDate,
     O.UpdateDate
FROM
    [Order] O
Left Join [User] U ON (O.SalesUserId = U.UserId);
