Public Class File
    Private _url As String

    Public Property Url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
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

        'wc.DownloadFile(Me._url, toFile)
        Dim path As String = My.Computer.FileSystem.GetParentPath(toFile)

        If (My.Computer.FileSystem.DirectoryExists(path) = False) Then
            My.Computer.FileSystem.CreateDirectory(path)
        End If

        ' test security protocols
        Try
            wc.DownloadFile(Me._url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Ssl3
            wc.DownloadFile(Me._url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            wc.DownloadFile(Me._url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls11
            wc.DownloadFile(Me._url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

        Try
            Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            wc.DownloadFile(Me._url, toFile)

            GoTo finish
        Catch ex As Exception

        End Try

finish:
    End Sub
End Class
