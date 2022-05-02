Public Class Character
    Public ReadOnly Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub
    Friend Shared Function Create(location As Location, characterType As CharacterType) As Character
        Return New Character(CharacterData.Create(characterType, location.Id))
    End Function

    Friend Sub SetAsPlayer()
        PlayerData.WriteCharacter(Id)
    End Sub

    Public ReadOnly Property IsDead As Boolean
        Get
            'TODO: how does a tree die?
            Return False
        End Get
    End Property

    Public ReadOnly Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocation(Id).Value)
        End Get
    End Property

    Public ReadOnly Property World As World
        Get
            Return Location.World
        End Get
    End Property
End Class
