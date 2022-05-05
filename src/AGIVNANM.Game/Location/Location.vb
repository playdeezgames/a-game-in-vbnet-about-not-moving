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

    Property WaterLevel As Long
        Get
            Return LocationData.ReadWaterLevel(Id).Value
        End Get
        Set(value As Long)
            LocationData.WriteWaterLevel(Id, Math.Max(value, 0))
        End Set
    End Property

    ReadOnly Property HasWaterLeft As Boolean
        Get
            Return WaterLevel > 0
        End Get
    End Property

    ReadOnly Property LocationType As LocationType
        Get
            Return CType(LocationData.ReadLocationType(Id).Value, LocationType)
        End Get
    End Property

    Friend Sub NextDay(conditionType As ConditionType)
        LightLevel = World.LightLevel
        Dim additionalWaterLevel =
            If(conditionType = ConditionType.ExtremeDrought, 0,
            If(conditionType = ConditionType.Drought, RNG.RollDice(LocationType.WaterLevelDice) \ 2,
            If(conditionType = ConditionType.HeavyRains, RNG.RollDice(LocationType.WaterLevelDice) * 2,
            RNG.RollDice(LocationType.WaterLevelDice))))
        WaterLevel = Math.Min(WaterLevel + additionalWaterLevel, LocationType.WaterLevelSaturation)
        For Each character In Characters
            character.NextDay(conditionType)
        Next
    End Sub
End Class
