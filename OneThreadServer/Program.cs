using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace OneThreadServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Однопоточный сервер запущен!");
            //Подготавливаем конечную точку сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");//подобнее о хост энтри
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddr, 8888);//подобнее о конечной точке сокета
            //Создаём потоковый сокет по протоколу TCP/IP
            Socket sock = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {//связываем сокет с конечной точкой
                sock.Bind(iPEndPoint);
                //начинаем прослушку сокета
                sock.Listen(10);
                while(true)
                {//Начинаем слушать соединения в бесконечном цикле
                    Console.WriteLine("Слушаем, порт {0}",iPEndPoint);
                    //Программа приостанавливается, ожидая входящее соединение
                    //сокет для обмена данными с клиентом
                    Socket s = sock.Accept();
                }
            }
        }
    }
}
