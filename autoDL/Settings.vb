Public Class Settings
    Private _SaveInDirectory As String

    Public Property SaveInDirectory As String
        Get
            Return _SaveInDirectory
        End Get
        Set(value As String)
            _SaveInDirectory = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub Save()
        Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)
        Dim fileWriter As IO.StreamWriter

        fileWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath + "\settings.xml", False)
        x.Serialize(fileWriter, Me)
        fileWriter.Close()
    End Sub

    Public Sub Load()
        Dim ISettings As New Settings()
        Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)

        If (My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "\settings.xml")) Then
            Using fs As New IO.FileStream(My.Application.Info.DirectoryPath + "\settings.xml", IO.FileMode.Open)
                ISettings = x.Deserialize(fs)
            End Using
        End If

        Me.SaveInDirectory = ISettings.SaveInDirectory
    End Sub
End Class
