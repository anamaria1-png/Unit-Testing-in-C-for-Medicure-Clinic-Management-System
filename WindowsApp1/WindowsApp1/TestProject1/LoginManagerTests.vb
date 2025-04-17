Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class LoginManagerTests

    Private Const TestFilePath As String = "users.txt"
    Private _loginManager As LoginManager

    <TestInitialize>
    Public Sub SetUp()
        ' Create a temporary test file
        If Not File.Exists(TestFilePath) Then
            ' Creating a mock users.txt file for testing
            File.WriteAllLines(TestFilePath, New String() {
                "1,John Doe,johndoe,pass123",
                "2,Jane Smith,janesmith,pass456",
                "3,Bob Johnson,bobjohnson,pass789"
            })
        End If

        ' Initialize the LoginManager with the test file path
        _loginManager = New LoginManager()
    End Sub

    <TestMethod>
    Public Sub Authenticate_ValidCredentials_ReturnsTrue()
        ' Arrange
        Dim username As String = "johndoe"
        Dim password As String = "pass123"

        ' Act
        Dim result As Boolean = _loginManager.Authenticate(username, password)

        ' Assert
        Assert.IsTrue(result)
    End Sub

    <TestMethod>
    Public Sub Authenticate_InvalidCredentials_ReturnsFalse()
        ' Arrange
        Dim username As String = "nonexistentuser"
        Dim password As String = "wrongpassword"

        ' Act
        Dim result As Boolean = _loginManager.Authenticate(username, password)

        ' Assert
        Assert.IsFalse(result)
    End Sub

    <TestMethod>
    Public Sub GetUserDetails_ValidUsername_ReturnsDetails()
        ' Arrange
        Dim username As String = "janesmith"

        ' Act
        Dim userDetails As String() = _loginManager.GetUserDetails(username)

        ' Assert
        Assert.IsNotNull(userDetails)
        Assert.AreEqual("2", userDetails(0)) ' ID
        Assert.AreEqual("Jane Smith", userDetails(1)) ' Name
        Assert.AreEqual("janesmith", userDetails(2)) ' Username
        Assert.AreEqual("pass456", userDetails(3)) ' Password
    End Sub

    <TestMethod>
    Public Sub GetUserDetails_InvalidUsername_ReturnsNothing()
        ' Arrange
        Dim username As String = "nonexistentuser"

        ' Act
        Dim userDetails As String() = _loginManager.GetUserDetails(username)

        ' Assert
        Assert.IsNull(userDetails)
    End Sub

    <TestCleanup>
    Public Sub TearDown()
        ' Clean up the test file after each test
        If File.Exists(TestFilePath) Then
            File.Delete(TestFilePath)
        End If
    End Sub
End Class
