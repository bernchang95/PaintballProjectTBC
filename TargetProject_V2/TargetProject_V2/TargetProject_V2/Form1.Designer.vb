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
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(332, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(730, 82)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Target Control Center"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 174)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(259, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shooter Name:"
        '
        'ShooterNameTBox
        '
        Me.ShooterNameTBox.AcceptsReturn = True
        Me.ShooterNameTBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShooterNameTBox.Location = New System.Drawing.Point(346, 175)
        Me.ShooterNameTBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ShooterNameTBox.Name = "ShooterNameTBox"
        Me.ShooterNameTBox.Size = New System.Drawing.Size(614, 40)
        Me.ShooterNameTBox.TabIndex = 2
        '
        'Target1FarBtn
        '
        Me.Target1FarBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Target1FarBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1FarBtn.Location = New System.Drawing.Point(760, 332)
        Me.Target1FarBtn.Name = "Target1FarBtn"
        Me.Target1FarBtn.Size = New System.Drawing.Size(110, 58)
        Me.Target1FarBtn.TabIndex = 72
        Me.Target1FarBtn.Text = "Far"
        Me.Target1FarBtn.UseVisualStyleBackColor = False
        '
        'Target1MidBtn
        '
        Me.Target1MidBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Target1MidBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1MidBtn.Location = New System.Drawing.Point(644, 332)
        Me.Target1MidBtn.Name = "Target1MidBtn"
        Me.Target1MidBtn.Size = New System.Drawing.Size(110, 58)
        Me.Target1MidBtn.TabIndex = 71
        Me.Target1MidBtn.Text = "Mid"
        Me.Target1MidBtn.UseVisualStyleBackColor = False
        '
        'Target1NearBtn
        '
        Me.Target1NearBtn.BackColor = System.Drawing.Color.Gold
        Me.Target1NearBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1NearBtn.Location = New System.Drawing.Point(528, 332)
        Me.Target1NearBtn.Name = "Target1NearBtn"
        Me.Target1NearBtn.Size = New System.Drawing.Size(110, 58)
        Me.Target1NearBtn.TabIndex = 70
        Me.Target1NearBtn.Text = "Near"
        Me.Target1NearBtn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(380, 338)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 40)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Range:"
        '
        'RecordBtn
        '
        Me.RecordBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RecordBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecordBtn.Location = New System.Drawing.Point(236, 463)
        Me.RecordBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RecordBtn.Name = "RecordBtn"
        Me.RecordBtn.Size = New System.Drawing.Size(280, 74)
        Me.RecordBtn.TabIndex = 64
        Me.RecordBtn.Text = "Start Record"
        Me.RecordBtn.UseVisualStyleBackColor = False
        '
        'Target1HitCount
        '
        Me.Target1HitCount.AutoSize = True
        Me.Target1HitCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1HitCount.Location = New System.Drawing.Point(1304, 338)
        Me.Target1HitCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Target1HitCount.Name = "Target1HitCount"
        Me.Target1HitCount.Size = New System.Drawing.Size(37, 40)
        Me.Target1HitCount.TabIndex = 57
        Me.Target1HitCount.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1119, 337)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 40)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Hit Count:"
        '
        'Target1Timer
        '
        Me.Target1Timer.AutoSize = True
        Me.Target1Timer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1Timer.Location = New System.Drawing.Point(996, 339)
        Me.Target1Timer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Target1Timer.Name = "Target1Timer"
        Me.Target1Timer.Size = New System.Drawing.Size(127, 40)
        Me.Target1Timer.TabIndex = 55
        Me.Target1Timer.Text = "00:000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(879, 337)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 40)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Timer:"
        '
        'Target1ToggleButton
        '
        Me.Target1ToggleButton.BackColor = System.Drawing.Color.Red
        Me.Target1ToggleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1ToggleButton.Location = New System.Drawing.Point(200, 326)
        Me.Target1ToggleButton.Name = "Target1ToggleButton"
        Me.Target1ToggleButton.Size = New System.Drawing.Size(162, 65)
        Me.Target1ToggleButton.TabIndex = 50
        Me.Target1ToggleButton.Tag = "Target1Toggle"
        Me.Target1ToggleButton.Text = "Off"
        Me.Target1ToggleButton.UseVisualStyleBackColor = False
        '
        'Target1
        '
        Me.Target1.AutoSize = True
        Me.Target1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Target1.Location = New System.Drawing.Point(18, 338)
        Me.Target1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Target1.Name = "Target1"
        Me.Target1.Size = New System.Drawing.Size(161, 40)
        Me.Target1.TabIndex = 53
        Me.Target1.Text = "Target 1:"
        '
        'QuitBtn
        '
        Me.QuitBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.QuitBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitBtn.Location = New System.Drawing.Point(884, 463)
        Me.QuitBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.QuitBtn.Name = "QuitBtn"
        Me.QuitBtn.Size = New System.Drawing.Size(166, 74)
        Me.QuitBtn.TabIndex = 52
        Me.QuitBtn.Text = "Quit"
        Me.QuitBtn.UseVisualStyleBackColor = False
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SaveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(609, 463)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(174, 74)
        Me.SaveBtn.TabIndex = 51
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 255)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(271, 40)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Target Settings:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 597)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 29)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Connected to:"
        '
        'ArduinoPort
        '
        Me.ArduinoPort.AutoSize = True
        Me.ArduinoPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArduinoPort.Location = New System.Drawing.Point(192, 597)
        Me.ArduinoPort.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ArduinoPort.Name = "ArduinoPort"
        Me.ArduinoPort.Size = New System.Drawing.Size(21, 29)
        Me.ArduinoPort.TabIndex = 74
        Me.ArduinoPort.Text = "-"
        '
        'ShooterDashBoardBtn
        '
        Me.ShooterDashBoardBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ShooterDashBoardBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShooterDashBoardBtn.Location = New System.Drawing.Point(990, 175)
        Me.ShooterDashBoardBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ShooterDashBoardBtn.Name = "ShooterDashBoardBtn"
        Me.ShooterDashBoardBtn.Size = New System.Drawing.Size(340, 49)
        Me.ShooterDashBoardBtn.TabIndex = 75
        Me.ShooterDashBoardBtn.Text = "Shooters' Dashboard"
        Me.ShooterDashBoardBtn.UseVisualStyleBackColor = False
        '
        'ReconnectBtn
        '
        Me.ReconnectBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ReconnectBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReconnectBtn.Location = New System.Drawing.Point(282, 586)
        Me.ReconnectBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ReconnectBtn.Name = "ReconnectBtn"
        Me.ReconnectBtn.Size = New System.Drawing.Size(166, 49)
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
        'TargetProjectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1348, 642)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
End Class
