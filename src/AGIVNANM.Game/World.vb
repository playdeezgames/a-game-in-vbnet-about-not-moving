Public Class World
    Public ReadOnly Id As Long
    Sub New(worldId As Long)
        Id = worldId
    End Sub
    Public Sub Start()
        Dim location = AGIVNANM.Game.Location.Create(Id, 0, 0, LocationType.Dirt)
        Dim character = AGIVNANM.Game.Character.Create(location, CharacterType.Tree)
        character.SetAsPlayer()
    End Sub

    Friend Sub NextDay()
        WorldData.WriteDay(Id, WorldData.ReadDay(Id).Value + 1)
    End Sub

    Shared Function Create() As World
        Return New World(WorldData.Create())
    End Function

    ReadOnly Property Day As Long
        Get
            Return WorldData.ReadDay(Id).Value
        End Get
    End Property
End Class
