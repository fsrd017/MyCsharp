/*
 * Locator�����𵽵�����;
 * 
 * 
  1:��App.xaml�����ȫ����Դ:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MvvmLightDemo" x:Key="Locator" />
  </Application.Resources>
  
  2:��ǰ�ˣ���MainWindow��DataContext�󶨸���Locator:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  3:���Լ��Ĺ��캯���У�ע����������ҪMvvmLight���Ƶ�VM�������;
  SimpleIoc.Default.Register<MainViewModel>();

  4:��һ�����Խ�View��ViewModel��������
  ��ǰ����࣬ʹ�õ���Main�������;
  
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace MvvmLightDemo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// ������͵��ô����ǰ��������е�View��ViewModel֮��Ĺ�����ʹ��View��ViewModel����ֱ������;
    /// 
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // ��Visual Studio�����Ԥ��Xaml�ļ���ʱ��������ע���������;
                SimpleIoc.Default.Register<MainViewModel>();
            }
            else
            {
                // ������ʱ��������ע���������;
                SimpleIoc.Default.Register<MainViewModel>();
            }

            // �����ʱ��Ĭ��������ע��Ϳ�����;
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            
        }

        /// <summary>
        /// �����Ӧ����View��DataContext��Ҫ����������;
        /// �������Main���ԣ���������View��ViewModel;
        /// DataContext="{Binding Source={StaticResource Locator}, Path=Main}
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MainPageViewModel MainPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}