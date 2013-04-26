VERSION 5.00
Begin VB.Form PhoneSearch 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "电话号码查询"
   ClientHeight    =   2235
   ClientLeft      =   45
   ClientTop       =   735
   ClientWidth     =   6240
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2235
   ScaleWidth      =   6240
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame3 
      Height          =   735
      Left            =   4680
      TabIndex        =   14
      Top             =   0
      Width           =   1455
      Begin VB.CommandButton DeleteRec 
         BackColor       =   &H00000000&
         Caption         =   "删除记录"
         Height          =   275
         Left            =   120
         MaskColor       =   &H0080FFFF&
         TabIndex        =   16
         Top             =   120
         Width           =   1200
      End
      Begin VB.CommandButton UpdateRec 
         Caption         =   "更新记录"
         Height          =   275
         Left            =   120
         TabIndex        =   15
         Top             =   410
         Width           =   1200
      End
   End
   Begin VB.ListBox LocList 
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   960
      ItemData        =   "Phone.frx":0000
      Left            =   5280
      List            =   "Phone.frx":0002
      TabIndex        =   13
      Top             =   1080
      Width           =   735
   End
   Begin VB.ListBox SexList 
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   960
      ItemData        =   "Phone.frx":0004
      Left            =   1080
      List            =   "Phone.frx":0006
      TabIndex        =   10
      Top             =   1080
      Width           =   480
   End
   Begin VB.ListBox MailList 
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   960
      ItemData        =   "Phone.frx":0008
      Left            =   2400
      List            =   "Phone.frx":000A
      TabIndex        =   5
      Top             =   1080
      Width           =   2895
   End
   Begin VB.ListBox Extlist 
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   960
      ItemData        =   "Phone.frx":000C
      Left            =   1560
      List            =   "Phone.frx":000E
      TabIndex        =   4
      Top             =   1080
      Width           =   855
   End
   Begin VB.ListBox NameList 
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   960
      ItemData        =   "Phone.frx":0010
      Left            =   240
      List            =   "Phone.frx":0026
      TabIndex        =   3
      Top             =   1080
      Width           =   855
   End
   Begin VB.Frame Frame1 
      Height          =   735
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   4455
      Begin VB.CommandButton SearchRec 
         Caption         =   "查询"
         Height          =   375
         Left            =   3480
         TabIndex        =   2
         Top             =   240
         Width           =   855
      End
      Begin VB.TextBox InputText 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Width           =   3255
      End
   End
   Begin VB.Frame Frame2 
      Height          =   1455
      Left            =   120
      TabIndex        =   6
      Top             =   720
      Width           =   6015
      Begin VB.Label Label2 
         Caption         =   "地址"
         Height          =   255
         Index           =   2
         Left            =   5200
         TabIndex        =   17
         Top             =   120
         Width           =   615
      End
      Begin VB.Label Label2 
         Caption         =   " 性别"
         Height          =   255
         Index           =   0
         Left            =   960
         TabIndex        =   12
         Top             =   120
         Width           =   495
      End
      Begin VB.Label Label3 
         Caption         =   " 邮件地址"
         Height          =   255
         Index           =   1
         Left            =   2280
         TabIndex        =   9
         Top             =   120
         Width           =   1935
      End
      Begin VB.Label Label2 
         Caption         =   " 电话号码"
         Height          =   255
         Index           =   1
         Left            =   1440
         TabIndex        =   8
         Top             =   120
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   " 姓名"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   7
         Top             =   120
         Width           =   495
      End
   End
   Begin VB.Label Label1 
      Caption         =   " 姓名"
      Height          =   255
      Index           =   0
      Left            =   1080
      TabIndex        =   11
      Top             =   840
      Width           =   975
   End
   Begin VB.Menu Edit 
      Caption         =   "编辑(&E)"
      Begin VB.Menu Add 
         Caption         =   "添加(&A)"
      End
      Begin VB.Menu Delete 
         Caption         =   "删除(&D)"
      End
      Begin VB.Menu Separator 
         Caption         =   "-"
      End
      Begin VB.Menu Import 
         Caption         =   "导入(&I)"
      End
      Begin VB.Menu Export 
         Caption         =   "导出(&E)"
      End
      Begin VB.Menu Separator1 
         Caption         =   "-"
      End
      Begin VB.Menu Exit 
         Caption         =   "退出(&E)"
      End
   End
   Begin VB.Menu Tool 
      Caption         =   "工具(&T)"
      Begin VB.Menu BackupRec 
         Caption         =   "备份(&B)"
      End
      Begin VB.Menu RestoreRec 
         Caption         =   "恢复(&R)"
      End
      Begin VB.Menu Separator3 
         Caption         =   "-"
      End
      Begin VB.Menu Option 
         Caption         =   "选项(&O)"
      End
   End
   Begin VB.Menu Help 
      Caption         =   "帮助(&H)"
      Begin VB.Menu PhoneNO 
         Caption         =   "主机号(&P)"
      End
      Begin VB.Menu About 
         Caption         =   "关于(&A)"
      End
   End
