
Public Class Form4
    Dim id As Integer
    Dim Parole, PaName As String

    Dim FName, UName, Pass, Role, Email, gender, MobileNo, Salary As String

    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        Parole = Prole
        PaName = Pname
        ' This call is required by the designer.

        InitializeComponent()
        If Parole <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click
        Me.Close()
        Dim f As Form5 = New Form5(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Me.Close()
        Dim f As Form2 = New Form2(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub RegisterPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterPatientToolStripMenuItem.Click
        Me.Close()
        Dim f As Form3 = New Form3(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form7 = New Form7(id, Parole, PaName)
        f.Show()
    End Sub
    Private Sub AppointmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppointmentsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form8 = New Form8(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub ViewPatientHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPatientHistoryToolStripMenuItem.Click
        Me.Close()
        Dim f As Form9 = New Form9(id, Parole, PaName)
        f.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide error labels
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False

        ' Get input values
        FName = TextBox1.Text.Trim()
        UName = TextBox2.Text.Trim()
        Pass = TextBox5.Text.Trim()
        Role = ComboBox1.Text.Trim()
        Email = TextBox6.Text.Trim()
        MobileNo = TextBox4.Text.Trim()
        Salary = TextBox3.Text.Trim()

        ' Determine gender
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        Else
            gender = "Other"
        End If

        ' Show labels for missing fields
        If FName = "" Then Label11.Visible = True
        If UName = "" Then Label12.Visible = True
        If Pass = "" Then Label13.Visible = True
        If Role = "" Then Label14.Visible = True
        If Email = "" Then Label15.Visible = True
        If Salary = "" Then Label16.Visible = True
        If MobileNo = "" Then Label17.Visible = True

        ' If all fields are valid
        If FName <> "" And UName <> "" And Pass <> "" And Email <> "" And Role <> "" And Salary <> "" And MobileNo <> "" Then
            ' Create an instance of UserManager
            Dim userManager As New UserManager()

            ' Attempt to register the user
            If userManager.RegisterUser(FName, UName, Pass, Role, gender, Email, MobileNo, Salary) Then
                ' Show success message
                MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form fields
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox1.SelectedIndex = -1
                RadioButton1.Checked = False
                RadioButton2.Checked = False
            Else
                ' Show error message if registration failed
                MessageBox.Show("Error saving user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class