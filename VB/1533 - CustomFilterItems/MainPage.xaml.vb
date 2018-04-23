Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports DevExpress.Data.Filtering

Namespace _1533___CustomFilterItems
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			grid.ItemsSource = New AccountList().GetData()
		End Sub

		Private Sub TableView_ShowFilterPopup(ByVal sender As Object, ByVal e As FilterPopupEventArgs)
			If e.Column.FieldName <> "RegistrationDate" Then
				Return
			End If
			Dim filterItems As New List(Of Object)()
			filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "(All)", .EditValue = New CustomComboBoxItem()})
			filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "Registered in 2008", .EditValue = CriteriaOperator.Parse(String.Format("[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", New DateTime(2008, 1, 1), New DateTime(2009, 1, 1)))})
			filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "Registered in 2009", .EditValue = CriteriaOperator.Parse(String.Format("[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", New DateTime(2009, 1, 1), New DateTime(2010, 1, 1)))})
			e.ComboBoxEdit.ItemsSource = filterItems
		End Sub
	End Class

	Public Class AccountList
		Public Function GetData() As List(Of Account)
			Return CreateAccounts()
		End Function
		Private Function CreateAccounts() As List(Of Account)
			Dim list As New List(Of Account)()
			list.Add(New Account() With {.UserName = "Nick White", .RegistrationDate = DateTime.Today})
			list.Add(New Account() With {.UserName = "Jack Rodman", .RegistrationDate = New DateTime(2009, 5, 10)})
			list.Add(New Account() With {.UserName = "Sandra Sherry", .RegistrationDate = New DateTime(2008, 12, 22)})
			list.Add(New Account() With {.UserName = "Sabrina Vilk", .RegistrationDate = DateTime.Today})
			list.Add(New Account() With {.UserName = "Mike Pearson", .RegistrationDate = New DateTime(2008, 10, 18)})
			Return list
		End Function
	End Class
	Public Class Account
		Private privateUserName As String
		Public Property UserName() As String
			Get
				Return privateUserName
			End Get
			Set(ByVal value As String)
				privateUserName = value
			End Set
		End Property
		Private privateRegistrationDate As DateTime
		Public Property RegistrationDate() As DateTime
			Get
				Return privateRegistrationDate
			End Get
			Set(ByVal value As DateTime)
				privateRegistrationDate = value
			End Set
		End Property
	End Class
End Namespace
