CREATE TABLE [dbo].[Gestion_de_dvd] (
    [Id_dvd]              VARCHAR (50) NOT NULL,
    [titre]               VARCHAR (50) NOT NULL,
    [date_de_realisation] DATE         NOT NULL,
    [disponibilité]       DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_dvd] ASC)
);

