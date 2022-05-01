Module NewGame
    Friend Sub Run()
        Store.Reset()
        Game.Start()
        InPlay.Run()
        Store.ShutDown()
    End Sub
End Module
