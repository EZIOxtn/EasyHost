Imports System.Runtime.InteropServices
Imports System.Threading
Imports NAudio.Wave
Imports System.Drawing
Imports System.Threading.Tasks
Public Class about
    Private originalLocation As Point
    Private waveStream As WaveStream
    Private wavePlayer As WaveOutEvent
    Dim random As New Random()

    Dim elapsedTime As Integer = 0
    Dim moveRight As Boolean = True
    Private displayTimer As Timer
    Dim stepSize As Integer = 1

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        Form1.ShowInTaskbar = False
        Form1.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
        Guna2ImageButton2.Enabled = False

        ' Dim audioFile As New WaveFileReader(My.Resources.btch)
        'waveStream = audioFile

        'wavePlayer = New WaveOutEvent()
        ' wavePlayer.Init(waveStream)


        ' wavePlayer.Play()



        originalLocation = Me.Location



        Dim duration As Integer = 5000

        Dim timer As New System.Windows.Forms.Timer()

        timer.Interval = 30

        timer.Start()

        Dim thread As New Thread(
            Sub()
                Dim startTime As DateTime = DateTime.Now


                While (DateTime.Now - startTime).TotalMilliseconds < duration
                    Me.Invoke(
                        Sub()

                            Me.Location = New Point(
                                originalLocation.X + random.Next(-10, 10),
                                originalLocation.Y + random.Next(-10, 10)
                            )
                        End Sub
                    )


                    Thread.Sleep(20)
                End While


                timer.Stop()
                Me.Invoke(
                    Sub()
                        Me.Location = originalLocation

                        Guna2ImageButton2.Enabled = True
                    End Sub
                )
            End Sub
        )


        thread.Start()

    End Sub
    ' Private Sub chkMute_CheckedChanged(sender As Object, e As EventArgs) Handles chkMute.CheckedChanged
    'If wavePlayer IsNot Nothing Then

    'If wavePlayer IsNot Nothing Then

    '    wavePlayer.Volume = If(chkMute.Checked, 0, 1)
    '

    '  chkMute.Image = If(chkMute.Checked, My.Resources.mute, My.Resources.audio)
    'End If
    'End If
    ' End Sub
    Private Sub Timer_Tick(sender As Object, e As EventArgs)

    End Sub


    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton2.Click
        Form1.ShowInTaskbar = True
        Form1.WindowState = FormWindowState.Normal
        ' wavePlayer?.Stop()
        ' wavePlayer?.Dispose()
        ' waveStream?.Dispose()
        Me.Close()
    End Sub
End Class