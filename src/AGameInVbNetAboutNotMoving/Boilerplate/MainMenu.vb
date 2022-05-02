Module MainMenu
    Const QuitText = "Quit"
    Const NewGameText = "New Game"
    Const LoadGameText = "Load Game"
    Friend Sub Run()
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "Main Menu"}
            prompt.AddChoices(NewGameText, LoadGameText, QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case NewGameText
                    NewGame.Run()
                Case LoadGameText
                    LoadGameMenu.Run()
                Case QuitText
                    done = AnsiConsole.Confirm("[red]Are you sure you want to quit?[/]", False)
                Case Else
                    Throw New NotImplementedException
            End Select
        End While
    End Sub
End Module
