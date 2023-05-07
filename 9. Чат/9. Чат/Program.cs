using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _9.Чат
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5); //выстраиваем очередь из 5

            while (true)
            {
                var listener = tcpSocket.Accept(); //обрабатываем этого клиента
                var buffer = new byte[256]; //созраняем данные сюда, хранилище данных
                var size = 0;
                var data = new StringBuilder(); //собирает полученные данные

                do
                {
                    size = listener.Receive(buffer); //возвращаем значения
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size)); //перекодируем значения в строку
                }
                while (listener.Available > 0);

                Console.WriteLine(data);

                listener.Send(Encoding.UTF8.GetBytes("Успех"));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}
