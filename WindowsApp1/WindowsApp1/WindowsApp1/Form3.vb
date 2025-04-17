Imports System.IO

Public Class Form3
    Dim id As Integer
    Dim role, PaName As String
    Dim FName, fathername, gender, email, mobileNo As String
    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        role = Prole
        PaName = Pname
        ' This call is required by the designer.
        InitializeComponent()
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        If role <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub RegisterEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterEmployeesToolStripMenuItem.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click
        Me.Close()
        Dim f As Form5 = New Form5(id, role, PaName)
        f.Show()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Me.Close()
        Dim f As Form2 = New Form2(id, role, PaName)
        f.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        Dim f As Form4 = New Form4(id, role, PaName)
        f.Show()
    End Sub

    Private Sub ReportManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportManagementToolStripMenuItem.Click
        Me.Close()
        Dim f As Form10 = New Form10(id, role, PaName)
        f.Show()
    End Sub

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, role, PaName)
        f.Show()
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form7 = New Form7(id, role, PaName)
        f.Show()
    End Sub

    Private Sub AppointmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppointmentsToolStripMenuItem.Click
        Me.Close()
        Dim f As Form8 = New Form8(id, role, PaName)
        f.Show()
    End Sub

    Private Sub ViewPatientHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPatientHistoryToolStripMenuItem.Click
        Me.Close()
        Dim f As Form9 = New Form9(id, role, PaName)
        f.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide error labels
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False

        ' Get input values
        FName = TextBox1.Text.Trim()
        fathername = TextBox2.Text.Trim()
        email = TextBox3.Text.Trim()
        mobileNo = TextBox4.Text.Trim()

        ' Determine gender
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        Else
            gender = "Other"
        End If

        ' Validate inputs
        If FName = "" Then Label9.Visible = True
        If fathername = "" Then Label10.Visible = True
        If mobileNo = "" Then Label11.Visible = True

        ' Proceed if all required fields are filled
        If FName <> "" And fathername <> "" And mobileNo <> "" Then
            ' Create an instance of PatientManager
            Dim patientManager As New PatientManager()

            ' Attempt to register the patient
            If patientManager.RegisterPatient(FName, fathername, gender, email, mobileNo, DateTimePicker1.Value) Then
                ' Show success message
                MessageBox.Show("Patient registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form fields
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                DateTimePicker1.Value = DateTime.Now
            Else
                ' Show error message if registration failed
                MessageBox.Show("Error saving patient data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class