Public Module PlayerData
    Friend Const TableName = "Players"
    Friend Const PlayerIdColumn = "PlayerId"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const ScoreColumn = "Score"

    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{PlayerIdColumn}] INT NOT NULL DEFAULT(1),
                [{CharacterIdColumn}] INT NOT NULL,
                [{ScoreColumn}] INT NOT NULL DEFAULT(0),
                CHECK([{PlayerIdColumn}]=1),
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}])
            );")
    End Sub

    Public Sub WriteScore(score As Long)
        Initialize()
        ExecuteNonQuery($"UPDATE [{TableName}] SET [{ScoreColumn}]=@{ScoreColumn};", MakeParameter($"@{ScoreColumn}", score))
    End Sub

    Public Function ReadScore() As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PlayerIdColumn, 1, ScoreColumn)
    End Function

    Public Function ReadCharacter() As Long?
        Return ReadColumnValue(Of Long)(AddressOf Initialize, TableName, PlayerIdColumn, 1, CharacterIdColumn)
    End Function

    Public Sub WriteCharacter(characterId As Long)
        Initialize()
        ExecuteNonQuery($"DELETE FROM [{TableName}];")
        ExecuteNonQuery($"INSERT INTO [{TableName}]([{CharacterIdColumn}]) VALUES(@{CharacterIdColumn});", MakeParameter($"@{CharacterIdColumn}", characterId))
    End Sub
End Module
