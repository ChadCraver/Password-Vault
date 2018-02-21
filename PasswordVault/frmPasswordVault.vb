Imports System.Configuration
Imports System.ComponentModel
Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography

Public Class frmPasswordVault

    Public editRec As Boolean = False
    Public newRec As Boolean = False

    Private Sub frmPasswordVault_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Height = 235

        Me.DesktopLocation = ParseDesktopLocationPointFromConfigFile()

        comboAccts.Items.Add("")
        refreshComboBox()

        Dim cntrl As Control
        For Each cntrl In pnlAcctEditControls.Controls
            cntrl.Enabled = False
            cntrl.Visible = False
        Next

        txtUsername.Enabled = True
        txtPassword.Enabled = True
        txtUsername.ReadOnly = True
        txtPassword.ReadOnly = True
        txtUsername.BackColor = Color.White
        txtPassword.BackColor = Color.White

    End Sub

    Private Sub frmPasswordVault_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Create timeout timer.
        tmrLockout.Start()
        Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        btnEdit.Enabled = False

        Me.DesktopLocation = ParseDesktopLocationPointFromConfigFile()
    End Sub

    Private Sub frmPasswordVault_Move(sender As Object, e As EventArgs) Handles Me.Move
        Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim settings = configFile.AppSettings.Settings

        Dim currentDesktopLocation As Point = Me.DesktopLocation

        If settings("DesktopLocation").Value = "" Or settings("DesktopLocation").Value <> currentDesktopLocation.ToString Then
            settings("DesktopLocation").Value = currentDesktopLocation.ToString
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection("appSettings")
        End If
    End Sub

    Private Sub frmPasswordVault_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmLogin.Close()
    End Sub

    Public Function ParseDesktopLocationPointFromConfigFile()
        Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim settings = configFile.AppSettings.Settings

        Dim arrPoints
        arrPoints = Replace(settings("DesktopLocation").Value, "{", "")
        arrPoints = Replace(arrPoints, "}", "")
        arrPoints = Replace(arrPoints, "X", "")
        arrPoints = Replace(arrPoints, "Y", "")
        arrPoints = Replace(arrPoints, "=", "").Split(",")

        Dim myPoint As Point = New Point(Int(arrPoints(0)), Int(arrPoints(1)))

        Return myPoint
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        newRec = True
        expandForm()

        txtNewAcctName.Text = "New Account"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        editRec = True

        Dim acctConfig = New XmlDocument
        acctConfig.Load("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")
        Dim s As XmlElement

        For Each s In acctConfig.SelectSingleNode("/configuration").ChildNodes
            If Not IsNothing(comboAccts.SelectedItem) Then
                If s.Name.ToString = Replace(comboAccts.SelectedItem.ToString, " ", "_") Then

                    Dim usrnm, psswrd, val() As String
                    val = Split(s.InnerText.ToString, ";")
                    usrnm = val(0)
                    psswrd = val(1)

                    txtNewAcctName.Text = s.Name.ToString
                    txtNewAcctUsername.Text = usrnm
                    txtNewAcctPassword.Text = psswrd

                    Exit For
                End If
            Else
                MsgBox("Unable to edit the record.", vbOKOnly + vbCritical, "Edit Error")
            End If
        Next

        expandForm()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim acctConfig = New XmlDocument
        Dim s As XmlElement
        acctConfig.Load("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")

        For Each s In acctConfig.SelectSingleNode("/configuration").ChildNodes
            If s.Name.ToString = Replace(comboAccts.SelectedItem.ToString, " ", "_") Then
                s.ParentNode.RemoveChild(s)
                comboAccts.Items.Remove(comboAccts.SelectedItem.ToString)
                txtUsername.Text = ""
                txtPassword.Text = ""
                comboAccts.Refresh()
                Exit For
            End If
        Next

        acctConfig.Save("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")

        refreshComboBox()

        grpAccount.Text = "Account"
        comboAccts.SelectedIndex = 0

    End Sub

    Private Sub btnNewAcctSave_Click(sender As Object, e As EventArgs) Handles btnNewAcctSave.Click

        Dim strKeyName As String
        Dim strKeyValue As String

        If txtNewAcctName.Text <> "" And txtNewAcctUsername.Text <> "" And txtNewAcctPassword.Text <> "" Then
            strKeyName = txtNewAcctName.Text
            strKeyValue = txtNewAcctUsername.Text & ";" & txtNewAcctPassword.Text
        Else
            MsgBox("You must provide values for all fields to save a new record.", vbOKOnly + vbCritical, "Save Error")
            Exit Sub
        End If

        Dim acctConfig = New XmlDocument

        acctConfig.Load("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")
        Dim s As XmlElement
        If newRec Then
            Dim elem As XmlElement = acctConfig.CreateElement(Replace(strKeyName, " ", "_"))
            elem.InnerText = strKeyValue
            acctConfig.SelectSingleNode("/configuration").AppendChild(elem)
            newRec = False
        ElseIf editRec Then
            For Each s In acctConfig.SelectSingleNode("/configuration").ChildNodes
                ' Key name is unchanged.
                If s.Name.ToString = strKeyName Then
                    s.InnerText = strKeyValue
                    editRec = False
                    Exit For
                End If
            Next
            ' Key name is changed.
            If editRec Then
                For Each s In acctConfig.SelectSingleNode("/configuration").ChildNodes
                    ' Key name is unchanged.
                    If s.Name.ToString = Replace(comboAccts.SelectedItem.ToString, " ", "_") Then
                        ' Delete the current element.
                        s.ParentNode.RemoveChild(s)

                        ' Create a new element.
                        Dim elem As XmlElement
                        Try
                            elem = acctConfig.CreateElement(Replace(txtNewAcctName.Text, " ", "_"))
                            grpAccount.Text = Replace(txtNewAcctName.Text, "_", " ")
                        Catch ex As Exception
                            MsgBox("Illegal character in account name." & vbCrLf & vbCrLf & ex.Message, vbOKOnly + vbCritical, "Edit Error")
                            Exit Sub
                        End Try
                        elem.InnerText = strKeyValue
                        acctConfig.SelectSingleNode("/configuration").AppendChild(elem)

                        editRec = False
                        Exit For
                    End If
                Next
            End If
        End If

        acctConfig.Save("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")

        refreshComboBox()

        txtUsername.Text = ""
        txtPassword.Text = ""
        txtNewAcctName.Text = "New Account"
        txtNewAcctUsername.Text = ""
        txtNewAcctPassword.Text = ""

        unexpandForm()

    End Sub

    Private Sub picNewAcctClose_Click(sender As Object, e As EventArgs) Handles picNewAcctClose.Click

        txtNewAcctName.Text = ""
        txtNewAcctUsername.Text = ""
        txtNewAcctPassword.Text = ""
        unexpandForm()

    End Sub

    Private Sub tmrLockout_Tick(sender As Object, e As EventArgs) Handles tmrLockout.Tick
        Me.Hide()

        With frmLogin
            .picLocked.Visible = True
            .picGreenOff.Visible = True
            .picGreenOn.Visible = False
            .picRedOff.Visible = False
            .picRedOn.Visible = True
            .Show()
        End With
    End Sub

    Private Sub btnGenerateNewPass_Click(sender As Object, e As EventArgs) Handles btnGenerateNewPass.Click
        txtNewAcctPassword.Text = PasswordGenerator.GenerateRandomPassword
    End Sub

    Private Sub comboAccts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAccts.SelectedIndexChanged
        If IsNothing(comboAccts.SelectedItem) Then
            btnEdit.Enabled = False
        Else
            If comboAccts.SelectedItem.ToString = "" Then
                btnEdit.Enabled = False
                txtUsername.Enabled = False
                txtPassword.Enabled = False
                txtUsername.ReadOnly = True
                txtPassword.ReadOnly = True
                txtUsername.BackColor = Color.White
                txtPassword.BackColor = Color.White
                txtUsername.Text = ""
                txtPassword.Text = ""
                grpAccount.Text = "Account"
            Else
                btnEdit.Enabled = True
            End If
        End If

        Dim acctConfig = New XmlDocument
        Dim s As XmlElement

        acctConfig.Load("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")

        For Each s In acctConfig.SelectSingleNode("/configuration").ChildNodes
            If s.Name.ToString = Replace(comboAccts.SelectedItem.ToString, " ", "_") Then
                txtUsername.Enabled = True
                txtPassword.Enabled = True
                txtUsername.ReadOnly = True
                txtPassword.ReadOnly = True
                txtUsername.BackColor = Color.White
                txtPassword.BackColor = Color.White

                Dim usrnm, psswrd, val() As String
                val = Split(s.InnerText.ToString, ";")
                usrnm = val(0)
                psswrd = val(1)

                grpAccount.Text = Replace(s.Name, "_", " ")
                txtUsername.Text = usrnm
                txtPassword.Text = psswrd

                Exit For
            End If
        Next

    End Sub

    Private Sub expandForm()
        ' Form expansion animation.
        Dim unexpandedHeight As Integer = 235
        Dim expandedHeight As Integer = 470
        Dim currentHeight As Integer = Me.Height
        If currentHeight = unexpandedHeight Then
            Do Until currentHeight = expandedHeight
                Me.Height += 1
                currentHeight = Me.Height
            Loop

            Dim cntrl As Control
            For Each cntrl In pnlAcctEditControls.Controls
                cntrl.Enabled = True
                cntrl.Visible = True
            Next
        End If
    End Sub

    Private Sub unexpandForm()
        ' Form expansion animation.
        Dim unexpandedHeight As Integer = 235
        Dim expandedHeight As Integer = 470
        Dim currentHeight As Integer = Me.Height
        If currentHeight <> unexpandedHeight Then
            Dim cntrl As Control
            For Each cntrl In pnlAcctEditControls.Controls
                cntrl.Enabled = False
                cntrl.Visible = False
            Next

            Do Until currentHeight = unexpandedHeight
                Me.Height -= 1
                currentHeight = Me.Height
            Loop
        End If
    End Sub

    Private Sub refreshComboBox()

        comboAccts.Items.Clear()
        comboAccts.Items.Add("")

        Dim acctConfig = New XmlDocument
        acctConfig.Load("C:\Users\" & Environment.UserName & "\Documents\Password Vault\AcctManifest.xml")
        Dim s As XmlElement
        ' Add existing accounts.
        For Each s In acctConfig.SelectSingleNode("/configuration").ChildNodes
            If Not IsNothing(s) Then
                If s.Name.ToString <> "" Then
                    comboAccts.Items.Add(Replace(s.Name.ToString, "_", " "))
                End If
            End If
        Next
    End Sub

End Class

Public Class PasswordGenerator

    Public Shared Function GetRandomInt(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static rndNum As System.Random = New System.Random()
        Return rndNum.Next(Min, Max)
    End Function

    Public Shared Function GenerateRandomPassword()
        ' Allowed:
        '   - Capital Letters A-Z
        '   - Lower case a-z
        '   - Numbers 0-9
        '   - Dashes (-) and underscored (_)
        '   - Forward (/) and back (\) slashes
        '   - Parentheses ()
        '   - Exclamation point (!)
        '   - Min. length = 6
        '   - Max length = 16

        Dim passwordLength As Integer = GetRandomInt(6, 16)
        Dim password As String = ""

        For X = 1 To passwordLength
            password &= GenerateRandomCharacter()
        Next

        Return password

    End Function

    Private Shared Function GetRandomAlphaCharacter(Optional ByVal lowercase As Boolean = False)

        Dim int As Integer = GetRandomInt(1, 26)
        Dim chrCase As Integer = GetRandomInt(1, 2)
        Dim chr As String = Nothing

        Select Case int
            Case 1
                chr = "A"
            Case 2
                chr = "B"
            Case 3
                chr = "C"
            Case 4
                chr = "D"
            Case 5
                chr = "E"
            Case 6
                chr = "F"
            Case 7
                chr = "G"
            Case 8
                chr = "H"
            Case 9
                chr = "I"
            Case 10
                chr = "J"
            Case 11
                chr = "K"
            Case 12
                chr = "L"
            Case 13
                chr = "M"
            Case 14
                chr = "N"
            Case 15
                chr = "O"
            Case 16
                chr = "P"
            Case 17
                chr = "Q"
            Case 18
                chr = "R"
            Case 19
                chr = "S"
            Case 20
                chr = "T"
            Case 21
                chr = "U"
            Case 22
                chr = "V"
            Case 23
                chr = "W"
            Case 24
                chr = "X"
            Case 25
                chr = "Y"
            Case 26
                chr = "Z"
        End Select

        If (chrCase / 2) = 1 Or lowercase = True Then
            chr = LCase(chr)
            Return chr
        Else
            Return chr
        End If

    End Function

    Private Shared Function GenerateRandomCharacter() As String

        Dim typeIndicator As Integer = GetRandomInt(1, 5)

        Select Case typeIndicator
            Case 1 ' Number
                Return GetRandomInt(0, 9)
            Case 2 ' Special Character
                Return GetRandomSpecial()
            Case 3 ' Character
                Return GetRandomAlphaCharacter()
            Case 4 ' Lowercase Character
                Return GetRandomAlphaCharacter(True)
            Case 5 ' Character
                Return GetRandomAlphaCharacter()
        End Select

    End Function

    Private Shared Function GetRandomSpecial()

        Dim typeIndicator As Integer = GetRandomInt(1, 7)

        Select Case typeIndicator
            Case 1 ' Dash
                Return "-"
            Case 2 ' Back slash
                Return "\"
            Case 3 ' Forward slash
                Return "/"
            Case 4 ' Exclamation point
                Return "!"
            Case 5 ' Closed parenthesis
                Return ")"
            Case 6 ' Open parenthesis
                Return "("
            Case 7 'Underscore
                Return "_"
        End Select
    End Function

End Class

Public Class Encryption
    Public configPath As String = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.ToString
    Public strFileToEncrypt As String
    Public strFileToDecrypt As String
    Public strOutputEncrypt As String
    Public strOutputDecrypt As String
    Public fsInput As FileStream
    Public fsOutput As FileStream

    Private Function CreateKey(ByVal strPassword As String) As Byte()
        ' Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        ' Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        ' Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte


        ' Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        ' Declare what hash to use.
        Dim SHA512 As New SHA512Managed
        ' Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        ' Declare bytKey(31). It will hold 256 bits.
        Dim bytKey(31) As Byte

        ' Use For Next to put a specific size (256 bits) of byteResult into bytKey.
        ' The 0 to 31 will put the first 256 bits of 512 bits into bytKey.
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next

        ' Reutrn the key.
        Return bytKey
    End Function

    Private Function CreateIV(ByVal strPassword As String) As Byte()
        ' Intitialization vector.
        ' Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        ' Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        ' Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte


        ' Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        ' Declare what hash to use.
        Dim SHA512 As New SHA512Managed
        ' Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        ' Declare bytIV(15). It will hold 128 bits.
        Dim bytIV(15) As Byte

        ' Use For Next to put a specific size (128 bits) of bytResult into bytIV.
        ' The 0 to 30 for bytKey used the first 256 bits of the hashed password.
        ' The 32 to 47 will put the next 128 bits into bytIV.
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next

        ' Return the IV.
        Return bytIV
    End Function

    Private Enum CryptoAction
        ' Define the enumeration for CryptoAction.
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    Private Function EncryptOrDecryptFile(ByVal strInputFile As String,
                                     ByVal strOutputFile As String,
                                     ByVal bytKey() As Byte,
                                     ByVal bytIV() As Byte,
                                     ByVal Direction As CryptoAction)
        Try
            ' Setup file streams to handle input and output.
            fsInput = New FileStream(strInputFile, FileMode.Open, FileAccess.Read)
            fsOutput = New FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write)

            ' Ensure fsOutput is empty.
            fsOutput.SetLength(0)

            ' Declare variables for encrypt/decrypt process.
            Dim bytBuffer(4096) As Byte ' Holds a block of bytes for processing.
            Dim lngBytesProcessed As Long = 0 ' A running count of bytes processed.
            Dim lngFileLength As Long = fsInput.Length ' The input file's length.
            Dim intBytesInCurrentBlock As Integer ' Current bytes being processed.
            Dim csCryptoStream As CryptoStream

            ' Declare the CryptoServiceProvider.
            Dim cspRijndael As New RijndaelManaged

            ' Determine if encryption or decryption and setup CryptoStream.
            Select Case Direction
                Case CryptoAction.ActionEncrypt
                    csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
                Case CryptoAction.ActionDecrypt
                    csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write)
            End Select

            ' Use While to loop until all of the file is processed.
            While lngBytesProcessed < lngFileLength
                ' Read file with the input filestream.
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                ' Write output file with the cryptostream.
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                ' Update lngBytesProcessed
                lngBytesProcessed += CLng(intBytesInCurrentBlock)

            End While

            ' Close filestreams and cryptostream.
            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()
            Return True
        Catch ex As Exception
            fsInput.Close()
            fsOutput.Close()
            MsgBox(ex.Message, vbOKOnly + vbCritical, "Unhandled Error Encountered")
            Return False
        End Try
    End Function

    Private Function ChangeFileExt(ByVal Direction As CryptoAction)
        strFileToDecrypt = configPath
        Select Case Direction
            Case CryptoAction.ActionEncrypt

                Dim iPosition As Integer = 0
                Dim i As Integer = 0

                ' Get the position of the last "\" in the OpenFileDialog.FileName path.
                ' Returns -1 when the character your searching for is absent.
                ' IndexOf searches for left to right.
                While strFileToEncrypt.IndexOf("\"c, i) <> -1
                    iPosition = strFileToEncrypt.IndexOf("\"c, i)
                    i = iPosition + 1
                End While

                ' Assign strOutputFile to the position after the last "\" in the path.
                ' This position is the beginning of the file name.
                strOutputEncrypt = strFileToEncrypt.Substring(iPosition + 1)
                ' Assign S the entire path, ending at the last "\".
                Dim S As String = strFileToEncrypt.Substring(0, iPosition + 1)
                ' Replace the "." in the file extension with "_".
                strOutputEncrypt = strOutputEncrypt.Replace("."c, "_"c)
                Return S & strOutputEncrypt & ".encrypt"
            Case CryptoAction.ActionDecrypt
                Dim iPosition As Integer = 0
                Dim i As Integer = 0

                ' Get the position of the last "\" in the OpenFileDialog.FileName path.
                ' Returns -1 when the character your searching for is absent.
                ' IndexOf searches for left to right.
                While strFileToDecrypt.IndexOf("\"c, i) <> -1
                    iPosition = strFileToDecrypt.IndexOf("\"c, i)
                    i = iPosition + 1
                End While

                ' Assign strOutputFile to the position after the last "\" in the path.
                ' This position is the beginning of the file name.
                strOutputDecrypt = strFileToDecrypt.Substring(0, strFileToDecrypt.Length - 8)
                ' Assign S the entire path, ending at the last "\".
                Dim S As String = strFileToDecrypt.Substring(0, iPosition + 1)
                ' Replace the "_" in the file extension with ".".
                strOutputDecrypt = strOutputDecrypt.Substring((iPosition + 1))
                Return S & strOutputDecrypt.Replace("_"c, "."c)
        End Select
    End Function
End Class


