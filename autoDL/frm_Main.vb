Imports System.Text.RegularExpressions

Public Class frm_Main
    Public Sub addToLog(newMessage As String)
        Dim timestamp As String
        timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        txt_Log.AppendText(timestamp & vbTab & newMessage & vbCrLf)
    End Sub

    Private Sub btn_Download_Click(sender As Object, e As EventArgs) Handles btn_Download.Click
        Dim url As String
        url = txt_PasteHere.Text

        ' recognize supported sites by url
        If (Regex.Match(url, "^http[s]{0,1}:\/\/.*bandcamp.com\/", RegexOptions.IgnoreCase).Success) Then
            addToLog("recognized BandCamp")
            Exit Sub
        End If


        ' recognize supported sites by urlData
        'TODO get urlData from url
        Dim urlData As String = getUrlData(url)
        addToLog(urlData)

        If (Regex.Match(urlData, "<a id=""footer-logo"" href=""https:\/\/bandcamp\.com\?from=logo"" ><span class=""hiddenAccess"">Bandcamp<\/span><\/a>", RegexOptions.IgnoreCase).Success) Then
            addToLog("recognized BandCamp")
            Exit Sub
        End If

        addToLog("no supported site recognized")
    End Sub

    Private Function getUrlData(url As String)
        Dim wc As Net.WebClient = New Net.WebClient()
        Dim retval As String = ""

        wc.Encoding = System.Text.Encoding.UTF8

        ' test security protocols
        Try
            retval = wc.DownloadString(url)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Ssl3
            retval = wc.DownloadString(url)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            retval = wc.DownloadString(url)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls11
            retval = wc.DownloadString(url)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            retval = wc.DownloadString(url)

            GoTo finish
        Catch ex As Exception

        End Try

finish:
        'retval = Regex.Replace(retval, "\r\n|\r|\n", "")
        Return retval
    End Function
End Class
