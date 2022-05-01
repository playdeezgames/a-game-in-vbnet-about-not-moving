Public Class Game
    Public Shared Sub Start()
        Dim location = AGIVNANM.Game.Location.Create(0, 0, LocationType.Dirt)
        Dim character = AGIVNANM.Game.Character.Create(location, CharacterType.Tree)
        character.SetAsPlayer()
    End Sub
End Class
