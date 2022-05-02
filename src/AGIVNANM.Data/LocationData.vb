Public Module LocationData
    Friend Const TableName = "Locations"
    Friend Const LocationIdColumn = "LocationId"
    Friend Const XColumn = "X"
    Friend Const YColumn = "Y"
    Friend Const LocationTypeColumn = "LocationType"
    Friend Const WorldIdColumn = WorldData.WorldIdColumn
    Friend Sub Initialize()
        WorldData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{LocationIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{WorldIdColumn}] INT NOT NULL,
                [{XColumn}] INT NOT NULL,
                [{YColumn}] INT NOT NULL,
                [{LocationTypeColumn}] INT NOT NULL,
                UNIQUE([{XColumn}],[{YColumn}]),
                FOREIGN KEY ([{WorldIdColumn}]) REFERENCES [{WorldData.TableName}]([{WorldData.WorldIdColumn}])
            );")
    End Sub

    Public Function ReadWorld(locationId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, LocationIdColumn, locationId, WorldIdColumn)
    End Function

    Public Function Create(worldId As Long, x As Long, y As Long, locationType As Long) As Long
        Initialize()
        ExecuteNonQuery(
            $"INSERT INTO [{TableName}]
            (
                [{WorldIdColumn}],
                [{XColumn}],
                [{YColumn}],
                [{LocationTypeColumn}]
            ) 
            VALUES
            (
                @{WorldIdColumn},
                @{XColumn},
                @{YColumn},
                @{LocationTypeColumn}
            );",
            MakeParameter($"@{WorldIdColumn}", worldId),
            MakeParameter($"@{XColumn}", x),
            MakeParameter($"@{YColumn}", y),
            MakeParameter($"@{LocationTypeColumn}", locationType))
        Return LastInsertRowId
    End Function
End Module
