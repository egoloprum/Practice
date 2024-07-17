USE masternewnew;
GO

CREATE OR ALTER PROCEDURE dbo.CleanTables
    @CutoffDate char(20)
AS
BEGIN
    DECLARE @tableName NVARCHAR(256)
    DECLARE @sql NVARCHAR(MAX)
    DECLARE @currentDate DATE = GETDATE()
    DECLARE @oneYearAgo DATE = DATEADD(YEAR, -1, @currentDate)
	SET @CutoffDate = CONVERT(datetime, @CutoffDate)

    -- Check if the cutoff date is within the last year
    IF @CutoffDate > @oneYearAgo
    BEGIN
        RAISERROR('Cannot delete data within the last year.', 16, 1)
        RETURN
    END

    DECLARE tableCursor CURSOR FOR
    SELECT '[' + SCHEMA_NAME(schema_id) + '].[' + name + ']' AS TableName
    FROM sys.tables
    WHERE name NOT LIKE '%Label'

    OPEN tableCursor
    FETCH NEXT FROM tableCursor INTO @tableName

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Check and delete from DAT_Start_Dosing from table TBatchs
        IF EXISTS (
            SELECT 1 
            FROM sys.columns 
            WHERE [object_id] = OBJECT_ID(@tableName) 
              AND [name] = 'DAT_Start_Dosing'
        )
        BEGIN
            SET @sql = 'DELETE FROM ' + @tableName + ' WHERE DAT_Start_Dosing < @CutoffDate'
            EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate
			PRINT 'Successfully deleted DAT_Start_Dosing from TBatchs'
        END

        -- Check and delete from DAT_Start from table TDosing
        IF EXISTS (
            SELECT 1 
            FROM sys.columns 
            WHERE [object_id] = OBJECT_ID(@tableName) 
              AND [name] = 'DAT_Start'
        )
        BEGIN
            SET @sql = 'DELETE FROM ' + @tableName + ' WHERE DAT_Start < @CutoffDate'
            EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate
			PRINT 'Successfully deleted DAT_Start from TDosing'
        END

        FETCH NEXT FROM tableCursor INTO @tableName
    END

    CLOSE tableCursor
    DEALLOCATE tableCursor
END
GO


USE masternewnew_alarm;
GO

CREATE OR ALTER PROCEDURE dbo.CleanTables_Alarm
    @CutoffDate char(20)
AS
BEGIN
    DECLARE @tableName NVARCHAR(256)
    DECLARE @sql NVARCHAR(MAX)
    DECLARE @currentDate DATE = GETDATE()
    DECLARE @oneYearAgo DATE = DATEADD(YEAR, -1, @currentDate)

	SET @CutoffDate = CONVERT(datetime, @CutoffDate)

    -- Check if the cutoff date is within the last year
    IF @CutoffDate > @oneYearAgo
    BEGIN
        RAISERROR('Cannot delete data within the last year.', 16, 1)
        RETURN
    END

    DECLARE tableCursor CURSOR FOR
    SELECT '[' + SCHEMA_NAME(schema_id) + '].[' + name + ']' AS TableName
    FROM sys.tables
    WHERE name NOT LIKE '%Label'

    OPEN tableCursor
    FETCH NEXT FROM tableCursor INTO @tableName

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Check and delete from plc_time from table alarms_tested, alarms
        IF EXISTS (
            SELECT 1 
            FROM sys.columns 
            WHERE [object_id] = OBJECT_ID(@tableName) 
              AND [name] = 'plctime'
        )
        BEGIN
            SET @sql = 'DELETE FROM ' + @tableName + ' WHERE plctime < @CutoffDate'
            EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate
			PRINT 'Successfully deleted plc_time from ' + @tableName
        END

        -- Check and delete from TimeString from table Data_log_SQL0, Alarm_log_10, Data_log_10
        IF EXISTS (
            SELECT 1 
            FROM sys.columns 
            WHERE [object_id] = OBJECT_ID(@tableName) 
              AND [name] = 'TimeString'
        )
        BEGIN
            SET @sql = 'DELETE FROM ' + @tableName + ' WHERE TRY_CONVERT(DATETIME, TimeString) < @CutoffDate'
            EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate
			PRINT 'Successfully deleted TimeString from ' + @tableName
        END

        FETCH NEXT FROM tableCursor INTO @tableName
    END

    CLOSE tableCursor
    DEALLOCATE tableCursor
END
GO
