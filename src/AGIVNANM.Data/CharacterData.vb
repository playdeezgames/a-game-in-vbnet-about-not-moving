Public Module CharacterData
    Friend Const TableName = "Characters"
    Friend Const CharacterIdColumn = "CharacterId"
    Friend Const LocationIdColumn = LocationData.LocationIdColumn
    Friend Const CharacterTypeColumn = "CharacterType"
    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{LocationIdColumn}] INT NOT NULL,
                [{CharacterTypeColumn}] INT NOT NULL,
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub

    Public Function ReadLocation(characterId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, CharacterIdColumn, characterId, LocationIdColumn)
    End Function

    Public Function Create(characterType As Long, locationId As Long) As Long
        Initialize()
        ExecuteNonQuery(
            $"INSERT INTO [{TableName}]([{CharacterTypeColumn}],[{LocationIdColumn}]) VALUES(@{CharacterTypeColumn},@{LocationIdColumn});",
            MakeParameter($"@{CharacterTypeColumn}", characterType),
            MakeParameter($"@{LocationIdColumn}", locationId))
        Return LastInsertRowId
    End Function
End Module
