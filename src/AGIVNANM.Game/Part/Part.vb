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
        Actions -= 1
        Return sugars
    End Function

    Public Function AbsorbWater() As Long
        Dim water As Long = RNG.RollDice(PartType.WaterAbsorptionDice)
        water = If(water > Location.WaterLevel, Location.WaterLevel, water)
        Location.WaterLevel -= water
        Character.ChangeResource(ResourceType.Water, water)
        Actions -= 1
        Return water
    End Function

    Property Actions As Long
        Get
            Return PartData.ReadActions(Id).Value
        End Get
        Set(value As Long)
            PartData.WriteActions(Id, value)
        End Set
    End Property

    Friend Sub Destroy()
        PartData.Clear(Id)
    End Sub

    ReadOnly Property Name As String
        Get
            Return PartType.Name
        End Get
    End Property

    ReadOnly Property IsDead As Boolean
        Get
            Return Vitality < 1
        End Get
    End Property

    ReadOnly Property HasAction As Boolean
        Get
            Return Not IsDead AndAlso Actions > 0
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
        For Each entry In PartType.Upkeep
            Dim availableResource As Long = Character.GetResource(entry.Key)
            Dim damage = If(entry.Value > availableResource, entry.Value - availableResource, 0)
            Character.ChangeResource(entry.Key, -entry.Value)
            AddDamage(damage)
        Next
        PartData.WriteActions(Id, PartType.MaximumActions)
    End Sub

    ReadOnly Property Damage As Long
        Get
            Return PartData.ReadDamage(Id).Value
        End Get
    End Property

    Private Sub AddDamage(delta As Long)
        Dim newDamage = Math.Max(Math.Min(Damage + delta, MaximumVitality), 0)
        PartData.WriteDamage(Id, newDamage)
    End Sub

    ReadOnly Property Vitality As Long
        Get
            Return MaximumVitality - Damage
        End Get
    End Property

    ReadOnly Property MaximumVitality As Long
        Get
            Return PartType.MaximumVitality
        End Get
    End Property

    ReadOnly Property CanAbsorbWater As Boolean
        Get
            Return PartType.CanAbsorbWater AndAlso HasAction AndAlso Location.HasWaterLeft
        End Get
    End Property
End Class
