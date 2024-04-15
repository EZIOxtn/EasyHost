Imports System.IO

Public Class grok
    Public ngrokstrg As String = "config add-authtoken "
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click

        Dim StatusDate As String

        StatusDate = TextBox1.Text()

        If StatusDate.IsNullOrEmpty(StatusDate.Trim()) Then

            MessageBox.Show("You must enter a valid authtoken to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)









        Else
Error_Expected:
            Try
                Dim yamlContent As String = $"version: ""2""" & vbCrLf & $"authtoken: {StatusDate}"

                Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                Dim lastdir As String = appDataPath.ToString() + "\ngrok"


                Try
                    If Not Directory.Exists(lastdir) Then
                        Directory.CreateDirectory(lastdir)
                    Else
                        Directory.Delete(lastdir, True)
                    End If

                Catch ex As Exception

                End Try

                Dim filePath As String = lastdir + "\ngrok.yml"


                File.WriteAllText(filePath, yamlContent)
            Catch ex As Exception
                GoTo Error_Expected
            End Try


            My.Settings.ngrokex = StatusDate

        End If

        My.Settings.Save()

    End Sub

    Private Sub Guna2GradientButton1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox2.CheckedChanged

        If Guna2CheckBox2.Checked Then My.Settings.ipinject = True And MsgBox("a file named [  ip.php ]  will be added to your project directory", MsgBoxStyle.Information) Else My.Settings.ipinject = False
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked Then My.Settings.serveouse = True Else My.Settings.serveouse = False
    End Sub

    Private Sub Guna2ShadowPanel1_Paint(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.ipinject Then Guna2CheckBox2.Checked = True Else Guna2CheckBox1.Checked = False
        If My.Settings.serveouse Then Guna2CheckBox1.Checked = True Else Guna2CheckBox1.Checked = False

    End Sub

    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton2.Click
        Close()
    End Sub
End Class