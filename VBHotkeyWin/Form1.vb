Public Class Form1

    Private ghk As VBHotkeys.GlobalHotkey

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ghk = New VBHotkeys.GlobalHotkey(VBHotkeys.Constants.ALT, Keys.O, Me)
        WriteLine("Trying to register ALT+O")
        If ghk.Register() Then
            WriteLine("Hotkey Registered")
        Else
            WriteLine("Hotkey failed to register!")
        End If
    End Sub

    Private Sub HandleHotkey()
        WriteLine("Hotkey pressed!")
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If (m.Msg = VBHotkeys.Constants.WM_HOTKEY_MSG_ID) Then
            HandleHotkey()
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not ghk.Unregister() Then
            MessageBox.Show("Hotkey failed to unregister!")
        End If
    End Sub

    Private Sub WriteLine(ByVal message As String)
        TextBox1.Text &= message & Environment.NewLine
    End Sub
End Class
