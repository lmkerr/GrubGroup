CREATE TABLE [Identity].[Claim] (
    [ClaimId] UNIQUEIDENTIFIER NOT NULL,
    [Type]    NVARCHAR (MAX)   NOT NULL,
    [Name]    NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Identity_Claim] PRIMARY KEY CLUSTERED ([ClaimId] ASC)
);

