<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPasswordVault
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPasswordVault))
        Me.grpAccount = New System.Windows.Forms.GroupBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.comboAccts = New System.Windows.Forms.ComboBox()
        Me.btnNewAcctSave = New System.Windows.Forms.Button()
        Me.btnGenerateNewPass = New System.Windows.Forms.Button()
        Me.lblNewAcctPassword = New System.Windows.Forms.Label()
        Me.lblAcctName = New System.Windows.Forms.Label()
        Me.lblNewAcctUsername = New System.Windows.Forms.Label()
        Me.txtNewAcctPassword = New System.Windows.Forms.TextBox()
        Me.txtNewAcctName = New System.Windows.Forms.TextBox()
        Me.txtNewAcctUsername = New System.Windows.Forms.TextBox()
        Me.pnlAcctEditControls = New System.Windows.Forms.Panel()
        Me.picNewAcctClose = New System.Windows.Forms.PictureBox()
        Me.tmrLockout = New System.Windows.Forms.Timer(Me.components)
        Me.grpAccount.SuspendLayout()
        Me.pnlAcctEditControls.SuspendLayout()
        CType(Me.picNewAcctClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpAccount
        '
        Me.grpAccount.Controls.Add(Me.lblUsername)
        Me.grpAccount.Controls.Add(Me.lblPassword)
        Me.grpAccount.Controls.Add(Me.txtPassword)
        Me.grpAccount.Controls.Add(Me.txtUsername)
        Me.grpAccount.Location = New System.Drawing.Point(12, 74)
        Me.grpAccount.Name = "grpAccount"
        Me.grpAccount.Size = New System.Drawing.Size(320, 100)
        Me.grpAccount.TabIndex = 2
        Me.grpAccount.TabStop = False
        Me.grpAccount.Text = "Account"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(4, 16)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 3
        Me.lblUsername.Text = "Username"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(4, 58)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(7, 74)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(311, 20)
        Me.txtPassword.TabIndex = 1
        '
        'txtUsername
        '
        Me.txtUsername.Enabled = False
        Me.txtUsername.Location = New System.Drawing.Point(7, 35)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(311, 20)
        Me.txtUsername.TabIndex = 0
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(35, 39)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(87, 23)
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(128, 39)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(87, 23)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(221, 39)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'comboAccts
        '
        Me.comboAccts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAccts.FormattingEnabled = True
        Me.comboAccts.Location = New System.Drawing.Point(12, 12)
        Me.comboAccts.Name = "comboAccts"
        Me.comboAccts.Size = New System.Drawing.Size(320, 21)
        Me.comboAccts.TabIndex = 5
        '
        'btnNewAcctSave
        '
        Me.btnNewAcctSave.Location = New System.Drawing.Point(239, 180)
        Me.btnNewAcctSave.Name = "btnNewAcctSave"
        Me.btnNewAcctSave.Size = New System.Drawing.Size(75, 23)
        Me.btnNewAcctSave.TabIndex = 13
        Me.btnNewAcctSave.Text = "Save"
        Me.btnNewAcctSave.UseVisualStyleBackColor = True
        '
        'btnGenerateNewPass
        '
        Me.btnGenerateNewPass.Location = New System.Drawing.Point(7, 180)
        Me.btnGenerateNewPass.Name = "btnGenerateNewPass"
        Me.btnGenerateNewPass.Size = New System.Drawing.Size(144, 23)
        Me.btnGenerateNewPass.TabIndex = 12
        Me.btnGenerateNewPass.Text = "Generate a New Password"
        Me.btnGenerateNewPass.UseVisualStyleBackColor = True
        '
        'lblNewAcctPassword
        '
        Me.lblNewAcctPassword.AutoSize = True
        Me.lblNewAcctPassword.Location = New System.Drawing.Point(7, 117)
        Me.lblNewAcctPassword.Name = "lblNewAcctPassword"
        Me.lblNewAcctPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblNewAcctPassword.TabIndex = 11
        Me.lblNewAcctPassword.Text = "Password"
        '
        'lblAcctName
        '
        Me.lblAcctName.AutoSize = True
        Me.lblAcctName.Location = New System.Drawing.Point(4, 27)
        Me.lblAcctName.Name = "lblAcctName"
        Me.lblAcctName.Size = New System.Drawing.Size(78, 13)
        Me.lblAcctName.TabIndex = 9
        Me.lblAcctName.Text = "Account Name"
        '
        'lblNewAcctUsername
        '
        Me.lblNewAcctUsername.AutoSize = True
        Me.lblNewAcctUsername.Location = New System.Drawing.Point(4, 69)
        Me.lblNewAcctUsername.Name = "lblNewAcctUsername"
        Me.lblNewAcctUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblNewAcctUsername.TabIndex = 10
        Me.lblNewAcctUsername.Text = "Username"
        '
        'txtNewAcctPassword
        '
        Me.txtNewAcctPassword.Location = New System.Drawing.Point(7, 133)
        Me.txtNewAcctPassword.Name = "txtNewAcctPassword"
        Me.txtNewAcctPassword.Size = New System.Drawing.Size(307, 20)
        Me.txtNewAcctPassword.TabIndex = 8
        '
        'txtNewAcctName
        '
        Me.txtNewAcctName.Location = New System.Drawing.Point(7, 43)
        Me.txtNewAcctName.Name = "txtNewAcctName"
        Me.txtNewAcctName.Size = New System.Drawing.Size(307, 20)
        Me.txtNewAcctName.TabIndex = 6
        '
        'txtNewAcctUsername
        '
        Me.txtNewAcctUsername.Location = New System.Drawing.Point(7, 85)
        Me.txtNewAcctUsername.Name = "txtNewAcctUsername"
        Me.txtNewAcctUsername.Size = New System.Drawing.Size(307, 20)
        Me.txtNewAcctUsername.TabIndex = 7
        '
        'pnlAcctEditControls
        '
        Me.pnlAcctEditControls.Controls.Add(Me.picNewAcctClose)
        Me.pnlAcctEditControls.Controls.Add(Me.lblAcctName)
        Me.pnlAcctEditControls.Controls.Add(Me.btnNewAcctSave)
        Me.pnlAcctEditControls.Controls.Add(Me.txtNewAcctUsername)
        Me.pnlAcctEditControls.Controls.Add(Me.btnGenerateNewPass)
        Me.pnlAcctEditControls.Controls.Add(Me.txtNewAcctName)
        Me.pnlAcctEditControls.Controls.Add(Me.lblNewAcctPassword)
        Me.pnlAcctEditControls.Controls.Add(Me.txtNewAcctPassword)
        Me.pnlAcctEditControls.Controls.Add(Me.lblNewAcctUsername)
        Me.pnlAcctEditControls.Location = New System.Drawing.Point(12, 214)
        Me.pnlAcctEditControls.Name = "pnlAcctEditControls"
        Me.pnlAcctEditControls.Size = New System.Drawing.Size(320, 206)
        Me.pnlAcctEditControls.TabIndex = 14
        '
        'picNewAcctClose
        '
        Me.picNewAcctClose.Image = Global.PasswordVault.My.Resources.Resources.windows_x
        Me.picNewAcctClose.Location = New System.Drawing.Point(293, 13)
        Me.picNewAcctClose.Name = "picNewAcctClose"
        Me.picNewAcctClose.Size = New System.Drawing.Size(21, 14)
        Me.picNewAcctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNewAcctClose.TabIndex = 15
        Me.picNewAcctClose.TabStop = False
        '
        'tmrLockout
        '
        Me.tmrLockout.Interval = 600000
        '
        'frmPasswordVault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 197)
        Me.Controls.Add(Me.pnlAcctEditControls)
        Me.Controls.Add(Me.comboAccts)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.grpAccount)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPasswordVault"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Password Vault"
        Me.grpAccount.ResumeLayout(False)
        Me.grpAccount.PerformLayout()
        Me.pnlAcctEditControls.ResumeLayout(False)
        Me.pnlAcctEditControls.PerformLayout()
        CType(Me.picNewAcctClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpAccount As GroupBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnNew As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents comboAccts As ComboBox
    Friend WithEvents btnNewAcctSave As Button
    Friend WithEvents btnGenerateNewPass As Button
    Friend WithEvents lblNewAcctPassword As Label
    Friend WithEvents lblAcctName As Label
    Friend WithEvents lblNewAcctUsername As Label
    Friend WithEvents txtNewAcctPassword As TextBox
    Friend WithEvents txtNewAcctName As TextBox
    Friend WithEvents txtNewAcctUsername As TextBox
    Friend WithEvents pnlAcctEditControls As Panel
    Friend WithEvents picNewAcctClose As PictureBox
    Friend WithEvents tmrLockout As Timer
End Class
