CREATE TABLE [dbo].[DepartmentMember]
(
    [DepartmentNo] INT NOT NULL PRIMARY KEY, 
    [UserId] NCHAR(10) NULL, 
    CONSTRAINT [FK_DepartmentMember_ToDepartment] FOREIGN KEY ([DepartmentNo]) REFERENCES [Department]([DepartmentNo])
)
