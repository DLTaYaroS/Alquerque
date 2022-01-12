CREATE TABLE [dbo].[UserLoginModel] (
    [Id]       INT           IDENTITY,
    [Login]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

