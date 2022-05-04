Imports System.Runtime.CompilerServices

Public Enum LocationType
    None
    Dirt
End Enum
Public Module LocationTypeExtensions
    <Extension>
    Function WaterLevel(locationType As LocationType) As Long
        Select Case locationType
            Case LocationType.Dirt
                Return 10
            Case Else
                Return 0
        End Select
    End Function
End Module