Public Class Location
    Public ReadOnly Id As Long
    Sub New(locationId As Long)
        Id = locationId
    End Sub
    Public Shared Function Create(x As Long, y As Long, locationType As LocationType) As Location
        Return New Location(LocationData.Create(x, y, locationType))
    End Function
End Class
