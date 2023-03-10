using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AbstractFactoryPattern
{
    internal class Program
    {
        private static bool _highRes = false;

        static void Main(string[] args)
        {
            if(args.Length != 0)
            {
                if (!bool.TryParse(args[0], out _highRes))
                    _highRes = TryGetResSetting();
            }
            else if(File.Exists("Config.ini"))
            {
                try
                {
                    string path = new FileInfo("Config.ini").FullName;

                    StringBuilder retVal = new(255);
                    if (GetPrivateProfileString("Program", "highRes", "", retVal, 255, path) > 0)
                    {
                        if (!bool.TryParse(retVal.ToString(), out _highRes))
                            _highRes = TryGetResSetting();
                    }
                    else
                    {
                        _highRes = TryGetResSetting();
                    }
                }
                catch
                {
                    _highRes = TryGetResSetting();
                }
            }
            else
            {
                _highRes = TryGetResSetting();
            }

            IWidgetDocFactory factory = _highRes == true ? new HighResFactory() : new LowResFactory();

            IWidget widget = factory.CreateWidget();
            IDocument doc = factory.CreateDocument();

            widget.Draw();
            doc.Print();

            Console.WriteLine("Press any key to exit the program...");
            Console.ReadKey();
        }

        static bool TryGetResSetting()
        {
            Console.WriteLine("Was unable to configure from command line or config file.\nShould this application run in High Res Mode?\nEnter Y for yes, N for no");

            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.WriteLine($"Invalid input key ({key})\nPress any key to continue and try again...");
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}