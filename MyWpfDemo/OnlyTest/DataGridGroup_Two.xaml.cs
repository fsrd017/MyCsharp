using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlyTest {

    /// <summary>
    /// DataGridGroup.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridGroupTwo : Window {

        private ObservableCollection<Model> data = new ObservableCollection<Model>();

        public DataGridGroupTwo()
        {
            InitializeComponent();

            dataGrid1.ItemsSource = data;
            for (int i = 0; i < 13; i++) {
                Model m = CreateModel("张" + i, i / 4 + "年级", (i % 2 == 0 ? "女" : "男"));
                data.Add(m);
            }
            ICollectionView vw = CollectionViewSource.GetDefaultView(data);
            vw.GroupDescriptions.Add(new PropertyGroupDescription("Sex"));
            vw.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }

        private Model CreateModel(string name, string cate, string sex)
        {
            Model model = new Model();
            model.Name = name;
            model.Category = cate;
            model.Sex = sex;
            return model;
        }
    }

}
