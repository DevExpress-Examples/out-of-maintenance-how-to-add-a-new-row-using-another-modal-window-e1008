using System;
using System.ComponentModel;
using System.Windows;

namespace AddNewRow {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        public DemoViewModel ViewModel { get { return (DemoViewModel)DataContext; } }
        
        private void addNewRowButton_Click(object sender, RoutedEventArgs e) {
            CreateNewRowWindow newRowWindow = new CreateNewRowWindow();
            newRowWindow.ShowDialog();
            if (newRowWindow.DialogResult.Value == true) {
                ViewModel.AddNewRow(newRowWindow.text1.Text, newRowWindow.text2.Text, newRowWindow.text3.Text);
                view.MoveLastRow();
                grid.Focus();
            }
        }
    }
}