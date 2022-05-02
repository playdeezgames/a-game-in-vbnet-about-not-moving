Public Module PartData
    Friend Const TableName = "Parts"
    Friend Const PartIdColumn = "PartId"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const LocationIdColumn = LocationData.LocationIdColumn
    Friend Const PartTypeColumn = "PartType"
    Friend Sub Initialize()
        CharacterData.Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{PartIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{PartTypeColumn}] INT NOT NULL,
                [{CharacterIdColumn}] INT NOT NULL,
                [{LocationIdColumn}] INT NOT NULL,
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}]),
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub

    Public Function ReadPartType(partId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PartIdColumn, partId, PartTypeColumn)
    End Function

    Public Function Create(partType As Long, characterId As Long, locationId As Long) As Long
        Initialize()
        ExecuteNonQuery(
            $"INSERT INTO [{TableName}]
            (
                [{PartTypeColumn}],
                [{CharacterIdColumn}],
                [{LocationIdColumn}]
            ) 
            VALUES 
            (
                @{PartTypeColumn},
                @{CharacterIdColumn},
                @{LocationIdColumn}
            );",
            MakeParameter($"@{PartTypeColumn}", partType),
            MakeParameter($"@{CharacterIdColumn}", characterId),
            MakeParameter($"@{LocationIdColumn}", locationId))
        Return LastInsertRowId
    End Function

    Public Function ReadForCharacter(characterId As Long) As IEnumerable(Of Long)
        Return ReadIdsWithColumnValue(AddressOf Initialize, TableName, PartIdColumn, CharacterIdColumn, characterId)
    End Function
End Module
