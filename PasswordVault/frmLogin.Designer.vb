<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
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
    Friend WithEvents picLocked As System.Windows.Forms.PictureBox
    Friend WithEvents OK As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.OK = New System.Windows.Forms.Button()
        Me.btnPin1 = New System.Windows.Forms.Button()
        Me.btnPin2 = New System.Windows.Forms.Button()
        Me.btnPin3 = New System.Windows.Forms.Button()
        Me.btnPin0 = New System.Windows.Forms.Button()
        Me.btnPin4 = New System.Windows.Forms.Button()
        Me.btnPin5 = New System.Windows.Forms.Button()
        Me.btnPin6 = New System.Windows.Forms.Button()
        Me.btnPin7 = New System.Windows.Forms.Button()
        Me.btnPin8 = New System.Windows.Forms.Button()
        Me.btnPin9 = New System.Windows.Forms.Button()
        Me.picRedOn = New System.Windows.Forms.PictureBox()
        Me.picLocked = New System.Windows.Forms.PictureBox()
        Me.picGreenOn = New System.Windows.Forms.PictureBox()
        Me.picRedOff = New System.Windows.Forms.PictureBox()
        Me.picGreenOff = New System.Windows.Forms.PictureBox()
        CType(Me.picRedOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLocked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGreenOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRedOff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGreenOff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(162, 157)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(87, 23)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&OK"
        '
        'btnPin1
        '
        Me.btnPin1.Location = New System.Drawing.Point(162, 24)
        Me.btnPin1.Name = "btnPin1"
        Me.btnPin1.Size = New System.Drawing.Size(25, 25)
        Me.btnPin1.TabIndex = 6
        Me.btnPin1.Text = "1"
        Me.btnPin1.UseVisualStyleBackColor = True
        '
        'btnPin2
        '
        Me.btnPin2.Location = New System.Drawing.Point(193, 24)
        Me.btnPin2.Name = "btnPin2"
        Me.btnPin2.Size = New System.Drawing.Size(25, 25)
        Me.btnPin2.TabIndex = 6
        Me.btnPin2.Text = "2"
        Me.btnPin2.UseVisualStyleBackColor = True
        '
        'btnPin3
        '
        Me.btnPin3.Location = New System.Drawing.Point(224, 24)
        Me.btnPin3.Name = "btnPin3"
        Me.btnPin3.Size = New System.Drawing.Size(25, 25)
        Me.btnPin3.TabIndex = 6
        Me.btnPin3.Text = "3"
        Me.btnPin3.UseVisualStyleBackColor = True
        '
        'btnPin0
        '
        Me.btnPin0.Location = New System.Drawing.Point(193, 117)
        Me.btnPin0.Name = "btnPin0"
        Me.btnPin0.Size = New System.Drawing.Size(25, 25)
        Me.btnPin0.TabIndex = 6
        Me.btnPin0.Text = "0"
        Me.btnPin0.UseVisualStyleBackColor = True
        '
        'btnPin4
        '
        Me.btnPin4.Location = New System.Drawing.Point(162, 55)
        Me.btnPin4.Name = "btnPin4"
        Me.btnPin4.Size = New System.Drawing.Size(25, 25)
        Me.btnPin4.TabIndex = 6
        Me.btnPin4.Text = "4"
        Me.btnPin4.UseVisualStyleBackColor = True
        '
        'btnPin5
        '
        Me.btnPin5.Location = New System.Drawing.Point(193, 55)
        Me.btnPin5.Name = "btnPin5"
        Me.btnPin5.Size = New System.Drawing.Size(25, 25)
        Me.btnPin5.TabIndex = 6
        Me.btnPin5.Text = "5"
        Me.btnPin5.UseVisualStyleBackColor = True
        '
        'btnPin6
        '
        Me.btnPin6.Location = New System.Drawing.Point(224, 55)
        Me.btnPin6.Name = "btnPin6"
        Me.btnPin6.Size = New System.Drawing.Size(25, 25)
        Me.btnPin6.TabIndex = 6
        Me.btnPin6.Text = "6"
        Me.btnPin6.UseVisualStyleBackColor = True
        '
        'btnPin7
        '
        Me.btnPin7.Location = New System.Drawing.Point(162, 86)
        Me.btnPin7.Name = "btnPin7"
        Me.btnPin7.Size = New System.Drawing.Size(25, 25)
        Me.btnPin7.TabIndex = 6
        Me.btnPin7.Text = "7"
        Me.btnPin7.UseVisualStyleBackColor = True
        '
        'btnPin8
        '
        Me.btnPin8.Location = New System.Drawing.Point(193, 86)
        Me.btnPin8.Name = "btnPin8"
        Me.btnPin8.Size = New System.Drawing.Size(25, 25)
        Me.btnPin8.TabIndex = 6
        Me.btnPin8.Text = "8"
        Me.btnPin8.UseVisualStyleBackColor = True
        '
        'btnPin9
        '
        Me.btnPin9.Location = New System.Drawing.Point(224, 86)
        Me.btnPin9.Name = "btnPin9"
        Me.btnPin9.Size = New System.Drawing.Size(25, 25)
        Me.btnPin9.TabIndex = 6
        Me.btnPin9.Text = "9"
        Me.btnPin9.UseVisualStyleBackColor = True
        '
        'picRedOn
        '
        Me.picRedOn.Image = Global.PasswordVault.My.Resources.Resources.red_indicator
        Me.picRedOn.Location = New System.Drawing.Point(43, 158)
        Me.picRedOn.Name = "picRedOn"
        Me.picRedOn.Size = New System.Drawing.Size(32, 32)
        Me.picRedOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picRedOn.TabIndex = 8
        Me.picRedOn.TabStop = False
        '
        'picLocked
        '
        Me.picLocked.Image = Global.PasswordVault.My.Resources.Resources.orange_lock_locked
        Me.picLocked.Location = New System.Drawing.Point(12, 24)
        Me.picLocked.Name = "picLocked"
        Me.picLocked.Size = New System.Drawing.Size(128, 128)
        Me.picLocked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLocked.TabIndex = 0
        Me.picLocked.TabStop = False
        '
        'picGreenOn
        '
        Me.picGreenOn.Image = Global.PasswordVault.My.Resources.Resources.green_indicator
        Me.picGreenOn.Location = New System.Drawing.Point(81, 158)
        Me.picGreenOn.Name = "picGreenOn"
        Me.picGreenOn.Size = New System.Drawing.Size(32, 32)
        Me.picGreenOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picGreenOn.TabIndex = 9
        Me.picGreenOn.TabStop = False
        '
        'picRedOff
        '
        Me.picRedOff.Image = Global.PasswordVault.My.Resources.Resources.grey_indicator
        Me.picRedOff.Location = New System.Drawing.Point(43, 158)
        Me.picRedOff.Name = "picRedOff"
        Me.picRedOff.Size = New System.Drawing.Size(32, 32)
        Me.picRedOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picRedOff.TabIndex = 10
        Me.picRedOff.TabStop = False
        '
        'picGreenOff
        '
        Me.picGreenOff.Image = Global.PasswordVault.My.Resources.Resources.grey_indicator
        Me.picGreenOff.Location = New System.Drawing.Point(81, 158)
        Me.picGreenOff.Name = "picGreenOff"
        Me.picGreenOff.Size = New System.Drawing.Size(32, 32)
        Me.picGreenOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picGreenOff.TabIndex = 10
        Me.picGreenOff.TabStop = False
        '
        'frmLogin
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 192)
        Me.Controls.Add(Me.picGreenOff)
        Me.Controls.Add(Me.picRedOff)
        Me.Controls.Add(Me.picGreenOn)
        Me.Controls.Add(Me.picRedOn)
        Me.Controls.Add(Me.btnPin0)
        Me.Controls.Add(Me.btnPin9)
        Me.Controls.Add(Me.btnPin6)
        Me.Controls.Add(Me.btnPin3)
        Me.Controls.Add(Me.btnPin8)
        Me.Controls.Add(Me.btnPin5)
        Me.Controls.Add(Me.btnPin2)
        Me.Controls.Add(Me.btnPin7)
        Me.Controls.Add(Me.btnPin4)
        Me.Controls.Add(Me.btnPin1)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.picLocked)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Password Vault"
        CType(Me.picRedOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLocked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGreenOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRedOff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGreenOff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPin1 As Button
    Friend WithEvents btnPin2 As Button
    Friend WithEvents btnPin3 As Button
    Friend WithEvents btnPin0 As Button
    Friend WithEvents btnPin4 As Button
    Friend WithEvents btnPin5 As Button
    Friend WithEvents btnPin6 As Button
    Friend WithEvents btnPin7 As Button
    Friend WithEvents btnPin8 As Button
    Friend WithEvents btnPin9 As Button
    Friend WithEvents picRedOn As PictureBox
    Friend WithEvents picGreenOn As PictureBox
    Friend WithEvents picRedOff As PictureBox
    Friend WithEvents picGreenOff As PictureBox
End Class
