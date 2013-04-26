VERSION 5.00
Begin VB.Form OptionWindow 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "查询设置"
   ClientHeight    =   2310
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   2520
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2310
   ScaleWidth      =   2520
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame1 
      Height          =   1695
      Left            =   120
      TabIndex        =   2
      Top             =   0
      Width           =   2295
      Begin VB.OptionButton dLoc 
         Caption         =   "北京 和 武汉"
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
         TabIndex        =   6
         Top             =   1320
         Width           =   1935
      End
      Begin VB.OptionButton dLoc 
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
         Left            =   120
         TabIndex        =   5
         Top             =   960
         Width           =   1095
      End
      Begin VB.OptionButton dLoc 
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
         Left            =   120
         TabIndex        =   4
         Top             =   600
         Width           =   1095
      End
      Begin VB.Label Label1 
         Caption         =   "默认选择："
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
         TabIndex        =   3
         Top             =   240
         Width           =   1455
      End
   End
   Begin VB.CommandButton AddRec 
      Caption         =   "&OK"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   360
      TabIndex        =   1
      Top             =   1800
      Width           =   855
   End
   Begin VB.CommandButton CancelRec 
      Caption         =   "&Cancel"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1320
      TabIndex        =   0
      Top             =   1800
      Width           =   855
   End
End
Attribute VB_Name = "OptionWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub AddRec_Click()
Dim sLoc As String
Dim database As String
Dim rs As Recordset

If dLoc(0).Value = True Then
    sLoc = "beijing"
Else
    If dLoc(1).Value = True Then
        sLoc = "wuhan"
    Else
        sLoc = "bjwh"
    End If
End If

Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
Set rs = dbase.OpenRecordset("select * from settings")

If rs.RecordCount <> 0 Then
    rs.Edit
    rs.Fields(0) = sLoc
    rs.Update
Else
    rs.AddNew
    rs.Fields(0) = sLoc
    rs.Update
End If

rs.Close
dbase.Close

Unload Me

End Sub

Private Sub CancelRec_Click()
Unload Me
End Sub
