using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TreeListViewSample.Controls
{
    public class MyStyleSelector : StyleSelector
    {
        public Style Style1 { get; set; }
        public Style Style2 { get; set; }

        private int internalCounter = 1;
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Style stl;
            stl = internalCounter == 1 ? Style1 : Style2;

            if (++internalCounter > 2)
            {
                internalCounter = 1;
            }

            return stl;
        }
    }
}
