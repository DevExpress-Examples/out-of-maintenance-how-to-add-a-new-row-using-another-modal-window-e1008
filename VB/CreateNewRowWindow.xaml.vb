Imports Microsoft.VisualBasic
Imports System.Windows

Namespace AddNewRow

	Partial Public Class CreateNewRowWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			DialogResult = True
			Close()
		End Sub
	End Class
End Namespace
