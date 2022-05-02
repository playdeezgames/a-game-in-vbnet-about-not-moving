Public Module WorldData
    Friend Const TableName = "Worlds"
    Friend Const WorldIdColumn = "WorldId"
    Friend Const DayColumn = "Day"
    Friend Sub Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{WorldIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{DayColumn}] INT NOT NULL DEFAULT(1)
            );")
    End Sub

    Public Sub WriteDay(worldId As Long, day As Long)
        WriteColumnValue(AddressOf Initialize, TableName, WorldIdColumn, worldId, DayColumn, day)
    End Sub

    Public Function ReadDay(worldId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, WorldIdColumn, worldId, DayColumn)
    End Function

    Public Function Create() As Long
        Initialize()
        ExecuteNonQuery($"INSERT INTO [{TableName}] DEFAULT VALUES;")
        Return LastInsertRowId
    End Function
End Module
