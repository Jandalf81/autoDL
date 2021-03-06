﻿Imports System.Text.RegularExpressions

Public Class Vivo_sx
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
        Dim name As String
        Dim url As String

        addToLog("getting interpreted HTML...")
        Me.UrlData = getInterpretedHTML(Me.Url)

        name = Regex.Match(Me.UrlData, "<h1 class=""vivo-video-data-holder"" data-hash="".*?"" data-type=""video"">\s*?Watch (?'videoName'.*?)&nbsp;", RegexOptions.IgnoreCase).Groups(1).Value
        ' TODO url is not in source!
        url = Regex.Match(Me.UrlData, "<source src=""(?'videoURL'.*?)"" type=""video\/mp4"" size=""\d{1,4}"">", RegexOptions.IgnoreCase).Groups(1).Value

        addToLog(vbTab + "found NAME: " + name)
        addToLog(vbTab + "found URL: " + url)
        addToLog("downloading to " + toDirectory + name + "...")

        Dim track As New Track()
        track.url = url
        track.download(toDirectory + "\" + name)

        addToLog("finished download")
    End Sub
End Class
