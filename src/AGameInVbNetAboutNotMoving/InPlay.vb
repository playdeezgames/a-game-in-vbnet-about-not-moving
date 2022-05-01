Module InPlay
    Const GameMenuText = "Game Menu"
    Friend Sub Run()
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim character As New PlayerCharacter()
            If character.IsDead Then
                done = RunDead()
            Else
                done = RunAlive()
            End If
        End While
    End Sub

    Private Function RunAlive() As Boolean
        AnsiConsole.WriteLine("Yer alive!")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now what?[/]"}
        prompt.AddChoice(GameMenuText)
        Select Case AnsiConsole.Prompt(prompt)
            Case GameMenuText
                Return GameMenu.Run()
            Case Else
                Throw New NotImplementedException
        End Select
        Return False
    End Function

    Private Function RunDead() As Boolean
        Dim done As Boolean
        AnsiConsole.WriteLine("Yer dead!")
        OkPrompt()
        done = True
        Return done
    End Function
End Module
