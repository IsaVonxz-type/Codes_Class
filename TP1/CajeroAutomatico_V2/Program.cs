using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero_Automatico
{
    class Program
    {
        // LISTAS
        static List<string> Users = new List<string>();
        static List<int> Sald = new List<int>();
        static List<string> Transac = new List<string>();
        static int Account, tmp;

        // DIVISOR
        static string Div = ("================================================");

        // PROGRAMA PRINCIPAL
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("=================== OPCIONES ===================");
                Console.WriteLine("1 - Iniciar Sesion. \n2 - Crear cuenta. \n3 - Salir.");
                Console.WriteLine(Div);
                Console.Write("Ingrese la opcion que desee: ");
                Valid_Value();

                Console.Clear();
                // OPCIONES
                switch (tmp)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 3:
                        CloseProgram();
                        return;
                    default:
                        Console.WriteLine("Ingrese una opcion entre 1 y 3 para continuar.");
                        break;
                }
            }
        }

        // FUNCIONES

        // LOGIN
        static void Login()
        {
            Console.WriteLine("=================== INICIAR SESION ===================");
            Console.Write("Ingrese el nombre de usuario: ");
            string User = Console.ReadLine();

            while (true)
            {
                foreach (string Sent in Users)
                {
                    if (Sent == User)
                    {
                        Account = Users.IndexOf(User);
                        Console.Clear();
                        Console.WriteLine("Sesion Iniciada");
                        Session();
                    }
                }
                Console.WriteLine("Usuario no encontrado.");
                break;
            }

        }
        
        // REGISTRO
        static void Register()
        {
            Console.WriteLine("=================== REGISTRO ===================");
            Console.Write("Ingrese el nombre de usuario: ");
            string User = Console.ReadLine();
            if (Verify_User(User))
            {
                Console.Clear();
                Console.WriteLine("Usuario ya registrado.");
                Main();
            }

            Users.Add(User);

            while (true)
            {
                Console.Write("Ingrese el saldo de la cuenta: ");
                Valid_Value();

                if (tmp == 0)
                {
                    Console.WriteLine("Debe ingresar un valor valido.");
                }
                else
                {
                    Sald.Add(tmp);
                    Transac.Add("");
                    break;
                }

            }

            Console.Clear();
            Console.WriteLine($"Usuario {User} registrado con Exito!");
        }

        // VERIFICAR USUARIO
        static bool Verify_User(string User)
        {
            foreach (string Sent_User in Users)
            {
                if (Sent_User == User) return true;
            }
            return false;
        }

        // SESION
        static void Session()
        {
            Console.WriteLine("=================== OPCIONES ===================");
            Console.WriteLine($"Usuario: {Users[Account]}");
            Console.WriteLine($"Saldo: {Sald[Account]}");
            Console.WriteLine(Div);
            Console.WriteLine("1 - Depositar dinero. \n2 - Retirar. \n3 - Historial de Transacciones. \n4 - Salir de la cuenta.");
            Console.WriteLine(Div);
            Console.Write("Ingrese la opcion que desee: ");
            Valid_Value();
            Console.Clear();


            // OPCIONES DEL USUARIO
            switch (tmp)
            {
                case 1:
                    Deposit();
                    break;
                case 2:
                    Retired();
                    break;
                case 3:
                    History();
                    break;
                case 4:
                    Console.Clear();
                    Account = -1;
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ingrese una opcion entre 1 y 4 para continuar.");
                    Session();
                    break;
            }
        }

        // DEPOSITAR SALDO
        static void Deposit()
        {
            Console.WriteLine("=================== DEPOSITAR ===================");
            Console.WriteLine($"Saldo: {Sald[Account]}");

            while (true)
            {
                Console.Write($"Ingresa la cantidad que desea depositar: ");
                Valid_Value();

                if (tmp <= 0)
                {
                    Console.WriteLine("Debe ingresar un valor valido.");
                }
                else
                {
                    break;
                }

            }

            Sald[Account] += tmp;

            if (string.IsNullOrEmpty(Transac[Account]))
            {
                Transac[Account] = "+" + tmp.ToString();
            }
            else
            {
                Transac[Account] += ", +" + tmp.ToString();
            }

            Console.Clear();
            Console.WriteLine($"Deposito de ${tmp} realizado con exito.");
            Session();
        }

        // RETIRAR SALDO
        static void Retired()
        {
            Console.WriteLine("=================== RETIRAR ===================");
            Console.WriteLine($"Saldo: {Sald[Account]}");

            while (true)
            {
                Console.Write($"Ingresa la cantidad que desea retirar: ");
                Valid_Value();

                if (tmp == 0)
                {
                    Console.WriteLine("Debe ingresar un valor valido.");
                }
                else if (Sald[Account] < tmp)
                {
                    Console.Clear();
                    Console.WriteLine("No tiene suficiente saldo para retirar.");
                }
                else
                {
                    break;
                }
            }

            Sald[Account] -= tmp;

            if (string.IsNullOrEmpty(Transac[Account]))
            {
                Transac[Account] = "-" + tmp.ToString();
            }
            else
            {
                Transac[Account] += ", -" + tmp.ToString();
            }

            Console.Clear();
            Console.WriteLine($"Saldo de ${tmp} retirado con exito.");
            Session();
        }

        // HISTORIAL DE TRANSACCIONES
        static void History()
        {
            Console.Clear();
            Console.WriteLine("================ TRANSACCIONES =================");
            Console.WriteLine($"Usuario: {Users[Account]}");

            if (string.IsNullOrEmpty(Transac[Account]))
            {
                Console.WriteLine("\nNo hay transacciones registradas.");
            }
            else
            {
                Console.WriteLine($"\nTransacciones: {Transac[Account]}.");
            }

            Console.WriteLine(Div);
            Session();
        }
        // VALIDAR NUMERO
        static void Valid_Value()
        {
            if (!int.TryParse(Console.ReadLine(), out tmp) || tmp < 0) { }
        }

        // CERRAR PROGRAMA
        static void CloseProgram()
        {
            Console.WriteLine("Saliendo del programa...");
        }
    }
}