End
Attribute VB_Name = "PhoneSearch"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim sSQLStr As String

Sub RemoveBackup()
Dim dbase As database
Dim rs As Recordset
Dim i As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from backup")

If rs.RecordCount <> 0 Then
    rs.MoveLast
    iTotal = rs.RecordCount
    
    rs.MoveFirst
    
    For i = 1 To iTotal
        rs.Delete
        rs.MoveNext
    Next i
End If

rs.Close
dbase.Close
End Sub

Sub BackRecord()
Dim dbase As database
Dim rs As Recordset
Dim rsTmp As Recordset
Dim i As Long
Dim iTotal As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from phone")

If rs.RecordCount <> 0 Then
    RemoveBackup
    
    rs.MoveLast
    iTotal = rs.RecordCount
    rs.MoveFirst
    
    Set rsTmp = dbase.OpenRecordset("select * from backup")
    
    For i = 1 To iTotal
        rsTmp.AddNew
        
        For j = 0 To 4
            rsTmp.Fields(j) = rs.Fields(j)
        Next j
        
        rsTmp.Update
        rs.MoveNext
    Next i
    
    rs.Close
    rsTmp.Close
    dbase.Close

End If

End Sub

Sub RestoreRecord()
Dim dbase As database
Dim rs As Recordset
Dim rsTmp As Recordset
Dim i As Long
Dim iTotal As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rsTmp = dbase.OpenRecordset("select * from backup")

If rsTmp.RecordCount <> 0 Then
    DeleteRecord
    
    rsTmp.MoveLast
    iTotal = rsTmp.RecordCount
    rsTmp.MoveFirst
    
    Set rs = dbase.OpenRecordset("select * from phone")
    
    For i = 1 To iTotal
        rs.AddNew
        
        For j = 0 To 4
            rs.Fields(j) = rsTmp.Fields(j)
        Next j
        
        rs.Update
        rsTmp.MoveNext
    Next i
    
    rs.Close
    rsTmp.Close
    dbase.Close
End If

End Sub

Sub DeleteRecord()
Dim dbase As database
Dim rs As Recordset
Dim rsTmp As Recordset
Dim iTotal As Long
Dim i As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from phone")

If rs.RecordCount <> 0 Then
    rs.MoveLast
    iTotal = rs.RecordCount
    rs.MoveFirst
    
    For i = 1 To iTotal
        rs.Delete
        rs.MoveNext
    Next i
    
    rs.Close
    dbase.Close
End If

End Sub

Private Sub About_Click()
frmAbout.Show vbModal
End Sub

Private Sub Add_Click()
AddMember.Show vbModal
End Sub

Private Sub BackupRec_Click()

If MsgBox("你确认备份现有记录么？", vbYesNo) = vbYes Then
    BackRecord
    MsgBox "备份完毕！"
End If

End Sub

Sub DisplayPhoneNumber()

PhoneDisplay.zpark.Text = "Not Set"
PhoneDisplay.fenghuo.Text = "Not Set"
PhoneDisplay.wuhan.Text = "Not Set"

PhoneDisplay.zpark.Locked = True
PhoneDisplay.fenghuo.Locked = True
PhoneDisplay.wuhan.Locked = True

PhoneDisplay.zpark.BackColor = &H8000000F
PhoneDisplay.fenghuo.BackColor = &H8000000F
PhoneDisplay.wuhan.BackColor = &H8000000F

PhoneDisplay.zpark.Appearance = 0
PhoneDisplay.fenghuo.Appearance = 0
PhoneDisplay.wuhan.Appearance = 0

PhoneDisplay.zpark.BorderStyle = 0
PhoneDisplay.fenghuo.BorderStyle = 0
PhoneDisplay.wuhan.BorderStyle = 0

PhoneDisplay.ModifyPhone.Visible = True
PhoneDisplay.ConfirmModify.Visible = False

End Sub


Private Sub PhoneNO_Click()
Dim dbase As database
Dim rs As Recordset
Dim iTotal As Long
Dim i As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from majorno")

DisplayPhoneNumber

