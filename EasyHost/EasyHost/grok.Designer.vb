<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(grok))
        Me.Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.Guna2CheckBox2 = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.Guna2CheckBox1 = New Guna.UI2.WinForms.Guna2CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2NumericUpDown1 = New Guna.UI2.WinForms.Guna2NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2GradientButton1 = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Guna2ImageButton2 = New Guna.UI2.WinForms.Guna2ImageButton()
        Me.Guna2ShadowPanel1.SuspendLayout()
        CType(Me.Guna2NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2ShadowPanel1
        '
        Me.Guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2ImageButton2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2CheckBox2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2CheckBox1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label2)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2NumericUpDown1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Label1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.Guna2GradientButton1)
        Me.Guna2ShadowPanel1.Controls.Add(Me.TextBox1)
        Me.Guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2ShadowPanel1.FillColor = System.Drawing.Color.Black
        Me.Guna2ShadowPanel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Me.Guna2ShadowPanel1.Radius = 10
        Me.Guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Maroon
        Me.Guna2ShadowPanel1.ShadowShift = 20
        Me.Guna2ShadowPanel1.Size = New System.Drawing.Size(605, 312)
        Me.Guna2ShadowPanel1.TabIndex = 0
        '
        'Guna2CheckBox2
        '
        Me.Guna2CheckBox2.AutoSize = True
        Me.Guna2CheckBox2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CheckBox2.CheckedState.BorderRadius = 2
        Me.Guna2CheckBox2.CheckedState.BorderThickness = 0
        Me.Guna2CheckBox2.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CheckBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Guna2CheckBox2.Location = New System.Drawing.Point(83, 203)
        Me.Guna2CheckBox2.Name = "Guna2CheckBox2"
        Me.Guna2CheckBox2.Size = New System.Drawing.Size(436, 17)
        Me.Guna2CheckBox2.TabIndex = 10
        Me.Guna2CheckBox2.Text = "inject javascript and php to the ""Index.(html,php)"" to monitor users traffic [IP " &
    "LOGGING]"
        Me.Guna2CheckBox2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2CheckBox2.UncheckedState.BorderRadius = 2
        Me.Guna2CheckBox2.UncheckedState.BorderThickness = 0
        Me.Guna2CheckBox2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2CheckBox2.UseVisualStyleBackColor = True
        '
        'Guna2CheckBox1
        '
        Me.Guna2CheckBox1.AutoSize = True
        Me.Guna2CheckBox1.Checked = True
        Me.Guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CheckBox1.CheckedState.BorderRadius = 2
        Me.Guna2CheckBox1.CheckedState.BorderThickness = 0
        Me.Guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Guna2CheckBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Guna2CheckBox1.Location = New System.Drawing.Point(161, 180)
        Me.Guna2CheckBox1.Name = "Guna2CheckBox1"
        Me.Guna2CheckBox1.Size = New System.Drawing.Size(273, 17)
        Me.Guna2CheckBox1.TabIndex = 9
        Me.Guna2CheckBox1.Text = "use Serveo ssh instead of ngrok tunnel (without key)"
        Me.Guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2CheckBox1.UncheckedState.BorderRadius = 2
        Me.Guna2CheckBox1.UncheckedState.BorderThickness = 0
        Me.Guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(176, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "port to use "
        '
        'Guna2NumericUpDown1
        '
        Me.Guna2NumericUpDown1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2NumericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2NumericUpDown1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2NumericUpDown1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2NumericUpDown1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2NumericUpDown1.DisabledState.Parent = Me.Guna2NumericUpDown1
        Me.Guna2NumericUpDown1.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.Guna2NumericUpDown1.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Guna2NumericUpDown1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2NumericUpDown1.FocusedState.Parent = Me.Guna2NumericUpDown1
        Me.Guna2NumericUpDown1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2NumericUpDown1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.Guna2NumericUpDown1.Location = New System.Drawing.Point(278, 106)
        Me.Guna2NumericUpDown1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Guna2NumericUpDown1.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Guna2NumericUpDown1.Name = "Guna2NumericUpDown1"
        Me.Guna2NumericUpDown1.ShadowDecoration.Parent = Me.Guna2NumericUpDown1
        Me.Guna2NumericUpDown1.Size = New System.Drawing.Size(112, 31)
        Me.Guna2NumericUpDown1.TabIndex = 7
        Me.Guna2NumericUpDown1.Value = New Decimal(New Integer() {8080, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(33, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ngrok key"
        '
        'Guna2GradientButton1
        '
        Me.Guna2GradientButton1.Animated = True
        Me.Guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2GradientButton1.BorderRadius = 3
        Me.Guna2GradientButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.Guna2GradientButton1.BorderThickness = 1
        Me.Guna2GradientButton1.CheckedState.Parent = Me.Guna2GradientButton1
        Me.Guna2GradientButton1.CustomImages.Parent = Me.Guna2GradientButton1
        Me.Guna2GradientButton1.FillColor = System.Drawing.Color.Red
        Me.Guna2GradientButton1.FillColor2 = System.Drawing.Color.Black
        Me.Guna2GradientButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2GradientButton1.ForeColor = System.Drawing.Color.White
        Me.Guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.Black
        Me.Guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.Maroon
        Me.Guna2GradientButton1.HoverState.Parent = Me.Guna2GradientButton1
        Me.Guna2GradientButton1.Location = New System.Drawing.Point(154, 232)
        Me.Guna2GradientButton1.Name = "Guna2GradientButton1"
        Me.Guna2GradientButton1.ShadowDecoration.Parent = Me.Guna2GradientButton1
        Me.Guna2GradientButton1.Size = New System.Drawing.Size(292, 38)
        Me.Guna2GradientButton1.TabIndex = 5
        Me.Guna2GradientButton1.Text = "Save"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(111, 37)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(467, 28)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "1zmafVntdie1giscrLvZcnveYhj_7P4SdAun48XdFzmUUHTwB"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2ImageButton2
        '
        Me.Guna2ImageButton2.CheckedState.Parent = Me.Guna2ImageButton2
        Me.Guna2ImageButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2ImageButton2.HoverState.Parent = Me.Guna2ImageButton2
        Me.Guna2ImageButton2.Image = CType(resources.GetObject("Guna2ImageButton2.Image"), System.Drawing.Image)
        Me.Guna2ImageButton2.Location = New System.Drawing.Point(566, 8)
        Me.Guna2ImageButton2.Name = "Guna2ImageButton2"
        Me.Guna2ImageButton2.PressedState.Parent = Me.Guna2ImageButton2
        Me.Guna2ImageButton2.Size = New System.Drawing.Size(27, 23)
        Me.Guna2ImageButton2.TabIndex = 11
        '
        'grok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(605, 312)
        Me.Controls.Add(Me.Guna2ShadowPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "grok"
        Me.Text = "grok"
        Me.Guna2ShadowPanel1.ResumeLayout(False)
        Me.Guna2ShadowPanel1.PerformLayout()
        CType(Me.Guna2NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2GradientButton1 As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Guna2CheckBox1 As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2NumericUpDown1 As Guna.UI2.WinForms.Guna2NumericUpDown
    Friend WithEvents Guna2CheckBox2 As Guna.UI2.WinForms.Guna2CheckBox
    Friend WithEvents Guna2ImageButton2 As Guna.UI2.WinForms.Guna2ImageButton
End Class
