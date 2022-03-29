CREATE TABLE [dbo].[Reteta] (
    [numar]      INT          NOT NULL,
    [cnp]        VARCHAR (13) NOT NULL,
    [medicament] VARCHAR (20) NOT NULL,
    [indicati]   VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([medicament] ASC),
    FOREIGN KEY ([cnp]) REFERENCES [dbo].[Pacienti] ([CNP]) ON DELETE CASCADE
);