If rs.RecordCount <> 0 Then
    rs.MoveLast
    iTotal = rs.RecordCount
    rs.MoveFirst
    
    For i = 1 To iTotal
        If rs.Fields(0).Value = "软件园" Then
            If rs.Fields(1).Value <> "" Then
                PhoneDisplay.zpark.Text = rs.Fields(1).Value
            End If
        Else
            If rs.Fields(0).Value = "烽火" Then
                If rs.Fields(1).Value <> "" Then
                    PhoneDisplay.fenghuo.Text = rs.Fields(1).Value
                End If
            Else
                If rs.Fields(0).Value = "武汉" Then
                    If rs.Fields(1).Value <> "" Then
                        PhoneDisplay.wuhan.Text = rs.Fields(1).Value
                    End If
                End If
            End If
        End If
        
        rs.MoveNext
    Next i
    
    rs.Close
    dbase.Close
End If

PhoneDisplay.Show vbModal
End Sub

Private Sub RestoreRec_Click()

If MsgBox("你确认要还原记录么？", vbYesNo) = vbYes Then
    RestoreRecord
    MsgBox "还原完毕!"
End If

End Sub

Private Sub Delete_Click()
Dim i As Long
Dim j As Long

If MsgBox("你确认要删除所有的记录么？", vbYesNo) = vbYes Then
    BackRecord
    DeleteRecord
End If
    
End Sub

Private Sub Export_Click()
Dim xlApp As Excel.Application
Dim xlBook As Excel.Workbook
Dim xlSheet As Excel.Worksheet
Dim i As Long
Dim iTotal As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from phone")
   
Set xlApp = CreateObject("Excel.Application")
xlApp.Visible = False

Set xlBook = xlApp.Workbooks.Add

Set xlSheet = xlBook.Worksheets.Add
xlSheet.Name = "电话列表"

For i = 1 To xlBook.Worksheets.Count
    If xlBook.Worksheets(i).Name <> "电话列表" Then
        xlBook.Worksheets(i).Delete
    End If
Next i

xlSheet.Columns(1).ColumnWidth = 13
xlSheet.Columns(4).ColumnWidth = 30

xlSheet.Cells(1, 1).Value = "姓名"
xlSheet.Cells(1, 2).Value = "性别"
xlSheet.Cells(1, 3).Value = "分机"
xlSheet.Cells(1, 4).Value = "邮件"
xlSheet.Cells(1, 5).Value = "地址"

If rs.RecordCount <> 0 Then
    rs.MoveLast
    iTotal = rs.RecordCount
    rs.MoveFirst
    
    For i = 1 To iTotal
        xlSheet.Cells(i + 1, 1).Value = rs.Fields(0).Value
        xlSheet.Cells(i + 1, 2).Value = rs.Fields(1).Value
        xlSheet.Cells(i + 1, 3).Value = rs.Fields(2).Value
        xlSheet.Cells(i + 1, 4).Value = rs.Fields(4).Value
        xlSheet.Cells(i + 1, 5).Value = rs.Fields(3).Value
        
        rs.MoveNext
    Next i
End If

If Dir(App.Path & "\电话列表.xls") <> "" Then
    Kill App.Path & "\电话列表.xls"
End If

xlBook.SaveAs App.Path & "\电话列表.xls"
xlApp.Visible = True

Set xlSheet = Nothing
Set xlBook = Nothing
Set xlApp = Nothing

rs.Close
dbase.Close

End Sub

Private Sub Import_Click()
ImportWindow.Show vbModal
End Sub

Private Sub Option_Click()
Dim db As database
Dim rs As Recordset

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from settings")

If rs.RecordCount <> 0 Then
    If rs.Fields(0).Value = "beijing" Then
        OptionWindow.dLoc(0).Value = True
    Else
        If rs.Fields(0).Value = "wuhan" Then
            OptionWindow.dLoc(1).Value = True
        Else
            If rs.Fields(0).Value = "bjwh" Then
                OptionWindow.dLoc(2).Value = True
            Else
                OptionWindow.dLoc(o).Value = True
                
                rs.Edit
                rs.Fields(0).Value = "beijing"
                rs.Update
            End If
        End If
    End If
Else
    OptionWindow.dLoc(0).Value = True
    
    rs.AddNew
    
    rs.Fields(0).Value = "beijing"
    rs.Update
End If

rs.Close
dbase.Close

OptionWindow.Show vbModal
End Sub


Private Sub UpdateRec_Click()
Dim i As Long
Dim iFlag As Boolean
Dim sqlstr As String

iFlag = False

