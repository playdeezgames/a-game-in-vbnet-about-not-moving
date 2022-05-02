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
End Class
