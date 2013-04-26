VERSION 5.00
Begin VB.Form AddMember 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "添加记录"
   ClientHeight    =   3060
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   4590
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3060
   ScaleWidth      =   4590
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame2 
      Height          =   530
      Left            =   120
      TabIndex        =   15
      Top             =   1800
      Width           =   4335
      Begin VB.OptionButton Location 
         Caption         =   "武汉"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   1
         Left            =   2160
         TabIndex        =   18
         Top             =   200
         Width           =   975
      End
      Begin VB.OptionButton Location 
         Caption         =   "北京"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   960
         TabIndex        =   17
         Top             =   200
         Width           =   975
      End
      Begin VB.Label Label1 
         Caption         =   "地点："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   8
         Left            =   120
         TabIndex        =   16
         Top             =   210
         Width           =   855
      End
   End
   Begin VB.CommandButton CancelRec 
      Caption         =   "取消(&C)"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2400
      TabIndex        =   12
      Top             =   2520
      Width           =   975
   End
   Begin VB.CommandButton AddRec 
      Caption         =   "添加(&A)"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   11
      Top             =   2520
      Width           =   975
   End
   Begin VB.Frame Frame1 
      Height          =   1815
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   4335
      Begin VB.TextBox MailBox 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   960
         TabIndex        =   9
         Top             =   1300
         Width           =   1335
      End
      Begin VB.TextBox ExtBox 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   960
         TabIndex        =   7
         Top             =   915
         Width           =   2895
      End
      Begin VB.OptionButton Sex 
         Caption         =   "女"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Index           =   1
         Left            =   2040
         TabIndex        =   5
         Top             =   580
         Width           =   975
      End
      Begin VB.OptionButton Sex 
         Caption         =   "男"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Index           =   0
         Left            =   960
         TabIndex        =   4
         Top             =   580
         Width           =   975
      End
      Begin VB.TextBox NameBox 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   960
         TabIndex        =   1
         Top             =   210
         Width           =   2895
      End
      Begin VB.Label Label1 
         Caption         =   "**"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   255
         Index           =   6
         Left            =   3960
         TabIndex        =   14
         Top             =   960
         Width           =   255
      End
      Begin VB.Label Label1 
         Caption         =   "**"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   255
         Index           =   5
         Left            =   3960
         TabIndex        =   13
         Top             =   240
         Width           =   255
      End
      Begin VB.Label Label1 
         Caption         =   "@beyondsoft.com"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   4
         Left            =   2400
         TabIndex        =   10
         Top             =   1305
         Width           =   1695
      End
      Begin VB.Label Label1 
         Caption         =   "邮件："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   3
         Left            =   120
         TabIndex        =   8
         Top             =   1350
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "分机："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   2
         Left            =   120
         TabIndex        =   6
         Top             =   970
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "性别："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Index           =   1
         Left            =   120
         TabIndex        =   3
         Top             =   600
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "姓名："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   2
         Top             =   260
         Width           =   855
      End
   End
End
Attribute VB_Name = "AddMember"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub AddRec_Click()
Dim sqlstr As String
Dim sMsg As String
Dim dbase As Database
Dim rs As Recordset

Dim sName As String
Dim sSex As String
Dim sExt As String
Dim sEmail As String
Dim sLoc As String

sName = Trim(NameBox.Text)

If Sex(0).Value = True Then
    sSex = "男"
Else
    sSex = "女"
End If

sExt = Trim(ExtBox.Text)

If LCase(Trim(MailBox.Text)) <> "" Then
    sEmail = LCase(Trim(MailBox.Text)) & "@beyondsoft.com"
Else
    sEmail = "NO EMAIL"
End If

If Location(0).Value = True Then
    sLoc = "北京"
Else
    sLoc = "武汉"
End If

If InputCheck = 1 Then
    sqlstr = "select * from phone where name=" & "'" & sName & "'"
 
    Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
    Set rs = dbase.OpenRecordset(sqlstr)
    
    If rs.RecordCount <> 0 Then
        sMsg = "该姓名已存在：" & vbCrLf & "姓名：" & rs(0).Value & vbCrLf & "性别：" & rs(1).Value & vbCrLf & "分机：" & rs(2).Value & vbCrLf & "邮件：" & rs(3).Value & vbCrLf & vbCrLf & "是否覆盖？"
        
        If MsgBox(sMsg, vbYesNo) = vbYes Then
            rs.Edit
            
            rs.Fields(0).Value = sName
            rs.Fields(1).Value = sSex
            rs.Fields(2).Value = sExt
            rs.Fields(4).Value = sEmail
            rs.Fields(3).Value = sLoc
            
            rs.Update
        End If
    Else
        rs.AddNew
        rs.Fields(0).Value = sName
        rs.Fields(1).Value = sSex
        rs.Fields(2).Value = sExt
        rs.Fields(4).Value = sEmail
        rs.Fields(3).Value = sLoc
        
        rs.Update
    End If
    
    rs.Close
    dbase.Close
    
    Unload Me
End If

End Sub

Function InputCheck() As Long
Dim iFlag As Long

iFlag = 1

If Trim(NameBox.Text) = "" Or Trim(ExtBox.Text) = "" Then
    MsgBox "姓名或电话号码缺失！"
    iFlag = 0
Else
    If Len(Trim(ExtBox.Text)) > 4 Or IsNumeric(ExtBox.Text) = False Then
        MsgBox "非法分机号！"
        iFlag = 0
    Else
        If EmailCheck(LCase(Trim(MailBox.Text))) = False Then
            MsgBox "非法邮件地址！"
            iFlag = 0
        End If
    End If
End If

InputCheck = iFlag
End Function

Function EmailCheck(sName As String) As Boolean
Dim i As Long
Dim sText As String
Dim iFlag As Boolean

iFlag = True

If sName <> "" Then
   
    For i = 1 To Len(sName)
        sText = Mid(sName, i, 1)
        
        If Asc(sText) < 95 Or Asc(sText) > 122 Or Asc(sText) = 96 Then
            iFlag = False
        End If
    Next i
End If

EmailCheck = iFlag

End Function

Private Sub CancelRec_Click()
Unload Me
End Sub

Private Sub Form_Load()
Sex(0).Value = True
Location(0).Value = True
End Sub
