Public Class Character
    Public ReadOnly Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub
    Friend Shared Function Create(location As Location, characterType As CharacterType) As Character
        Dim character = New Character(CharacterData.Create(characterType, location.Id))
        Part.Create(character, character.Location, PartType.Trunk)
        Part.Create(character, character.Location, PartType.Leaves)
        Part.Create(character, character.Location, PartType.Roots)
        For Each resourceType In AllResourceTypes
            character.ChangeResource(resourceType, resourceType.InitialAmount)
        Next
        Return character
    End Function

    Friend Sub SetAsPlayer()
        PlayerData.WriteCharacter(Id)
    End Sub

    Public ReadOnly Property IsDead As Boolean
        Get
            Return Not Parts.Any(Function(x) x.PartType = PartType.Trunk)
        End Get
    End Property

    Friend Sub ChangeResource(resourceType As ResourceType, amount As Long)
        Dim newAmount = If(CharacterResourceData.Read(Id, resourceType), 0) + amount
        CharacterResourceData.Write(Id, resourceType, Math.Max(newAmount, 0))
    End Sub

    ReadOnly Property DeadParts As IEnumerable(Of Part)
        Get
            Return Parts.Where(Function(x) x.IsDead)
        End Get
    End Property

    ReadOnly Property LivingParts As IEnumerable(Of Part)
        Get
            Return Parts.Where(Function(x) Not x.IsDead)
        End Get
    End Property

    Friend Sub NextDay(conditionType As ConditionType)
        For Each part In DeadParts
            part.Destroy()
        Next
        For Each part In Parts
            part.NextDay(conditionType)
        Next
    End Sub

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

    Public ReadOnly Property Parts As IEnumerable(Of Part)
        Get
            Return PartData.ReadForCharacter(Id).Select(Function(id) New Part(id))
        End Get
    End Property

    Public ReadOnly Property StackedParts As Dictionary(Of PartType, IEnumerable(Of Part))
        Get
            Dim groups = LivingParts.GroupBy(Function(x) x.PartType)
            Dim result As New Dictionary(Of PartType, IEnumerable(Of Part))
            For Each group In groups
                result(group.Key) = group
            Next
            Return result
        End Get
    End Property

    Friend Function GetResource(resourceType As ResourceType) As Long
        Return If(CharacterResourceData.Read(Id, resourceType), 0)
    End Function

    Public ReadOnly Property CanPhotosynthesize As Boolean
        Get
            Return Parts.Any(Function(x) x.CanPhotosynthesize)
        End Get
    End Property

    Public ReadOnly Property CanAbsorbWater As Boolean
        Get
            Return Parts.Any(Function(x) x.CanAbsorbWater)
        End Get
    End Property

    ReadOnly Property Resources As Dictionary(Of ResourceType, Long)
        Get
            Dim result As New Dictionary(Of ResourceType, Long)
            For Each entry In CharacterResourceData.ReadForCharacter(Id)
                result(CType(entry.Key, ResourceType)) = entry.Value
            Next
            Return result
        End Get
    End Property

    ReadOnly Property Vitality As Long
        Get
            Return Parts.Sum(Function(x) x.Vitality)
        End Get
    End Property

    ReadOnly Property MaximumVitality As Long
        Get
            Return Parts.Sum(Function(x) x.MaximumVitality)
        End Get
    End Property

    ReadOnly Property CanProduceSap As Boolean
        Get
            Return Parts.Any(Function(x) x.CanProduceSap)
        End Get
    End Property

    ReadOnly Property HasWater As Boolean
        Get
            Return GetResource(ResourceType.Water) > 0
        End Get
    End Property

    ReadOnly Property HasSugar As Boolean
        Get
            Return GetResource(ResourceType.Sugar) > 0
        End Get
    End Property

    ReadOnly Property HasSap As Boolean
        Get
            Return GetResource(ResourceType.Sap) > 0
        End Get
    End Property

    ReadOnly Property CanRepairDamage As Boolean
        Get
            Return Parts.Any(Function(x) x.CanRepairDamage)
        End Get
    End Property

    Public Function CanGrow(partType As PartType) As Boolean
        Return GetResource(ResourceType.Sap) >= partType.SapCost
    End Function

    Public Sub Grow(partType As PartType)
        If CanGrow(partType) Then
            ChangeResource(ResourceType.Sap, -partType.SapCost)
            Part.Create(Me, Me.Location, partType)
        End If
    End Sub
End Class
