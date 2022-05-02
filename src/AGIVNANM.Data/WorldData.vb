Public Module WorldData
    Friend Const TableName = "Worlds"
    Friend Const WorldIdColumn = "WorldId"
    Friend Const DayColumn = "Day"
    Friend Const LightLevelColumn = "LightLevel"
    Friend Sub Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{WorldIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{DayColumn}] INT NOT NULL DEFAULT(1),
                [{LightLevelColumn}] INT NOT NULL
            );")
    End Sub

    Public Sub WriteLightLevel(worldId As Long, lightLevel As Long)
        WriteColumnValue(AddressOf Initialize, TableName, WorldIdColumn, worldId, LightLevelColumn, lightLevel)
    End Sub

    Public Sub WriteDay(worldId As Long, day As Long)
        WriteColumnValue(AddressOf Initialize, TableName, WorldIdColumn, worldId, DayColumn, day)
    End Sub

    Public Function ReadDay(worldId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, WorldIdColumn, worldId, DayColumn)
    End Function

    Public Function ReadLightLevel(worldId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, WorldIdColumn, worldId, LightLevelColumn)
    End Function

    Public Function Create(lightLevel As Long) As Long
        Initialize()
        ExecuteNonQuery(
            $"INSERT INTO [{TableName}]([{LightLevelColumn}]) VALUES (@{LightLevelColumn});",
            MakeParameter($"@{LightLevelColumn}", lightLevel))
        Return LastInsertRowId
    End Function
End Module
