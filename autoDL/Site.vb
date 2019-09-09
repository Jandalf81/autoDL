Public Class Site
    Private _url As String
    Private _urlData As String

    Public Property url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
        End Set
    End Property
    Public Property urlData As String
        Get
            Return _urlData
        End Get
        Set(value As String)
            _urlData = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(INurl As String)
        url = INurl
        getUrlData(Me.url)
    End Sub

    Private Sub getUrlData(url As String)
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
        _urlData = retval
    End Sub
End Class
