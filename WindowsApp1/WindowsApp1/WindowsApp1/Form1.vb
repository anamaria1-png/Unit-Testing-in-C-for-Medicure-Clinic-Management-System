Public Class Form1
    Dim username As String
    Dim password As String

    Public Sub New()
        InitializeComponent()
        PictureBox2.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide error messages
        Label2.Visible = False
        Label5.Visible = False

        username = TextBox1.Text.Trim()
        password = TextBox2.Text.Trim()

        ' Check for empty fields
        If username = "" Then
            Label2.Text = "Username not entered"
            Label2.Visible = True
            Exit Sub
        End If

        If password = "" Then
            Label5.Text = "Password not entered"
            Label5.Visible = True
            Exit Sub
        End If

        ' Create an instance of LoginManager
        Dim loginManager As New LoginManager()

        ' Authenticate user
        If loginManager.Authenticate(username, password) Then
            ' Login successful
            ' Get user details (Id, Name, Role)
            Dim userDetails As String() = loginManager.GetUserDetails(username)

            ' Show the loading picture
            PictureBox2.Visible = True
            PictureBox2.Update()
            Threading.Thread.Sleep(3000)  ' Simulate loading time

            Me.Hide()

            ' Open Form2 with user details
            Dim f As New Form2(userDetails(0), userDetails(4), userDetails(1))
            f.Show()

            ' Reset input fields and hide the loading picture
            PictureBox2.Visible = False
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            ' Login failed
            MessageBox.Show("Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
