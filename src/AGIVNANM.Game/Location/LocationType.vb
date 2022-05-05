Imports System.Runtime.CompilerServices

Public Enum LocationType
    None
    Dirt
End Enum
Public Module LocationTypeExtensions
    <Extension>
    Function WaterLevelDice(locationType As LocationType) As String
        Select Case locationType
            Case LocationType.Dirt
                Return "3d2"
            Case Else
                Return "0d1"
        End Select
    End Function
    <Extension>
    Function WaterLevelSaturation(locationType As LocationType) As Long
        Select Case locationType
            Case LocationType.Dirt
                Return 10
            Case Else
                Return 0
        End Select
    End Function
End Module