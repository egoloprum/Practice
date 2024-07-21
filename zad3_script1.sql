USE masternewnew;
GO

CREATE OR ALTER PROCEDURE dbo.CheckDatabaseSize
    @DBSizeInMB FLOAT OUTPUT
AS
BEGIN
    DECLARE @MaxSizeInMB FLOAT = 10240; -- 10 GB in MB

    -- Calculate the size of the database
    SELECT @DBSizeInMB = SUM(size * 8.0 / 1024) 
    FROM sys.master_files 
    WHERE type = 0 AND database_id = DB_ID();

    -- Print the database size
    PRINT 'Current database size in MB: ' + CAST(@DBSizeInMB AS NVARCHAR(20));

    -- Check if the database size exceeds the maximum allowed size
    IF @DBSizeInMB > @MaxSizeInMB
    BEGIN
        PRINT 'Warning: Database size exceeds the maximum allowed size of 10 GB!';
        RETURN 1; -- Return 1 if the size exceeds 10 GB
    END
    ELSE
    BEGIN
        RETURN 0; -- Return 0 if the size is within the limit
    END
END
GO

USE masternewnew_alarm;
GO

CREATE OR ALTER PROCEDURE dbo.CheckDatabaseSize_alarm
    @DBSizeInMB FLOAT OUTPUT
AS
BEGIN
    DECLARE @MaxSizeInMB FLOAT = 10240; -- 10 GB in MB

    -- Calculate the size of the database
    SELECT @DBSizeInMB = SUM(size * 8.0 / 1024) 
    FROM sys.master_files 
    WHERE type = 0 AND database_id = DB_ID();

    -- Print the database size
    PRINT 'Current database size in MB: ' + CAST(@DBSizeInMB AS NVARCHAR(20));

    -- Check if the database size exceeds the maximum allowed size
    IF @DBSizeInMB > @MaxSizeInMB
    BEGIN
        PRINT 'Warning: Database size exceeds the maximum allowed size of 10 GB!';
        RETURN 1; -- Return 1 if the size exceeds 10 GB
    END
    ELSE
    BEGIN
        RETURN 0; -- Return 0 if the size is within the limit
    END
END
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[CheckDatabaseSize]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[MyProc]
END



use "databaseName"
go 

CREATE OR ALTER PROCEDURE GetCurrentDatabaseSize
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DatabaseSizeInBytes BIGINT;

    SELECT @DatabaseSizeInBytes = SUM(size) * 8 * 1024
    FROM sys.master_files
    WHERE type = 0 AND database_id = DB_ID(DB_NAME());

    SELECT @DatabaseSizeInBytes AS DatabaseSizeInBytes;
END;
