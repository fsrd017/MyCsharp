using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DatagridTest : Window {

        private List<int[]> list = new List<int[]>();

        private ObservableCollection<int[]> showdata = new ObservableCollection<int[]>();

        public DatagridTest()
        {
            InitializeComponent();
            AddSource();
            GetComboBoxSource();
            GetShowData();
        }

        //---原始数据源到显示数据源
        private void GetShowData()
        {
            showdata.Clear();
            foreach (var a in list) {
                showdata.Add(a);
            }
            dtgShow.ItemsSource = showdata;
        }

        //---显示数据到原始数据
        private void GetRawData()
        {
            list.Clear();
            foreach (var a in showdata) {
                list.Add(a);
            }
        }

        //---添加 ComboBox 数据源
        private void GetComboBoxSource()
        {
            //cbbSelectMode 为 ComboBox 控件实例
            cbbSelectMode.Items.Add(DataGridSelectionUnit.Cell);
            cbbSelectMode.Items.Add(DataGridSelectionUnit.FullRow);
            cbbSelectMode.Items.Add(DataGridSelectionUnit.CellOrRowHeader);
            cbbSelectMode.SelectedIndex = 2;

        }

        //---DataGrid 选择方式
        private void cbbSelectMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgShow.SelectionUnit = (DataGridSelectionUnit)cbbSelectMode.SelectedValue;
        }

        //---添加 DataGrid 数据源
        private void AddSource()
        {
            list.Add(new int[] { 1, 2, 3, 4, 5 });
            list.Add(new int[] { 2, 3, 4, 5, 6 });
            list.Add(new int[] { 3, 4, 5, 6, 7 });

            int _col = list[0].Length;

            //int _row = list.Count;
            for (int i = 0; i < _col; i++) {
                dtgShow.Columns.Add(new DataGridTextColumn {
                    Width = (Width - 38) / _col,
                    Header = $"{(char)(65 + i)}",
                    Binding = new Binding($"[{i.ToString()}]")
                });
            }
        }

        //---自动添加行号
        private void dtgShow_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        //---Enter 达到 Tab 的效果
        private void dtgShow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter) {
                uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                e.Handled = true;
            }
        }

        //---给lbxData（ListBox） 添加数据
        private void GetListBoxSource()
        {
            lbxData.Items.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (var a in list) {
                sb.Clear();
                foreach (var b in a) {
                    sb.Append(b.ToString());
                    sb.Append(" ");
                }
                lbxData.Items.Add(sb.ToString());
            }
        }

        //---切换 DataGrid 和 ListBox
        private void chkResult_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.IsChecked == true) {
                dtgShow.Visibility = Visibility.Hidden;
                lbxData.Visibility = Visibility.Visible;
                GetRawData();
                GetListBoxSource();
            } else {
                lbxData.Visibility = Visibility.Hidden;
                dtgShow.Visibility = Visibility.Visible;
                GetShowData();
            }
        }

        //增加新行
        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            showdata.Add(new int[dtgShow.Columns.Count]);
        }

        //删除末行
        private void btnRemoveLast_Click(object sender, RoutedEventArgs e)
        {
            if (showdata.Count > 0) {
                showdata.RemoveAt(showdata.Count - 1);
            }
        }

        //---取得选中 Cell 所在的行列
        private bool GetCellXY(DataGrid dg, ref int rowIndex, ref int columnIndex)
        {
            var _cells = dg.SelectedCells;
            if (_cells.Any()) {
                rowIndex = dg.Items.IndexOf(_cells.First().Item);
                columnIndex = _cells.First().Column.DisplayIndex;
                return true;
            }
            return false;
        }

        //在选中 Cell 所在行上插入新行
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int _rowIndex = 0;
            int _columnIndex = 0;
            if (GetCellXY(dtgShow, ref _rowIndex, ref _columnIndex)) {
                showdata.Insert(_rowIndex, new int[dtgShow.Columns.Count]);
            }
        }

        //删除选中 Cell 所在行
        private void btnRemoveSelect_Click(object sender, RoutedEventArgs e)
        {
            int _rowIndex = 0;
            int _columnIndex = 0;
            if (GetCellXY(dtgShow, ref _rowIndex, ref _columnIndex)) {
                showdata.RemoveAt(_rowIndex);
            }
        }

        //---获取所有的选中cell 的值
        private string GetSelectedCellsValue(DataGrid dg)
        {
            var cells = dg.SelectedCells;
            StringBuilder sb = new StringBuilder();
            if (cells.Any()) {
                foreach (var cell in cells) {
                    sb.Append((cell.Column.GetCellContent(cell.Item) as TextBlock).Text);
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        //---显示选中单元格的值
        private void dtgShow_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            tbxSelect.Text = GetSelectedCellsValue(dtgShow);
        }
    }

}
