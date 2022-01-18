CREATE TABLE [dbo].[UserLoginModel] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
	[Role] INT NOT NULL DEFAULT (1),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
