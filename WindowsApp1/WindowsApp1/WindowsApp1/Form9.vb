Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Reflection.Emit
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class Form9
    Dim conn As OleDbConnection
    Dim conn1 As OleDbConnection
    Dim adapter As OleDbDataAdapter
    Dim adapter1 As OleDbDataAdapter
    Dim dataset As DataSet
    Dim tables As DataTableCollection
    Dim dataset1 As DataSet
    Dim tables1 As DataTableCollection
    Dim source As New BindingSource
    Dim id As Integer
    Dim role, PaName As String
    Dim PatientID As Integer


    Dim cmd As OleDbCommand
    Dim cmd1 As OleDbCommand
    Dim reader As OleDbDataReader
    Dim reader1 As OleDbDataReader


    Public Sub New(Pid As Integer, Prole As String, Pname As String)
        id = Pid
        role = Prole
        PaName = Pname
        InitializeComponent()

        Label2.Visible = False
        DataGridView1.Visible = False

        If role <> "Admin" Then
            AppointmentsToolStripMenuItem.Visible = False
            RegisterPatientToolStripMenuItem.Visible = False
            PatientsToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
        End If
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

    Private Sub RegisterPatientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterPatientToolStripMenuItem.Click
        Me.Close()
        Dim f As Form3 = New Form3(id, role, PaName)
        f.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
        Dim f As Form4 = New Form4(id, role, PaName)
        f.Show()
    End Sub

    Private Sub RegisterEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterEmployeesToolStripMenuItem.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label6.Visible = False

        If TextBox1.Text = "" Then
            Label6.Text = "Patient Id not entered"
            Label6.Visible = True
            Exit Sub
        End If

        Dim inputPatientId As String = TextBox1.Text.Trim()

        If DataHelper.PatientExists(inputPatientId) Then
            PatientID = inputPatientId
            Label2.Visible = True
            DataGridView1.Visible = True
            TextBox1.Text = ""

            Dim appointmentsTable = DataHelper.GetAppointmentsByPatientId(PatientID)
            Dim source As New BindingSource()
            source.DataSource = appointmentsTable
            DataGridView1.DataSource = source
        Else
            Label6.Text = "Patient not Exist"
            Label6.Visible = True
        End If
    End Sub



    Private Sub ReportManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportManagementToolStripMenuItem.Click
        Me.Close()
        Dim f As Form10 = New Form10(id, role, PaName)
        f.Show()
    End Sub

    Private Sub ViewPatientHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPatientHistoryToolStripMenuItem.Click
        Me.Close()
        Dim f As Form9 = New Form9(id, role, PaName)
        f.Show()
    End Sub

    Private Sub BookAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookAppointmentToolStripMenuItem.Click
        Me.Close()
        Dim f As Form6 = New Form6(id, role, PaName)
        f.Show()
    End Sub
End Class