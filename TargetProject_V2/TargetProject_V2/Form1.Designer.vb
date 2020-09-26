<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TargetProjectForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShooterNameTBox = New System.Windows.Forms.TextBox()
        Me.Target1FarBtn = New System.Windows.Forms.Button()
        Me.Target1MidBtn = New System.Windows.Forms.Button()
        Me.Target1NearBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RecordBtn = New System.Windows.Forms.Button()
        Me.Target1HitCount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Target1Timer = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Target1ToggleButton = New System.Windows.Forms.Button()
        Me.Target1 = New System.Windows.Forms.Label()
        Me.QuitBtn = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ArduinoPort = New System.Windows.Forms.Label()
        Me.ShooterDashBoardBtn = New System.Windows.Forms.Button()
        Me.ReconnectBtn = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.CounterTimer = New System.Windows.Forms.Timer(Me.components)
        Me.HitCountDetector = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Target2FarBtn = New System.Windows.Forms.Button()
        Me.Target2MidBtn = New System.Windows.Forms.Button()
        Me.Target2NearBtn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Target2HitCount = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Target2Timer = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Target2ToggleButton = New System.Windows.Forms.Button()
        Me.Target2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(221, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(489, 55)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Target Control Center"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shooter Name:"
        '
        'ShooterNameTBox
        '
        Me.ShooterNameTBox.AcceptsReturn = True
        Me.ShooterNameTBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShooterNameTBox.Location = New System.Drawing.Point(231, 114)
        Me.ShooterNameTBox.Name = "ShooterNameTBox"
        Me.ShooterNameTBox.Size = New System.Drawing.Size(411, 29)
        Me.ShooterNameTBox.TabIndex = 2
        '
        'Target1FarBtn
        '
        Me.Target1FarBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Target1FarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1FarBtn.Location = New System.Drawing.Point(507, 216)
        Me.Target1FarBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.Target1FarBtn.Name = "Target1FarBtn"
        Me.Target1FarBtn.Size = New System.Drawing.Size(73, 38)
        Me.Target1FarBtn.TabIndex = 72
        Me.Target1FarBtn.Text = "Long"
        Me.Target1FarBtn.UseVisualStyleBackColor = False
        '
        'Target1MidBtn
        '
        Me.Target1MidBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Target1MidBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1MidBtn.Location = New System.Drawing.Point(429, 216)
        Me.Target1MidBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.Target1MidBtn.Name = "Target1MidBtn"
        Me.Target1MidBtn.Size = New System.Drawing.Size(73, 38)
        Me.Target1MidBtn.TabIndex = 71
        Me.Target1MidBtn.Text = "Mid"
        Me.Target1MidBtn.UseVisualStyleBackColor = False
        '
        'Target1NearBtn
        '
        Me.Target1NearBtn.BackColor = System.Drawing.Color.Gold
        Me.Target1NearBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1NearBtn.Location = New System.Drawing.Point(352, 216)
        Me.Target1NearBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.Target1NearBtn.Name = "Target1NearBtn"
        Me.Target1NearBtn.Size = New System.Drawing.Size(73, 38)
        Me.Target1NearBtn.TabIndex = 70
        Me.Target1NearBtn.Text = "Close"
        Me.Target1NearBtn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(253, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 29)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Range:"
        '
        'RecordBtn
        '
        Me.RecordBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RecordBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecordBtn.Location = New System.Drawing.Point(137, 481)
        Me.RecordBtn.Name = "RecordBtn"
        Me.RecordBtn.Size = New System.Drawing.Size(187, 48)
        Me.RecordBtn.TabIndex = 64
        Me.RecordBtn.Text = "Start Record"
        Me.RecordBtn.UseVisualStyleBackColor = False
        '
        'Target1HitCount
        '
        Me.Target1HitCount.AutoSize = True
        Me.Target1HitCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1HitCount.Location = New System.Drawing.Point(869, 220)
        Me.Target1HitCount.Name = "Target1HitCount"
        Me.Target1HitCount.Size = New System.Drawing.Size(26, 29)
        Me.Target1HitCount.TabIndex = 57
        Me.Target1HitCount.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(746, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 29)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Hit Count:"
        '
        'Target1Timer
        '
        Me.Target1Timer.AutoSize = True
        Me.Target1Timer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1Timer.Location = New System.Drawing.Point(664, 220)
        Me.Target1Timer.Name = "Target1Timer"
        Me.Target1Timer.Size = New System.Drawing.Size(84, 29)
        Me.Target1Timer.TabIndex = 55
        Me.Target1Timer.Text = "00:000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(586, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 29)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Timer:"
        '
        'Target1ToggleButton
        '
        Me.Target1ToggleButton.BackColor = System.Drawing.Color.Red
        Me.Target1ToggleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1ToggleButton.Location = New System.Drawing.Point(133, 212)
        Me.Target1ToggleButton.Margin = New System.Windows.Forms.Padding(2)
        Me.Target1ToggleButton.Name = "Target1ToggleButton"
        Me.Target1ToggleButton.Size = New System.Drawing.Size(108, 42)
        Me.Target1ToggleButton.TabIndex = 50
        Me.Target1ToggleButton.Tag = "Target1Toggle"
        Me.Target1ToggleButton.Text = "Off"
        Me.Target1ToggleButton.UseVisualStyleBackColor = False
        '
        'Target1
        '
        Me.Target1.AutoSize = True
        Me.Target1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1.Location = New System.Drawing.Point(12, 220)
        Me.Target1.Name = "Target1"
        Me.Target1.Size = New System.Drawing.Size(109, 29)
        Me.Target1.TabIndex = 53
        Me.Target1.Text = "Target 1:"
        '
        'QuitBtn
        '
        Me.QuitBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.QuitBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitBtn.Location = New System.Drawing.Point(569, 481)
        Me.QuitBtn.Name = "QuitBtn"
        Me.QuitBtn.Size = New System.Drawing.Size(111, 48)
        Me.QuitBtn.TabIndex = 52
        Me.QuitBtn.Text = "Quit"
        Me.QuitBtn.UseVisualStyleBackColor = False
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SaveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(386, 481)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(116, 48)
        Me.SaveBtn.TabIndex = 51
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 29)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Target Settings:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 545)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 20)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Connected to:"
        '
        'ArduinoPort
        '
        Me.ArduinoPort.AutoSize = True
        Me.ArduinoPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArduinoPort.Location = New System.Drawing.Point(127, 545)
        Me.ArduinoPort.Name = "ArduinoPort"
        Me.ArduinoPort.Size = New System.Drawing.Size(14, 20)
        Me.ArduinoPort.TabIndex = 74
        Me.ArduinoPort.Text = "-"
        '
        'ShooterDashBoardBtn
        '
        Me.ShooterDashBoardBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ShooterDashBoardBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShooterDashBoardBtn.Location = New System.Drawing.Point(660, 114)
        Me.ShooterDashBoardBtn.Name = "ShooterDashBoardBtn"
        Me.ShooterDashBoardBtn.Size = New System.Drawing.Size(227, 32)
        Me.ShooterDashBoardBtn.TabIndex = 75
        Me.ShooterDashBoardBtn.Text = "Shooters' Dashboard"
        Me.ShooterDashBoardBtn.UseVisualStyleBackColor = False
        '
        'ReconnectBtn
        '
        Me.ReconnectBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ReconnectBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReconnectBtn.Location = New System.Drawing.Point(187, 538)
        Me.ReconnectBtn.Name = "ReconnectBtn"
        Me.ReconnectBtn.Size = New System.Drawing.Size(111, 32)
        Me.ReconnectBtn.TabIndex = 76
        Me.ReconnectBtn.Text = "Reconnect"
        Me.ReconnectBtn.UseVisualStyleBackColor = False
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'CounterTimer
        '
        Me.CounterTimer.Interval = 1
        '
        'HitCountDetector
        '
        Me.HitCountDetector.Interval = 1
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM7"
        '
        'Target2FarBtn
        '
        Me.Target2FarBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Target2FarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2FarBtn.Location = New System.Drawing.Point(507, 262)
        Me.Target2FarBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.Target2FarBtn.Name = "Target2FarBtn"
        Me.Target2FarBtn.Size = New System.Drawing.Size(73, 38)
        Me.Target2FarBtn.TabIndex = 86
        Me.Target2FarBtn.Text = "Long"
        Me.Target2FarBtn.UseVisualStyleBackColor = False
        '
        'Target2MidBtn
        '
        Me.Target2MidBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Target2MidBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2MidBtn.Location = New System.Drawing.Point(429, 262)
        Me.Target2MidBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.Target2MidBtn.Name = "Target2MidBtn"
        Me.Target2MidBtn.Size = New System.Drawing.Size(73, 38)
        Me.Target2MidBtn.TabIndex = 85
        Me.Target2MidBtn.Text = "Mid"
        Me.Target2MidBtn.UseVisualStyleBackColor = False
        '
        'Target2NearBtn
        '
        Me.Target2NearBtn.BackColor = System.Drawing.Color.Gold
        Me.Target2NearBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2NearBtn.Location = New System.Drawing.Point(352, 262)
        Me.Target2NearBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.Target2NearBtn.Name = "Target2NearBtn"
        Me.Target2NearBtn.Size = New System.Drawing.Size(73, 38)
        Me.Target2NearBtn.TabIndex = 84
        Me.Target2NearBtn.Text = "Close"
        Me.Target2NearBtn.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(253, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 29)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Range:"
        '
        'Target2HitCount
        '
        Me.Target2HitCount.AutoSize = True
        Me.Target2HitCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2HitCount.Location = New System.Drawing.Point(869, 266)
        Me.Target2HitCount.Name = "Target2HitCount"
        Me.Target2HitCount.Size = New System.Drawing.Size(26, 29)
        Me.Target2HitCount.TabIndex = 82
        Me.Target2HitCount.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(746, 265)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 29)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Hit Count:"
        '
        'Target2Timer
        '
        Me.Target2Timer.AutoSize = True
        Me.Target2Timer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2Timer.Location = New System.Drawing.Point(664, 266)
        Me.Target2Timer.Name = "Target2Timer"
        Me.Target2Timer.Size = New System.Drawing.Size(84, 29)
        Me.Target2Timer.TabIndex = 80
        Me.Target2Timer.Text = "00:000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(586, 265)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 29)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Timer:"
        '
        'Target2ToggleButton
        '
        Me.Target2ToggleButton.BackColor = System.Drawing.Color.Red
        Me.Target2ToggleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2ToggleButton.Location = New System.Drawing.Point(133, 258)
        Me.Target2ToggleButton.Margin = New System.Windows.Forms.Padding(2)
        Me.Target2ToggleButton.Name = "Target2ToggleButton"
        Me.Target2ToggleButton.Size = New System.Drawing.Size(108, 42)
        Me.Target2ToggleButton.TabIndex = 77
        Me.Target2ToggleButton.Tag = ""
        Me.Target2ToggleButton.Text = "Off"
        Me.Target2ToggleButton.UseVisualStyleBackColor = False
        '
        'Target2
        '
        Me.Target2.AutoSize = True
        Me.Target2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target2.Location = New System.Drawing.Point(12, 266)
        Me.Target2.Name = "Target2"
        Me.Target2.Size = New System.Drawing.Size(109, 29)
        Me.Target2.TabIndex = 78
        Me.Target2.Text = "Target 2:"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(507, 308)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(73, 38)
        Me.Button5.TabIndex = 96
        Me.Button5.Text = "Long"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(429, 308)
        Me.Button6.Margin = New System.Windows.Forms.Padding(2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(73, 38)
        Me.Button6.TabIndex = 95
        Me.Button6.Text = "Mid"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Gold
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(352, 308)
        Me.Button7.Margin = New System.Windows.Forms.Padding(2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(73, 38)
        Me.Button7.TabIndex = 94
        Me.Button7.Text = "Close"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(253, 312)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 29)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "Range:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(869, 312)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 29)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(746, 311)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 29)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Hit Count:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(664, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 29)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "00:000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(586, 311)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 29)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "Timer:"
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Red
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(133, 304)
        Me.Button8.Margin = New System.Windows.Forms.Padding(2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(108, 42)
        Me.Button8.TabIndex = 87
        Me.Button8.Tag = "Target1Toggle"
        Me.Button8.Text = "Off"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 312)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 29)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "Target 3:"
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(507, 354)
        Me.Button9.Margin = New System.Windows.Forms.Padding(2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(73, 38)
        Me.Button9.TabIndex = 106
        Me.Button9.Text = "Long"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(429, 354)
        Me.Button10.Margin = New System.Windows.Forms.Padding(2)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(73, 38)
        Me.Button10.TabIndex = 105
        Me.Button10.Text = "Mid"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Gold
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(352, 354)
        Me.Button11.Margin = New System.Windows.Forms.Padding(2)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(73, 38)
        Me.Button11.TabIndex = 104
        Me.Button11.Text = "Close"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(253, 358)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 29)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "Range:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(869, 358)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 29)
        Me.Label21.TabIndex = 102
        Me.Label21.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(746, 357)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 29)
        Me.Label22.TabIndex = 101
        Me.Label22.Text = "Hit Count:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(664, 358)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 29)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "00:000"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(586, 357)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 29)
        Me.Label24.TabIndex = 99
        Me.Label24.Text = "Timer:"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Red
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(133, 350)
        Me.Button12.Margin = New System.Windows.Forms.Padding(2)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(108, 42)
        Me.Button12.TabIndex = 97
        Me.Button12.Tag = "Target1Toggle"
        Me.Button12.Text = "Off"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 358)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(109, 29)
        Me.Label25.TabIndex = 98
        Me.Label25.Text = "Target 4:"
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(507, 400)
        Me.Button13.Margin = New System.Windows.Forms.Padding(2)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(73, 38)
        Me.Button13.TabIndex = 116
        Me.Button13.Text = "Long"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(429, 400)
        Me.Button14.Margin = New System.Windows.Forms.Padding(2)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(73, 38)
        Me.Button14.TabIndex = 115
        Me.Button14.Text = "Mid"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.Gold
        Me.Button15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.Location = New System.Drawing.Point(352, 400)
        Me.Button15.Margin = New System.Windows.Forms.Padding(2)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(73, 38)
        Me.Button15.TabIndex = 114
        Me.Button15.Text = "Close"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(253, 404)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(90, 29)
        Me.Label26.TabIndex = 113
        Me.Label26.Text = "Range:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(869, 404)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(26, 29)
        Me.Label27.TabIndex = 112
        Me.Label27.Text = "0"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(746, 403)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(117, 29)
        Me.Label28.TabIndex = 111
        Me.Label28.Text = "Hit Count:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(664, 404)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 29)
        Me.Label29.TabIndex = 110
        Me.Label29.Text = "00:000"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(586, 403)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(83, 29)
        Me.Label30.TabIndex = 109
        Me.Label30.Text = "Timer:"
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.Red
        Me.Button16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.Location = New System.Drawing.Point(133, 396)
        Me.Button16.Margin = New System.Windows.Forms.Padding(2)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(108, 42)
        Me.Button16.TabIndex = 107
        Me.Button16.Tag = "Target1Toggle"
        Me.Button16.Text = "Off"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 404)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(109, 29)
        Me.Label31.TabIndex = 108
        Me.Label31.Text = "Target 5:"
        '
        'TargetProjectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 571)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Target2FarBtn)
        Me.Controls.Add(Me.Target2MidBtn)
        Me.Controls.Add(Me.Target2NearBtn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Target2HitCount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Target2Timer)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Target2ToggleButton)
        Me.Controls.Add(Me.Target2)
        Me.Controls.Add(Me.ReconnectBtn)
        Me.Controls.Add(Me.ShooterDashBoardBtn)
        Me.Controls.Add(Me.ArduinoPort)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Target1FarBtn)
        Me.Controls.Add(Me.Target1MidBtn)
        Me.Controls.Add(Me.Target1NearBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RecordBtn)
        Me.Controls.Add(Me.Target1HitCount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Target1Timer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Target1ToggleButton)
        Me.Controls.Add(Me.Target1)
        Me.Controls.Add(Me.QuitBtn)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ShooterNameTBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TargetProjectForm"
        Me.Text = "Target Command Center V1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ShooterNameTBox As TextBox
    Friend WithEvents Target1FarBtn As Button
    Friend WithEvents Target1MidBtn As Button
    Friend WithEvents Target1NearBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents RecordBtn As Button
    Friend WithEvents Target1HitCount As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Target1Timer As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Target1ToggleButton As Button
    Friend WithEvents Target1 As Label
    Friend WithEvents QuitBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ArduinoPort As Label
    Friend WithEvents ShooterDashBoardBtn As Button
    Friend WithEvents ReconnectBtn As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CounterTimer As Timer
    Friend WithEvents HitCountDetector As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Target2FarBtn As Button
    Friend WithEvents Target2MidBtn As Button
    Friend WithEvents Target2NearBtn As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Target2HitCount As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Target2Timer As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Target2ToggleButton As Button
    Friend WithEvents Target2 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Button16 As Button
    Friend WithEvents Label31 As Label
End Class
