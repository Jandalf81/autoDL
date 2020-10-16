Imports System.Text.RegularExpressions

Public Class DwellingOfDuels_Duel
    Private _url As String
    Private _urlData As String

    Public Property Url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
        End Set
    End Property
    Public Property UrlData As String
        Get
            Return _urlData
        End Get
        Set(value As String)
            _urlData = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(INurl As String, INurlData As String)
        Me.Url = INurl
        Me.UrlData = INurlData
    End Sub

    Public Sub download(toDirectory As String)
        Dim table As String
        Dim matchColl As MatchCollection
        Dim row As String
        Dim matchCollRow As MatchCollection
        Dim matchCollCell As MatchCollection

        Dim trackName As String
        Dim trackURL As String
        Dim trackArtist As New List(Of String)
        Dim trackAlbum As New List(Of String)

        Dim i As Integer = 1
        Dim fileName As String
        Dim track As Track

        table = Regex.Match(Me.UrlData, "<table class=""table"" data-sortable>.*<\/thead>\s*<tbody>(?'table'.*)<\/tbody>\s*<\/table>", RegexOptions.IgnoreCase).Groups("table").Value

        matchColl = Regex.Matches(table, "(?'row'<tr.*?>.*?<\/tr>)", RegexOptions.IgnoreCase)

        ' iterate through each row of the table
        For Each match As Match In matchColl
            row = match.Groups("row").Value

            ' split row into columns
            matchCollRow = Regex.Matches(row, "(?'column'<td>.*?<\/td>)", RegexOptions.IgnoreCase)

            trackName = Regex.Match(matchCollRow(1).Value, "<a href="".*?"">(?'trackName'.*?)<\/a>", RegexOptions.IgnoreCase).Groups("trackName").Value
            trackURL = Regex.Match(matchCollRow(1).Value, "<a href=""(?'trackURL'.*?)"">.*?<\/a>", RegexOptions.IgnoreCase).Groups("trackURL").Value

            ' split ARTIST cell into distinct entries
            matchCollCell = Regex.Matches(matchCollRow(2).Value, "<a href=""\/artists\/.*?"">(?'artistName'.*?)<\/a>", RegexOptions.IgnoreCase)
            For Each artist In matchCollCell
                trackArtist.Add(artist.groups("artistName").value)
            Next

            ' split GAME cell into distinct entries
            matchCollCell = Regex.Matches(matchCollRow(2).Value, "<a href=""\/games\/.*?"">(?'gameName'.*?)<\/a>", RegexOptions.IgnoreCase)
            For Each game In matchCollCell
                trackArtist.Add(game.groups("gameName").value)
            Next

            fileName = System.IO.Path.GetFileName(trackURL)

            track = New Track(trackURL)
            track.download(toDirectory & fileName)

            i += 1
        Next
    End Sub
End Class
