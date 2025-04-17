Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO

<TestClass>
Public Class UserManagerTests
    Private testFilePath As String = "users.txt"

    <TestInitialize>
    Public Sub TestInit()
        ' Ensure the test file is clean before each test
        If File.Exists(testFilePath) Then
            File.Delete(testFilePath)
        End If
    End Sub

    <TestCleanup>
    Public Sub TestCleanup()
        ' Clean up after each test
        If File.Exists(testFilePath) Then
            File.Delete(testFilePath)
        End If
    End Sub

    <TestMethod>
    Public Sub RegisterUser_ShouldReturnTrue_WhenUserIsSavedSuccessfully()
        ' Arrange
        Dim um As New UserManager()
        Dim result As Boolean = um.RegisterUser("Ali", "ali123", "pass123", "Admin", "Male", "ali@example.com", "03001234567", "50000")

        ' Assert
        Assert.IsTrue(result, "User should be registered successfully.")
        Assert.IsTrue(File.Exists("users.txt"), "users.txt file should be created.")
    End Sub

    <TestMethod>
    Public Sub RegisterUser_ShouldReturnFalse_WhenFileCannotBeCreated()
        ' Arrange
        Dim um As New UserManager()
        Dim restrictedFile As String = "users.txt"

        ' Create read-only file
        File.WriteAllText(restrictedFile, "1,Existing,Data")
        File.SetAttributes(restrictedFile, FileAttributes.ReadOnly)

        ' Act
        Dim result As Boolean = um.RegisterUser("Test", "user", "123", "Admin", "Male", "email@test.com", "000000000", "1000")

        ' Cleanup attribute
        File.SetAttributes(restrictedFile, FileAttributes.Normal)

        ' Assert
        Assert.IsFalse(result, "User registration should return false if the file is read-only.")
    End Sub

    <TestMethod>
    Public Sub GetUserDataById_ShouldReturnCorrectData_WhenUserExists()
        ' Arrange
        Dim testLine As String = "5,John,john123,pass123,Admin,Male,john@example.com,03009998888,60000"
        File.WriteAllText("users.txt", testLine)

        Dim um As New UserManager()

        ' Act
        Dim result As String() = um.GetUserDataById(5)

        ' Assert
        Assert.IsNotNull(result)
        Assert.AreEqual("john123", result(2))
        Assert.AreEqual("60000", result(8))
    End Sub

    <TestMethod>
    Public Sub GetUserDataById_ShouldReturnNothing_WhenUserDoesNotExist()
        ' Arrange
        Dim testLine As String = "1,Alice,alice1,pwd,User,Female,alice@example.com,03005554444,45000"
        File.WriteAllText("users.txt", testLine)

        Dim um As New UserManager()

        ' Act
        Dim result As String() = um.GetUserDataById(999)

        ' Assert
        Assert.IsNull(result, "Should return null if user ID is not found.")
    End Sub

    <TestMethod>
    Public Sub GetUserDataById_ShouldReturnNothing_WhenFileDoesNotExist()
        ' Ensure file is not there
        If File.Exists("users.txt") Then File.Delete("users.txt")

        Dim um As New UserManager()

        ' Act
        Dim result As String() = um.GetUserDataById(1)

        ' Assert
        Assert.IsNull(result, "Should return null if file does not exist.")
    End Sub
End Class
