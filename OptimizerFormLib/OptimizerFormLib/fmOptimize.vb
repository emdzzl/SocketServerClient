Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Net.Sockets
Imports System.Text
Imports System.Net

Public Class fmOptimize
    Dim m_sAddress As String
    Dim m_nPort As Integer
    Public Property Address As String
        Get
            Return m_sAddress
        End Get
        Set(value As String)
            m_sAddress = value
        End Set
    End Property
    Public Property Port As Integer
        Get
            Return m_nPort
        End Get
        Set(value As Integer)
            m_nPort = value
        End Set
    End Property
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_nPort = 4002
        m_sAddress = "127.0.0.1"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbAddress.Text = m_sAddress
        tbPort.Text = Str(m_nPort)
        btnOptimize.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnOptimze_Click(sender As Object, e As EventArgs) Handles btnOptimize.Click
        Dim END_MARK As String
        Dim Message As String
        Dim serverStream As NetworkStream
        Dim readData As String
        Dim sUserID As String
        'Static startTime As DateTime
        'Static stopTime As DateTime
        'Dim elapedTime As TimeSpan
        'startTime = Now
        sUserID = ModuleWinAPI.GetUserName
        Dim clientSocket As New System.Net.Sockets.TcpClient()  ' create socket
        'setup message text
        END_MARK = "!"
        Message = "OPT1~userid~password~MAX~Example~ssmith~001" & END_MARK
        Message = Replace(Message, "ssmith", sUserID)
        TextBox.Clear()
        'connect to server at address and port entred into textbox fields
        clientSocket.Connect(Address, Port)
        'stream to send data to server
        serverStream = clientSocket.GetStream()
        'Send Message To Server
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Message)
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
        Dim returndata As String = ""
        
        Do 
            'Receive loop
            Application.DoEvents()
            serverStream = clientSocket.GetStream()   'stream to receive data from server
            Dim buffSize As Integer
            Dim inStream(1024) As Byte
            buffSize = clientSocket.ReceiveBufferSize
            ReDim inStream(buffSize + 1)
            serverStream.Read(inStream, 0, buffSize)    'read data from server
            returndata = System.Text.Encoding.ASCII.GetString(inStream)   'as ascii string
            TextBox.AppendText(returndata)
        Loop While serverStream.DataAvailable
        
        serverStream.Close()   'dispose stream
        clientSocket.Close()   'destroy socket 
        'stopTime = Now
        'elapedTime = stopTime.Subtract(startTime)
        'TextBox.Text = TextBox.Text & "Elapsed Time:" & Str(elapedTime.Milliseconds) & " ms" & vbCr
    End Sub

End Class


