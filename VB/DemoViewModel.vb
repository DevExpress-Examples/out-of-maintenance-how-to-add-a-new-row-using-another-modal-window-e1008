Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace AddNewRow
	Public Class DemoViewModel
		Implements INotifyPropertyChanged

'INSTANT VB NOTE: The field itemsSource was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private itemsSource_Conflict As BindingList(Of TestData)
		Public Sub New()
			ItemsSource = GenerateData()
		End Sub
		Private Function GenerateData() As BindingList(Of TestData)
			Dim list As New BindingList(Of TestData)()
			For i As Integer = 0 To 4
				list.Add(CreateTestData(Guid.NewGuid().ToString(), "text2 " & i, "text3 " & i))
			Next i
			Return list
		End Function

		Private Function CreateTestData(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String) As TestData
			Return New TestData() With {
				.Text1 = text1,
				.Text2 = text2,
				.Text3 = text3
			}
		End Function
		Public Property ItemsSource() As BindingList(Of TestData)
			Get
				Return itemsSource_Conflict
			End Get
			Set(ByVal value As BindingList(Of TestData))
				If value Is itemsSource_Conflict Then
					Return
				End If
				itemsSource_Conflict = value
				NotifyPropertyChanged("ItemsSource")
			End Set
		End Property

		Public Sub AddNewRow(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String)
			ItemsSource.Add(CreateTestData(text1, text2, text3))
		End Sub

		#Region "INotifyPropertyChanged"
		Public Event PropertyChanged As PropertyChangedEventHandler
		Private Sub NotifyPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub
		#End Region
	End Class

	#Region "Test data"
	Public Class TestData
		Public Property Text1() As String
		Public Property Text2() As String
		Public Property Text3() As String
	End Class
	#End Region
End Namespace
