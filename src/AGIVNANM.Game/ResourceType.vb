Imports System.Runtime.CompilerServices

Public Enum ResourceType
    None
    Sugar
    Water
    Sap
End Enum
Public Module ResourceTypeExtensions
    <Extension>
    Function Name(resourceType As ResourceType) As String
        Select Case resourceType
            Case ResourceType.Sap
                Return "sap"
            Case ResourceType.Sugar
                Return "sugar"
            Case ResourceType.Water
                Return "water"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
