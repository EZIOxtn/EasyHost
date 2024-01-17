Imports System.IO
Imports System.Threading
Imports AltoControls
Imports Guna.UI2.WinForms
Imports Newtonsoft.Json
Public Class Form1
    Inherits Form
    Public integ As Boolean = False
    Public integ2 As Boolean = False
    Dim targetText As String = "First Time Process "
    Dim currentIndex As Integer = 0
    Private ramCounter As PerformanceCounter
    Private systemCpuCounter As PerformanceCounter
    Private phpProcessName As String = "php"
    Private phpProcessId As Integer = -1
    Private phpCpuCounter As PerformanceCounter
    Private phpRamCounter As PerformanceCounter
    Public counterstat As Boolean = False
    Public process As New Process
    Public ngrokProcess As New Process
    Public dir As String
    Public row As Boolean = True
    Public svc As Boolean = False
    Private Const BlueThreshold As Integer = 20
    Private Const GreenThreshold As Integer = 40
    Private Const YellowThreshold As Integer = 60
    Private Const RedThreshold As Integer = 80
    Public initxt As String
    Public Sub checkphp()
        Dim folderPath As String = Application.StartupPath + "\resources\php"
        Dim filesToCheck As String() = {
            "deplister.exe",
            "dev",
            "ext",
            "extras",
            "glib-2.dll",
            "gmodule-2.dll",
            "icudt72.dll",
            "icuin72.dll",
            "icuio72.dll",
            "icuuc72.dll",
            "lib",
            "libcrypto-3-x64.dll",
            "libenchant2.dll",
            "libpq.dll",
            "libsasl.dll",
            "libsodium.dll",
            "libsqlite3.dll",
            "libssh2.dll",
            "libssl-3-x64.dll",
            "license.txt",
            "news.txt",
            "nghttp2.dll",
            "phar.phar.bat",
            "pharcommand.phar",
            "php-cgi.exe",
            "php-win.exe",
            "php.exe",
            "php.ini-development",
            "php.ini-production",
            "php.zip",
            "php8.dll",
            "php8embed.lib",
            "php8phpdbg.dll",
            "phpdbg.exe",
            "readme-redist-bins.txt",
            "README.md",
            "snapshot.txt"
        }
        If Directory.Exists(folderPath) Then
            For Each fileToCheck As String In filesToCheck
                Dim filePath As String = Path.Combine(folderPath, fileToCheck)
                If File.Exists(filePath) OrElse Directory.Exists(filePath) Then
                    integ2 = True
                Else
                    integ2 = False
                End If
            Next
        Else
            integ2 = False
        End If
    End Sub
    Public Sub phpcounter()
        Dim phpProcesses() As Process = Process.GetProcessesByName(phpProcessName)
        If phpProcesses.Length > 0 Then
            phpProcessId = phpProcesses(0).Id
        End If
        If phpProcessId <> -1 Then
            phpCpuCounter = New PerformanceCounter("Process", "% Processor Time", phpProcessName)
            phpRamCounter = New PerformanceCounter("Process", "Working Set", phpProcessName)
            counterstat = True
        Else
        End If
    End Sub
    Public Sub checkngrok()
        Dim folderPath As String = Application.StartupPath + "\resources\ngrok"
        Dim filesToCheck As String() = {"ngrok.exe", "ngrok.zip"}
        If Directory.Exists(folderPath) Then
            For Each fileToCheck As String In filesToCheck
                Dim filePath As String = Path.Combine(folderPath, fileToCheck)
                If File.Exists(filePath) OrElse Directory.Exists(filePath) Then
                    integ = True
                Else
                    integ = False
                End If
            Next
        Else
            integ = False
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim gunaScrollBar As New Guna2VScrollBar()
        TextBox1.ScrollBars = ScrollBars.Vertical
        Guna2DataGridView1.ScrollBars = ScrollBars.Vertical

        Try
            If Not File.Exists(Application.StartupPath + "\resources\tsweb.zip") Then
                Try
                    Directory.CreateDirectory("resources")
                Catch ex As Exception

                End Try

                ExtractResourceToFile("tsweb", Application.StartupPath + "\resources\tsweb.zip")
                Threading.Thread.Sleep(1000)
                ExtractZipFile(Application.StartupPath + "\resources\tsweb.zip", Application.StartupPath + "\resources")
            End If
        Catch ex As Exception
        End Try
        Dim extractPath As String = Application.StartupPath + "\resources\WebTest"
        ramCounter = New PerformanceCounter("Memory", "Available MBytes")
        systemCpuCounter = New PerformanceCounter("Processor", "% Processor Time", "_Total")
        CircularPB1.MaxValue = 100
        Me.DoubleBuffered = True
        If My.Settings.firstTM Then
            Try
                Directory.CreateDirectory("resources")
                Directory.CreateDirectory("resource\ngrok")
                Directory.CreateDirectory("resources\php")

            Catch ex As Exception

            End Try
            Me.ShowInTaskbar = False
            FirstTM.Show()

            My.Settings.firstTM = False
            My.Settings.Save()
            Me.Hide()
        End If
        checkngrok()
        checkphp()
        If Not integ And Not integ2 Then
            Try
                Try
                    If Directory.Exists("resources") Then
                        Directory.Delete("resources", True)
                        FirstTM.Show()
                    Else
                    End If
                Catch ex As Exception
                End Try

            Catch ex As Exception
                MsgBox("Error : " + ex.ToString(), MsgBoxStyle.Exclamation)
                Application.Exit()
            End Try
            Guna2HtmlLabel1.Hide()
        End If
        CircularPB1.Visible = True
        CircularPB2.Visible = True
        CircularPB3.Visible = True
        Label2.Visible = True
        Label1.Visible = True
        Label3.Visible = True
        Timer2.Start()
    End Sub
    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If currentIndex < targetText.Length Then
            Guna2HtmlLabel1.Text += targetText(currentIndex)
            currentIndex += 1
        Else
            Timer1.Stop()
            Await Task.Delay(3000)
            My.Settings.firstTM = False
            My.Settings.Save()
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim totalRam As Single = My.Computer.Info.TotalPhysicalMemory / (1024 * 1024)
        Dim systemCpuUsage As Single = systemCpuCounter.NextValue()
        Dim cpuUsagePercentage As Integer = CInt(systemCpuUsage)
        Dim availableRam As Single = ramCounter.NextValue()
        Dim ramUsagePercentage As Integer = CInt(((totalRam - availableRam) / totalRam) * 100)
        Label1.Text = $"RAM {totalRam}/{availableRam} MB"
        CircularPB1.Value = ramUsagePercentage
        CircularPB2.Value = cpuUsagePercentage
        If counterstat Then
            UpdateProgressBar(phpRamCounter, CircularPB3, Label2, "PHP RAM usage {0} MB")
        Else
            phpcounter()
        End If
        UpdateProgressBarColor(CircularPB1, BlueThreshold, GreenThreshold, YellowThreshold, RedThreshold)
        UpdateProgressBarColor(CircularPB2, BlueThreshold, GreenThreshold, YellowThreshold, RedThreshold)
        UpdateProgressBarColor(CircularPB3, BlueThreshold, GreenThreshold, YellowThreshold, RedThreshold)
    End Sub
    Private Sub UpdateProgressBarColor(progressBar As CircularPB, blueThreshold As Integer, greenThreshold As Integer, yellowThreshold As Integer, redThreshold As Integer)
        Dim value As Integer = CInt(progressBar.Value)
        If value < blueThreshold Then
            progressBar.ProgressColor = Color.Blue
            progressBar.ForeColor = Color.Blue
        ElseIf value < greenThreshold Then
            progressBar.ProgressColor = Color.Green
            progressBar.ForeColor = Color.Green
        ElseIf value < yellowThreshold Then
            progressBar.ProgressColor = Color.Yellow
            progressBar.ForeColor = Color.Yellow
        ElseIf value < redThreshold Then
            progressBar.ProgressColor = Color.Red
            progressBar.ForeColor = Color.Red
        Else
            progressBar.ProgressColor = Color.White
            progressBar.ForeColor = Color.White
        End If
    End Sub
    Private Sub UpdateProgressBar(counter As PerformanceCounter, progressBar As CircularPB, label As Label, labelTextFormat As String)
        Try
            Dim phpRamUsage As Single = counter.NextValue() / (1024 * 1024)
            Dim percentage As Integer = CInt((phpRamUsage / progressBar.MaxValue) * 100)
            progressBar.Value = percentage
            label.Text = String.Format(labelTextFormat, phpRamUsage)
        Catch ex As Exception
            label.Text = "No PHP Process"
            progressBar.Value = 0
        End Try
    End Sub
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Dim folderBrowserDialog As New FolderBrowserDialog()
        If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Guna2TextBox1.Text = folderBrowserDialog.SelectedPath
        End If
    End Sub
    Private Async Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        If My.Settings.ngrokex = "nullable" Then
            grok.Show()
        Else
            If svc = False Then
                If String.IsNullOrWhiteSpace(Guna2TextBox1.Text) Or Guna2TextBox1.Text = String.Empty Then
                    Guna2TextBox1.Text = Application.StartupPath + "\resources\tsweb"
                    Dim x As String = Guna2TextBox1.Text()
                    Dim htmlFilePath As String = Guna2TextBox1.Text + "\index.html"
                    Try
                        File.Create(Guna2TextBox1.Text + "\ip.json")
                        WritePhpCodeToFile(Guna2TextBox1.Text + "\ip.php")
                    Catch ex As Exception
                    End Try
                    If File.Exists(htmlFilePath) Then
                        Dim htmlContent As String = File.ReadAllText(htmlFilePath)
                        InjectJavaScriptIntoHTML(htmlContent)
                    Else
                        MessageBox.Show("index.html file not found.")
                        Exit Sub
                    End If
                    StartphpSERVER(x)
                    StartNgrokAsync()
                    Threading.Thread.Sleep(500)
                    Await DownloadWebsite("http://127.0.0.1:4040/api/tunnels", Application.StartupPath + "\resources\tunnels.json")
                    Threading.Thread.Sleep(1500)
                    Dim publicUrl As String = ParseJsonAndExtractPublicUrl(Application.StartupPath + "\resources\tunnels.json")
                    DisplayPublicUrlInTextBox(publicUrl)
                    If publicUrl = String.Empty Then
                        Guna2CustomCheckBox1.Checked = False
                        Exit Sub
                    End If
                    Timer3.Start()
                Else
                    Dim folderBrowserDialog As New FolderBrowserDialog()
                    If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                        Guna2TextBox1.Text = folderBrowserDialog.SelectedPath
                        Dim htmlFilePath As String = Guna2TextBox1.Text + "\index.html"
                        If File.Exists(htmlFilePath) Then
                            Dim htmlContent As String = File.ReadAllText(htmlFilePath)
                            InjectJavaScriptIntoHTML(htmlContent)
                        Else
                            MessageBox.Show("index.html file not found.")
                            Exit Sub
                        End If
                        Try
                            File.Create(Guna2TextBox1.Text + "\ip.json")
                            WritePhpCodeToFile(Guna2TextBox1.Text + "\ip.php")
                        Catch ex As Exception
                        End Try
                        Dim x As String = Guna2TextBox1.Text()

                        StartphpSERVER(x)
                        StartNgrokAsync()
                        Threading.Thread.Sleep(500)
                        Await DownloadWebsite("http://127.0.0.1:4040/api/tunnels", Application.StartupPath + "\resources\tunnels.json")
                        Threading.Thread.Sleep(1500)
                        Dim publicUrl As String = ParseJsonAndExtractPublicUrl(Application.StartupPath + "\resources\tunnels.json")
                        DisplayPublicUrlInTextBox(publicUrl)
                        If publicUrl = String.Empty Then
                            Guna2CustomCheckBox1.Checked = False
                            Guna2GradientButton3.FillColor = Color.DarkBlue
                            Guna2GradientButton3.Text = "Restart the server"
                            Exit Sub
                        End If
                        Timer3.Start()
                    Else
                        Exit Sub

                    End If
                    End If
                Guna2GradientButton3.FillColor = Color.DarkRed
                Guna2GradientButton3.Text = "Close the server"
                svc = True
            Else
                Try
                    Dim psi As ProcessStartInfo = New ProcessStartInfo
                    psi.WindowStyle = ProcessWindowStyle.Hidden
                    psi.Arguments = "/im " & "php.exe" & " /f"
                    psi.FileName = "taskkill"
                    Dim p As Process = New Process()
                    p.StartInfo = psi
                    p.Start()
                    p.Close()
                    Dim psi0 As ProcessStartInfo = New ProcessStartInfo
                    psi0.WindowStyle = ProcessWindowStyle.Hidden
                    psi0.Arguments = "/im " & "ngrok.exe" & " /f"
                    psi0.FileName = "taskkill"
                    Dim p0 As Process = New Process()
                    p0.StartInfo = psi0
                    p0.Start()
                    p0.Close()
                Catch ex As Exception
                    MsgBox("ERROR_HDL_CLOSING : TaskKill ngrok and php error")
                End Try
                Guna2GradientButton3.FillColor = Color.FromArgb(0, 192, 0)
                Guna2GradientButton3.Text = "Start the server"
                Guna2CustomCheckBox2.Checked = False
                Guna2CustomCheckBox1.Checked = False
                svc = False
                Timer3.Stop()
                TextBox1.Clear()

            End If
        End If
    End Sub
    Private Sub LoadAndPopulateDataGridView(jsonFilePath As String)
        Dim json As String = File.ReadAllText(jsonFilePath)
        Dim ipList As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)
        Dim dt As New DataTable()
        dt.Columns.Add("IP Address", GetType(String))
        For Each ip As String In ipList
            If Not IPExistsInDataTable(dt, ip) Then
                dt.Rows.Add(ip)
            End If
        Next
        Guna2DataGridView1.DataSource = dt
        Label8.Text = "LAST_CONNECT " + (Guna2DataGridView1.Rows.Count - 1).ToString()
    End Sub
    Private Sub AppendTextToTextBox(text As String)
        If Not String.IsNullOrEmpty(text) Then
            TextBox1.Invoke(Sub() TextBox1.AppendText(text & Environment.NewLine))
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        grok.Show()
    End Sub
    Public Async Sub StartphpSERVER(webFolderPath As String)
        Dim phpExePath As String = Application.StartupPath + "\resources\php\php.exe"
        Dim serverOptions As String = "-S localhost:8000 -t ."
        ChDir(webFolderPath)
        Dim processInfo As New ProcessStartInfo(phpExePath, serverOptions)
        processInfo.CreateNoWindow = True
        processInfo.RedirectStandardOutput = True
        processInfo.RedirectStandardError = True
        processInfo.UseShellExecute = False
        processInfo.WindowStyle = ProcessWindowStyle.Hidden
        Dim process As New Process()
        process.StartInfo = processInfo
        AddHandler process.OutputDataReceived, Sub(sender, e) AppendTextToTextBox(e.Data)
        AddHandler process.ErrorDataReceived, Sub(sender, e) AppendTextToTextBox(e.Data)
        process.Start()
        Guna2CustomCheckBox2.Checked = True
        process.BeginOutputReadLine()
        process.BeginErrorReadLine()
        Await Task.Run(Sub() process.WaitForExit())
        process.Close()
    End Sub
    Public Async Sub StartNgrokAsync()
        Dim ngrokExePath As String = Application.StartupPath + "\resources\ngrok\ngrok.exe"
        Dim ngrokOptions As String = "http 8000"
        Dim ngrokProcessInfo As New ProcessStartInfo(ngrokExePath, ngrokOptions)
        ngrokProcessInfo.CreateNoWindow = True
        ngrokProcessInfo.RedirectStandardOutput = True
        ngrokProcessInfo.RedirectStandardError = True
        ngrokProcessInfo.UseShellExecute = False
        ngrokProcessInfo.WindowStyle = ProcessWindowStyle.Hidden
        Dim ngrokProcess As New Process()
        ngrokProcess.StartInfo = ngrokProcessInfo
        AddHandler ngrokProcess.OutputDataReceived, Sub(sender, e) GrokErrorHandler(e.Data)
        AddHandler ngrokProcess.ErrorDataReceived, Sub(sender, e) GrokErrorHandler(e.Data)
        ngrokProcess.Start()
        Guna2CustomCheckBox1.Checked = True
        Await Task.Run(Sub() ngrokProcess.WaitForExit())
    End Sub
    Sub DisplayPublicUrlInTextBox(publicUrl As String)
        If Not String.IsNullOrEmpty(publicUrl) Then
            Guna2TextBox2.Text = publicUrl
            initxt = publicUrl
            If Guna2CheckBox1.Checked Then
                Process.Start(publicUrl)
            End If

        Else
            Guna2TextBox2.Text = "Error retrieving public_url"
            initxt = "Error retrieving public_url"
        End If
    End Sub
    Sub ApplicationExitHandler(sender As Object, e As EventArgs) Handles MyBase.Closing
        Try
            Dim psi As ProcessStartInfo = New ProcessStartInfo
            psi.Arguments = "/im " & "php.exe" & " /f"
            psi.FileName = "taskkill"
            Dim p As Process = New Process()
            p.StartInfo = psi
            p.Start()
            p.Close()
            Dim psi0 As ProcessStartInfo = New ProcessStartInfo
            psi0.Arguments = "/im " & "ngrok.exe" & " /f"
            psi0.FileName = "taskkill"
            Dim p0 As Process = New Process()
            p0.StartInfo = psi0
            p0.Start()
            p0.Close()
        Catch ex As Exception
            MsgBox("ERROR_HDL_CLOSING : TaskKill ngrok and php error")
        End Try
    End Sub
    Private Async Sub GrokErrorHandler(text As String)
        If Not String.IsNullOrEmpty(text) Then
            Await Task.Run(Sub()
                               If text.Contains("ERR_NGROK") Then
                                   Me.Invoke(Sub()
                                                 MsgBox("ERROR_NGROK_CONSOLE : invalid key or key timeout", MsgBoxStyle.Critical)
                                                 Application.Exit()
                                             End Sub)
                               End If
                           End Sub)
        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        FirstTM.Show()
        Me.Hide()
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            LoadAndPopulateDataGridView(Guna2TextBox1.Text + "\ip.json")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub InjectJavaScriptIntoHTML(htmlContent As String)
        Dim jsCode As String = "document.addEventListener(""DOMContentLoaded"", function () {" & vbCrLf &
                               "    // OZIRIS to get user's IP address" & vbCrLf &
                               "    function getUserIP(callback) {" & vbCrLf &
                               "        fetch(""https://api64.ipify.org?format=json"")" & vbCrLf &
                               "            .then(response => response.json())" & vbCrLf &
                               "            .then(data => callback(data.ip))" & vbCrLf &
                               "            .catch(error => console.error(""Error fetching IP:"", error));" & vbCrLf &
                               "    }" & vbCrLf &
                               vbCrLf &
                               "    // Function to send IP to PHP file" & vbCrLf &
                               "    function sendIPToPHP(ip) {" & vbCrLf &
                               "        fetch(""ip.php"", {" & vbCrLf &
                               "            method: ""POST""," & vbCrLf &
                               "            headers: {" & vbCrLf &
                               "                ""Content-Type"": ""application/x-www-form-urlencoded""," & vbCrLf &
                               "            }," & vbCrLf &
                               "            body: ""ip="" + ip," & vbCrLf &
                               "        })" & vbCrLf &
                               "            .then(response => response.text())" & vbCrLf &
                               "            .then(data => console.log(data))" & vbCrLf &
                               "            .catch(error => console.error(""Error sending IP to PHP:"", error));" & vbCrLf &
                               "}" & vbCrLf &
                               vbCrLf &
                               "// Get user's IP and send it to PHP file" & vbCrLf &
                               "getUserIP(function (ip) {" & vbCrLf &
                               "    sendIPToPHP(ip);" & vbCrLf &
                               "});" & vbCrLf &
                               "});"
        Dim injectPosition As Integer = htmlContent.IndexOf("</body>", StringComparison.OrdinalIgnoreCase)
        If injectPosition >= 0 Then
            If Not htmlContent.Contains("OZIRIS") Then
                Dim modifiedHtmlContent As String = htmlContent.Insert(injectPosition, "<script>" & vbCrLf & jsCode & vbCrLf & "</script>")
                File.WriteAllText(Guna2TextBox1.Text + "\index.html", modifiedHtmlContent)
            End If

        Else
            MessageBox.Show("Error injecting JavaScript. </body> not found in the HTML content.")
            Application.Exit()
        End If
    End Sub
    Private Sub WritePhpCodeToFile(phpFilePath As String)
        Dim phpCode As String = "<?php" & vbCrLf &
                               vbCrLf &
                               "function getIPs() {" & vbCrLf &
                               "    $json = file_get_contents('ip.json');" & vbCrLf &
                               "    $ips = json_decode($json, true);" & vbCrLf &
                               vbCrLf &
                               "    return is_array($ips) ? $ips : [];" & vbCrLf &
                               "}" & vbCrLf &
                               vbCrLf &
                               "function saveIPs($ips) {" & vbCrLf &
                               "    $json = json_encode($ips);" & vbCrLf &
                               "    file_put_contents('ip.json', $json);" & vbCrLf &
                               "}" & vbCrLf &
                               vbCrLf &
                               "$ip = isset($_POST['ip']) ? $_POST['ip'] : '';" & vbCrLf &
                               vbCrLf &
                               "if ($ip !== '') {" & vbCrLf &
                               "    $existingIPs = getIPs();" & vbCrLf &
                               vbCrLf &
                               "    if (!in_array($ip, $existingIPs)) {" & vbCrLf &
                               "        $existingIPs[] = $ip;" & vbCrLf &
                               "        saveIPs($existingIPs);" & vbCrLf &
                               "        echo 'IP added successfully.';" & vbCrLf &
                               "    } else {" & vbCrLf &
                               "        echo 'IP already exists.';" & vbCrLf &
                               "    }" & vbCrLf &
                               "} else {" & vbCrLf &
                               "    echo 'Invalid IP.';" & vbCrLf &
                               "}" & vbCrLf &
                               "?>"
        File.WriteAllText(phpFilePath, phpCode)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        grok.Show()
    End Sub

    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton2.Click
        Try
            Dim psi As ProcessStartInfo = New ProcessStartInfo
            psi.Arguments = "/im " & "php.exe" & " /f"
            psi.FileName = "taskkill"
            Dim p As Process = New Process()
            p.StartInfo = psi
            p.Start()
            p.Close()
            Dim psi0 As ProcessStartInfo = New ProcessStartInfo
            psi0.Arguments = "/im " & "ngrok.exe" & " /f"
            psi0.FileName = "taskkill"
            Dim p0 As Process = New Process()
            p0.StartInfo = psi0
            p0.Start()
            p0.Close()
        Catch ex As Exception
            MsgBox("ERROR_HDL_CLOSING : TaskKill ngrok and php error")
        End Try
        Application.Exit()
    End Sub

    Private Sub Guna2ImageButton3_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Dim isDragging As Boolean
    Dim clickPoint As Point
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2ShadowPanel2.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            clickPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2ShadowPanel2.MouseMove
        If isDragging Then
            Dim newLocation As New Point(Me.Left + e.X - clickPoint.X, Me.Top + e.Y - clickPoint.Y)
            Me.Location = newLocation
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2ShadowPanel2.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

    Private Sub Guna2ImageButton4_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton4.Click
        about.Show()
    End Sub
End Class