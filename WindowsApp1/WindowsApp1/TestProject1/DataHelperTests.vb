Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Data

<TestClass>
Public Class DataHelperTests
    Dim testDir As String = Path.Combine(Path.GetTempPath(), "DataHelperTests")

    <TestInitialize>
    Public Sub Setup()
        Directory.CreateDirectory(testDir)
        Directory.SetCurrentDirectory(testDir)
    End Sub

    <TestCleanup>
    Public Sub Teardown()
        Directory.SetCurrentDirectory(Path.GetTempPath())
        Directory.Delete(testDir, True)
    End Sub

    <TestMethod>
    Public Sub GetPatientById_ShouldReturnTrue_IfPatientExists()
        File.WriteAllText("patients.txt", "P001,John,25,Male,1234567890,USA")
        Assert.IsTrue(DataHelper.GetPatientById("P001"))
    End Sub

    <TestMethod>
    Public Sub GetPatientById_ShouldReturnFalse_IfPatientDoesNotExist()
        File.WriteAllText("patients.txt", "P002,Jane,30,Female,1234567890,USA")
        Assert.IsFalse(DataHelper.GetPatientById("P999"))
    End Sub

    <TestMethod>
    Public Sub GetDoctors_ShouldReturnOnlyDoctors()
        File.WriteAllText("users.txt", "1,Dr. Smith,user,pass,Doctor,Male,email,phone,salary" & Environment.NewLine &
                                        "2,John Doe,user,pass,Patient,Male,email,phone,salary")
        Dim result = DataHelper.GetDoctors()
        Assert.AreEqual(1, result.Count)
        Assert.AreEqual("Dr. Smith", result(0))
    End Sub

    <TestMethod>
    Public Sub GetDoctorIdByName_ShouldReturnCorrectId()
        File.WriteAllText("users.txt", "5,Dr. Wilson,user,pass,Doctor,Male,email,phone,salary")
        Dim id = DataHelper.GetDoctorIdByName("Dr. Wilson")
        Assert.AreEqual(5, id)
    End Sub

    <TestMethod>
    Public Sub GetDoctorIdByName_ShouldReturnMinus1_IfNotFound()
        File.WriteAllText("users.txt", "10,Dr. Adams,user,pass,Doctor,Male,email,phone,salary")
        Dim id = DataHelper.GetDoctorIdByName("Unknown")
        Assert.AreEqual(-1, id)
    End Sub

    <TestMethod>
    Public Sub SaveAppointment_ShouldWriteToAppointmentsFile()
        DataHelper.SaveAppointment("P001", 3, "2025-05-01 12:00")
        Dim content = File.ReadAllText("appointments.txt")
        Assert.IsTrue(content.Contains("P001,3,2025-05-01 12:00,Enrolled,1000"))
    End Sub

    <TestMethod>
    Public Sub GetAllPatients_ShouldReturnCorrectRows()
        File.WriteAllText("patients.txt", "7,Alice,22,Female,123456,CA")
        Dim table = DataHelper.GetAllPatients()
        Assert.AreEqual(1, table.Rows.Count)
        Assert.AreEqual("Alice", table.Rows(0)("Name"))
    End Sub

    <TestMethod>
    Public Sub GetAllAppointments_ShouldReturnExpectedRows()
        File.WriteAllText("appointments.txt", "A1,P001,E001,2025-04-01 11:00,Enrolled,1000")
        Dim table = DataHelper.GetAllAppointments()
        Assert.AreEqual(1, table.Rows.Count)
        Assert.AreEqual("A1", table.Rows(0)("AppointmentId"))
    End Sub

    <TestMethod>
    Public Sub PatientExists_ShouldReturnTrue_IfExists()
        File.WriteAllText("patients.txt", "P123,Alex,33,Male,987654,TX")
        Assert.IsTrue(DataHelper.PatientExists("P123"))
    End Sub

    <TestMethod>
    Public Sub PatientExists_ShouldReturnFalse_IfNotExists()
        File.WriteAllText("patients.txt", "P456,Bob,45,Male,456123,NY")
        Assert.IsFalse(DataHelper.PatientExists("P000"))
    End Sub

    <TestMethod>
    Public Sub GetAppointmentsByPatientId_ShouldReturnCorrectAppointments()
        File.WriteAllText("appointments.txt", "A2,P321,D123,2025-04-20 15:30,Enrolled,1500")
        Dim table = DataHelper.GetAppointmentsByPatientId("P321")
        Assert.AreEqual(1, table.Rows.Count)
        Assert.AreEqual("2025-04-20 15:30", table.Rows(0)("DateTime"))
        Assert.AreEqual("1500", table.Rows(0)("Payment"))
    End Sub

    <TestMethod>
    Public Sub PatientExist_ShouldReturnTrue_IfExists()
        File.WriteAllText("patients.txt", "P101,Lara,27,Female,9876,LA")
        Assert.IsTrue(DataHelper.PatientExist("P101"))
    End Sub

    <TestMethod>
    Public Sub PatientExist_ShouldReturnFalse_IfNotExists()
        File.WriteAllText("patients.txt", "P102,James,40,Male,1111,Chicago")
        Assert.IsFalse(DataHelper.PatientExist("P000"))
    End Sub

    <TestMethod>
    Public Sub AppendReportLine_ShouldWriteLineToReportFile()
        DataHelper.AppendReportLine("New report line added.")
        Dim lines = File.ReadAllLines("reports.txt")
        Assert.AreEqual("New report line added.", lines(0))
    End Sub

End Class
