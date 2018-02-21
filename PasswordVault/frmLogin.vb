Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Xml
Imports System.IO

Public Class frmLogin

    Public usrPin As String = ""
    Public recordNewPin As Boolean = False
    Public closeForm As Boolean = False

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If recordNewPin = True Then
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings
            settings("PassKey").Value = usrPin
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("appSettings")
            recordNewPin = False
        End If
        If CheckPin(usrPin) Then
            usrPin = ""
            picGreenOff.Visible = False
            picGreenOn.Visible = True
            picRedOff.Visible = True
            picRedOn.Visible = False
            Me.Refresh()

            Dim waitTimer As New System.Timers.Timer
            waitTimer.AutoReset = True
            waitTimer.Interval = 2000
            AddHandler waitTimer.Elapsed, AddressOf waitTimer_Tick
            waitTimer.Start()

            Do
                If closeForm = True Then
                    waitTimer.Dispose()
                    frmPasswordVault.Show()
                    Me.Hide()
                    Exit Sub
                End If
            Loop

        Else
            picGreenOff.Visible = True
            picGreenOn.Visible = False
            picRedOff.Visible = False
            picRedOn.Visible = True
        End If
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True

        picLocked.Visible = True
        picGreenOff.Visible = True
        picGreenOn.Visible = False
        picRedOff.Visible = False
        picRedOn.Visible = True

        If ConfigurationSettings.AppSettings("FirstStartup") = "True" Then
            Dim dirPath As String = "C:\Users\" & Environment.UserName & ".JPRS\Documents\Password Vault"

            If My.Computer.FileSystem.DirectoryExists(dirPath) = False Then
                My.Computer.FileSystem.CreateDirectory(dirPath)
            End If

            If My.Computer.FileSystem.FileExists(Path.Combine(dirPath, "AcctManifest.xml")) = False Then
                CreateXml.Main(Path.Combine(dirPath, "AcctManifest.xml"))
            End If

            ConfigurationSettings.AppSettings("FirstStartup") = "False"
        End If

    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.DesktopLocation = frmPasswordVault.ParseDesktopLocationPointFromConfigFile

        Dim setPass As String = ConfigurationSettings.AppSettings("PassKey")

        If IsNothing(setPass) Then
            MsgBox("A critical error has been encountered. The config file is missing!", vbOKOnly + vbCritical, "Critical Error")
        End If

        If setPass = "" Then
            Dim msg
            msg = MsgBox("Thank you for using Password Vault! Please set your 4-digit login pin now. You can click each button or use your numpad.", vbOKCancel, "Set New Pin")
            If msg = vbCancel Then
                Application.Exit()
            Else
                recordNewPin = True
            End If
        End If
    End Sub

    Private Sub LoginForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            PinButton_Click(Nothing, Nothing, "btnPin" & Char.GetNumericValue(e.KeyChar))
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            OK_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub PinButton_Click(sender As Object, e As EventArgs, Optional keyDigit As String = "") Handles btnPin0.Click, btnPin1.Click, btnPin2.Click, btnPin3.Click,
        btnPin4.Click, btnPin5.Click, btnPin6.Click, btnPin7.Click, btnPin8.Click, btnPin9.Click

        If Len(usrPin) >= 4 Then
            Exit Sub
        End If

        Dim arg

        If IsNothing(sender) Then
            arg = keyDigit
        Else
            Dim btn As Button = CType(sender, Button)
            arg = btn.Name
        End If

        Select Case CInt(Replace(arg, "btnPin", ""))
            Case 0
                usrPin &= 0
            Case 1
                usrPin &= 1
            Case 2
                usrPin &= 2
            Case 3
                usrPin &= 3
            Case 4
                usrPin &= 4
            Case 5
                usrPin &= 5
            Case 6
                usrPin &= 6
            Case 7
                usrPin &= 7
            Case 8
                usrPin &= 8
            Case 9
                usrPin &= 9
        End Select
    End Sub

    Function CheckPin(userPin As String)
        Dim setPin As String = ConfigurationSettings.AppSettings("PassKey")
        If usrPin = setPin Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub waitTimer_Tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim timer As System.Timers.Timer = CType(sender, System.Timers.Timer)

        timer.Stop()
        closeForm = True

    End Sub

    Private Sub frmLogin_Move(sender As Object, e As EventArgs) Handles Me.Move
        Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim settings = configFile.AppSettings.Settings

        Dim currentDesktopLocation As Point = Me.DesktopLocation

        If settings("DesktopLocation").Value = "" Or settings("DesktopLocation").Value <> currentDesktopLocation.ToString Then
            settings("DesktopLocation").Value = currentDesktopLocation.ToString
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("appSettings")
        End If
    End Sub

End Class

Public Class CreateXml
    Public Shared Sub Main(filePath As String)
        Dim doc As XmlDocument = New XmlDocument

        Dim docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "")
        doc.AppendChild(docNode)

        Dim configNode = doc.CreateElement("configuration")
        doc.AppendChild(configNode)

        doc.Save(filePath)
    End Sub
End Class
