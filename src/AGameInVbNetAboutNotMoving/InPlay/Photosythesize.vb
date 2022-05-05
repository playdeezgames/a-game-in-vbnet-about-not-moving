Module Photosythesize
    Friend Function Run(character As PlayerCharacter) As Boolean
        AnsiConsole.Clear()
        Dim part = character.Parts.FirstOrDefault(Function(x) x.CanPhotosynthesize)
        If part Is Nothing Then
            AnsiConsole.WriteLine("You cannot photosynthesize now!")
            OkPrompt()
            Return False
        End If
        Dim result = part.Photosynthesize()
        AnsiConsole.WriteLine($"You photosynthesize {result} sugars.")
        OkPrompt()
        Return False
    End Function
End Module
