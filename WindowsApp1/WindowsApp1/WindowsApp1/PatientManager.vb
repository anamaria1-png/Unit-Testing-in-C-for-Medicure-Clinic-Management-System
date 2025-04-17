Imports System.IO

Public Class PatientManager
    ' Method to register a new patient
    Public Function RegisterPatient(FName As String, fathername As String, gender As String, email As String, mobileNo As String, dob As DateTime) As Boolean
        Try
            Dim filePath As String = "patients.txt"
            Dim newId As Integer = 1

            ' Read the last ID from the file if it exists
            If IO.File.Exists(filePath) Then
                Dim lines() As String = IO.File.ReadAllLines(filePath)
                If lines.Length > 0 Then
                    Dim lastLine As String = lines.Last()
                    Dim parts() As String = lastLine.Split(","c)
                    If parts.Length > 0 AndAlso Integer.TryParse(parts(0), newId) Then
                        newId += 1
                    End If
                End If
            End If

            ' Format: Id,Name,FatherName,Gender,Email,MobileNo,DOB
            Dim newLine As String = $"{newId},{FName},{fathername},{gender},{email},{mobileNo},{dob.ToShortDateString()}"
            IO.File.AppendAllText(filePath, newLine & Environment.NewLine)

            Return True
        Catch ex As Exception
            ' Log the error and return false
            Console.WriteLine("Error saving patient data: " & ex.Message)
            Return False
        End Try
    End Function
End Class
