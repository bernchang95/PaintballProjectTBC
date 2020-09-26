Imports System.ComponentModel
Imports System.IO.Ports


Public Class TargetProjectForm


    'Essential Global Variables
    Dim ToggleButtonName As String
    Dim RangeButtonName As String
    Private MillisCounter As New Diagnostics.Stopwatch
    Dim millis As String
    Dim seconds As String

    Dim TargetTracker As Integer = 0
    Dim TargetArray() As String
    Dim TargetArraySort() As String
    Dim SystemCall As String = ""

    'Process Invokers (For Hit Count Detect and Main Timer)
    Private Delegate Sub Handshaker()
    Private ReadOnly Start As New Handshaker(AddressOf SystemStart)
    Private ReadOnly Lap As New Handshaker(AddressOf SystemLap)
    Private ReadOnly Finish As New Handshaker(AddressOf SystemStop)
    Private ReadOnly Interact As New Handshaker(AddressOf ArduinoTalk)
    Private ReadOnly AllTrue As New Handshaker(AddressOf EnableAll)
    Private ReadOnly AllFalse As New Handshaker(AddressOf DisableAll)

    'GUI function flags
    Dim RecordFlag As Boolean = False
    Dim RangeFlag As Boolean = False
    Dim ToggleFlag As Boolean = False
    Dim InterruptFlag As Boolean = False

    'Auto-detect Arduino USB
    Dim connected As Boolean = False
    Dim IsRefreshClicked As Boolean = False
    Dim comport As String

    'Start Hit Count detect and Timer (Invoke)
    Private Sub SystemStart()
        'Handshake to check if arduino is ready
        Try
            If Not SerialPort1.IsOpen() Then
                SerialPort1.Open()
            End If
            SerialPort1.WriteLine(SystemCall)
            Dim data As String = SerialPort1.ReadExisting()
            If data <> "" Then
                If InStr(data, "G", vbTextCompare) <> 0 Then
                    CounterTimer.Start()
                    HitCountDetector.Start()
                End If
            Else
                MsgBox("Failed to send START command! Please try again!", vbCritical, "Epic Failed...")
            End If
        Catch ex As Exception
            Debug.Print("Record feature stucked!")
            Debug.Print(ex.ToString)
        End Try
    End Sub

    'Stop Hit Count detect and Timer (Invoke)
    Private Sub SystemStop()

        If SerialPort1.IsOpen() Then
            SerialPort1.Close()
        End If
        CounterTimer.Stop()
        HitCountDetector.Stop()
        Invoke(AllTrue)
    End Sub

    'In charge of switching Target timer on GUI (Invoke)
    Private Sub SystemLap()
        'Check if current Target is last
        If TargetTracker > UBound(TargetArraySort) Then
            Invoke(Finish)
        Else
            TargetTracker += 1
        End If
    End Sub

    'Enable all buttons when system job done (Invoke)
    Private Sub EnableAll()
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button And InStr(ctrl.Name, "Dashboard", vbTextCompare) = 0 Then
                CType(Me.Controls(ctrl.name), Button).Enabled = True
            End If
        Next
    End Sub

    'Disable all buttons when system start (Invoke)
    Private Sub DisableAll()
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button And InStr(ctrl.Name, "Dashboard", vbTextCompare) = 0 Then
                CType(Me.Controls(ctrl.name), Button).Enabled = False
            End If
        Next
    End Sub

    'Handles all Arduino interaction. All Flags should be here (Invoke)
    Private Sub ArduinoTalk()

        Dim Targets As String = ""
        Dim TargetName As String

        If ToggleFlag Then

            Dim TargetNumber As String

            'ToggleButtonName will show current target
            TargetName = Replace(ToggleButtonName, "ToggleButton", "")
            TargetNumber = Replace(TargetName, "Target", "")

            Try
                If Not SerialPort1.IsOpen() Then
                    SerialPort1.Open()
                End If

                If CType(Me.Controls(ToggleButtonName), Button).Text = "On" Then
                    SerialPort1.WriteLine(TargetNumber & "xON")
                Else
                    SerialPort1.WriteLine(TargetNumber & "xOFF")
                End If
                'Handshake to check if arduino is ready
                Dim data As String = SerialPort1.ReadExisting()
                If data <> "" Then
                    If InStr(data, "G", vbTextCompare) <> 0 Then
                        Debug.Print("Successfully toggled target!")
                    End If
                Else
                    MsgBox("Failed to send ON/OFF command! Please try again!", vbCritical, "Epic Failed...")
                End If
                SerialPort1.Close()
            Catch ex As Exception
                Debug.Print("Toggle Feature Stucked!")
                Debug.Print(ex.ToString())
            End Try
            ToggleFlag = False
            Invoke(AllTrue)
        ElseIf RangeFlag Then
            Dim TargetNumber As String = ""
            Dim RangeValue As Integer
            If InStr(RangeButtonName, "Near", vbTextCompare) <> 0 Then
                TargetName = Replace(RangeButtonName, "NearBtn", "")
                TargetNumber = Replace(TargetName, "Target", "")
                CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.Gold
                CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke
                RangeValue = 800
            ElseIf InStr(RangeButtonName, "Mid", vbTextCompare) <> 0 Then
                TargetName = Replace(RangeButtonName, "MidBtn", "")
                TargetNumber = Replace(TargetName, "Target", "")
                CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.Gold
                CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke
                RangeValue = 500
            ElseIf InStr(RangeButtonName, "Far", vbTextCompare) <> 0 Then
                TargetName = Replace(RangeButtonName, "FarBtn", "")
                TargetNumber = Replace(TargetName, "Target", "")
                CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.Gold
                RangeValue = 200
            End If

            Try
                If Not SerialPort1.IsOpen Then
                    SerialPort1.Open()
                End If
                SerialPort1.WriteLine(TargetNumber & "x" & RangeValue)
                Dim data As String = SerialPort1.ReadExisting()
                If data <> "" Then
                    If InStr(data, "G", vbTextCompare) <> 0 Then
                        Debug.Print("Range command sent successfully!")
                    End If
                Else
                    MsgBox("Failed to send Range command! Please try again!", vbCritical, "Epic Failed...")
                End If
                'Handshake to check if arduino is ready
                SerialPort1.Close()
            Catch ex As Exception
                Debug.Print("Range feature stucked!")
                Debug.Print(ex.ToString)
            End Try

            RangeFlag = False
            Invoke(AllTrue)
        ElseIf RecordFlag Then
            'Get all On Targets (Reset all hit counts and timers to 0)
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Button And InStr(ctrl.Name, "ToggleButton", vbTextCompare) <> 0 Then
                    TargetName = Replace(ctrl.Name, "ToggleButton", "")
                    Targets = Targets & TargetName & ","
                ElseIf TypeOf ctrl Is Label And InStr(ctrl.Name, "Timer", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.Name), Label).Text = "00:000"
                ElseIf TypeOf ctrl Is Label And InStr(ctrl.name, "HitCount", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.name), Label).Text = "0"
                End If
            Next

            'Remove last comma
            Targets = Mid(Targets, 1, Len(Targets) - 1)
            TargetArray = Split(Targets, ",")

            'Sort the target order
            For ta = LBound(TargetArray) To UBound(TargetArray)
                ReDim Preserve TargetArraySort(0 To ta)
                TargetArraySort(ta) = TargetArray(ta)
            Next

            RecordFlag = False
            Invoke(Start)
        ElseIf InterruptFlag Then
            'Force Stop feature here
            HitCountDetector.Stop()
            CounterTimer.Stop()

            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Label And InStr(ctrl.name, "Timer", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.Name), Label).Text = "00:000"
                ElseIf TypeOf ctrl Is Label And InStr(ctrl.name, "HitCount", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.name), Label).Text = "0"
                End If
            Next

            'Send "STOP" command to Arduino
            Try
                If Not SerialPort1.IsOpen Then
                    SerialPort1.Open()
                End If
                SerialPort1.WriteLine(SystemCall)
                Dim data As String = SerialPort1.ReadExisting()
                If data <> "" Then
                    If InStr(data, "G", vbTextCompare) <> 0 Then
                        Debug.Print("Stop command sent successfully!")
                    End If
                Else
                    MsgBox("Failed to send Stop command! Please try again!", vbCritical, "Epic Failed...")
                End If
                'Handshake to check if arduino is ready
                SerialPort1.Close()
            Catch ex As Exception
                Debug.Print("Interrupt feature stucked!")
                Debug.Print(ex.ToString)
            End Try

            InterruptFlag = False
            Invoke(AllTrue)
        End If
    End Sub

    Private Sub TargetProjectForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Make the app appear at center of screen
        CenterToScreen()
        'Run Arduino Auto-detector
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Arduino_Auto_Detect("BW1")
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Arduino_Auto_Detect("BW2")
    End Sub

    Private Sub Arduino_Auto_Detect(BWorkerName As String)
        'Search for correct Arduino Port
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Try
                Using com As SerialPort = My.Computer.Ports.OpenSerialPort(sp)
                    ''comPort_ComboBox.Items.Add(sp)
                    com.ReadTimeout = 3000
                    If BWorkerName = "BW1" Then
                        com.WriteLine("S")
                    ElseIf BWorkerName = "BW2" Then
                        com.WriteLine("RESET")
                        IsRefreshClicked = True
                    End If

                    Dim data As String = com.ReadExisting()

                    ''*****Successfull Handshake*******
                    If InStr(data, "G") Then
                        connected = True
                        comport = sp
                    End If
                    com.Close()

                End Using
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub SerialPortInit()
        SerialPort1.PortName = comport
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted,
        BackgroundWorker2.RunWorkerCompleted
        If connected Then
            'If success
            SerialPortInit()
            MsgBox("Successfully connected to Arduino Receiver!", vbInformation, "Success!")
            ArduinoPort.Text = comport
            HitCountDetector.Enabled = True
            CounterTimer.Enabled = True
        Else
            'If fail
            MsgBox("Unable to find Arduino Receiver, please click " & """" & "Refresh USB Connection" & """" & " to try again!", vbCritical, "Failed to Connect!")
            ArduinoPort.Text = "Error"
        End If
    End Sub

    Private Sub ReconnectBtn_Click(sender As Object, e As EventArgs) Handles ReconnectBtn.Click
        'Send reconnect command to Arduino
        'Re-do serial handshake (Arduino IsConnected = False)
        Try
            'Arduino (IsConnected = True)
            BackgroundWorker2.RunWorkerAsync()
        Catch ex As Exception
            Try
                BackgroundWorker1.RunWorkerAsync()
            Catch ex2 As Exception
                MsgBox("Unable to refresh system, please reconnect the system again to do a hard reset.", vbCritical, "Unable to send command!")
            End Try
        End Try
    End Sub

    Private Sub QuitBtn_Click(sender As Object, e As EventArgs) Handles QuitBtn.Click
        TargetProjectForm.ActiveForm.Close()
    End Sub

    Private Sub Target1ToggleButton_Click(sender As Object, e As EventArgs) Handles Target1ToggleButton.Click
        Dim TargetButton As Button = sender
        Dim TargetName As String

        Invoke(AllFalse)

        ToggleButtonName = TargetButton.Name
        TargetName = Replace(ToggleButtonName, "ToggleButton", "")

        If TargetButton.Text = "Off" Then
            TargetButton.Text = "On"
            TargetButton.BackColor = Color.LawnGreen
        Else
            'Initialize all Range Sensor Buttons
            CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
            CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
            CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke

            TargetButton.Text = "Off"
            TargetButton.BackColor = Color.Red
        End If
        ToggleFlag = True
        Invoke(Interact)
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        'Adjust Table Header according to how many targets are on.
        Dim ShooterName = ""
        Dim TargetName As String
        Dim TargetRange As String = ""
        Dim Targets As String = ""
        Dim Timers As String = ""
        Dim HitCounts As String = ""
        Dim ctrl As Control

        For Each ctrl In Me.Controls
            If TypeOf ctrl Is TextBox And ctrl.Name = "ShooterNameTBox" Then
                'TextBox Validation
                If ctrl.Text = "" Then
                    MsgBox("Shooter's Name is Empty! Please fill it up before saving!", vbExclamation, "Shooter Name Field is Empty!")
                    Exit Sub
                End If
                ShooterName = ctrl.Text
            ElseIf TypeOf ctrl Is Button And InStr(ctrl.Name, "ToggleButton", vbTextCompare) <> 0 Then
                'Target On Validation
                If ctrl.Text = "On" Then
                    TargetName = Replace(ctrl.Name, "ToggleButton", "")
                    Targets &= TargetName & ","
                    Timers &= CType(Me.Controls(TargetName & "Timer"), Label).Text & ","
                    HitCounts &= CType(Me.Controls(TargetName & "HitCount"), Label).Text & ","

                    'If Else to determine which range setting is on
                    If CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.Gold Then
                        TargetRange &= CType(Me.Controls(TargetName & "NearBtn"), Button).Text & ","
                    ElseIf CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.Gold Then
                        TargetRange &= CType(Me.Controls(TargetName & "MidBtn"), Button).Text & ","
                    ElseIf CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.Gold Then
                        TargetRange &= CType(Me.Controls(TargetName & "FarBtn"), Button).Text & ","
                    End If

                End If
            End If
        Next

        'Remove last comma
        Targets = Mid(Targets, 1, Len(Targets) - 1)
        Timers = Mid(Timers, 1, Len(Timers) - 1)
        HitCounts = Mid(HitCounts, 1, Len(HitCounts) - 1)
        TargetRange = Mid(TargetRange, 1, Len(TargetRange) - 1)

        'File Header Setup
        Dim TableData As String = ShooterName & ","

        If InStr(Targets, ",", vbTextCompare) <> 0 Then
            'Multiple Targets
            Dim TargetNameSave() As String
            Dim TimerArraySave() As String
            Dim HitCountSave() As String
            Dim TargetRangeSave() As String

            TargetNameSave = Split(Targets, ",")
            TimerArraySave = Split(Timers, ",")
            HitCountSave = Split(HitCounts, ",")
            TargetRangeSave = Split(TargetRange, ",")

            'Start adding table data
            For tns = UBound(TargetNameSave) To LBound(TargetNameSave) Step -1
                TableData &= TargetNameSave(tns) & "," & TargetRangeSave(tns) & "," & TimerArraySave(tns) & "," & HitCountSave(tns) & ","
            Next
        Else
            '1 Target only
            TableData &= Targets & "," & TargetRange & "," & Timers & "," & HitCounts
        End If

        'Remove last comma on TableHeader and TableData
        TableData = Mid(TableData, 1, Len(TableData) - 1)

        'Start writing data to file
        Dim FilePath As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShooterDetails.csv")

        'Check if the file already exists
        If IO.File.Exists(FilePath) Then
            'Append Mode
            Try
                Dim FileAppend As New System.IO.StreamWriter(FilePath, True)
                FileAppend.WriteLine(TableData)
                FileAppend.Close()
                MsgBox("New shooter data appended! You can find the file in " & """" & "My Documents" & """" & " folder.", vbInformation, "Success!")
            Catch ex As Exception
                MsgBox("New shooter data not saved! Please report the bug immediately!", vbExclamation, "Warning! Data not saved!")
            End Try
        Else
            'Write Mode
            Try
                Dim FileWriter As New System.IO.StreamWriter(FilePath, False)
                FileWriter.WriteLine(TableData)
                FileWriter.Close()
                MsgBox("Shooter data saved! You can find the file in " & """" & "My Documents" & """" & " folder.", vbInformation, "Success!")
            Catch ex As Exception
                MsgBox("Shooter data not saved! Please report the bug immediately!", vbExclamation, "Warning! Data not saved!")
            End Try
        End If
    End Sub

    Private Sub ShooterDashBoardBtn_Click(sender As Object, e As EventArgs) Handles ShooterDashBoardBtn.Click
        'Allows user to view all previous records directly in GUI without opening the CSV file
        ShooterDashboardWindow.Show()
    End Sub

    Private Sub RecordBtn_Click(sender As Object, e As EventArgs) Handles RecordBtn.Click
        Invoke(AllFalse)
        'Only button to get enabled to allow user to stop timer record halfway
        'Invoke Interrupt Stop required
        If RecordBtn.Text = "Start Record" Then
            RecordFlag = True
            RecordBtn.Enabled = True
            SystemCall = "START"
            RecordBtn.Text = "Stop Record"
        Else
            InterruptFlag = True
            RecordBtn.Enabled = True
            SystemCall = "STOP"
            RecordBtn.Text = "Start Record"
        End If

        Invoke(Interact)
    End Sub

    Private Sub TargetProjectForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'Come back again after finishing Final Integration Receiver Arduino codes
        'Send RESET command to arduino
        'Receive G for successful handshake
    End Sub

    Private Sub CounterTimer_Tick(sender As Object, e As EventArgs) Handles CounterTimer.Tick
        Dim Count As TimeSpan = MillisCounter.Elapsed

        millis = Count.Milliseconds
        seconds = Count.Seconds

        'Update counter here (Use a target tracker)
        'Assuming rounding up from millis to seconds is done by the class
        If seconds < 10 Then
            CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":" & millis
        Else
            If millis < 10 Then
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":00" & millis
            ElseIf millis < 100 Then
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":0" & millis
            Else
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":" & millis
            End If
        End If

    End Sub

    Private Sub HitCountDetector_Tick(sender As Object, e As EventArgs) Handles HitCountDetector.Tick
        Try
            Dim data As String = SerialPort1.ReadLine() 'TBD
            If data <> "" Then
                If InStr(data, "HIT", vbTextCompare) <> 0 Then
                    'Trigger current target hit count
                    CType(Me.Controls(TargetArraySort(TargetTracker) & "HitCount"), Label).Text = "1"
                    Invoke(Lap)
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.ToString())
        End Try
    End Sub

    Private Sub Target1NearBtn_Click(sender As Object, e As EventArgs) Handles Target1NearBtn.Click, Target1MidBtn.Click, Target1FarBtn.Click

        Dim TargetRangeBtn As Button = sender
        Dim TargetName As String

        Invoke(AllFalse)
        'Get button name
        RangeButtonName = TargetRangeBtn.Name
        If InStr(RangeButtonName, "Near", vbTextCompare) <> 0 Then
            TargetName = Replace(RangeButtonName, "NearBtn", "")
            CType(Controls(TargetName & "NearBtn"), Button).BackColor = Color.Gold
            CType(Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
            CType(Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke
        ElseIf InStr(RangeButtonName, "Mid", vbTextCompare) <> 0 Then
            TargetName = Replace(RangeButtonName, "MidBtn", "")
            CType(Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
            CType(Controls(TargetName & "MidBtn"), Button).BackColor = Color.Gold
            CType(Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke
        ElseIf InStr(RangeButtonName, "Far", vbTextCompare) <> 0 Then
            TargetName = Replace(RangeButtonName, "FarBtn", "")
            CType(Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
            CType(Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
            CType(Controls(TargetName & "FarBtn"), Button).BackColor = Color.Gold
        End If
        Invoke(Interact)
    End Sub
End Class
