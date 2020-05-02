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

        ' ToDo move this into background worker as it is quite time consuming

        ' get chromedriver.exe here: http://chromedriver.storage.googleapis.com/index.html
        Dim chromeS = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService(My.Application.Info.DirectoryPath)
        chromeS.HideCommandPromptWindow = True

        Dim chromeO = New OpenQA.Selenium.Chrome.ChromeOptions()
        chromeO.AddArgument("headless")
        'chromeO.BinaryLocation = My.Application.Info.DirectoryPath

        Dim chrome As OpenQA.Selenium.IWebDriver = New OpenQA.Selenium.Chrome.ChromeDriver(chromeS, chromeO)
        'Dim chrome As OpenQA.Selenium.IWebDriver = New OpenQA.Selenium.Chrome.ChromeDriver(My.Application.Info.DirectoryPath)

        chrome.Navigate().GoToUrl(url)
        retval = chrome.PageSource

        'phantomjs.Close()
        'phantomjs.Dispose()

        chrome.Close()
        chrome.Dispose()

        Return retval
    End Function

    Public Function tidyUp(INstring As String) As String
        Dim retval As String

        retval = INstring.Replace(":", "_")
        retval = retval.Replace("&quot;", "'") 'double quotes
        retval = retval.Replace("&#39;", "'") 'single quote
        retval = retval.Replace("&#8203;", "") 'zero-width space
        retval = retval.Replace("&amp;", "&")
        retval = retval.Replace("/", "_")
        retval = retval.Replace("?", "_")

        Return retval
    End Function
End Module
