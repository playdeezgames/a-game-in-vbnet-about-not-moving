Module GrowPart
    Friend Function Run(character As PlayerCharacter, partType As PartType) As Boolean
        AnsiConsole.Clear()
        If Not character.CanGrow(partType) Then
            AnsiConsole.WriteLine($"You cannot grow {partType.Name} at this time.")
            OkPrompt()
            Return False
        End If
        character.Grow(partType)
        character.AddScore(partType.Score)
        AnsiConsole.WriteLine($"You grow {partType.Name}.")
        OkPrompt()
        Return False
    End Function
End Module