If NameList.ListCount = 0 Then
    MsgBox "没有选定记录！"
Else
    For i = 0 To NameList.ListCount - 1
        If NameList.Selected(i) = True Then
            iFlag = True
            
            sqlstr = "select * from phone where name=" & "'" & NameList.List(i) & "'" & " and sex=" & "'" & SexList.List(i) & "'" & " and ext=" & "'" & Extlist.List(i) & "'" & " and mail=" & "'" & MailList.List(i) & "'" & " and location=" & "'" & LocList.List(i) & "'"
           
            EditMember.NameBox.Text = NameList.List(i)
            
            If SexList.List(i) = "男" Then
                EditMember.Sex(0).Value = True
            Else
                EditMember.Sex(1).Value = True
            End If
            
            EditMember.ExtBox.Text = Extlist.List(i)
            EditMember.MailBox.Text = Left(MailList.List(i), InStr(MailList.List(i), "@") - 1)
            
            If LocList.List(i) = "北京" Then
                EditMember.Location(0).Value = True
            Else
                EditMember.Location(1).Value = True
            End If
            
            EditMember.LocTmp.Caption = sqlstr
        End If
    Next i
    
    If iFlag = True Then
        EditMember.Show vbModal
    Else
        MsgBox "没有选定记录！"
    End If
        
End If

End Sub

Private Sub DeleteRec_Click()
Dim i As Long
Dim iFlag As Boolean
Dim sMsg As String
Dim sqlstr As String
Dim dbase As database
Dim rs As Recordset

iFlag = False

If NameList.ListCount = 0 Then
    MsgBox "没有选定记录!"
Else
    For i = 0 To NameList.ListCount - 1
        If NameList.Selected(i) = True Then
            iFlag = True
            sMsg = "确认要删除以下记录么？" & vbCrLf & vbCrLf & "姓名：" & NameList.List(i) & vbCrLf & "性别：" & SexList.List(i) & vbCrLf & "分机：" & Extlist.List(i) & vbCrLf & "邮件：" & MailList.List(i) & vbCrLf & "地址：" & LocList.List(i)
            sqlstr = "select * from phone where name=" & "'" & NameList.List(i) & "'" & " and sex=" & "'" & SexList.List(i) & "'" & " and ext=" & "'" & Extlist.List(i) & "'" & " and mail=" & "'" & MailList.List(i) & "'" & " and location=" & "'" & LocList.List(i) & "'"
        End If
    Next i
    
    If iFlag = True Then
        If MsgBox(sMsg, vbYesNo) = vbYes Then
            Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
            Set rs = dbase.OpenRecordset(sqlstr)
            
            If rs.RecordCount <> 0 Then
                rs.Delete
                RefreshData sSQLStr
            End If
            
            rs.Close
            dbase.Close
        End If
    Else
        MsgBox "没有选定记录!"
    End If
End If

End Sub

Private Sub Exit_Click()
Unload Me
End Sub

Private Sub SearchRec_Click()
Dim dbase As database
Dim rs As Recordset
Dim sText As String
Dim sLoc As String

If Trim(InputText.Text) = "" Then
    MsgBox "请输入查询条件！"
    Exit Sub
End If

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from settings")

If rs.RecordCount <> 0 Then
    If rs.Fields(0).Value = "beijing" Then
        sLoc = "北京"
    Else
        If rs.Fields(0).Value = "wuhan" Then
            sLoc = "武汉"
        Else
            If rs.Fields(0).Value = "bjwh" Then
                sLoc = ""
            Else
                sLoc = "北京"
            End If
        End If
    End If
Else
    sLoc = "北京"
End If
            
sText = LCase(Trim(InputText.Text))

If sLoc = "" Then
    sSQLStr = "select * from phone where name like ""*" & sText & "*""" & " or sex like ""*" & sText & "*""" & " or ext like ""*" & sText & "*""" & " or mail like ""*" & sText & "*"" "
Else
    sSQLStr = "select * from phone where (location= " & "'" & sLoc & "'" & ")" & " and (" & "name like ""*" & sText & "*""" & " or sex like ""*" & sText & "*""" & " or ext like ""*" & sText & "*""" & " or mail like ""*" & sText & "*""" & ")"
End If

RefreshData sSQLStr

rs.Close
dbase.Close

End Sub

Sub RefreshData(sSQLStr As String)
Dim dbase As database
Dim rs As Recordset
Dim iRec As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset(sSQLStr)

If rs.RecordCount = 0 Then
    MsgBox "没有匹配的结果！"
    Exit Sub
End If

rs.MoveLast
iRec = rs.RecordCount

