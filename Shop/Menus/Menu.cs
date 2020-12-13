using KirpichyovLib;
using System;

namespace Shop.Menus
{
    public abstract class Menu
    {
        public abstract string Title { get; }
        public bool IsDone { get; protected set; }

        public void Run()
        {
            IsDone = false;
            OnInit();
            while (!IsDone)
            {
                var title = ExtendedConsole.GetHeader(Title, qHeaderChars: 10);
                ExtendedConsole.WriteLineColorized(title, ConsoleColor.Green);
                OnShowLegend();
                OnPerform();
            }
            OnExit();
        }

        public virtual void OnInit()
        {
            Console.Beep();
        }

        public abstract void OnShowLegend();
        public abstract void OnPerform();

        public virtual void OnExit() 
        {
            Console.Beep(512, 300);
        }

    }
}
