Public Module LocationData
    Friend Const TableName = "Locations"
    Friend Const LocationIdColumn = "LocationId"
    Friend Const XColumn = "X"
    Friend Const YColumn = "Y"
    Friend Const LocationTypeColumn = "LocationType"
    Friend Sub Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{LocationIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{XColumn}] INT NOT NULL,
                [{YColumn}] INT NOT NULL,
                [{LocationTypeColumn}] INT NOT NULL,
                UNIQUE([{XColumn}],[{YColumn}])
            );")
    End Sub
    Public Function Create(x As Long, y As Long, locationType As Long) As Long
        Initialize()
        ExecuteNonQuery(
            $"INSERT INTO [{TableName}]([{XColumn}],[{YColumn}],[{LocationTypeColumn}]) VALUES(@{XColumn},@{YColumn},@{LocationTypeColumn});",
            MakeParameter($"@{XColumn}", x),
            MakeParameter($"@{YColumn}", y),
            MakeParameter($"@{LocationTypeColumn}", locationType))
        Return LastInsertRowId
    End Function
End Module
