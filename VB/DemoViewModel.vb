Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace AddNewRow

    Public Class DemoViewModel
        Inherits INotifyPropertyChanged

        Private itemsSourceField As BindingList(Of TestData)

        Public Sub New()
            ItemsSource = GenerateData()
        End Sub

        Private Function GenerateData() As BindingList(Of TestData)
            Dim list As BindingList(Of TestData) = New BindingList(Of TestData)()
            For i As Integer = 0 To 5 - 1
                list.Add(CreateTestData(Guid.NewGuid().ToString(), "text2 " & i, "text3 " & i))
            Next

            Return list
        End Function

        Private Function CreateTestData(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String) As TestData
            Return New TestData() With {text1, text2, text3}
        End Function

        Public Property ItemsSource As BindingList(Of TestData)
            Get
                Return itemsSourceField
            End Get

            Set(ByVal value As BindingList(Of TestData))
                If value Is itemsSourceField Then Return
                itemsSourceField = value
                NotifyPropertyChanged("ItemsSource")
            End Set
        End Property

        Public Sub AddNewRow(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String)
            ItemsSource.Add(Me.CreateTestData(text1, text2, text3))
        End Sub

'#Region "INotifyPropertyChanged"
        Public Event PropertyChanged As PropertyChangedEventHandler

        Private Sub NotifyPropertyChanged(ByVal info As [String])
            RaiseEvent PropertyChangedEvent(Me, New PropertyChangedEventArgs(info))
        End Sub
'#End Region
    End Class

'#Region "Test data"
    Public Class TestData

        Public Property Text1 As String

        Public Property Text2 As String

        Public Property Text3 As String
    End Class
'#End Region
End Namespace
