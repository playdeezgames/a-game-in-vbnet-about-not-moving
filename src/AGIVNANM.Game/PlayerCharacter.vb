Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New(PlayerData.ReadCharacter().Value)
    End Sub

End Class
