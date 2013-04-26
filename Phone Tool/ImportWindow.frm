VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form ImportWindow 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "导入记录"
   ClientHeight    =   1770
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1770
   ScaleWidth      =   4680
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3840
      Top             =   960
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton CacelRec 
      Caption         =   "取消(&C)"
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
      Left            =   2520
      TabIndex        =   4
      Top             =   1200
      Width           =   855
   End
   Begin VB.CommandButton ImportRec 
      Caption         =   "导入(&I)"
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
      Left            =   960
      TabIndex        =   3
      Top             =   1200
      Width           =   855
   End
   Begin VB.Frame Frame1 
      Height          =   735
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   4455
      Begin VB.TextBox Addr 
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
         Locked          =   -1  'True
         TabIndex        =   2
         Top             =   240
         Width           =   3255
      End
      Begin VB.CommandButton OpenRec 
         Caption         =   "打开"
         Height          =   375
         Left            =   3480
         TabIndex        =   1
         Top             =   240
         Width           =   855
      End
   End
   Begin VB.Label Label1 
      Caption         =   "注意：导入时原来所有的记录将会被删除！"
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   840
      Width           =   4455
   End
End
Attribute VB_Name = "ImportWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub CacelRec_Click()
Unload Me
End Sub

Private Sub ImportRec_Click()
Dim xlApp As Excel.Application
Dim xlBook As Excel.Workbook
Dim xlSheet As Excel.Worksheet
Dim i As Long
Dim iFlag As Boolean
Dim iTotal As Long

Dim dbase As database
Dim rs As Recordset
Dim rsTmp As Recordset

If Trim(Addr.Text) = "" Then
    MsgBox "请选择需要导入的文件！"
Else
    If Dir(Addr.Text) = "" Then
        MsgBox "文件不存在！"
    Else
        Set xlApp = CreateObject("Excel.Application")
        xlApp.Visible = False
        Set xlBook = xlApp.Workbooks.Open(Addr.Text)
        
        iFlag = False
        
        For i = 1 To xlBook.Worksheets.Count
            If xlBook.Worksheets(i).Name = "电话列表" Then
                iFlag = True
                Set xlSheet = xlBook.Worksheets(i)
            End If
        Next i
        
        If iFlag = False Then
            MsgBox "请检查文件是否正确！" & vbCrLf & "格式必须和导出文件一致。"
            xlBook.Close
            
            Set xlSheet = Nothing
            Set xlBook = Nothing
            Set xlApp = Nothing
            
            Exit Sub
        Else
            If Trim(xlSheet.Cells(2, 1).Value) = "" Then
                MsgBox "没有记录!"
                xlBook.Close
                
                Set xlSheet = Nothing
                Set xlBook = Nothing
                Set xlApp = Nothing
                
                Exit Sub
            Else
                PhoneSearch.BackRecord
                PhoneSearch.DeleteRecord
                
                Set dbase = OpenDatabase(App.Path & "/PhoneList.mdb")
                Set rs = dbase.OpenRecordset("select * from phone")
                
                For i = 2000 To 1 Step -1
                    If Trim(xlSheet.Cells(i, 1).Value) <> "" Then
                        iTotal = i
                        Exit For
                    End If
                Next i
                
                For i = 2 To iTotal
                    If Trim(xlSheet.Cells(i, 1).Value) <> "" Then
                        rs.AddNew
                        rs.Fields(0).Value = Trim(xlSheet.Cells(i, 1).Value)
                        rs.Fields(1).Value = Trim(xlSheet.Cells(i, 2).Value)
                        rs.Fields(2).Value = Trim(xlSheet.Cells(i, 3).Value)
                        rs.Fields(3).Value = Trim(xlSheet.Cells(i, 5).Value)
                        rs.Fields(4).Value = Trim(xlSheet.Cells(i, 4).Value)
                        rs.Update
                    End If
                Next i
                
                MsgBox "导入完成!"
                
                xlBook.Close
                
                Set xlSheet = Nothing
                Set xlBook = Nothing
                Set xlApp = Nothing
                
                Unload Me
            End If
        End If
        
    End If
End If
        
End Sub

Private Sub OpenRec_Click()
CommonDialog1.DialogTitle = "请选择需要导入的文件："
CommonDialog1.Filter = "Excel|*.xls"
CommonDialog1.ShowOpen

Addr.Text = CommonDialog1.FileName
End Sub
