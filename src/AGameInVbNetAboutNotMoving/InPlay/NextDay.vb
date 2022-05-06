Module NextDay
    Friend Function Run(character As PlayerCharacter) As Boolean
        character.AddScore(1)
        AnsiConsole.Clear()
        AnsiConsole.WriteLine("Time passes....")
        Game.NextDay()
        OkPrompt()
        Return False
    End Function
End Module
