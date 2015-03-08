CREATE TABLE [Identity].[User] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [UserName]             NVARCHAR (50)    NOT NULL,
    [Email]                NCHAR (10)       NOT NULL,
    [EmailConfirmed]       BIT              NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)   NOT NULL,
    [SecurityStamp]        NVARCHAR (MAX)   NOT NULL,
    [PhoneNumber]          NVARCHAR (200)   NULL,
    [PhoneNumberConfirmed] BIT              NOT NULL,
    [TwoFactorEnabled]     BIT              NOT NULL,
    [LockoutEndDateUtc]    DATETIME         NULL,
    [LockoutEnabled]       BIT              NOT NULL,
    [AccessFailedCount]    INT              NOT NULL,
    [CreatedById]          UNIQUEIDENTIFIER NOT NULL,
    [CreatedByIp]          NVARCHAR (100)   NOT NULL,
    [CreatedOn]            DATETIME         NOT NULL,
    [ModifiedById]         UNIQUEIDENTIFIER NULL,
    [ModifiedByIp]         NVARCHAR (100)   NULL,
    [ModifiedOn]           DATETIME         NULL,
    [DeletedOn]            DATETIME         NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

