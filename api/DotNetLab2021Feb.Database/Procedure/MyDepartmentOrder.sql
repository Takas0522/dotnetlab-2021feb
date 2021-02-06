CREATE PROCEDURE [dbo].[GetMyDepartmentOrders]
    @userId int
AS
    Select
        O.OrderNo,
        O.OrderName,
        O.SalesUserId,
        U.[Name] SalesUserName,
        O.SalesDate,
        O.UpdateDate
    From
        [Order] O
    Left Join [User] U On (O.SalesUserId = U.UserId)
    Where
       O.SalesUserId In (
        Select
            UserId
        From
            DepartmentMember
        Where
            DepartmentNo in (
                SELECT DepartmentNo
                  FROM [DepartmentMember]
                  Where UserId = @userId
            )
        )