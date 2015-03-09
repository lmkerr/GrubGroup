CREATE TABLE [Identity].[Role] (
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    [Name]   NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Identity_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);



