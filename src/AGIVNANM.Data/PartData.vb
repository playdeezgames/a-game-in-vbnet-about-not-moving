Public Module PartData
    Friend Const TableName = "Parts"
    Friend Const PartIdColumn = "PartId"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const LocationIdColumn = LocationData.LocationIdColumn
    Friend Const PartTypeColumn = "PartType"
    Friend Const ActionsColumn = "Actions"
    Friend Const DamageColumn = "Damage"
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
                [{ActionsColumn}] INT NOT NULL DEFAULT(0),
                [{DamageColumn}] INT NOT NULL DEFAULT(0),
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}]),
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub

    Public Function ReadCharacter(partId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PartIdColumn, partId, CharacterIdColumn)
    End Function

    Public Function ReadLocation(partId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PartIdColumn, partId, LocationIdColumn)
    End Function

    Public Sub WriteActions(partId As Long, actions As Long)
        WriteColumnValue(AddressOf Initialize, TableName, PartIdColumn, partId, ActionsColumn, actions)
    End Sub

    Public Function ReadActions(partId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PartIdColumn, partId, ActionsColumn)
    End Function

    Public Function ReadPartType(partId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PartIdColumn, partId, PartTypeColumn)
    End Function

    Public Function ReadDamage(partId As Long) As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PartIdColumn, partId, DamageColumn)
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

    Public Sub WriteDamage(partId As Long, damage As Long)
        WriteColumnValue(AddressOf Initialize, TableName, PartIdColumn, partId, DamageColumn, damage)
    End Sub

    Public Function ReadForCharacter(characterId As Long) As IEnumerable(Of Long)
        Return ReadIdsWithColumnValue(AddressOf Initialize, TableName, PartIdColumn, CharacterIdColumn, characterId)
    End Function
End Module
