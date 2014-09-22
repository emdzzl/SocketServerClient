Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Net.Sockets
Imports System.Text
Imports System.Net

Public Class Form1
    Dim data As DataTable
    Dim da As MySqlDataAdapter
    Dim cb As MySqlCommandBuilder
    Dim conn As MySqlConnection
    Dim connStr = String.Format("server={0};user id={1}; password={2}; database=solverdb; pooling=false", _
                     "localhost", "root", "password")
   

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        textBox.Text = ""
        Try
            Dim stm As String = "UPDATE TACTIVITY SET VALUE = 0 WHERE CASEID = 001"
            Dim cmd As MySqlCommand = New MySqlCommand(stm, conn)
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Console.WriteLine("Error: " & ex.ToString())
        End Try
        LoadGrid()

    End Sub

    Private Sub LoadGrid()
        data = New DataTable
        da = New MySqlDataAdapter("SELECT CNAME,VALUE FROM TACTIVITY WHERE CASEID = 001", conn)
        cb = New MySqlCommandBuilder(da)
        da.Fill(data)
        DataGrid.DataSource = data
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        tbAddress.Text = "localhost"
        tbPort.Text = "4002"
        Try
            conn = New MySqlConnection(connStr)
            conn.Open()     'open the db connection only once for the app
        Catch ex As Exception
            textBox.Text = ""
            'show any connection error in textBox
            textBox.Text = textBox.Text & "Failed to Connect to database" & ex.Message & vbCr
        End Try
        If conn.State = ConnectionState.Open Then
            LoadGrid()
        End If
    End Sub

    Private Sub btnOptimize_Click_1(sender As Object, e As EventArgs) Handles btnOptimize.Click
        Dim END_MARK As String
        Dim Message As String
        Dim serverStream As NetworkStream
        Dim readData As String
        Static startTime As DateTime
        Static stopTime As DateTime
        Dim elapedTime As TimeSpan
        startTime = Now
        Dim clientSocket As New System.Net.Sockets.TcpClient()  ' create socket
        'setup message text
        END_MARK = "!"
        Message = "OPT1~root~password~MAX~Example~ssmith~001" & END_MARK
        textBox.Clear()
        'connect to server at address and port entred into textbox fields
        clientSocket.Connect(tbAddress.Text, Int(tbPort.Text))
        'stream to send data to server
        serverStream = clientSocket.GetStream()
        'Send Message To Server
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Message)
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
        Dim returndata As String = ""
        Do 'Receive loop
            serverStream = clientSocket.GetStream()   'stream to receive data from server
            Dim buffSize As Integer
            Dim inStream(10024) As Byte
            buffSize = clientSocket.ReceiveBufferSize
            serverStream.Read(inStream, 0, buffSize)    'read data from server
            returndata = System.Text.Encoding.ASCII.GetString(inStream)   'as ascii string
            readData = "" + returndata
            'textBox.Text = textBox.Text & returndata   ' add to textBox
            textBox.AppendText(returndata)
        Loop While String.Compare(returndata, "") <> 0 ' while returndata not blank
        serverStream.Close()   'dispose stream
        clientSocket.Close()   'destroy socket 
        LoadGrid()
        stopTime = Now
        elapedTime = stopTime.Subtract(startTime)
        textBox.Text = textBox.Text & "Elapsed Time:" & Str(elapedTime.Milliseconds) & " ms" & vbCr
    End Sub
End Class
