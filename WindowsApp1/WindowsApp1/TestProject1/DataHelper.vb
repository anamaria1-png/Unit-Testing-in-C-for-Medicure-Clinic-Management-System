Imports System.Data

Public Class DataHelper
    Public Shared Function GetPatientById(patientId As String) As Boolean
        If IO.File.Exists("patients.txt") Then
            Dim lines() = IO.File.ReadAllLines("patients.txt")
            For Each line In lines
                Dim parts() = line.Split(","c)
                If parts.Length > 0 AndAlso parts(0).Trim() = patientId Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Public Shared Function GetDoctors() As List(Of String)
        Dim doctors As New List(Of String)
        If IO.File.Exists("users.txt") Then
            Dim lines() = IO.File.ReadAllLines("users.txt")
            For Each line In lines
                Dim parts() = line.Split(","c)
                If parts.Length > 4 AndAlso parts(4).Trim().ToLower() = "doctor" Then
                    doctors.Add(parts(1)) ' Name
                End If
            Next
        End If
        Return doctors
    End Function

    Public Shared Function GetDoctorIdByName(name As String) As Integer
        If IO.File.Exists("users.txt") Then
            Dim lines() = IO.File.ReadAllLines("users.txt")
            For Each line In lines
                Dim parts() = line.Split(","c)
                If parts.Length >= 2 AndAlso parts(1).Trim().ToLower() = name.Trim().ToLower() Then
                    Return CInt(parts(0)) ' Id
                End If
            Next
        End If
        Return -1
    End Function

    Public Shared Sub SaveAppointment(patientId As String, doctorId As Integer, appointmentInfo As String)
        Dim newAppointment As String = patientId & "," & doctorId & "," & appointmentInfo & ",Enrolled,1000"
        IO.File.AppendAllText("appointments.txt", newAppointment & Environment.NewLine)
    End Sub

    Public Shared Function GetAllPatients() As DataTable
        Dim patientTable As New DataTable()
        patientTable.Columns.Add("Id")
        patientTable.Columns.Add("Name")
        patientTable.Columns.Add("Age")
        patientTable.Columns.Add("Gender")
        patientTable.Columns.Add("Phone")
        patientTable.Columns.Add("Address")

        If IO.File.Exists("patients.txt") Then
            Dim lines = IO.File.ReadAllLines("patients.txt")
            For Each line In lines
                Dim fields() = line.Split(","c)
                If fields.Length >= 6 Then
                    patientTable.Rows.Add(fields(0), fields(1), fields(2), fields(3), fields(4), fields(5))
                End If
            Next
        End If

        Return patientTable
    End Function

    Public Shared Function GetAllAppointments() As DataTable
        Dim appointmentsTable As New DataTable()
        appointmentsTable.Columns.Add("AppointmentId")
        appointmentsTable.Columns.Add("PatientId")
        appointmentsTable.Columns.Add("EmployeeId")
        appointmentsTable.Columns.Add("DateTime")
        appointmentsTable.Columns.Add("Status")
        appointmentsTable.Columns.Add("Payment")

        If IO.File.Exists("appointments.txt") Then
            Dim lines = IO.File.ReadAllLines("appointments.txt")
            For Each line In lines
                Dim fields() = line.Split(","c)
                If fields.Length >= 6 Then
                    appointmentsTable.Rows.Add(fields(0), fields(1), fields(2), fields(3), fields(4), fields(5))
                End If
            Next
        End If

        Return appointmentsTable
    End Function

    Public Shared Function PatientExists(patientId As String) As Boolean
        If IO.File.Exists("patients.txt") Then
            Dim patients = IO.File.ReadAllLines("patients.txt")
            For Each line In patients
                If line.Trim().StartsWith(patientId & ",") Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Public Shared Function GetAppointmentsByPatientId(patientId As String) As DataTable
        Dim appointmentsTable As New DataTable()
        appointmentsTable.Columns.Add("DateTime")
        appointmentsTable.Columns.Add("Payment")

        If IO.File.Exists("appointments.txt") Then
            Dim lines = IO.File.ReadAllLines("appointments.txt")
            For Each line In lines
                Dim fields = line.Split(","c)
                ' Format: Id, PatientId, EmployeeId, DateTime, Status, Payment
                If fields.Length >= 6 AndAlso fields(1).Trim() = patientId Then
                    appointmentsTable.Rows.Add(fields(3).Trim(), fields(5).Trim())
                End If
            Next
        End If

        Return appointmentsTable
    End Function

    Public Shared Function PatientExist(patientId As String) As Boolean
        If IO.File.Exists("patients.txt") Then
            Return IO.File.ReadAllLines("patients.txt").Any(Function(line) line.Trim().StartsWith(patientId & ","))
        End If
        Return False
    End Function

    Public Shared Sub AppendReportLine(reportLine As String)
        IO.File.AppendAllText("reports.txt", reportLine & Environment.NewLine)
    End Sub



End Class
