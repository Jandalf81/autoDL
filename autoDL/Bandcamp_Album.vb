Imports System.Text.RegularExpressions

Public Class Bandcamp_Album
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
        ' iterate through all tracks, download them
        Dim matchColl As MatchCollection
        Dim row As String
        Dim tracknum As String

        Dim baseURL As String
        Dim trackURL As String

        Dim site As Site
        Dim bc_Track As Bandcamp_Track

        baseURL = Regex.Match(Me.Url, "(?'baseURL'http[s]{0,1}:\/\/.*?)\/.*", RegexOptions.IgnoreCase).Groups("baseURL").Value

        'matchColl = Regex.Matches(site.urlData, "<table class=""track_list track_table"" id=""track_table"">\s*?(?'row'<tr class=""track_row_view linked"".*?<\/tr>)\s*?<\/table>", RegexOptions.IgnoreCase)
        matchColl = Regex.Matches(Me.UrlData, "(?'row'<tr class=""track_row_view linked"" (.|\s)*?<\/tr>)", RegexOptions.IgnoreCase)

        For Each match As Match In matchColl
            row = match.Groups("row").Value

            ' extract track number from row
            tracknum = Regex.Match(row, "<tr class=""track_row_view linked"" rel=""tracknum=(?'tracknumber'[0-9]*)""\s*itemprop", RegexOptions.IgnoreCase).Groups("tracknumber").Value

            trackURL = Regex.Match(row, "<td class=""title-col"">\s*<div class=""title"">\s*<a href=""(?'trackURL'.*)"" itemprop=""url"">", RegexOptions.IgnoreCase).Groups("trackURL").Value

            'MsgBox(baseURL & trackURL, vbOKOnly)

            site = New Site(baseURL & trackURL)
            bc_Track = New Bandcamp_Track(site.url, site.urlData)
            bc_Track.download(toDirectory, tracknum)
        Next
    End Sub
End Class
