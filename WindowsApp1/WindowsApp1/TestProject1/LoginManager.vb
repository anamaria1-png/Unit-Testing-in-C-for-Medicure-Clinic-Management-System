Imports System.IO

Public Class LoginManager
    ' Method to handle the login logic
    Public Function Authenticate(username As String, password As String) As Boolean
        ' Read users.txt line by line
        Dim lines() As String = File.ReadAllLines("users.txt")

        For Each line As String In lines
            Dim parts() As String = line.Split(","c)
            ' Ensure there are enough parts and match the username and password
            If parts.Length >= 4 AndAlso parts(2) = username AndAlso parts(3) = password Then
                ' Login successful, return True
                Return True
            End If
        Next

        ' Login failed
        Return False
    End Function

    ' Method to get user details if login is successful
    Public Function GetUserDetails(username As String) As String()
        ' Read users.txt line by line
        Dim lines() As String = File.ReadAllLines("users.txt")

        For Each line As String In lines
            Dim parts() As String = line.Split(","c)
            ' Ensure there are enough parts and match the username
            If parts.Length >= 4 AndAlso parts(2) = username Then
                ' Return the user details
                Return parts
            End If
        Next

        ' If no match found, return nothing
        Return Nothing
    End Function
End Class
