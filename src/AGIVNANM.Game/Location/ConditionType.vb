Imports System.Runtime.CompilerServices

Public Enum ConditionType
    None
    Drought
    ExtremeDrought
    CompleteCloudCover
    CloudCover
    HeavyRains
    HighWinds
End Enum
Public Module ConditionTypeExensions
    Friend ReadOnly ConditionTypeGenerator As New Dictionary(Of ConditionType, Integer) From
        {
            {ConditionType.None, 100},
            {ConditionType.CloudCover, 20},
            {ConditionType.CompleteCloudCover, 5}
        }
    <Extension>
    Public Function Name(conditionType As ConditionType) As String
        Select Case conditionType
            Case ConditionType.HeavyRains
                Return "heavy rains"
            Case ConditionType.CloudCover
                Return "cloud cover"
            Case ConditionType.CompleteCloudCover
                Return "complete cloud cover"
            Case ConditionType.Drought
                Return "drought"
            Case ConditionType.ExtremeDrought
                Return "extreme drought"
            Case ConditionType.HighWinds
                Return "high winds"
            Case ConditionType.None
                Return "none"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
