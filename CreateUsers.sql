CREATE TABLE [dbo].[ServerAdmin]
(
    [ServerAdmin_ID] INT NOT NULL PRIMARY KEY, 
    [ServerAdmin_Name] NCHAR(15) NULL, 
    [ServerAdmin_Number] NCHAR(15) NULL, 
    [ServerAdmin_ZipCode] NCHAR(15) NULL
)

CREATE TABLE [dbo].[PortalAdmin]
(
    [PortalAdmin_ID] INT NOT NULL PRIMARY KEY, 
    [PortalAdmin_Name] NCHAR(15) NULL, 
    [PortalAdmin_Number] NCHAR(15) NULL, 
    [PortalAdmin_ZipCode] NCHAR(15) NULL
)