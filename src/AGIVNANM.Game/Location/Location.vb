﻿Public Class Location
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

    ReadOnly Property Characters As IEnumerable(Of Character)
        Get
            Return CharacterData.ReadForLocation(Id).Select(Function(id) New Character(id))
        End Get
    End Property

    Property LightLevel As Long
        Get
            Return LocationData.ReadLightLevel(Id).Value
        End Get
        Set(value As Long)
            LocationData.WriteLightLevel(Id, If(value > 0, value, 0))
        End Set
    End Property

    ReadOnly Property HasLightLeft As Boolean
        Get
            Return LightLevel > 0
        End Get
    End Property

    Friend Sub NextDay()
        LightLevel = World.LightLevel
        For Each character In Characters
            character.NextDay()
        Next
    End Sub
End Class