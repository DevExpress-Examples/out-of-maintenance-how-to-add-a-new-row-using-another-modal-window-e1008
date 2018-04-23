using System;
using System.ComponentModel;
using System.Windows;

namespace AddNewRow {

    public partial class Window1 : Window {
        BindingList<TestData> list;

        public Window1() {
            InitializeComponent();

            #region Fill the GridControl with data
            list = new BindingList<TestData>();
            for (int i = 0; i < 5; i++) {
                list.Add(new TestData() {
                    Text1 = Guid.NewGuid().ToString(),
                    Text2 = "text2 " + i,
                    Text3 = "text3 " + i
                });
            }
            grid.ItemsSource = list;
            #endregion
        }

        private void addNewRowButton_Click(object sender, RoutedEventArgs e) {
            CreateNewRowWindow newRowWindow = new CreateNewRowWindow();
            newRowWindow.ShowDialog();
            if (newRowWindow.DialogResult.Value == true) {
                TestData newRow = new TestData() {
                    Text1 = newRowWindow.text1.Text,
                    Text2 = newRowWindow.text2.Text,
                    Text3 = newRowWindow.text3.Text
                };
                list.Add(newRow);

                view.MoveFocusedRow(grid.GetRowHandleByListIndex(list.Count - 1));

                grid.Focus();
            }
        }
    }

    #region Test data
    public class TestData {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
    }
    #endregion
}
