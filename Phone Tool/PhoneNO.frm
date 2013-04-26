VERSION 5.00
Begin VB.Form PhoneDisplay 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "电话主机"
   ClientHeight    =   2160
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   3990
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2160
   ScaleWidth      =   3990
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton ConfirmModify 
      Caption         =   "确认(&C)"
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
      Left            =   720
      TabIndex        =   9
      Top             =   1680
      Width           =   975
   End
   Begin VB.Frame Frame1 
      Height          =   1455
      Left            =   120
      TabIndex        =   2
      Top             =   0
      Width           =   3735
      Begin VB.TextBox wuhan 
         Appearance      =   0  'Flat
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   320
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   8
         Text            =   "asd"
         Top             =   1000
         Width           =   2415
      End
      Begin VB.TextBox fenghuo 
         Appearance      =   0  'Flat
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   320
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   7
         Text            =   "asd"
         Top             =   640
         Width           =   2415
      End
      Begin VB.TextBox zpark 
         Appearance      =   0  'Flat
         BackColor       =   &H8000000F&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   320
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   3
         Text            =   "asd"
         Top             =   255
         Width           =   2415
      End
      Begin VB.Label Label1 
         Caption         =   "软件园："
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
         TabIndex        =   6
         Top             =   280
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "烽火："
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
         Index           =   2
         Left            =   120
         TabIndex        =   5
         Top             =   680
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "武汉："
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
         Index           =   3
         Left            =   120
         TabIndex        =   4
         Top             =   1035
         Width           =   855
      End
   End
   Begin VB.CommandButton ModifyPhone 
      Caption         =   "修改(&M)"
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
      Left            =   720
      TabIndex        =   1
      Top             =   1680
      Width           =   975
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
      Left            =   2040
      TabIndex        =   0
      Top             =   1680
      Width           =   975
   End
End
Attribute VB_Name = "PhoneDisplay"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub CancelRec_Click()
Unload Me
End Sub

Private Sub ConfirmModify_Click()
Dim dbase As database
Dim rs As Recordset
Dim i As Long
Dim iTotal As Long

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from majorno")

If rs.RecordCount <> 0 Then
    rs.MoveLast
    iTotal = rs.RecordCount
    rs.MoveFirst
    
    For i = 1 To iTotal
        rs.Delete
        rs.MoveNext
    Next i
End If

Set rs = dbase.OpenRecordset("select * from majorno")

rs.AddNew
rs.Fields(0).Value = "软件园"
rs.Fields(1).Value = Trim(zpark.Text)
rs.Update

rs.AddNew
rs.Fields(0).Value = "烽火"
rs.Fields(1).Value = Trim(fenghuo.Text)
rs.Update

rs.AddNew
rs.Fields(0).Value = "武汉"
rs.Fields(1).Value = Trim(wuhan.Text)
rs.Update

rs.Close
dbase.Close

Unload Me

End Sub

Private Sub ModifyPhone_Click()
ModifyPhoneNo
End Sub

Sub ModifyPhoneNo()

PhoneDisplay.zpark.Locked = False
PhoneDisplay.fenghuo.Locked = False
PhoneDisplay.wuhan.Locked = False

PhoneDisplay.zpark.BackColor = &H8000000E
PhoneDisplay.fenghuo.BackColor = &H8000000E
PhoneDisplay.wuhan.BackColor = &H8000000E

PhoneDisplay.zpark.Appearance = 1
PhoneDisplay.fenghuo.Appearance = 1
PhoneDisplay.wuhan.Appearance = 1

PhoneDisplay.zpark.BorderStyle = 1
PhoneDisplay.fenghuo.BorderStyle = 1
PhoneDisplay.wuhan.BorderStyle = 1

PhoneDisplay.ModifyPhone.Visible = False
PhoneDisplay.ConfirmModify.Visible = True
End Sub
