Imports System.IO
Imports System.Text

'Shooter's Dashboard GUI

' What it does?
' Loads all previous records created in this GUI. The default file path is saved at "My Documents" folder.

' How the file is saved?
' After user clicks the "Save" button in the main window, the file called "ShooterDetails.csv" will be created. Subsequent saves will be added to the same file.

' This GUI is accessed by clicking the "Shooter's Dashboard" buttton in the main window.

Public Class ShooterDashboardWindow

    'Process invoker, run things in background to prevent the program from lagging.
    Private Delegate Sub UpdateData()
    'Finished function is here, and it is connected to RefreshGrid function
    Private ReadOnly Finished As New UpdateData(AddressOf RefreshGrid)

    'Invoked process, updates the data grid based on the data read from "ShooterDetails.csv"
    Private Sub RefreshGrid()
        ShooterDataGrid.Rows.Add()
    End Sub

    'Closes the dashboard GUI... nothing much.
    Private Sub OkBtn_Click(sender As Object, e As EventArgs) Handles OkBtn.Click
        ShooterDashboardWindow.ActiveForm.Close()
    End Sub

    'Function runs the moment this GUI is opened.
    Private Sub ShooterDashboardWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FilePath As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ShooterDetails.csv")
        Dim FileReader As New StreamReader(FilePath, Encoding.Default)
        Dim FileLine As String = ""

        'Read Imported CSV file here
        If File.Exists(FilePath) Then
            Do
                FileLine = FileReader.ReadLine()
                If FileLine Is Nothing Then
                    Exit Do
                End If

                Dim data() As String = FileLine.Split(",")
                Dim input As String()
                Dim ShooterName As String = ""
                Dim TargetName As String = ""
                Dim TargetRange As String = ""
                Dim Timer As String = ""
                Dim HitCount As String = ""

                'Records under similar names should be grouped together
                'To achieve that, program has to determine how many targets user has selected for shooting

                'Output format:-
                'Shooter Name, Target Name, Range Mode selected (Close, Middle, Long), Recorded time on how fast the user hits the target, Hit count to indicate score.
                'A sample .csv file can be found in the repository, please place it in your "My Documents" folder to observe how the results are displayed.
                For d = LBound(data) To UBound(data)
                    If d = 0 Then
                        'Shooter Name
                        ShooterName = data(d)
                    ElseIf d < 5 Then
                        'First target details
                        If InStr(data(d), "Target", vbTextCompare) <> 0 Then
                            'Target Name
                            TargetName = data(d)
                        ElseIf InStr(data(d), "Close", vbTextCompare) <> 0 Or
                        InStr(data(d), "Mid", vbTextCompare) <> 0 Or
                        InStr(data(d), "Long", vbTextCompare) <> 0 Then
                            'Target Range
                            TargetRange = data(d)
                        ElseIf InStr(data(d), ":", vbTextCompare) <> 0 Then
                            'Timer
                            Timer = data(d)
                        Else
                            'Hit Count
                            HitCount = data(d)
                            input = New String() {ShooterName, TargetName, TargetRange, Timer, HitCount}
                            ShooterDataGrid.Rows.Add(input)

                        End If
                    Else
                        'Second target or more, ensure it groups with the same shooter name
                        If InStr(data(d), "Target", vbTextCompare) <> 0 Then
                            'Target Name
                            TargetName = data(d)
                        ElseIf InStr(data(d), "Close", vbTextCompare) <> 0 Or
                        InStr(data(d), "Mid", vbTextCompare) <> 0 Or
                        InStr(data(d), "Long", vbTextCompare) <> 0 Then
                            'Target Range
                            TargetRange = data(d)
                        ElseIf InStr(data(d), ":", vbTextCompare) <> 0 Then
                            'Timer
                            Timer = data(d)
                        Else
                            'Hit Count
                            HitCount = data(d)
                            input = New String() {ShooterName, TargetName, TargetRange, Timer, HitCount}
                            ShooterDataGrid.Rows.Add(input)
                        End If
                    End If
                Next
            Loop

            FileReader.Close()
            Invoke(Finished) 'Triggers process invoker "Finished", runs the function "Finished"
        Else
            MsgBox("Shooter File not found! Please save some data first before opening the dashboard!", vbCritical, "No Data Found!")
        End If

    End Sub
End Class