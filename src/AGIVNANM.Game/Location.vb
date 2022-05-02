Public Class Location
    Public ReadOnly Id As Long

    Sub New(locationId As Long)
        Id = locationId
    End Sub

    Public Shared Function Create(worldId As Long, x As Long, y As Long, locationType As LocationType) As Location
        Return New Location(LocationData.Create(worldId, x, y, locationType))
    End Function

    ReadOnly Property World As World
        Get
            Return New World(LocationData.ReadWorld(Id).Value)
        End Get
    End Property
End Class
