EXEC sp_configure 'clr enabled', 1
RECONFIGURE
GO

EXEC sp_configure 'show advanced options', 1
RECONFIGURE
GO

EXEC sp_configure 'clr strict security', 0;
RECONFIGURE
GO

DROP PROCEDURE IF EXISTS StudentGetClr;
GO

DROP ASSEMBLY IF EXISTS CLRFunctions;
GO

CREATE ASSEMBLY CLRFunctions FROM 'D:\Study\PNetPz2\PNetPz2\bin\Debug\PNetPz2.dll'
GO

CREATE PROCEDURE StudentGetClr
@Name nvarchar(max)
AS
    EXTERNAL NAME CLRFunctions.MyProcedure.UserGetProcedure;
GO

USE [master]
EXEC StudentGetClr @Name=Rublov