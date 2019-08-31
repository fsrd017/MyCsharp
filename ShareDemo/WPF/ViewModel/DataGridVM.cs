﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using LightMVVM;

namespace WPF.ViewModel
{
    /// <summary>
    /// DataGrid只支持显示如下类型：
    /// 字符串类型、Bool类型、Int\Double等数字类型;
    /// </summary>
    public class DataGridVM : MvvmBase
    {
        // 自定义的列名的VM层;
        private ColumnListName ColumnNameList;
        public ColumnListName m_ColumnNameList
        {   
            get { return ColumnNameList; }
            set
            {
                ColumnNameList = value;
                RaisePropertyChanged("ColumnNameList");
            }
        }

        //DataGrid的内容容器;
        private DataGridContent ColumnContent;
        public DataGridContent m_ColumnContent
        {
            get { return ColumnContent; }
            private set
            {
                ColumnContent = value;
                RaisePropertyChanged("ColumnContent");
                if(ColumnContent.m_content.Count > 1000)
                {
                    // 删除最开始的500条记录
                }
            }
        }
        
        public DataGridVM(List<string> column_list)
        {
            this.ColumnNameList = new ColumnListName();
            this.ColumnContent = new DataGridContent();
            this.ColumnNameList.m_list = column_list;
        }

    }

    /// <summary>
    /// 专门用来保存DataGrid列的类型;
    /// </summary>
    public class ColumnListName
    {
        public event EventHandler ListChanged;

        private List<string> list;
        public List<string> m_list
        {
            get;
            set;
        }

        // 添加;
        public void Add(string item)
        {
            m_list.Add(item);
            ListChanged(this, null);
        }
        
        // 删除;
        public void Clear()
        {
            m_list.Clear();
            ListChanged(this, null);
        }

        // 重新添加;
        public void CopyFrom(List<string> items)
        {
            m_list.Clear();
            foreach(string iter in items)
            {
                m_list.Add(iter);
            }
            ListChanged(this, null);
        }
    }

    /// <summary>
    /// 专门用来保存DataGrid内容的类型;
    /// </summary>
    public class DataGridContent
    {
        public event EventHandler ListChanged;
        public List<List<string>> m_content;

        public DataGridContent()
        {
            m_content = new List<List<string>>();
        }

        public void Add(List<string> item)
        {
            m_content.Add(item);
            ListChanged(this, null);
        }
    }

}
