using static KirpichyovLib.ExtendedConsole;
using Shop.ViewModels;
using System;

namespace Shop.Menus
{
    public static class ConsoleHelper
    {
        public static void ShowProduct(ProductViewModel viewmodel)
        {
            WriteLineColorized(GetHeader(""), ConsoleColor.White);
            WriteLineColorized($"ID: {viewmodel.Id}", ConsoleColor.Black, ConsoleColor.White);
            WriteLineColorized($"Name: {viewmodel.Name}", ConsoleColor.White);
            WriteLineColorized($"Price: {viewmodel.Price:N2} UAH", ConsoleColor.White);
            if(viewmodel.Description != null)
            {
                WriteLineColorized($"Description ID: {viewmodel.Description.Id}", ConsoleColor.DarkGreen);
                WriteLineColorized($"Information: {viewmodel.Description.Information}", ConsoleColor.White);
            }
            else
            {
                WriteLineColorized("Description doesn't exists!", ConsoleColor.DarkRed);
            }
        }

        public static void ShowDescription(DescriptionViewModel viewmodel)
        {
            WriteLineColorized(GetHeader(""), ConsoleColor.White);
            WriteLineColorized($"ID: {viewmodel.Id}", ConsoleColor.Black, ConsoleColor.White);
            WriteLineColorized($"Information: {viewmodel.Information}", ConsoleColor.White);
            WriteLineColorized($"Product ID: {viewmodel.ProductId}", ConsoleColor.DarkGreen);
        }

        public static void PlayErrorSound()
        {
            Console.Beep(200, 350);
        }
        public static void PlaySuccessSound()
        {
            Console.Beep(425, 350);
        }

    }
}
