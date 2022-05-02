Module InPlay
    Const GameMenuText = "Game Menu"
    Const NextDayText = "Next Day"
    Friend Sub Run()
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim character As New PlayerCharacter()
            If character.IsDead Then
                done = RunDead(character)
            Else
                done = RunAlive(character)
            End If
        End While
    End Sub

    Private Function RunAlive(character As PlayerCharacter) As Boolean
        AnsiConsole.WriteLine("Yer alive!")
        Dim world = character.World
        AnsiConsole.WriteLine($"Day: {world.Day}")
        AnsiConsole.WriteLine($"Light Level: {world.LightLevel}")

        AnsiConsole.WriteLine($"Parts: { String.Join(","c, character.StackedParts.Select(Function(x) $"{x.Key.Name}(x{x.Value.Count})"))}")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now what?[/]"}
        prompt.AddChoice(NextDayText)
        prompt.AddChoice(GameMenuText)
        Select Case AnsiConsole.Prompt(prompt)
            Case NextDayText
                Return NextDay.Run()
            Case GameMenuText
                Return GameMenu.Run()
            Case Else
                Throw New NotImplementedException
        End Select
        Return False
    End Function

    Private Function RunDead(character As PlayerCharacter) As Boolean
        Dim done As Boolean
        AnsiConsole.WriteLine("Yer dead!")
        OkPrompt()
        done = True
        Return done
    End Function
End Module
