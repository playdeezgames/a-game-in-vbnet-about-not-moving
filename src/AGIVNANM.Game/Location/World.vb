Public Class World
    Private Const LightLevelDice = "10d10/10"

    Public ReadOnly Id As Long
    Sub New(worldId As Long)
        Id = worldId
    End Sub
    Public Sub Start()
        Dim location = AGIVNANM.Game.Location.Create(Id, 0, 0, LocationType.Dirt)
        Dim character = AGIVNANM.Game.Character.Create(location, CharacterType.Tree)
        character.SetAsPlayer()
    End Sub

    ReadOnly Property Locations As IEnumerable(Of Location)
        Get
            Return LocationData.ReadForWorld(Id).Select(Function(id) New Location(id))
        End Get
    End Property

    Friend Sub NextDay()
        WorldData.WriteDay(Id, WorldData.ReadDay(Id).Value + 1)
        Dim conditionType = RNG.FromGenerator(ConditionTypeGenerator)
        WorldData.WriteConditionType(Id, conditionType)
        Dim newLightLevel =
            If(conditionType = ConditionType.CompleteCloudCover, 0,
            If(conditionType = ConditionType.CloudCover, RNG.RollDice(LightLevelDice) \ 2,
            RNG.RollDice(LightLevelDice)))
        WorldData.WriteLightLevel(Id, newLightLevel)
        For Each location In Locations
            location.NextDay(conditionType)
        Next
    End Sub

    Shared Function Create() As World
        Return New World(WorldData.Create(RNG.RollDice(LightLevelDice)))
    End Function

    ReadOnly Property Day As Long
        Get
            Return WorldData.ReadDay(Id).Value
        End Get
    End Property

    ReadOnly Property LightLevel As Long
        Get
            Return WorldData.ReadLightLevel(Id).value
        End Get
    End Property

    ReadOnly Property Condition As ConditionType
        Get
            Return CType(WorldData.ReadConditionType(Id).value, ConditionType)
        End Get
    End Property
End Class
