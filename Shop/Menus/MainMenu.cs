using KirpichyovLib;
using System;
using System.Threading;

namespace Shop.Menus
{
    public class MainMenu : Menu
    {
        private Menu _productDepartmentMenu;

        public override string Title => "CMS panel";

        public MainMenu(Menu productDepartmentMenu) 
            : base()
        {
            _productDepartmentMenu = productDepartmentMenu;
        }

        public override void OnShowLegend()
        {
            ExtendedConsole.WriteLineColorized("ESC - Exit from application", ConsoleColor.White);
            ExtendedConsole.WriteLineColorized("1 - Products department menu", ConsoleColor.Yellow);
            Console.WriteLine();
        }

        public override void OnPerform()
        {
            var key = Console.ReadKey(true).Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    _productDepartmentMenu.Run();
                    break;
                case ConsoleKey.Escape:
                        IsDone = true;
                        break;
                default:
                    ExtendedConsole.WriteLineColorized("Wrong key!", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    break;
            }
            Console.Clear();
        }
    }
}
