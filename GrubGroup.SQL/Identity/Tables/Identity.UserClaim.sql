CREATE TABLE [Identity].[UserClaim] (
    [UserClaimId] UNIQUEIDENTIFIER NOT NULL,
    [UserId]      UNIQUEIDENTIFIER NOT NULL,
    [ClaimType]   NVARCHAR (MAX)   NULL,
    [ClaimValue]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED ([UserClaimId] ASC),
    CONSTRAINT [FK_UserClaim_User] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([UserId])
);