If iRec > 20 Then
    MsgBox "结果太多，请重新设置查询条件！"
    Exit Sub
Else
    ChangScale iRec
End If

ClearContent
rs.MoveFirst

For i = 1 To iRec
    NameList.AddItem rs.Fields(0)
    SexList.AddItem rs.Fields(1)
    Extlist.AddItem rs.Fields(2)
    MailList.AddItem rs.Fields(4)
    LocList.AddItem rs.Fields(3)
    
    rs.MoveNext
Next i

rs.Close
dbase.Close
End Sub

Sub ChangScale(iRec As Long)
    If iRec > 4 Then
        NameList.Height = 960 + 230 * (iRec - 4)
        SexList.Height = 960 + 230 * (iRec - 4)
        Extlist.Height = 960 + 230 * (iRec - 4)
        MailList.Height = 960 + 230 * (iRec - 4)
        LocList.Height = 960 + 230 * (iRec - 4)
        
        Frame2.Height = 1455 + 230 * (iRec - 4)
        PhoneSearch.Height = 3000 + 230 * (iRec - 4)
    Else
        NameList.Height = 960
        SexList.Height = 960
        Extlist.Height = 960
        MailList.Height = 960
        LocList.Height = 960
        
        Frame2.Height = 1455
        PhoneSearch.Height = 3000
    End If
End Sub

Sub ClearContent()
NameList.Clear
SexList.Clear
Extlist.Clear
MailList.Clear
LocList.Clear
End Sub


Private Sub Form_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Private Sub namelist_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Private Sub sexlist_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Private Sub maillist_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Private Sub extlist_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Private Sub loclist_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Private Sub searchrec_KeyPress(KeyAscii As Integer)
ExitFun (KeyAscii)
End Sub

Sub ExitFun(iCode As Long)
If iCode = 27 Then
    Unload Me
End If
End Sub

Private Sub Form_Load()
ClearContent
End Sub

Private Sub InputText_KeyPress(KeyAscii As Integer)

If KeyAscii = 13 Then
    SearchRec_Click
Else
    ExitFun (KeyAscii)
End If

End Sub

Private Sub InputText_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
InputText.SelStart = 0
InputText.SelLength = 100
End Sub

Private Sub MailList_DblClick()
Dim sEmail As String

sEmail = MailList
InputText.Text = sEmail

End Sub


Private Sub NameList_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem NameList
End Sub

Private Sub sexList_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem SexList
End Sub

Private Sub extList_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem Extlist
End Sub

Private Sub mailList_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem MailList
End Sub

Private Sub loclist_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem LocList
End Sub

Private Sub NameList_Mouseup(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem NameList
End Sub

Private Sub sexList_Mouseup(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem SexList
End Sub

Private Sub extList_Mouseup(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem Extlist
End Sub

Private Sub mailList_Mouseup(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem MailList
End Sub

Private Sub loclist_Mouseup(Button As Integer, Shift As Integer, X As Single, Y As Single)
SelectItem LocList
End Sub

Private Sub nameList_KeyUp(KeyCode As Integer, Shift As Integer)
SelectItem NameList
End Sub

Private Sub sexList_KeyUp(KeyCode As Integer, Shift As Integer)
SelectItem SexList
End Sub

Private Sub extList_KeyUp(KeyCode As Integer, Shift As Integer)
SelectItem Extlist
End Sub

Private Sub MailList_KeyUp(KeyCode As Integer, Shift As Integer)
SelectItem MailList
End Sub

Private Sub loclist_KeyUp(KeyCode As Integer, Shift As Integer)
SelectItem LocList
End Sub

Private Sub nameList_Keydown(KeyCode As Integer, Shift As Integer)
SelectItem NameList
End Sub

Private Sub sexList_Keydown(KeyCode As Integer, Shift As Integer)
SelectItem SexList
End Sub

Private Sub extList_Keydown(KeyCode As Integer, Shift As Integer)
SelectItem Extlist
End Sub

Private Sub MailList_Keydown(KeyCode As Integer, Shift As Integer)
SelectItem MailList
End Sub

Private Sub loclist_Keydown(KeyCode As Integer, Shift As Integer)
SelectItem LocList
End Sub

Sub SelectItem(iObj As Object)
Dim iOrder As Long

iOrder = iObj.ListIndex

If iOrder >= 0 Then
    SexList.Selected(iOrder) = True
    Extlist.Selected(iOrder) = True
    MailList.Selected(iOrder) = True
    NameList.Selected(iOrder) = True
    LocList.Selected(iOrder) = True
End If
End Sub

