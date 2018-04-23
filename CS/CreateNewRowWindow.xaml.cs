using System.Windows;

namespace AddNewRow {

    public partial class CreateNewRowWindow : Window {
        public CreateNewRowWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
            Close();
        }
    }
}
