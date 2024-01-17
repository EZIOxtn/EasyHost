Imports System.Net
Imports System.IO
Imports System.Threading.Tasks
Imports Ionic.Zip

Public Class FirstTM

    Private WithEvents webClient As New WebClient()
    Private WithEvents taskTimer As New Timer()
    Public progressInMB As Double = 0
    Public progressPercentage As Integer = 1
    Public tb As Double
    Public bt As Double
    Private Async Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

        Catch ex As Exception

        End Try
        Dim url As String = "https://phpdev.toolsforresearch.com/php-8.3.1-nts-Win32-vs16-x64.zip"
        Dim grokurl As String = "https://bin.equinox.io/c/bNyj1mQVY4c/ngrok-v3-stable-windows-amd64.zip"
        Form1.WindowState = FormWindowState.Minimized
        Form1.ShowInTaskbar = False
        Try
            Directory.Delete("resources", True)
        Catch ex As Exception

        End Try
        Try
            Directory.CreateDirectory("resources")
            Directory.CreateDirectory("resource\ngrok")
            Directory.CreateDirectory("resources\php")

        Catch ex As Exception

        End Try

        Try
            taskTimer.Interval = 200


            taskTimer.Start()
            Guna2HtmlLabel3.Text = "php.zip"
            Await DownloadFileAsync(New Uri(url), "php_res.zip")
            Guna2HtmlLabel3.Text = "ngrok.zip"
            Guna2ProgressBar1.Value = 0
            progressInMB = 0

            Await DownloadFileAsync(New Uri(grokurl), "ngrok.zip")
            Guna2HtmlLabel3.Text = "extracting"
            Guna2ProgressBar1.Value = 0

            Dim zipFile As New ZipFile(Application.StartupPath + "\ngrok.zip")
            AddHandler zipFile.ExtractProgress, AddressOf ZipFile_ExtractProgress
            Await Task.Run(Sub()
                               zipFile.ExtractAll(Application.StartupPath + "\resources\ngrok")
                           End Sub)


            zipFile.Dispose()

            Guna2ProgressBar1.Value = 0
            Dim zipFile2 As New ZipFile(Application.StartupPath + "\php_res.zip")
            AddHandler zipFile2.ExtractProgress, AddressOf ZipFile_ExtractProgress
            Await Task.Run(Sub()
                               zipFile2.ExtractAll(Application.StartupPath + "\resources\php")
                           End Sub)



            zipFile2.Dispose()
        Catch ex As Exception
            MsgBox("INTERNET_CONNECTION_ERROR", MsgBoxStyle.Critical)
            Application.Restart()
        End Try
        Form1.WindowState = FormWindowState.Normal
        Form1.ShowInTaskbar = True
        My.Settings.firstTM = False
        My.Settings.Save()


        Me.Close()


    End Sub
    Private Async Function DownloadFileAsync(uri As Uri, fileName As String) As Task
        AddHandler webClient.DownloadProgressChanged, AddressOf DownloadProgressChanged

        Try
            Await webClient.DownloadFileTaskAsync(uri, fileName)
        Finally
            RemoveHandler webClient.DownloadProgressChanged, AddressOf DownloadProgressChanged
        End Try
    End Function
    Private Sub DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)

        progressInMB = e.BytesReceived / 1024 / 1024
        Dim speed As Double = e.BytesReceived / (e.ProgressPercentage * 1024)
        tb = e.TotalBytesToReceive \ 1024 \ 1024







        Guna2HtmlLabel2.Text = progressInMB.ToString("0.00") & " MB / " & (e.TotalBytesToReceive \ 1024 \ 1024).ToString("0.00") & " MB" + $" {speed.ToString("F2")} KB/s"
    End Sub
    Private Sub taskTimer_Tick(sender As Object, e As EventArgs) Handles taskTimer.Tick
        Try
            progressPercentage = CInt((progressInMB / tb) * 100)
        Catch ex As Exception

        End Try



        If progressPercentage <= 100 Then
            Guna2ProgressBar1.Value = progressPercentage
        Else
            Guna2ProgressBar1.Value = 100

        End If
    End Sub
    Private Sub ZipFile_ExtractProgress(sender As Object, e As ExtractProgressEventArgs)
        If e.TotalBytesToTransfer > 0 Then
            progressPercentage = CInt((e.BytesTransferred * 100) / e.TotalBytesToTransfer)

        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing


    End Sub
End Class