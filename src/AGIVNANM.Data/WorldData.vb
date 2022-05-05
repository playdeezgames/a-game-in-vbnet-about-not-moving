Public Module WorldData
    Friend Const TableName = "Worlds"
    Friend Const WorldIdColumn = "WorldId"
    Friend Const DayColumn = "Day"
    Friend Const LightLevelColumn = "LightLevel"
    Friend Const ConditionTypeColumn = "ConditionType"
    Friend Sub Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{WorldIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{DayColumn}] INT NOT NULL DEFAULT(0),
                [{LightLevelColumn}] INT NOT NULL,
                [{ConditionTypeColumn}] INT NOT NULL DEFAULT(0)
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

    Public Sub WriteConditionType(worldId As Long, conditionType As Long)
        WriteColumnValue(AddressOf Initialize, TableName, WorldIdColumn, worldId, ConditionTypeColumn, conditionType)
    End Sub

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

    Public Function ReadConditionType(worldId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, WorldIdColumn, worldId, ConditionTypeColumn)
    End Function
End Module
