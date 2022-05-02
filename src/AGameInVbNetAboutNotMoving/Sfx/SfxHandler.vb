Module SfxHandler
    Sub HandleSfx(sfx As Sfx)
        Select Case sfx
            Case Sfx.Title
                PlayTitle()
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Private Sub PlayTitle()
        PlayStatement.Play("L256;D5;L192;G5;L64;G5;L256;G5;A5;L192;B5;L64;B5;L384;B5;L128;B5;A5;B5;L256;C6;F#5;A5;G5;D5")
    End Sub
End Module
