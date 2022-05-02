Module SaveGameMenu
    Friend Sub Run()
        Dim filename = AnsiConsole.Ask("[olive]filename:[/]", "")
        If Not String.IsNullOrWhiteSpace(filename) Then
            Store.Save(filename)
        End If
    End Sub
End Module
