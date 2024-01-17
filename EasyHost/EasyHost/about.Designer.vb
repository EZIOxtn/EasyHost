<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class about
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(about))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2ImageButton2 = New Guna.UI2.WinForms.Guna2ImageButton()
        Me.Guna2ImageButton4 = New Guna.UI2.WinForms.Guna2ImageButton()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.chkMute = New Guna.UI2.WinForms.Guna2ImageCheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(640, 367)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ezio_TN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(640, 387)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ezio_TN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(640, 406)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ezio_TN"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Guna2ImageButton2
        '
        Me.Guna2ImageButton2.BackColor = System.Drawing.Color.Black
        Me.Guna2ImageButton2.CheckedState.Parent = Me.Guna2ImageButton2
        Me.Guna2ImageButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2ImageButton2.HoverState.Parent = Me.Guna2ImageButton2
        Me.Guna2ImageButton2.Image = CType(resources.GetObject("Guna2ImageButton2.Image"), System.Drawing.Image)
        Me.Guna2ImageButton2.Location = New System.Drawing.Point(691, 3)
        Me.Guna2ImageButton2.Name = "Guna2ImageButton2"
        Me.Guna2ImageButton2.PressedState.Parent = Me.Guna2ImageButton2
        Me.Guna2ImageButton2.Size = New System.Drawing.Size(27, 23)
        Me.Guna2ImageButton2.TabIndex = 14
        '
        'Guna2ImageButton4
        '
        Me.Guna2ImageButton4.BackColor = System.Drawing.Color.Black
        Me.Guna2ImageButton4.CheckedState.Parent = Me.Guna2ImageButton4
        Me.Guna2ImageButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2ImageButton4.HoverState.Parent = Me.Guna2ImageButton4
        Me.Guna2ImageButton4.Image = CType(resources.GetObject("Guna2ImageButton4.Image"), System.Drawing.Image)
        Me.Guna2ImageButton4.Location = New System.Drawing.Point(-105, 150)
        Me.Guna2ImageButton4.Name = "Guna2ImageButton4"
        Me.Guna2ImageButton4.PressedState.Parent = Me.Guna2ImageButton4
        Me.Guna2ImageButton4.Size = New System.Drawing.Size(27, 23)
        Me.Guna2ImageButton4.TabIndex = 16
        '
        'Timer2
        '
        Me.Timer2.Interval = 10
        '
        'chkMute
        '
        Me.chkMute.BackColor = System.Drawing.Color.Black
        Me.chkMute.CheckedState.Parent = Me.chkMute
        Me.chkMute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkMute.HoverState.Parent = Me.chkMute
        Me.chkMute.Image = CType(resources.GetObject("chkMute.Image"), System.Drawing.Image)
        Me.chkMute.Location = New System.Drawing.Point(3, 3)
        Me.chkMute.Name = "chkMute"
        Me.chkMute.PressedState.Parent = Me.chkMute
        Me.chkMute.Size = New System.Drawing.Size(24, 23)
        Me.chkMute.TabIndex = 17
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(719, 431)
        Me.Controls.Add(Me.chkMute)
        Me.Controls.Add(Me.Guna2ImageButton2)
        Me.Controls.Add(Me.Guna2ImageButton4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "about"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "about"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2ImageButton2 As Guna.UI2.WinForms.Guna2ImageButton
    Friend WithEvents Guna2ImageButton4 As Guna.UI2.WinForms.Guna2ImageButton
    Friend WithEvents Timer2 As Timer
    Friend WithEvents chkMute As Guna.UI2.WinForms.Guna2ImageCheckBox
End Class
