Imports System.IO

Public Class UserManager
    ' Method to register a new user
    Public Function RegisterUser(FName As String, UName As String, Pass As String, Role As String, Gender As String, Email As String, MobileNo As String, Salary As String) As Boolean
        Try
            Dim filePath As String = "users.txt"
            Dim newId As Integer = 1

            ' Read the last ID from the file if it exists
            If IO.File.Exists(filePath) Then
                Dim lines() As String = IO.File.ReadAllLines(filePath)
                If lines.Length > 0 Then
                    Dim lastLine = lines.Last()
                    Dim parts = lastLine.Split(","c)
                    If parts.Length > 0 AndAlso Integer.TryParse(parts(0), newId) Then
                        newId += 1
                    End If
                End If
            End If

            ' Format: Id,Name,Username,Password,Role,Gender,Email,MobileNo,Salary
            Dim newUser = $"{newId},{FName},{UName},{Pass},{Role},{Gender},{Email},{MobileNo},{Salary}"
            IO.File.AppendAllText(filePath, newUser & Environment.NewLine)

            Return True
        Catch ex As Exception
            ' Log the error and return false
            Console.WriteLine("Error saving user: " & ex.Message)
            Return False
        End Try
    End Function

    ' Method to retrieve user data by ID from the file
    Public Function GetUserDataById(userId As Integer) As String()
        Try
            Dim filePath As String = "users.txt"
            If IO.File.Exists(filePath) Then
                Dim lines() As String = IO.File.ReadAllLines(filePath)
                For Each line In lines
                    Dim parts() As String = line.Split(","c)
                    If parts.Length >= 9 Then
                        Dim fileUserId As Integer
                        If Integer.TryParse(parts(0), fileUserId) AndAlso fileUserId = userId Then
                            Return parts ' Return the data for the user
                        End If
                    End If
                Next
            Else
                MessageBox.Show("User data file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

End Class
