Imports System

Module Program
    Sub Main(args As String())
        Splash()
        MainMenu.Run()
    End Sub

    Private Sub Splash()
        Console.Title = "A game in VB.NET about not moving"
        Dim figlet As New FigletText("A game in VB.NET about not moving") With
            {
                .Alignment = Justify.Center,
                .Color = Color.Aqua
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine("A Production of TheGrumpyGameDev")
        AnsiConsole.WriteLine("For A Jam about making Terminal Based Games in VB.NET")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("OK")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
