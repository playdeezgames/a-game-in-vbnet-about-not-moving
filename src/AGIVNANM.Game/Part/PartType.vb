Imports System.Runtime.CompilerServices

Public Enum PartType
    None
    Trunk
    Leaves
    Roots
    Branch
    Seeds
    Tap
End Enum
Public Module PartTypeExtensions
    <Extension>
    Function Name(partType As PartType) As String
        Select Case partType
            Case PartType.Trunk
                Return "trunk"
            Case PartType.Leaves
                Return "leaves"
            Case PartType.Roots
                Return "roots"
            Case PartType.Branch
                Return "branch"
            Case PartType.Seeds
                Return "seeds"
            Case PartType.Tap
                Return "tap"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Function CanPhotosynthesize(partType As PartType) As Boolean
        Return partType = PartType.Leaves
    End Function
    <Extension>
    Function CanAbsorbWater(partType As PartType) As Boolean
        Return partType = PartType.Roots
    End Function
    <Extension>
    Function MaximumActions(partType As PartType) As Long
        Return 1
    End Function
    <Extension>
    Function PhotosynthesisDice(partType As PartType) As String
        Select Case partType
            Case PartType.Leaves
                Return "3d2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function WaterAbsorptionDice(partType As PartType) As String
        Select Case partType
            Case PartType.Roots
                Return "3d2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function WindDamageRoll(partType As PartType) As String
        Select Case partType
            Case PartType.Seeds
                Return "1d1"
            Case PartType.Leaves, PartType.Branch
                Return "1d2/2+1d2/2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function WoodpeckerDamageRoll(partType As PartType) As String
        Select Case partType
            Case PartType.Trunk, PartType.Branch
                Return "1d2/2+1d2/2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function TermiteDamageRoll(partType As PartType) As String
        Select Case partType
            Case PartType.Trunk, PartType.Branch
                Return "1d2/2+1d2/2+1d2/2+1d2/2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function Upkeep(partType As PartType) As Dictionary(Of ResourceType, Long)
        Select Case partType
            Case PartType.Trunk
                Return New Dictionary(Of ResourceType, Long) From {{ResourceType.Sugar, 1}}
            Case PartType.Leaves
                Return New Dictionary(Of ResourceType, Long) From {{ResourceType.Water, 1}}
            Case PartType.Roots
                Return New Dictionary(Of ResourceType, Long)
            Case PartType.Branch
                Return New Dictionary(Of ResourceType, Long) From
                    {
                        {ResourceType.Sugar, 1},
                        {ResourceType.Water, 1}
                    }
            Case PartType.Tap
                Return New Dictionary(Of ResourceType, Long) From
                    {
                        {ResourceType.Sap, 10}
                    }
            Case Else
                Return New Dictionary(Of ResourceType, Long)
        End Select
    End Function
    <Extension>
    Function MaximumVitality(partType As PartType) As Long
        Select Case partType
            Case PartType.Trunk
                Return 10
            Case PartType.Seeds, PartType.Tap
                Return 1
            Case Else
                Return 5
        End Select
    End Function
    <Extension>
    Function CanProduceSap(partType As PartType) As Boolean
        Return partType = PartType.Trunk OrElse partType = PartType.Branch
    End Function
    <Extension>
    Function SapProductionDice(partType As PartType) As String
        Select Case partType
            Case PartType.Trunk
                Return "3d2"
            Case PartType.Branch
                Return "2d2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function RepairDice(partType As PartType) As String
        Return "2d2"
    End Function

    <Extension>
    Function SapCost(partType As PartType) As Long
        Select Case partType
            Case PartType.Leaves
                Return 10
            Case PartType.Roots
                Return 25
            Case PartType.Branch
                Return 15
            Case PartType.Seeds
                Return 20
            Case Else
                Return Long.MaxValue
        End Select
    End Function
    <Extension>
    Function Score(partType As PartType) As Long
        Select Case partType
            Case PartType.Branch
                Return 5
            Case PartType.Roots
                Return 1
            Case PartType.Leaves
                Return 3
            Case PartType.Seeds
                Return 10
            Case Else
                Return 0
        End Select
    End Function
End Module