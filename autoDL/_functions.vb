Module _functions
    Public Sub addToLog(newMessage As String)
        Dim timestamp As String
        timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        frm_Main.txt_Log.AppendText(timestamp & vbTab & newMessage & vbCrLf)
    End Sub

    Public Function getInterpretedHTML(url As String) As String
        Dim retval As String = ""

        'Dim phantomjs As New Process()
        'With phantomjs
        '    .StartInfo.FileName = My.Application.Info.DirectoryPath + "\phantomjs.exe"
        '    .StartInfo.Arguments = "--webdriver 127.0.0.1:4711"
        '    .StartInfo.CreateNoWindow = True
        '    .StartInfo.UseShellExecute = True
        'End With
        'phantomjs.Start()

        'Dim site As Uri = New Uri("http://127.0.0.1:4711")

        ' get chromedriver.exe here: http://chromedriver.storage.googleapis.com/index.html
        Dim chrome As OpenQA.Selenium.IWebDriver = New OpenQA.Selenium.Chrome.ChromeDriver(My.Application.Info.DirectoryPath)
        chrome.Navigate().GoToUrl(url)
        retval = chrome.PageSource

        'phantomjs.Close()
        'phantomjs.Dispose()

        chrome.Close()
        chrome.Dispose()

        Return retval
    End Function
End Module
