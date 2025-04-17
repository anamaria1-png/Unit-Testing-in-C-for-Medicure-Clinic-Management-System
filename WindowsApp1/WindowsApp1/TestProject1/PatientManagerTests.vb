Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class PatientManagerTests

    ' Cleanup before and after tests
    Private Shared filePath As String = "patients.txt"

    <TestInitialize()>
    Public Sub TestInitialize()
        ' Delete the file before each test to ensure clean tests
        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If
    End Sub

    <TestCleanup()>
    Public Sub TestCleanup()
        ' Clean up after each test
        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If
    End Sub

    ' Test case for successful registration
    <TestMethod()>
    Public Sub RegisterPatient_ShouldReturnTrue_WhenValidDataIsProvided()
        ' Arrange
        Dim patientManager As New PatientManager()
        Dim firstName As String = "John"
        Dim fatherName As String = "David"
        Dim gender As String = "Male"
        Dim email As String = "john.doe@example.com"
        Dim mobileNo As String = "1234567890"
        Dim dob As DateTime = New DateTime(1990, 1, 1)

        ' Act
        Dim result As Boolean = patientManager.RegisterPatient(firstName, fatherName, gender, email, mobileNo, dob)

        ' Assert
        Assert.IsTrue(result, "Patient registration should return true when valid data is provided.")
        Assert.IsTrue(File.Exists(filePath), "The patient data file should exist after registration.")
        Dim lines() As String = File.ReadAllLines(filePath)
        Assert.AreEqual(1, lines.Length, "The file should contain one line after the first registration.")
    End Sub

    ' Test case for multiple registrations
    <TestMethod()>
    Public Sub RegisterPatient_ShouldIncrementId_WhenMultipleRegistrationsHappen()
        ' Arrange
        Dim patientManager As New PatientManager()
        Dim firstName As String = "Jane"
        Dim fatherName As String = "James"
        Dim gender As String = "Female"
        Dim email As String = "jane.doe@example.com"
        Dim mobileNo As String = "0987654321"
        Dim dob As DateTime = New DateTime(1995, 5, 15)

        ' Act
        Dim result1 As Boolean = patientManager.RegisterPatient(firstName, fatherName, gender, email, mobileNo, dob)
        Dim result2 As Boolean = patientManager.RegisterPatient(firstName, fatherName, gender, email, mobileNo, dob)

        ' Assert
        Assert.IsTrue(result1, "First patient registration should be successful.")
        Assert.IsTrue(result2, "Second patient registration should be successful.")
        Dim lines() As String = File.ReadAllLines(filePath)
        Assert.AreEqual(2, lines.Length, "The file should contain two lines after two registrations.")

        Dim firstLine As String = lines(0)
        Dim secondLine As String = lines(1)

        ' Check if the IDs are incremented correctly
        Dim firstId As Integer = Integer.Parse(firstLine.Split(","c)(0))
        Dim secondId As Integer = Integer.Parse(secondLine.Split(","c)(0))
        Assert.AreEqual(firstId + 1, secondId, "The second patient ID should be one greater than the first patient ID.")
    End Sub


End Class
