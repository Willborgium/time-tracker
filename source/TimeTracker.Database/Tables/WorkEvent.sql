CREATE TABLE [dbo].[WorkEvent]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[PersonId] INT NOT NULL FOREIGN KEY REFERENCES [Person]([Id]),
	[Type] INT NOT NULL FOREIGN KEY REFERENCES [WorkEventType]([Id]),
	[Date] DATE,
	[Duration] DECIMAL(4,2),
	[Description] NVARCHAR(MAX)
)