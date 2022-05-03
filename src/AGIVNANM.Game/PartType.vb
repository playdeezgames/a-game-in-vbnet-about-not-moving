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
    <Extension>
    Function CanPhotosynthesize(partType As PartType) As Boolean
        Return partType = PartType.Leaves
    End Function
    <Extension>
    Function MaximumActions(partType As PartType) As Long
        Return 1
    End Function
    <Extension>
    Function PhotosynthesisDice(partType As PartType) As String
        Select Case partType
            Case PartType.Leaves
                Return "2d2/2"
            Case Else
                Return "0d1"
        End Select
    End Function
End Module