Module GameMenu
    Const ContinueGameText = "Continue Game"
    Const AbandonGameText = "Abandon Game"
    Const SaveGameText = "Save Game"
    Friend Function Run() As Boolean
        AnsiConsole.Clear()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "Game Menu:"}
        prompt.AddChoice(ContinueGameText)
        prompt.AddChoice(SaveGameText)
        prompt.AddChoice(AbandonGameText)
        Select Case AnsiConsole.Prompt(prompt)
            Case ContinueGameText
                Return False
            Case SaveGameText
                SaveGameMenu.Run()
                Return False
            Case AbandonGameText
                Return AnsiConsole.Confirm("[red]Are you sure you want to abandon the game?[/]", False)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
