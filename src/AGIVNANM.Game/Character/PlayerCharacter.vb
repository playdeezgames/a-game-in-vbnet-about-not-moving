Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New(PlayerData.ReadCharacter().Value)
    End Sub

    Public Sub AddScore(delta As Long)
        If Not IsDead Then
            Score += delta
        End If
    End Sub

    Property Score As Long
        Get
            Return PlayerData.ReadScore().Value
        End Get
        Set(value As Long)
            PlayerData.WriteScore(value)
        End Set
    End Property
End Class
