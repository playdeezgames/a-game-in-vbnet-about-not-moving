Public Module Game
    Public Sub Start()
        Dim world = AGIVNANM.Game.World.Create()
        world.Start()
        world.NextDay()
    End Sub

    Public Sub NextDay()
        Dim player As New PlayerCharacter()
        player.World.NextDay()
    End Sub
End Module
