Module InPlay
    Const GameMenuText = "Game Menu"
    Const NextDayText = "Next Day"
    Const PhotosynthesizeText = "Photosynthesize"
    Const AbsorbWaterText = "Absorb Water"
    Const ProduceSapText = "Produce Sap"
    Const RepairDamageText = "Repair Damage"
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
        ReportStatus(character)
        Dim prompt As SelectionPrompt(Of String) = GeneratePrompt(character)
        Select Case AnsiConsole.Prompt(prompt)
            Case NextDayText
                Return NextDay.Run()
            Case GameMenuText
                Return GameMenu.Run()
            Case PhotosynthesizeText
                Return Photosythesize.Run(character)
            Case AbsorbWaterText
                Return AbsorbWater.Run(character)
            Case ProduceSapText
                Return ProduceSap.Run(character)
            Case RepairDamageText
                Return RepairDamage.Run(character)
            Case Else
                Throw New NotImplementedException
        End Select
        Return False
    End Function

    Private Sub ReportStatus(character As PlayerCharacter)
        AnsiConsole.WriteLine("Yer alive!")
        For Each part In character.DeadParts
            AnsiConsole.WriteLine($"{part.Name} is dead.")
        Next
        AnsiConsole.WriteLine($"Vitality: {character.Vitality}/{character.MaximumVitality}")
        Dim world = character.World
        AnsiConsole.WriteLine($"Day: {world.Day}")
        AnsiConsole.MarkupLine($"Condition: {world.Condition.Name}")
        AnsiConsole.WriteLine($"Light Level: {world.LightLevel}")
        AnsiConsole.WriteLine($"Parts: { String.Join(","c, character.StackedParts.Select(Function(x) $"{x.Key.Name}(x{x.Value.Count})"))}")
        Dim resources As Dictionary(Of ResourceType, Long) = character.Resources
        If resources.Any Then
            AnsiConsole.WriteLine($"Resources: { String.Join(","c, resources.Select(Function(x) $"{x.Key.Name}(x{x.Value})"))}")
        End If
    End Sub

    Private Function GeneratePrompt(character As PlayerCharacter) As SelectionPrompt(Of String)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now what?[/]"}
        prompt.AddChoice(NextDayText)
        If character.CanPhotosynthesize Then
            prompt.AddChoice(PhotosynthesizeText)
        End If
        If character.CanAbsorbWater Then
            prompt.AddChoice(AbsorbWaterText)
        End If
        If character.CanProduceSap Then
            prompt.AddChoice(ProduceSapText)
        End If
        If character.CanRepairDamage Then
            prompt.AddChoice(RepairDamageText)
        End If
        prompt.AddChoice(GameMenuText)
        Return prompt
    End Function

    Private Function RunDead(character As PlayerCharacter) As Boolean
        Dim done As Boolean
        AnsiConsole.WriteLine("Yer dead!")
        AnsiConsole.WriteLine($"Day: {character.World.Day}")
        OkPrompt()
        done = True
        Return done
    End Function
End Module
