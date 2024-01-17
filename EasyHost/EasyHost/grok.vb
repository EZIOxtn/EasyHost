Imports System.IO

Public Class grok
    Public ngrokstrg As String = "config add-authtoken "
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click

        Dim StatusDate As String

        StatusDate = TextBox1.Text()

        If StatusDate.IsNullOrEmpty(StatusDate.Trim()) Then
            ' Display an error message
            MessageBox.Show("You must enter a valid authtoken to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)









        Else
Error_Expected:
            Try
                Dim yamlContent As String = $"version: ""2""" & vbCrLf & $"authtoken: {StatusDate}"

                ' Specify the path to the ngrok directory in AppData
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
            My.Settings.Save()
        End If
        Me.Close()


    End Sub

    Private Sub Guna2GradientButton1_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class