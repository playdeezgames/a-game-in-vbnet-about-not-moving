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
    <Extension>
    Function InitialAmount(resourceType As ResourceType) As Long
        Select Case resourceType
            Case ResourceType.Sugar
                Return 1
            Case Else
                Return 0
        End Select
    End Function
    Public ReadOnly AllResourceTypes As New List(Of ResourceType) From {ResourceType.Sap, ResourceType.Sugar, ResourceType.Water}
End Module
