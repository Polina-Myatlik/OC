using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _9._2_Клиент
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообщение:");
            var message = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(message); //получили данные

            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data); //отправили сообщение

            var buffer = new byte[256]; //созраняем данные сюда, хранилище данных
            var size = 0;
            var answer = new StringBuilder(); //собирает полученные данные

            do
            {
                size = tcpSocket.Receive(buffer); //возвращаем значения
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); //перекодируем значения в строку
            }
            while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}
