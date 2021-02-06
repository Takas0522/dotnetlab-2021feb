set nocount on
Declare @insertCount int
Declare @now DATE
Declare @salesDate DATE
Declare @userDep int
Declare @addDate int
Declare @salesUser int

Set @insertCount = 1
Set @now = GETDATE()
Set @salesDate = GETDATE()
Set @salesUser = 1

While @insertCount < 10
Begin
	Insert Into [Department]
	Values
		(@insertCount, Convert(nvarchar, @insertCount) + '部門');
	Set @insertCount = @insertCount + 1
End

Set @insertCount = 1

While @insertCount < 200
Begin
	Insert Into [User] Values
		(@insertCount, CONVERT(nvarchar, @insertCount) + 'ユーザー');

	Set @userDep = (@insertCount % 9) + 1;
	Insert Into [DepartmentMember]
		([DepartmentNo], [UserId])
	Values
		(@userDep, @insertCount);
	Set @insertCount = @insertCount + 1
End

Set @insertCount = 1

While @insertCount < 10000
Begin

	Set @addDate = @insertCount % 365;
	Set @salesDate = DATEADD(DAY, @addDate, @salesDate);
	Set @salesUser = (@insertCount % 199) + 1


	Insert into [Order]
	Values
		(@insertCount, Convert(nvarchar, @insertCount) + '件目受注', @salesUser,@now, @now);
	Set @insertCount = @insertCount + 1
End