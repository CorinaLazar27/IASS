CREATE TABLE [dbo].[Medicament] (
    [id]       INT          NOT NULL,
    [denumire] VARCHAR (20) NOT NULL,
    [stoc]     INT          NULL,
    FOREIGN KEY ([denumire]) REFERENCES [dbo].[Reteta] ([medicament]) ON DELETE CASCADE
);

