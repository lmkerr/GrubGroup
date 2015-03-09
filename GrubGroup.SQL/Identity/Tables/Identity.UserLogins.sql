CREATE TABLE [Identity].[UserLogins] (
    [UserId]        UNIQUEIDENTIFIER NOT NULL,
    [LoginProvider] NVARCHAR (128)   NOT NULL,
    [ProviderKey]   NVARCHAR (128)   NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_Identity_UserLogins_Identity.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([UserId]) ON DELETE CASCADE
);

