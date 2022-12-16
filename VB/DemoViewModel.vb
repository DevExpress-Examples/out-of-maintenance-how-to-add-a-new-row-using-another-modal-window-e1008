Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace AddNewRow

    Public Class DemoViewModel
        Implements System.ComponentModel.INotifyPropertyChanged

        Private itemsSourceField As System.ComponentModel.BindingList(Of AddNewRow.TestData)

        Public Sub New()
            Me.ItemsSource = Me.GenerateData()
        End Sub

        Private Function GenerateData() As BindingList(Of AddNewRow.TestData)
            Dim list As System.ComponentModel.BindingList(Of AddNewRow.TestData) = New System.ComponentModel.BindingList(Of AddNewRow.TestData)()
            For i As Integer = 0 To 5 - 1
                list.Add(Me.CreateTestData(System.Guid.NewGuid().ToString(), "text2 " & i, "text3 " & i))
            Next

            Return list
        End Function

        Private Function CreateTestData(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String) As TestData
            Return New AddNewRow.TestData() With {.Text1 = text1, .Text2 = text2, .Text3 = text3}
        End Function

        Public Property ItemsSource As BindingList(Of AddNewRow.TestData)
            Get
                Return Me.itemsSourceField
            End Get

            Set(ByVal value As BindingList(Of AddNewRow.TestData))
                If value Is Me.itemsSourceField Then Return
                Me.itemsSourceField = value
                Me.NotifyPropertyChanged("ItemsSource")
            End Set
        End Property

        Public Sub AddNewRow(ByVal text1 As String, ByVal text2 As String, ByVal text3 As String)
            Me.ItemsSource.Add(Me.CreateTestData(text1, text2, text3))
        End Sub

'#Region "INotifyPropertyChanged"
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements Global.System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyPropertyChanged(ByVal info As System.[String])
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(info))
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
