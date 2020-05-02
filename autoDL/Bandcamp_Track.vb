Imports System.Text.RegularExpressions

Public Class Bandcamp_Track
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
        Me.download(toDirectory, 0)
    End Sub

    Public Sub download(toDirectory As String, trackNum As Integer)
        Dim track As Track
        Dim match As Match

        match = Regex.Match(Me.UrlData, """file"":\{""mp3-128"":""(?'trackUrl'http[s]?:\/\/.*?)""\}", RegexOptions.IgnoreCase)
        If match.Success Then
            track = New Track(match.Groups(1).Value)

            addToLog("found URL: " & track.url)

            ' extract metadata from site data
            track.artist = Regex.Match(Me.UrlData, "<span itemprop=""byArtist"">\s*?<a href="".*?"">(?'artist'.*?)<\/a>\s*?<\/span>", RegexOptions.IgnoreCase).Groups(1).Value
            track.album = Regex.Match(Me.UrlData, "<span class=""fromAlbum"" itemprop=""name"">\s*?(?'album'.*?)\s*?<\/span>", RegexOptions.IgnoreCase).Groups(1).Value
            track.title = Regex.Match(Me.UrlData, "<h2 class=""trackTitle"" itemprop=""name"">\s*(?'title'.*?)\s*?<\/h2>", RegexOptions.IgnoreCase).Groups(1).Value

            ' replace illegal characters in metadata
            track.artist = tidyUp(track.artist)
            track.album = tidyUp(track.album)
            track.title = tidyUp(track.title)

            addToLog(vbTab + "found ARTIST: " + track.artist)
            addToLog(vbTab + "found ALBUM: " + track.album)
            addToLog(vbTab + "found TITLE: " + track.title)
            addToLog(vbTab + "found URL: " + track.url)
            addToLog("downloading to " + toDirectory + "...")
            If (trackNum <> 0) Then
                track.download(toDirectory & track.artist & " - " & track.album & " - " & trackNum & " - " & track.title & ".mp3")
            Else
                track.download(toDirectory & track.artist & " - " & track.album & " - " & track.title & ".mp3")
            End If
            addToLog("finished download")
        End If
    End Sub

    ' Private Function tidyUp(INstring As String) As String
    '     Dim retval As String
    '
    '     retval = INstring.Replace(":", "_")
    '     retval = retval.Replace("&quot;", "'") 'double quotes
    '     retval = retval.Replace("&#39;", "'") 'single quote
    '     retval = retval.Replace("&#8203;", "") 'zero-width space
    '     retval = retval.Replace("&amp;", "&")
    '     retval = retval.Replace("/", "_")
    '     retval = retval.Replace("?", "_")
    '
    '     Return retval
    ' End Function

End Class
