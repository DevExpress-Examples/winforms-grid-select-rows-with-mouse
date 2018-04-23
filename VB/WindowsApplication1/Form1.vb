Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
			gridView1.OptionsSelection.MultiSelect = True
			gridView1.OptionsBehavior.Editable = False
			gridView1.OptionsSelection.EnableAppearanceFocusedCell = False
		End Sub

		Private Sub SelectRows(ByVal view As GridView, ByVal startRow As Integer, ByVal endRow As Integer)
			If startRow > -1 AndAlso endRow > -1 Then
				view.BeginSelection()
				view.ClearSelection()
				view.SelectRange(startRow, endRow)
				view.EndSelection()
			End If
		End Sub

		Private Function GetRowAt(ByVal view As GridView, ByVal x As Integer, ByVal y As Integer) As Integer
			Return view.CalcHitInfo(New Point(x, y)).RowHandle
		End Function

		Private StartRowHandle As Integer = -1
		Private CurrentRowHandle As Integer = -1

		Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridView1.MouseDown
			StartRowHandle = GetRowAt(TryCast(sender, GridView), e.X, e.Y)
		End Sub

		Private Sub gridView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridView1.MouseMove
			Dim newRowHandle As Integer = GetRowAt(TryCast(sender, GridView), e.X, e.Y)
			If CurrentRowHandle <> newRowHandle Then
				CurrentRowHandle = newRowHandle
				SelectRows(TryCast(sender, GridView), StartRowHandle, CurrentRowHandle)
			End If
		End Sub

		Private Sub gridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridView1.MouseUp
			StartRowHandle = -1
			CurrentRowHandle = -1
		End Sub
	End Class
End Namespace