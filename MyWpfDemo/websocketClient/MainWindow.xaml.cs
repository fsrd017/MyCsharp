using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace websocketClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string TextStr { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MywebSocket = new ClientWebSocket();
        }

        private void SendReq_Click(object sender, RoutedEventArgs e)
        {
            var url = "ws://192.168.0.102:60020/test/crte";

            if (MywebSocket == null)
            {
                MywebSocket = new ClientWebSocket();
                TextStr.Text = "new suc";
            }

            if (MywebSocket.State != WebSocketState.Open)
            {
                MywebSocket.ConnectAsync(new Uri(url), new System.Threading.CancellationToken());
                TextStr.Text = "ConnectAsync suc";
            }
        }

        public ClientWebSocket MywebSocket { get; set; }

        private void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            var bSend = new byte[32]; // = { 0x01, 0x02};
            for (int i = 0; i < 32; i++)
            {
                bSend[i] = 0x31;
            }

            if (MywebSocket.State == WebSocketState.Open)
            {
                MywebSocket.SendAsync(new ArraySegment<byte>(bSend), WebSocketMessageType.Text, true, new System.Threading.CancellationToken());
            }
            else
            {
                TextStr.Text = "send msg failed";
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (MywebSocket.State == WebSocketState.Open)
            {
                MywebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "close", new System.Threading.CancellationToken()); ;
                MywebSocket.Dispose();
                TextStr.Text = MywebSocket.State.ToString();
                MywebSocket = null;
            }
            else
            {
                TextStr.Text = "open failed";
            }
        }
    }
}
