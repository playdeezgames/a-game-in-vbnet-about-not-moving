Imports System.Runtime.CompilerServices

Public Enum PartType
    None
    Trunk
    Leaves
    Roots
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
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module