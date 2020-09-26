Imports System.ComponentModel
Imports System.IO.Ports


Public Class TargetProjectForm

    'Main GUI interface

    'What it does?
    'Allows user to change the Arduino's vibration sensor sensitivity directly, and controls the timer and hit trigger count.
    'There are 3 range modes you can change via the GUI.
    'Close = 800, Middle = 500, Long = 200 (Numbers represent the vibration sensor sensitivty)
    'The higher the number, the less sensitive the vibration sensor is, the more force the bullet needs to trigger and stop the timer.

    'This GUI directly interacts with the station aka Receiver Arduino (The one connected with the LCD) via USB connection.
    'You can notice this when SerialPort unit is declared
    'It is recommended for you to search on how VB.net SerialPort works to understand the interaction and functionality.

    'Essential Global Variables
    Dim ToggleButtonName As String
    Dim RangeButtonName As String
    Private ReadOnly MillisCounter As New Diagnostics.Stopwatch
    Dim millis As String
    Dim seconds As String

    Dim TargetTracker As Integer = 0
    Dim TargetArray() As String
    Dim TargetArraySort() As String

    'Process Invokers (For Hit Count Detect and Main Timer)
    'Why is this required?
    'To ensure the function can run independently in background without causing any lagging on the GUI itself.
    'When I mentioned "Trigger process invoker", the actual function name that contains the code is recorded in the "AddressOf" part
    'The Invoke() part triggers the handshaker, as you can see in the declaration below.
    'It is highly recommended for you to check the tutorial on process thread invokes.
    Private Delegate Sub Handshaker()
    Private ReadOnly Start As New Handshaker(AddressOf SystemStart)
    Private ReadOnly Lap As New Handshaker(AddressOf SystemLap)
    Private ReadOnly Finish As New Handshaker(AddressOf SystemStop)
    Private ReadOnly Interact As New Handshaker(AddressOf ArduinoTalk)
    Private ReadOnly AllTrue As New Handshaker(AddressOf EnableAll)
    Private ReadOnly AllFalse As New Handshaker(AddressOf DisableAll)
    Private ReadOnly FormClose As New Handshaker(AddressOf Quit)

    'GUI function flags
    Dim RecordFlag As Boolean = False
    Dim RangeFlag As Boolean = False
    Dim InterruptFlag As Boolean = False

    'Auto-detect Arduino USB
    Dim connected As Boolean = False
    Dim IsRefreshClicked As Boolean = False
    Dim comport As String

    'Start Hit Count detect and Timer (Invoke)
    'Initiates the counter timer after user clicks "Start Record" (Button name will change to "Stop Record")
    Private Sub SystemStart()
        'Handshake to check if arduino is ready
        Try
            If Not SerialPort1.IsOpen() Then
                SerialPort1.Open()
            End If
            'Letter x is placed in front of START since Arduino has the tendency to skip reading the first character.
            SerialPort1.WriteLine("xSTART") 'Tells Arduino to get ready and detect the target trigger.
            Dim data As String = SerialPort1.ReadLine()
            If data <> "" Then
                If InStr(data, "G", vbTextCompare) <> 0 Then
                    'HitCountDetector.Enabled = True
                    CounterTimer.Enabled = True
                    'Starts all GUI internal timers.
                    CounterTimer.Start()
                    MillisCounter.Start()
                    HitCountDetector.Start()
                    Debug.Print("Recording...")
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
    'Initiates the counter timer after user clicks "Stop Record" (Button name will change to "Start Record")
    Private Sub SystemStop()

        If SerialPort1.IsOpen() Then
            SerialPort1.Close()
        End If
        'Stops and reset all GUI internal timers.
        MillisCounter.Stop()
        MillisCounter.Reset()
        CounterTimer.Stop()
        HitCountDetector.Stop()
        'RecordBtn.Text = "Start Record"
        Invoke(AllTrue)
    End Sub

    'In charge of switching Target timer on GUI (Invoke)
    'To start the next timer of target (if any more with Target button swithced on) immediately.
    Private Sub SystemLap()
        'Check if current Target is last
        TargetTracker += 1
        If TargetTracker > UBound(TargetArraySort) Then
            Invoke(Finish) 'Trigger process invoker "Finish", executes the "Finish" function
        Else
            MillisCounter.Restart() 'Restarts millisecond counter.
        End If
    End Sub

    'Enable all buttons when system job done (Invoke)
    'Make all buttons clickable again (Purpose: Ensure user don't meddle with the GUI buttons until interaction with Arduino is completed.)
    Private Sub EnableAll()
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button And InStr(ctrl.Name, "Dashboard", vbTextCompare) = 0 Then
                CType(Me.Controls(ctrl.name), Button).Enabled = True
            End If
        Next
    End Sub

    'Disable all buttons when system start (Invoke)
    'Make all buttons non-clickable (Purpose: Ensure user don't meddle with the GUI buttons until interaction with Arduino is completed.)
    Private Sub DisableAll()
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button And InStr(ctrl.Name, "Dashboard", vbTextCompare) = 0 Then
                CType(Me.Controls(ctrl.name), Button).Enabled = False
            End If
        Next
    End Sub

    'Handles all Arduino interaction (connected to Target). All Flags should be here (Invoke)
    'Independent process that runs on background.
    'Most vital function of the program, it interacts directly with the Arduino here.
    Private Sub ArduinoTalk()

        Dim Targets As String = ""
        Dim TargetName As String

        'Manage and adjust the sensitivty of vibration sensor (connected to Target sytem)
        If RangeFlag Then
            Dim TargetNumber As String = ""
            Dim RangeValue As String = ""

            'GUI button color change
            If InStr(RangeButtonName, "Near", vbTextCompare) <> 0 Then
                TargetName = Replace(RangeButtonName, "NearBtn", "")
                TargetNumber = Replace(TargetName, "Target", "")
                CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.Gold
                CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke
                RangeValue = "800"
            ElseIf InStr(RangeButtonName, "Mid", vbTextCompare) <> 0 Then
                TargetName = Replace(RangeButtonName, "MidBtn", "")
                TargetNumber = Replace(TargetName, "Target", "")
                CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.Gold
                CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.WhiteSmoke
                RangeValue = "500"
            ElseIf InStr(RangeButtonName, "Far", vbTextCompare) <> 0 Then
                TargetName = Replace(RangeButtonName, "FarBtn", "")
                TargetNumber = Replace(TargetName, "Target", "")
                CType(Me.Controls(TargetName & "NearBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "MidBtn"), Button).BackColor = Color.WhiteSmoke
                CType(Me.Controls(TargetName & "FarBtn"), Button).BackColor = Color.Gold
                RangeValue = "200"
            End If

            'Tells Arduino (connected to Target sytem) to change the vibration sensor sensitivty here.
            Try
                If Not SerialPort1.IsOpen Then
                    SerialPort1.Open()
                End If
                'Tells Arduino Target which Target needs to change, and what sensitivity value that Arduino Target should adjust to.
                SerialPort1.WriteLine("x" + TargetNumber + RangeValue)
                Dim data As String = SerialPort1.ReadLine()
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
            Invoke(AllTrue) 'Triggers process invoker "AllTrue", refer to "AllTrue" function.

        ElseIf RecordFlag Then

            'Timer will start running here.
            'This function will check which target button is on (Green) and available for recording.

            'Get all On Targets (Reset all hit counts and timers to 0)
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Button And InStr(ctrl.Name, "ToggleButton", vbTextCompare) <> 0 Then
                    If CType(Me.Controls(ctrl.name), Button).Text = "On" Then
                        TargetName = Replace(ctrl.Name, "ToggleButton", "")
                        Targets = Targets & TargetName & ","
                    End If
                ElseIf TypeOf ctrl Is Label And InStr(ctrl.Name, "Timer", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.Name), Label).Text = "00:000"
                ElseIf TypeOf ctrl Is Label And InStr(ctrl.name, "HitCount", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.name), Label).Text = "0"
                End If
            Next

            'Just making sure the timer is calculating in ascending order (from Target 1 to Target 5)
            'Remove last comma
            Targets = Mid(Targets, 1, Len(Targets) - 1)
            TargetArray = Split(Targets, ",")
            Dim ta2 As Integer = 0
            'Sort the target order
            For ta = UBound(TargetArray) To LBound(TargetArray) Step -1
                ReDim Preserve TargetArraySort(0 To ta2)
                TargetArraySort(ta2) = TargetArray(ta)
                ta2 += 1
            Next

            RecordFlag = False
            Invoke(Start) 'Triggers process invoker "Start", refer to "Start" function.

        ElseIf InterruptFlag Then

            'This function acts as an emergency stopper inside the GUI.
            'Potential issue: At times this function may cause the interaction of Arduino and GUI to be out of sync.
            'Reason: The codes running in Arduino may not be ready to receive instructions from the GUI yet.
            'Prevention method: Attempt to not click immediately after you click the start function.

            'Force Stop feature here
            HitCountDetector.Stop()
            CounterTimer.Stop()
            MillisCounter.Stop()
            MillisCounter.Reset()

            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Label And InStr(ctrl.name, "Timer", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.Name), Label).Text = "00:000"
                ElseIf TypeOf ctrl Is Label And InStr(ctrl.name, "HitCount", vbTextCompare) <> 0 Then
                    CType(Me.Controls(ctrl.name), Label).Text = "0"
                End If
            Next

            'Send "STOP" command to Arduino
            'This will cause the Arduino receiver aka station (with LCD) to not wait for hit trigger count anymore.
            Try
                If Not SerialPort1.IsOpen Then
                    SerialPort1.Open()
                End If
                SerialPort1.WriteLine("xSTOP") 'Similar to xSTART, making sure "STOP" command is received successfully in Arduino without any missing letters.
                Dim data As String = SerialPort1.ReadLine()
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
            Invoke(AllTrue) 'Triggers process invoker "AllTrue", refer to "Start" function.
        End If
    End Sub

    'Efficiently closes the form without much delay
    Private Sub Quit()
        'Send RESET command to arduino
        'Receive G for successful handshake
        'This function makes sure the Arduino is in the correct code loop...
        'Also, it lets you know what function is running inside the Arduino station (with LCD)
        Try
            If Not SerialPort1.IsOpen Then
                SerialPort1.Open()
            End If

            If IsRefreshClicked Then
                SerialPort1.WriteLine("S")
                SerialPort1.WriteLine("CANCEL")
            Else
                SerialPort1.WriteLine("CANCEL")
            End If

            Dim data As String = SerialPort1.ReadLine()
            If data <> "" Then
                If InStr(data, "G", vbTextCompare) <> 0 Then
                    Debug.Print("Reset success!")
                End If
            End If
            SerialPort1.Close()
        Catch ex As Exception
            Debug.Print("Form closing procedure failed")
            Debug.Print(ex.ToString)
        End Try
    End Sub

    Private Sub TargetProjectForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Make the app appear at center of screen
        CenterToScreen()
        'Run Arduino Auto-detector
        Invoke(AllFalse) 'Triggers process invoker "AllFalse", refer to "AllFalse" function.

        'Activates background process (concept is similar to process invoker, but runs on its own independently or asynchronously)
        'Process invoker required the Invoke command as shown above to execute the function
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    'Async function of GUI
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Arduino_Auto_Detect("BW1")
    End Sub

    'Async function of GUI
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Arduino_Auto_Detect("BW2")
    End Sub

    'Auto-detects which USB port Arduino is using.
    'This function may failed if multiple Arduino is connected to PC.
    Private Sub Arduino_Auto_Detect(BWorkerName As String)
        'Search for correct Arduino Port
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Try
                Using com As SerialPort = My.Computer.Ports.OpenSerialPort(sp)
                    ''comPort_ComboBox.Items.Add(sp)
                    com.ReadTimeout = 3000
                    'BW1 = BackgroundWorker1, BW2 = BackgroundWorker2
                    'Reason of declaration, to re-synchronize the Arduino with the GUI so you can predict which loop the code is running.
                    If BWorkerName = "BW1" Then
                        com.WriteLine("S")
                    ElseIf BWorkerName = "BW2" Then
                        com.WriteLine("CANCEL")
                        IsRefreshClicked = True
                    End If

                    Dim data As String = com.ReadLine()
                    Debug.Print(data)
                    ''*****Successfull Handshake*******
                    If InStr(data, "G", vbTextCompare) <> 0 Then
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
        'Creates a connection between Arduino is GUI via the USB cable.
        'SerialPort1 is the channel for the GUI to talk to the Arduino directly.
        'Refer to the tutorial on serial ports to understand the properties of SerialPort for more details.
        SerialPort1.PortName = comport
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
    End Sub

    'This function runs after the background worker (async function) completes its job behind the scene.
    'Handles both BackgroundWorker1 and BackgroundWorker2
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted,
        BackgroundWorker2.RunWorkerCompleted
        'Validation function if the Arduino station (with LCD) is detected successfully
        If connected Then
            'If success
            SerialPortInit()
            MsgBox("Successfully connected to System!", vbInformation, "Success!")
            ArduinoPort.Text = comport
            Invoke(AllTrue)
        Else
            'If fail
            MsgBox("Unable to find system, please click " & """" & "Reconnect" & """" & " to try again!", vbCritical, "Failed to Connect!")
            ReconnectBtn.Enabled = True
            ArduinoPort.Text = "Error"
        End If
    End Sub

    'Reconnect function (in case the first attempt fails)
    Private Sub ReconnectBtn_Click(sender As Object, e As EventArgs) Handles ReconnectBtn.Click
        'Send reconnect command to Arduino
        'Re-do serial handshake (Arduino IsConnected = False)
        Invoke(AllFalse)

        '2 Background workers are used to re-sync the Arduino process flow with GUI.
        Try
            'Arduino (IsConnected = True)
            BackgroundWorker2.RunWorkerAsync()
        Catch ex As Exception
            Try
                BackgroundWorker1.RunWorkerAsync()
            Catch ex2 As Exception
                ReconnectBtn.Enabled = True
                MsgBox("Unable to refresh system, please reconnect the system again to do a hard reset.", vbCritical, "Unable to send command!")
            End Try
        End Try
    End Sub

    'Exits the main GUI after user clicks "Quit'
    Private Sub QuitBtn_Click(sender As Object, e As EventArgs) Handles QuitBtn.Click
        TargetProjectForm.ActiveForm.Close()
    End Sub

    'Target button "On" and "Off"
    'These buttons allow GUI to identify which timer to run and which hit trigger count to display

    'Link this function to Target3, Target4 and Target5 when more target systems are available.
    Private Sub Target1ToggleButton_Click(sender As Object, e As EventArgs) Handles Target1ToggleButton.Click, Target2ToggleButton.Click
        Dim TargetButton As Button = sender
        Dim TargetName As String

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
    End Sub

    'Saves all the record into a file "ShooterDetails.csv"
    'The file will be used by the "Shooter's Dashboard" button and its respective GUI.
    'Save format: Shooter's Name, Target's Name, Target Range setting, Timer recorded, Hit Count triggered.
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
        Dim MultiTarget As Boolean = False

        If InStr(Targets, ",", vbTextCompare) <> 0 Then
            'Multiple Targets
            MultiTarget = True
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
        If MultiTarget Then
            TableData = Mid(TableData, 1, Len(TableData) - 1)
        End If

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

    'Opens the Shooter's Dashboard GUI.
    Private Sub ShooterDashBoardBtn_Click(sender As Object, e As EventArgs) Handles ShooterDashBoardBtn.Click
        'Allows user to view all previous records directly in GUI without opening the CSV file
        ShooterDashboardWindow.Show()
    End Sub

    'Initiates the record button feature.
    Private Sub RecordBtn_Click(sender As Object, e As EventArgs) Handles RecordBtn.Click
        Invoke(AllFalse) 'Triggers process invoker "AllFalse"
        'Only button to get enabled to allow user to stop timer record halfway
        'Invoke Interrupt Stop required
        If RecordBtn.Text = "Start Record" Then
            RecordFlag = True
            RecordBtn.Enabled = True
            TargetTracker = 0
            RecordBtn.Text = "Stop Record"
        Else
            InterruptFlag = True
            RecordBtn.Enabled = True
            RecordBtn.Text = "Start Record"
        End If

        Invoke(Interact) 'Triggers process invoker "Interact", refer to "Interact" function
    End Sub

    'Runs after user clicks "Quit" button, think of it as some final tasks to do before completely closing the GUI
    'Reason: Making sure Arduino station is on sync with the GUI the next time you start the GUI without resetting the Arduino station (with LCD)
    Private Sub TargetProjectForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Invoke(FormClose)
    End Sub

    'Handles all the Timer counter. From Target 1 until Target 5
    Private Sub CounterTimer_Tick(sender As Object, e As EventArgs) Handles CounterTimer.Tick
        Dim Count As TimeSpan = MillisCounter.Elapsed

        millis = Count.Milliseconds
        seconds = Count.Seconds

        'Update counter here (Use a target tracker)
        'Assuming rounding up from millis to seconds is done by the class
        'Ensure Timer is displayed correctly in GUI.
        'Current display format: 00:000 (Seconds:Milliseconds)
        'You can change the text to display minutes if required (make sure you store the minutes variable from the timer counter)
        If millis < 10 Then
            If seconds < 10 Then
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":00" & millis
            Else
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = seconds & ":00" & millis
            End If

        ElseIf millis < 100 Then
            If seconds < 10 Then
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":0" & millis
            Else
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = seconds & ":0" & millis
            End If

        Else
            If seconds < 10 Then
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = "0" & seconds & ":" & millis
            Else
                CType(Me.Controls(TargetArraySort(TargetTracker) & "Timer"), Label).Text = seconds & ":" & millis
            End If
        End If
    End Sub

    'Standby to detect Arduino hit count.
    'What it detects? Text called "HIT1" and "HIT2" (representing response from target 1 and target 2)
    Private Sub HitCountDetector_Tick(sender As Object, e As EventArgs) Handles HitCountDetector.Tick
        Try
            Dim data As String = SerialPort1.ReadExisting() 'Ensure Arduino consistently sends command via USB to let this function run properly.
            Dim currentTarget As String = Replace(TargetArraySort(TargetTracker), "Target", "")
            Dim search As String = "HIT" + currentTarget 'Automatically change to HIT1 and HIT2 and detect that word from Arduino station via USB (with LCD)
            Debug.Print(data)
            If data <> "" Then
                'Search for target hit
                If InStr(data, search, vbTextCompare) <> 0 Then
                    'Trigger current target hit count
                    Debug.Print("Target HIT!")
                    CType(Me.Controls(TargetArraySort(TargetTracker) & "HitCount"), Label).Text = "1"
                    Invoke(Lap)
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.ToString())
        End Try
    End Sub

    'Changes the vibration sensor sensitivity from the Arduino.
    Private Sub Target1NearBtn_Click(sender As Object, e As EventArgs) Handles Target1NearBtn.Click, Target1MidBtn.Click, Target1FarBtn.Click, Target2NearBtn.Click,
        Target2MidBtn.Click, Target2FarBtn.Click

        Dim TargetRangeBtn As Button = sender
        Dim TargetName As String

        Invoke(AllFalse)
        RangeFlag = True
        'Get button name
        RangeButtonName = TargetRangeBtn.Name
        'For GUI display purposes, telling user the current vibration sensor sensitivity of the target
        'For debugging purposes, use the Serial Monitor to check the response and take note of the NRF radio max range, Arduino power supply etc.
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
