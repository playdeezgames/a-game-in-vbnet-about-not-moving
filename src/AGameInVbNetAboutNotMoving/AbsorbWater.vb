Module AbsorbWater
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        Dim character As New PlayerCharacter
        Dim part = character.Parts.FirstOrDefault(Function(x) x.CanAbsorbWater)
        If part Is Nothing Then
            AnsiConsole.WriteLine("You cannot absorb water now!")
            OkPrompt()
            Return False
        End If
        Dim result = part.AbsorbWater()
        AnsiConsole.WriteLine($"You absorb {result} water.")
        OkPrompt()
        Return False
    End Function
End Module
