Imports System
Imports System.ComponentModel
Imports System.Windows

Namespace AddNewRow

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property ViewModel As DemoViewModel
            Get
                Return CType(DataContext, DemoViewModel)
            End Get
        End Property

        Private Sub addNewRowButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim newRowWindow As CreateNewRowWindow = New CreateNewRowWindow()
            newRowWindow.ShowDialog()
            If newRowWindow.DialogResult.Value Is True Then
                ViewModel.AddNewRow(newRowWindow.text1.Text, newRowWindow.text2.Text, newRowWindow.text3.Text)
                view.MoveLastRow()
                grid.Focus()
            End If
        End Sub
    End Class
End Namespace
