Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace AddNewRow
	Public Class DemoViewModel
		Implements INotifyPropertyChanged
		Private itemsSource_Renamed As BindingList(Of TestData)
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
			Return New TestData() With {.Text1 = text1, .Text2 = text2, .Text3 = text3}
		End Function
		Public Property ItemsSource() As BindingList(Of TestData)
			Get
				Return itemsSource_Renamed
			End Get
			Set(ByVal value As BindingList(Of TestData))
				If value Is itemsSource_Renamed Then
					Return
				End If
				itemsSource_Renamed = value
				NotifyPropertyChanged("ItemsSource")
			End Set
		End Property

		Public Sub AddNewRow(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String)
			ItemsSource.Add(CreateTestData(text1, text2, text3))
		End Sub

		#Region "INotifyPropertyChanged"
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub NotifyPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub
		#End Region
	End Class

	#Region "Test data"
	Public Class TestData
		Private privateText1 As String
		Public Property Text1() As String
			Get
				Return privateText1
			End Get
			Set(ByVal value As String)
				privateText1 = value
			End Set
		End Property
		Private privateText2 As String
		Public Property Text2() As String
			Get
				Return privateText2
			End Get
			Set(ByVal value As String)
				privateText2 = value
			End Set
		End Property
		Private privateText3 As String
		Public Property Text3() As String
			Get
				Return privateText3
			End Get
			Set(ByVal value As String)
				privateText3 = value
			End Set
		End Property
	End Class
	#End Region
End Namespace
