Module Photosythesize
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        Dim character As New PlayerCharacter
        Dim part = character.Parts.FirstOrDefault(Function(x) x.CanPhotosynthesize)
        If part Is Nothing Then
            AnsiConsole.WriteLine("You cannot photosynthesize now!")
            OkPrompt()
            Return False
        End If
        Dim result = part.Photosynthesize()
        Return False
    End Function
End Module
