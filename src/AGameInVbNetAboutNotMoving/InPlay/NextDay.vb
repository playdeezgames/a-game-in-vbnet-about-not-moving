Module NextDay
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        AnsiConsole.WriteLine("Time passes....")
        Game.NextDay()
        OkPrompt()
        Return False
    End Function
End Module
