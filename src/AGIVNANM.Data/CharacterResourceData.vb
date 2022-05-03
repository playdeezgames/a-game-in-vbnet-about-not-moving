Public Module CharacterResourceData
    Friend Const TableName = "CharacterResources"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const ResourceTypeColumn = "ResourceType"
    Friend Const AmountColumn = "Amount"
    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INT NOT NULL,
                [{ResourceTypeColumn}] INT NOT NULL,
                [{AmountColumn}] INT NOT NULL,
                UNIQUE([{CharacterIdColumn}],[{ResourceTypeColumn}]),
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}])
            );")
    End Sub
    Public Function Read(characterId As Long, resourceType As Long) As Long?
        Initialize()
        Return ExecuteScalar(Of Long)(
            $"SELECT [{AmountColumn}] FROM [{TableName}] WHERE [{CharacterIdColumn}]=@{CharacterIdColumn} AND [{ResourceTypeColumn}]=@{ResourceTypeColumn};",
            MakeParameter($"@{CharacterIdColumn}", characterId),
            MakeParameter($"@{ResourceTypeColumn}", resourceType))
    End Function

    Public Sub Write(characterId As Long, resourceType As Long, amount As Long)
        ReplaceRecord(AddressOf Initialize, TableName, CharacterIdColumn, characterId, ResourceTypeColumn, resourceType, AmountColumn, amount)
    End Sub
End Module
