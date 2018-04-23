using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AddNewRow {
    public class DemoViewModel : INotifyPropertyChanged {
        BindingList<TestData> itemsSource;
        public DemoViewModel() {
            ItemsSource = GenerateData();
        }
        BindingList<TestData> GenerateData() {
            BindingList<TestData> list = new BindingList<TestData>();
            for(int i = 0; i < 5; i++) {
                list.Add(CreateTestData(Guid.NewGuid().ToString(), "text2 " + i, "text3 " + i));
            }
            return list;
        }

        TestData CreateTestData(string text1, string text2, string text3) {
            return new TestData() {
                Text1 = text1,
                Text2 = text2,
                Text3 = text3
            };
        }
        public BindingList<TestData> ItemsSource {
            get { return itemsSource; }
            set {
                if(value == itemsSource)
                    return;
                itemsSource = value;
                NotifyPropertyChanged("ItemsSource");
            }
        }

        public void AddNewRow(string text1, string text2, string text3) {
            ItemsSource.Add(CreateTestData(text1, text2, text3));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }

    #region Test data
    public class TestData {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
    }
    #endregion
}
