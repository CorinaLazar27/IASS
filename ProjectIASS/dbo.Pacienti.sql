CREATE TABLE [dbo].[Pacienti] (
    [Nume]       VARCHAR (20) NOT NULL,
    [Prenume]    VARCHAR (20) NOT NULL,
    [CNP]        VARCHAR (13) NOT NULL,
    [Diagnostic] VARCHAR (20) NULL,
    [Email]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([CNP] ASC)
);

