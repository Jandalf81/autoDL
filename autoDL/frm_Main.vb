Imports System.Text.RegularExpressions

Public Class frm_Main
    Dim site As Site

    Public Sub addToLog(newMessage As String)
        Dim timestamp As String
        timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        txt_Log.AppendText(timestamp & vbTab & newMessage & vbCrLf)
    End Sub

    Private Sub btn_Download_Click(sender As Object, e As EventArgs) Handles btn_Download.Click
        addToLog("detecting site for URL " & txt_PasteHere.Text)

        site = New Site(txt_PasteHere.Text)

        ' recognize supported sites by url or content
        If (
                Regex.Match(site.url, "^http[s]{0,1}:\/\/.*bandcamp.com\/", RegexOptions.IgnoreCase).Success _
                Or
                Regex.Match(site.urlData, "<a id=""footer-logo"" href=""https:\/\/bandcamp\.com\?from=logo"" ><span class=""hiddenAccess"">Bandcamp<\/span><\/a>", RegexOptions.IgnoreCase).Success
            ) Then
            addToLog("detected site ""www.bandcamp.com""")
            downloadFromBandcamp()
            Exit Sub
        End If

        addToLog("no supported site detected")
    End Sub


    Private Sub downloadFromBandcamp()
        If (Regex.Match(site.url, "^http[s]{0,1}:\/\/.*\/album\/.*", RegexOptions.IgnoreCase).Success) Then
            addToLog("detected BandCamp Album site")
        End If

        If (Regex.Match(site.url, "^http[s]{0,1}:\/\/.*\/track\/.*", RegexOptions.IgnoreCase).Success) Then
            addToLog("detected BandCamp Track site")
            downloadFromBandcamp_Track()
        End If
    End Sub

    Private Sub downloadFromBandcamp_Track()
        Dim track As Track
        Dim match As Match

        match = Regex.Match(site.urlData, """file"":\{""mp3-128"":""(?'trackUrl'http[s]?:\/\/.*?)""\}", RegexOptions.IgnoreCase)
        If match.Success Then
            track = New Track(match.Groups(1).Value)

            addToLog("found URL: " & track.url)

            ' extract metadata from site data
            track.artist = Regex.Match(site.urlData, "<span itemprop=""byArtist"">\s*?<a href="".*?"">(?'artist'.*?)<\/a>\s*?<\/span>", RegexOptions.IgnoreCase).Groups(1).Value
            track.album = Regex.Match(site.urlData, "<span class=""fromAlbum"" itemprop=""name"">\s*?(?'album'.*?)\s*?<\/span>", RegexOptions.IgnoreCase).Groups(1).Value
            track.title = Regex.Match(site.urlData, "<h2 class=""trackTitle"" itemprop=""name"">\s*(?'title'.*?)\s*?<\/h2>", RegexOptions.IgnoreCase).Groups(1).Value

            addToLog("downloading to ...")
            track.download("C:\Users\Jan\Downloads\test.mp3")
            addToLog("finished download")
        End If
    End Sub

    Private Sub downloadFromBandcamp_Album()
        ' ToDo iterate through all tracks, download them
    End Sub
End Class
