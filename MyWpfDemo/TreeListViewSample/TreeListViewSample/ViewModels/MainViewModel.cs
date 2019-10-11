using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using TreeListViewSample.Models;

namespace TreeListViewSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Staff> _StaffList = new ObservableCollection<Staff>();

        public ObservableCollection<Staff> StaffList
        {
            get { return _StaffList; }
            set
            {
                _StaffList = value;
                this.RaisePropertyChanged("StaffList");
            }
        }

        public MainViewModel()
        {
            Staff staff = new Staff()
            {
                Name = "张三",
                Age = 30,
                Sex = "男",
                Duty = "经理",
                IsExpanded = true
            };
            Staff staff2 = new Staff()
            {
                Name = "张三1",
                Age = 21,
                Sex = "男",
                Duty = "员工",
                IsExpanded = true
            };
            Staff staff3 = new Staff()
            {
                Name = "张三11",
                Age = 21,
                Sex = "男",
                Duty = "员工"
            };
            staff2.StaffList.Add(staff3);
            staff3 = new Staff()
            {
                Name = "张三22",
                Age = 21,
                Sex = "女",
                Duty = "员工"
            };
            staff2.StaffList.Add(staff3);
            staff.StaffList.Add(staff2);
            staff2 = new Staff()
            {
                Name = "张三2",
                Age = 22,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff()
            {
                Name = "张三3",
                Age = 23,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            StaffList.Add(staff);

            staff = new Staff()
            {
                Name = "李四",
                Age = 31,
                Sex = "男",
                Duty = "副经理"
            };
            staff2 = new Staff()
            {
                Name = "李四1",
                Age = 24,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff()
            {
                Name = "李四2",
                Age = 25,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff()
            {
                Name = "李四3",
                Age = 26,
                Sex = "男",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            StaffList.Add(staff);

            staff = new Staff()
            {
                Name = "王五",
                Age = 32,
                Sex = "女",
                Duty = "组长"
            };
            staff2 = new Staff()
            {
                Name = "王五1",
                Age = 27,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff()
            {
                Name = "王五2",
                Age = 28,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            StaffList.Add(staff);
        }

        public void ChangeNode1Value()
        {
            foreach (Staff staff in this.StaffList)
            {
                staff.Age += 1;
                staff.Sex = staff.Sex == "男" ? "女" : "男";
            }
        }

        public void ChangeNode2Value()
        {
            foreach (Staff staff in this.StaffList)
            {
                foreach (Staff staff2 in staff.StaffList)
                {
                    staff2.Age += 1;
                    staff2.Sex = staff2.Sex == "男" ? "女" : "男";
                }
            }
        }
    }
}
