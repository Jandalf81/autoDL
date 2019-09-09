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

        ' recognize supported sites by url
        If (Regex.Match(site.url, "^http[s]{0,1}:\/\/.*bandcamp.com\/", RegexOptions.IgnoreCase).Success) Then
            addToLog("detected BandCamp by URL")
            Exit Sub
        End If


        ' recognize supported sites by urlData
        If (Regex.Match(site.urlData, "<a id=""footer-logo"" href=""https:\/\/bandcamp\.com\?from=logo"" ><span class=""hiddenAccess"">Bandcamp<\/span><\/a>", RegexOptions.IgnoreCase).Success) Then
            addToLog("detected BandCamp by content")
            Exit Sub
        End If

        addToLog("no supported site detected")
    End Sub


End Class
