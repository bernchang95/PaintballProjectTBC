Imports System.IO
Imports System.Text

Public Class ShooterDashboardWindow

    Private Delegate Sub UpdateData()
    Private ReadOnly Finished As New UpdateData(AddressOf RefreshGrid)

    Private Sub RefreshGrid()
        ShooterDataGrid.Rows.Add()
    End Sub

    Private Sub OkBtn_Click(sender As Object, e As EventArgs) Handles OkBtn.Click
        ShooterDashboardWindow.ActiveForm.Close()
    End Sub

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
                For d = LBound(data) To UBound(data)
                    If d = 0 Then
                        'Shooter Name
                        ShooterName = data(d)
                    ElseIf d < 5 Then
                        'First target details
                        If InStr(data(d), "Target", vbTextCompare) <> 0 Then
                            'Target Name
                            TargetName = data(d)
                        ElseIf InStr(data(d), "Near", vbTextCompare) <> 0 Or
                        InStr(data(d), "Mid", vbTextCompare) <> 0 Or
                        InStr(data(d), "Far", vbTextCompare) <> 0 Then
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
                        ElseIf InStr(data(d), "Near", vbTextCompare) <> 0 Or
                        InStr(data(d), "Mid", vbTextCompare) <> 0 Or
                        InStr(data(d), "Far", vbTextCompare) <> 0 Then
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
            Invoke(Finished)
        Else
            MsgBox("Shooter File not found! Please save some data first before opening the dashboard!", vbCritical, "No Data Found!")
        End If

    End Sub
End Class