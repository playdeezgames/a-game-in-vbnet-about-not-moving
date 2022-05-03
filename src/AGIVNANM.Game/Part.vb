Public Class Part
    ReadOnly Id As Long
    Sub New(partId As Long)
        Id = partId
    End Sub

    Friend Shared Function Create(character As Character, location As Location, partType As PartType) As Part
        Return New Part(PartData.Create(partType, character.Id, location.Id))
    End Function

    ReadOnly Property PartType As PartType
        Get
            Return CType(PartData.ReadPartType(Id).Value, PartType)
        End Get
    End Property

    ReadOnly Property Character As Character
        Get
            Return New Character(PartData.ReadCharacter(Id).Value)
        End Get
    End Property

    Public Function Photosynthesize() As Long
        Dim sugars As Long = RNG.RollDice(PartType.PhotosynthesisDice)
        sugars = If(sugars > Location.LightLevel, Location.LightLevel, sugars)
        Location.LightLevel -= sugars
        Character.ChangeResource(ResourceType.Sugar, sugars)
        Return sugars
    End Function

    ReadOnly Property HasAction As Boolean
        Get
            Return PartData.ReadActions(Id).Value > 0
        End Get
    End Property

    ReadOnly Property Location As Location
        Get
            Return New Location(PartData.ReadLocation(Id).value)
        End Get
    End Property

    ReadOnly Property CanPhotosynthesize As Boolean
        Get
            Return PartType.CanPhotosynthesize AndAlso HasAction AndAlso Location.HasLightLeft
        End Get
    End Property

    Friend Sub NextDay()
        PartData.WriteActions(Id, PartType.MaximumActions)
    End Sub
End Class
