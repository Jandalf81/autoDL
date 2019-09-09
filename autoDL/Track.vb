Public Class Track
    Private _url As String

    Private _artist As String
    Private _album As String
    Private _title As String
    Private _tracknumber As Integer

    Public Property url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
        End Set
    End Property
    Public Property artist As String
        Get
            Return _artist
        End Get
        Set(value As String)
            _artist = value
        End Set
    End Property
    Public Property album As String
        Get
            Return _album
        End Get
        Set(value As String)
            _album = value
        End Set
    End Property
    Public Property title As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
        End Set
    End Property
    Public Property tracknumber As Integer
        Get
            Return _tracknumber
        End Get
        Set(value As Integer)
            _tracknumber = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(INurl As String)
        _url = INurl
    End Sub

    Public Sub download(toFile As String)
        Dim wc As Net.WebClient = New Net.WebClient()
        wc.Encoding = System.Text.Encoding.UTF8

        wc.DownloadFile(Me._url, toFile)
    End Sub
End Class
