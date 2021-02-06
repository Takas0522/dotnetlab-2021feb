CREATE TABLE [dbo].[DepartmentMember]
(
    [DepartmentNo] INT NOT NULL , 
    [UserId] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_DepartmentMember_ToDepartment] FOREIGN KEY ([DepartmentNo]) REFERENCES [Department]([DepartmentNo]), 
    PRIMARY KEY ([DepartmentNo], [UserId])
)
