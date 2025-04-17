# 🏥 Medicure App

**Medicure** is a desktop-based medical appointment and management application developed using Winforms. It facilitates appointment scheduling, patient management, and doctor-related data handling. It is ideal for small clinics or healthcare units looking for a simple and efficient patient-doctor interaction system.

---

## 📋 Table of Contents

- [Features](#features)
- [Functional Overview](#functional-overview)
- [Technologies Used](#technologies-used)
- [File Structure](#file-structure)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)

---

## 🌟 Features

- Add, update, and manage patient records.
- Doctor registration and doctor listing.
- Appointment booking with doctor and patient details.
- Real-time filtering and searching of records.
- View all appointments in a tabular format.
- Generate reports of patient visits.
- Lightweight file-based backend (using `.txt` files).
- Modular and testable helper functions.

---

## 🧠 Functional Overview

### 👤 Patient Management

- **Add New Patient:** Allows admin or reception to register a patient by capturing Name, Age, Gender, Phone, and Address.
- **Search by ID:** You can check whether a patient exists using their unique patient ID.
- **List All Patients:** Returns a complete DataTable of patients parsed from `patients.txt`.

---

### 👨‍⚕️ Doctor Management

- **List Doctors:** Fetches and displays doctors from the `users.txt` file by filtering users with the "Doctor" role.
- **Get Doctor ID by Name:** Extracts a doctor's unique ID from the records using their name.

---

### 📅 Appointment Scheduling

- **Book Appointment:** Registers an appointment by specifying patient ID, doctor ID, date/time, and saves it to `appointments.txt` with status "Enrolled".
- **Get All Appointments:** Retrieves all appointments, useful for calendar or administrative views.
- **Filter by Patient ID:** Allows viewing of all past and upcoming appointments for a specific patient.

---

### 📄 Report Generation

- **Append Report Line:** Allows appending a line to the `reports.txt` file. This can be used for logging consultation summaries or patient feedback.

---

### ✅ Validation Utilities

- `GetPatientById(patientId As String)`: Checks if a patient exists.
- `PatientExists(patientId As String)`: Similar utility to verify the presence of a patient in the system.

---

## 🧰 Technologies Used

- **IDE:** Visual Studio 2022
- **Framework:** .NET Framework
- **UI Library:** Windows Forms
- **Storage:** Text file-based system (`patients.txt`, `users.txt`, `appointments.txt`, etc.)

---

## 📁 File Structure

```plaintext
MedicureApp/
│
├── DataHelper.vb         # Contains logic for file operations and business rules
├── FormMain.vb           # Main UI logic and form design
├── patients.txt          # Stores patient records
├── users.txt             # Stores user and doctor data
├── appointments.txt      # Stores appointment data
├── reports.txt           # Stores report logs
├── bin/                  # Compiled output
└── README.md             # You're here!

```
--
## 🛠️ Installation
- Clone the repository or download the project:
``` bash
git clone https://github.com/yourusername/medicure-app.git
```
- Open MedicureApp.sln in Visual Studio.
- Build the project (Ctrl + Shift + B).
- Run the project using F5 or the green play button.
- No database setup is required. All data is stored in .txt files in the application's directory.

## 🚀 Usage
- **Login:** If implemented, users can log in with credentials from users.txt.
- Navigate through tabs:
- Add/view patients
- Book appointments
- View appointments list
- Access reports
- Exit application using the top-right close button or custom exit button.


## 📃 License
```plaintext
This project is for educational purposes and is not intended for production-level use in real healthcare systems without proper data handling compliance.
```