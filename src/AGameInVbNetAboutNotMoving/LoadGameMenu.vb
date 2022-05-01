Module LoadGameMenu
    Friend Sub Run()
        Dim filename = AnsiConsole.Ask("[olive]filename:[/]", "")
        If Not String.IsNullOrWhiteSpace(filename) Then
            Store.Load(filename)
            InPlay.Run()
            Store.ShutDown()
        End If
    End Sub
End Module
