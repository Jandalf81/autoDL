Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class frm_Main
    Public mySite As Site
    Public mySettings As New Settings()

#Region "GUI events"
    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        mySettings.Load()

        'txt_Settings_SaveIn.Text = mySettings.SaveInDirectory

        txt_Settings_SaveIn.Text = mySettings.SaveInDirectory
    End Sub

    Private Sub frm_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        mySettings.Save()
    End Sub
#End Region


#Region "GUI controls"
    Private Sub btn_Download_Click(sender As Object, e As EventArgs) Handles btn_Download.Click
        addToLog("detecting site for URL " & txt_PasteHere.Text)

        'web_Site.Navigate(txt_PasteHere.Text)
        'web_Site.Source = New Uri(txt_PasteHere.Text)

        mySite = New Site(txt_PasteHere.Text)

        ' recognize supported sites by url or content

        ' Bandcamp
        If (
                Regex.Match(mySite.url, "^http[s]{0,1}:\/\/.*bandcamp.com\/", RegexOptions.IgnoreCase).Success _
                Or
                Regex.Match(mySite.urlData, "<a id=""footer-logo"" href=""https:\/\/bandcamp\.com\?from=logo"" ><span class=""hiddenAccess"">Bandcamp<\/span><\/a>", RegexOptions.IgnoreCase).Success
            ) Then
            If (Regex.Match(mySite.url, "^http[s]{0,1}:\/\/.*\/album\/.*", RegexOptions.IgnoreCase).Success) Then
                addToLog("detected BandCamp Album site")
                Dim bc_Album As New Bandcamp_Album(mySite.url, mySite.urlData)
                bc_Album.download(mySettings.SaveInDirectory)
            End If

            If (Regex.Match(mySite.url, "^http[s]{0,1}:\/\/.*\/track\/.*", RegexOptions.IgnoreCase).Success) Then
                addToLog("detected BandCamp Track site")
                Dim bc_Track As New Bandcamp_Track(mySite.url, mySite.urlData)
                bc_Track.download(mySettings.SaveInDirectory)
            End If

            Exit Sub
        End If

        'vivo.sx
        If (Regex.Match(mySite.url, "^http[s]{0,1}:\/\/vivo\.sx\/", RegexOptions.IgnoreCase).Success) Then
            addToLog("detected Vivo.sx")

            Dim vivo As New Vivo_sx(mySite.url, mySite.urlData)
            vivo.download(mySettings.SaveInDirectory)

            Exit Sub
        End If

        addToLog("no supported site detected")
    End Sub

    Private Sub btn_Settings_SaveIn_Click(sender As Object, e As EventArgs) Handles btn_Settings_SaveIn.Click
        Dim fbd As New FolderBrowserDialog()

        With fbd
            .Description = "Set the destination directory"
            .RootFolder = System.Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
        End With

        If (fbd.ShowDialog() = DialogResult.OK) Then
            mySettings.SaveInDirectory = fbd.SelectedPath
            txt_Settings_SaveIn.Text = mySettings.SaveInDirectory
        End If
    End Sub

#End Region
End Class
