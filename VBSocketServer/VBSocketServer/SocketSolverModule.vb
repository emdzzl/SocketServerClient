'*****************************************************************************
'VB.NET Socket Server for Optimizer Client
'
'Example Usage: VBSocketServer 4002
'
'The expected incoming message is in the following format:
'
'END_MARK = '!'
'message = 'OPT1~myuserid~mypassword~MAX~Example~ssmith~001'+END_MARK
'
'This server will accept the message and echo it back to the client. Then it
'will parse the parameters and send the individual parameters back to the
'client.  This is for communication demonstration purposes.
'
'*****************************************************************************
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic

Module SocketServerModule
    Sub Main(ByVal sArgs() As String)
        Dim nPort As Integer
        'Handle command line arguments
        If sArgs.Length = 0 Then                'no arguments
            nPort = 4002 'default port
        Else                                    'we have an argument
            If sArgs.Length > 0 Then
                nPort = Int(sArgs(0))           'Example: C:\>VBSocketSover 4005, reads parameter 4005 as the port
            End If
        End If
        ' Set the TcpListener on port 
        Dim port As Int32 = nPort
        Dim localAddr As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim serverSocket As New TcpListener(localAddr, port)
        Dim clientSocket As TcpClient
        Dim counter As Integer
        serverSocket.Start()
        msg("Server Started")
        counter = 0
        While (True)
            counter += 1
            clientSocket = serverSocket.AcceptTcpClient()
            msg("Client Session :" + Convert.ToString(counter) + " processed")
            Dim client As New CHandleClient
            client.startClient(clientSocket, Convert.ToString(counter))
        End While
        'never gets here
        'clientSocket.Close()
        'serverSocket.Stop()
    End Sub
    Sub msg(ByVal mesg As String)
        mesg.Trim()
        Console.WriteLine(" >> " + mesg)
    End Sub
    Public Class CHandleClient
        Dim clientSocket As TcpClient
        Dim clNo As String
        Dim sCheckCode As String
        Dim sUserID As String
        Dim sPassword As String
        Dim sSense As String
        Dim sProbName As String
        Dim sUserName As String
        Dim sCaseID As String
        Dim sEndMark As String
        Public Sub startClient(ByVal inClientSocket As TcpClient, _
        ByVal clineNo As String)
            Me.clientSocket = inClientSocket
            Me.clNo = clineNo
            Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf HandleRequest)
            ctThread.Start()
        End Sub
        Private Sub SendToClient(Stream As NetworkStream, sMessage As String)
            sMessage = sMessage & vbCrLf   'important to add the CR and LF to string
            Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(sMessage)
            Stream.Write(outStream, 0, outStream.Length)
            Stream.Flush()
        End Sub
        Private Function ParseMessage(sMessage As String) As String
            Dim msg As String
            msg = Mid(sMessage, 1, InStr(sMessage, "!") - 1)
            Dim ParamsArray() As String = Split(msg, "~")
            sCheckCode = ParamsArray(0)
            sUserID = ParamsArray(1)
            sPassword = ParamsArray(2)
            sSense = ParamsArray(3)
            sProbName = ParamsArray(4)
            sUserName = ParamsArray(5)
            sCaseID = ParamsArray(6)
            ParseMessage = msg
        End Function
        Private Sub HandleRequest()
            Dim bytesFrom(1024) As Byte
            Dim dataFromClient As String
            Dim str As String
            Dim nSize As Integer
            Try
                Dim ns As NetworkStream = clientSocket.GetStream()
                nSize = CInt(clientSocket.ReceiveBufferSize)
                ReDim bytesFrom(nSize + 1)
                ns.Read(bytesFrom, 0, nSize)
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                str = ParseMessage(dataFromClient)
                'echo the clients message back to the server
                SendToClient(ns, str)
                'echo back the parameters after parsing the parameter from the client message
                If Mid(sCheckCode, 1, 3) = "OPT" Then  'valid incomming message
                    SendToClient(ns, "UserID=" & sUserID)
                    SendToClient(ns, "Password=" & sPassword)
                    SendToClient(ns, "Sense=" & sSense)
                    SendToClient(ns, "ProblemName=" & sProbName)
                    SendToClient(ns, "UserName=" & sUserName)
                    SendToClient(ns, "CaseID=" & sCaseID)
                    '***** LOAD THE DATABASE INTO YOUR SOLVER HERE ***** i.e. call a subroutine 
                    SendToClient(ns, "Loading Column Data from Database")
                    SendToClient(ns, "Loading Row Data from Database")
                    SendToClient(ns, "Loading Matrix Data from Database")
                    ns.Flush()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            clientSocket.Close()
        End Sub
    End Class
End Module


