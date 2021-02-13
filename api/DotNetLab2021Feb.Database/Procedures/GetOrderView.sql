CREATE PROCEDURE [dbo].[GetOrderView]
AS
Select
     O.OrderNo,
     O.OrderName,
     O.SalesUserId,
     O.SalesUserName,
     O.SalesDate,
     O.UpdateDate
From
    [OrderView] O;