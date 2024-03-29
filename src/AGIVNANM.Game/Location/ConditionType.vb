﻿Imports System.Runtime.CompilerServices

Public Enum ConditionType
    None
    Drought
    ExtremeDrought
    CompleteCloudCover
    CloudCover
    HeavyRains
    HighWinds
    SeverelyHighWinds
    AmorousDendrophiliac
    Woodpeckers
    Termites
    Tap
End Enum
Public Module ConditionTypeExensions
    Friend ReadOnly ConditionTypeGenerator As New Dictionary(Of ConditionType, Integer) From
        {
            {ConditionType.None, 50},
            {ConditionType.CloudCover, 25},
            {ConditionType.CompleteCloudCover, 10},
            {ConditionType.Drought, 15},
            {ConditionType.ExtremeDrought, 5},
            {ConditionType.HeavyRains, 20},
            {ConditionType.HighWinds, 30},
            {ConditionType.SeverelyHighWinds, 10},
            {ConditionType.AmorousDendrophiliac, 1},
            {ConditionType.Termites, 1},
            {ConditionType.Tap, 1},
            {ConditionType.Woodpeckers, 5}
        }
    <Extension>
    Public Function Name(conditionType As ConditionType) As String
        Select Case conditionType
            Case ConditionType.HeavyRains
                Return "[blue]heavy rains[/]"
            Case ConditionType.CloudCover
                Return "[grey]cloud cover[/]"
            Case ConditionType.CompleteCloudCover
                Return "[grey]complete cloud cover[/]"
            Case ConditionType.Drought
                Return "[maroon]drought[/]"
            Case ConditionType.ExtremeDrought
                Return "[red]extreme drought[/]"
            Case ConditionType.HighWinds
                Return "[yellow]high winds[/]"
            Case ConditionType.SeverelyHighWinds
                Return "[olive]severely high winds[/]"
            Case ConditionType.AmorousDendrophiliac
                Return "[mediumvioletred]an amorous dendrophiliac is visiting for a romantic interlude[/]"
            Case ConditionType.Woodpeckers
                Return "[blue]WOODPECKERS!!![/]"
            Case conditionType.Termites
                Return "[maroon]TERMITES!!![/]"
            Case ConditionType.Tap
                Return "[yellow]Yer being harvested for sap![/]"
            Case ConditionType.None
                Return "none"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
