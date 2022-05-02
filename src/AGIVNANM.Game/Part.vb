Public Class Part
    ReadOnly Id As Long
    Sub New(partId As Long)
        Id = partId
    End Sub

    Friend Shared Function Create(character As Character, location As Location, partType As PartType) As Part
        Return New Part(PartData.Create(partType, character.Id, location.Id))
    End Function
End Class
