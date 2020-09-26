<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShooterDashboardWindow
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
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.ShooterDataGrid = New System.Windows.Forms.DataGridView()
        Me.ShooterNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetRageColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecordTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HitCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ShooterDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OkBtn
        '
        Me.OkBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.OkBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkBtn.Location = New System.Drawing.Point(524, 600)
        Me.OkBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(118, 48)
        Me.OkBtn.TabIndex = 12
        Me.OkBtn.Text = "Ok"
        Me.OkBtn.UseVisualStyleBackColor = False
        '
        'ShooterDataGrid
        '
        Me.ShooterDataGrid.AllowUserToAddRows = False
        Me.ShooterDataGrid.AllowUserToDeleteRows = False
        Me.ShooterDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ShooterDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShooterNameColumn, Me.TargetNameColumn, Me.TargetRageColumn, Me.RecordTimeColumn, Me.HitCountColumn})
        Me.ShooterDataGrid.Location = New System.Drawing.Point(68, 145)
        Me.ShooterDataGrid.Name = "ShooterDataGrid"
        Me.ShooterDataGrid.RowHeadersWidth = 62
        Me.ShooterDataGrid.RowTemplate.Height = 28
        Me.ShooterDataGrid.Size = New System.Drawing.Size(1010, 437)
        Me.ShooterDataGrid.TabIndex = 11
        '
        'ShooterNameColumn
        '
        Me.ShooterNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ShooterNameColumn.HeaderText = "Shooter Name"
        Me.ShooterNameColumn.MinimumWidth = 8
        Me.ShooterNameColumn.Name = "ShooterNameColumn"
        '
        'TargetNameColumn
        '
        Me.TargetNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TargetNameColumn.HeaderText = "Target Name"
        Me.TargetNameColumn.MinimumWidth = 8
        Me.TargetNameColumn.Name = "TargetNameColumn"
        '
        'TargetRageColumn
        '
        Me.TargetRageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TargetRageColumn.HeaderText = "Target Range"
        Me.TargetRageColumn.MinimumWidth = 8
        Me.TargetRageColumn.Name = "TargetRageColumn"
        '
        'RecordTimeColumn
        '
        Me.RecordTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RecordTimeColumn.HeaderText = "Current Record Time"
        Me.RecordTimeColumn.MinimumWidth = 8
        Me.RecordTimeColumn.Name = "RecordTimeColumn"
        '
        'HitCountColumn
        '
        Me.HitCountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HitCountColumn.HeaderText = "Hit Count"
        Me.HitCountColumn.MinimumWidth = 8
        Me.HitCountColumn.Name = "HitCountColumn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(363, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 59)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Shooter's Record"
        '
        'ShooterDashboardWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 692)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.ShooterDataGrid)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ShooterDashboardWindow"
        Me.Text = "Shooter's Dashboard"
        CType(Me.ShooterDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OkBtn As Button
    Friend WithEvents ShooterDataGrid As DataGridView
    Friend WithEvents ShooterNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents TargetNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents TargetRageColumn As DataGridViewTextBoxColumn
    Friend WithEvents RecordTimeColumn As DataGridViewTextBoxColumn
    Friend WithEvents HitCountColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
End Class
