Module RepairDamage
    Friend Function Run(character As PlayerCharacter) As Boolean
        Dim part = character.Parts.FirstOrDefault(Function(x) x.CanRepairDamage)
        If part Is Nothing Then
            Return False
        End If
        Dim repairAmount = part.RepairDamage()
        AnsiConsole.WriteLine($"{part.Name} repairs {repairAmount} damage.")
        OkPrompt()
        Return False
    End Function
End Module
