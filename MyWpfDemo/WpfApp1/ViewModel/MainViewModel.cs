using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong> mvvminpc </strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //BUG
        public MainViewModel()
        {
            OnButtonCommand = new RelayCommand(ButtonCommand);
            AddStringToList = new RelayCommand(AddString);
        }

        public RelayCommand AddStringToList { get; set; }

        public List<string> ListSource
        {
            get { return M_ListSource; }
            set { Set(ref M_ListSource, value); }
        }

        public int Num { get; set; } = 0;

        /// <summary>
        /// button click ´¦Àí
        /// </summary>
        public RelayCommand OnButtonCommand { get; set; }

        public string TextStr
        {
            get { return sTextStr; }
            set { Set(ref sTextStr, value); }
        }

        private List<string> M_ListSource = new List<string>();

        private string sTextStr = "444444444444";

        public void Test()
        {
        }

        private void ButtonCommand()
        {
            TextStr = $"ButtonCommand + {Num++}";
        }

        private void AddString()
        {
            ListSource.Add("test ¿×ÏéÀ×");
        }

        private void test32()
        {
        }
    }
}
