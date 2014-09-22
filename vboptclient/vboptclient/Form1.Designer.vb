<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.tbPort = New System.Windows.Forms.TextBox()
        Me.textBox = New System.Windows.Forms.RichTextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnOptimize = New System.Windows.Forms.Button()
        Me.DataGrid = New System.Windows.Forms.DataGridView()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(464, 17)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(58, 49)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblAddress.TabIndex = 1
        Me.lblAddress.Text = "Address"
        '
        'tbAddress
        '
        Me.tbAddress.Location = New System.Drawing.Point(144, 41)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(243, 20)
        Me.tbAddress.TabIndex = 2
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(58, 80)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 13)
        Me.lblPort.TabIndex = 3
        Me.lblPort.Text = "Port"
        '
        'tbPort
        '
        Me.tbPort.Location = New System.Drawing.Point(144, 80)
        Me.tbPort.Name = "tbPort"
        Me.tbPort.Size = New System.Drawing.Size(100, 20)
        Me.tbPort.TabIndex = 4
        '
        'textBox
        '
        Me.textBox.Location = New System.Drawing.Point(61, 147)
        Me.textBox.Name = "textBox"
        Me.textBox.Size = New System.Drawing.Size(405, 304)
        Me.textBox.TabIndex = 6
        Me.textBox.Text = "Optimization Results Go Here"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(464, 70)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnOptimize
        '
        Me.btnOptimize.Location = New System.Drawing.Point(61, 113)
        Me.btnOptimize.Name = "btnOptimize"
        Me.btnOptimize.Size = New System.Drawing.Size(368, 28)
        Me.btnOptimize.TabIndex = 8
        Me.btnOptimize.Text = "Optimize"
        Me.btnOptimize.UseVisualStyleBackColor = True
        '
        'DataGrid
        '
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGrid.Location = New System.Drawing.Point(61, 457)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.Size = New System.Drawing.Size(405, 100)
        Me.DataGrid.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 569)
        Me.Controls.Add(Me.DataGrid)
        Me.Controls.Add(Me.btnOptimize)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.textBox)
        Me.Controls.Add(Me.tbPort)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.tbAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client for Remote Solver"
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents tbPort As System.Windows.Forms.TextBox
    Friend WithEvents textBox As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnOptimize As System.Windows.Forms.Button
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView

End Class
