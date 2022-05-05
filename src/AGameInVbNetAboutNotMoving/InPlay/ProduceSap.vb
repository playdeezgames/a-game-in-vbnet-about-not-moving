Module ProduceSap
    Friend Function Run(character As PlayerCharacter) As Boolean
        AnsiConsole.Clear()
        Dim part = character.Parts.FirstOrDefault(Function(x) x.CanProduceSap)
        If part Is Nothing Then
            AnsiConsole.WriteLine("You cannot produce sap now!")
            OkPrompt()
            Return False
        End If
        Dim result = part.ProduceSap()
        AnsiConsole.WriteLine($"You produce {result} sap.")
        OkPrompt()
        Return False
    End Function
End Module
