using static KirpichyovLib.ExtendedConsole;
using static KirpichyovLib.InputParser;
using Shop.Application;
using Shop.Services.Interfaces;
using System;
using System.Threading;
using Shop.ViewModels;

namespace Shop.Menus
{
    public class ProductDepartmentMenu : Menu
    {
        private IProductDepartmentService _service;

        public override string Title => "Products department";

        public ProductDepartmentMenu()
        {
            _service = IoCContainerFactory
                .GetInstance()
                .Create<IProductDepartmentService>();
        }

        public override void OnInit()
        {
            base.OnInit();
            Console.Clear();
        }

        public override void OnShowLegend()
        {
            WriteLineColorized("ESC - Exit from menu", ConsoleColor.White);
            WriteLineColorized("1 - Show products", ConsoleColor.Yellow);
            WriteLineColorized("2 - Show product (by id)", ConsoleColor.Yellow);
            WriteLineColorized("3 - Add product", ConsoleColor.Blue);
            WriteLineColorized("4 - Edit product (by id)", ConsoleColor.Magenta);
            WriteLineColorized("5 - Delete product (by id)", ConsoleColor.Red);
            WriteLineColorized(GetHeader("", '*', 15), ConsoleColor.Gray);
            WriteLineColorized("6 - Show descriptions", ConsoleColor.Yellow);
            WriteLineColorized("7 - Show descriptions (by id)", ConsoleColor.Yellow);
            WriteLineColorized("8 - Add descriptions", ConsoleColor.Blue);
            WriteLineColorized("9 - Edit descriptions (by id)", ConsoleColor.Magenta);
            WriteLineColorized("0 - Delete descriptions (by id)", ConsoleColor.Red);
        }

        public override void OnPerform()
        {
            var key = Console.ReadKey(true).Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("Products:");
                    var viewmodels = _service.GetProducts();
                    foreach (var model in viewmodels)
                    {
                        ConsoleHelper.ShowProduct(model);
                    }
                    Console.WriteLine("\t\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    int id = ParseIntInput("Id = ", ParseMode.MinZero);
                    if(_service.GetIsProuductExists(id))
                    {
                        var viewmodel = _service.GetProduct(id);
                        ConsoleHelper.ShowProduct(viewmodel);
                    }
                    else
                    {
                        WriteLineColorized("Unknown id!", ConsoleColor.Red);
                        ConsoleHelper.PlayErrorSound();
                    }
                    Console.WriteLine("\t\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    var newviewmodel = new ProductViewModel();
                    Console.Write("Name: ");
                    newviewmodel.Name = Console.ReadLine();
                    newviewmodel.Price = ParseDecimalInput("Price = ", ParseMode.MinExceptZero);
                    newviewmodel.DescriptionId = ParseIntInput("Description ID = ", ParseMode.MinZero);
                    _service.AddProduct(newviewmodel);
                    WriteLineColorized("Success", ConsoleColor.Green);
                    ConsoleHelper.PlaySuccessSound();
                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    id = ParseIntInput("Id = ", ParseMode.MinZero);
                    if (_service.GetIsProuductExists(id))
                    {
                        var viewmodel = _service.GetProduct(id);
                        Console.WriteLine("Current product info:");
                        ConsoleHelper.ShowProduct(viewmodel);
                        Console.WriteLine("\nNew product info:");

                        Console.Write("Name: ");
                        viewmodel.Name = Console.ReadLine();
                        viewmodel.Price = ParseDecimalInput("Price = ", ParseMode.MinExceptZero);
                        viewmodel.DescriptionId = ParseIntInput("Description ID = ", ParseMode.MinZero);
                        _service.EditProduct(viewmodel);
                        WriteLineColorized("Success", ConsoleColor.Green);
                        ConsoleHelper.PlaySuccessSound();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        WriteLineColorized("Unknown id!", ConsoleColor.Red);
                        ConsoleHelper.PlayErrorSound();
                        Console.WriteLine("\t\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    id = ParseIntInput("Id = ", ParseMode.MinZero);
                    if (_service.GetIsProuductExists(id))
                    {
                        _service.DeleteProduct(id);
                        WriteLineColorized("Success", ConsoleColor.Green);
                        ConsoleHelper.PlaySuccessSound();
                    }
                    else
                    {
                        ConsoleHelper.PlayErrorSound();
                        WriteLineColorized("Unknown id!", ConsoleColor.Red);
                    }
                    Console.WriteLine("\t\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                //Descriptios
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Console.WriteLine("Descriptions:");
                    var descrViewModels = _service.GetDescriptions();
                    foreach (var model in descrViewModels)
                    {
                        ConsoleHelper.ShowDescription(model);
                    }
                    Console.WriteLine("\t\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    id = ParseIntInput("Id = ", ParseMode.MinZero);
                    if (_service.GetIsDescriptionExists(id))
                    {
                        var descrViewmodel = _service.GetDescription(id);
                        ConsoleHelper.ShowDescription(descrViewmodel);
                    }
                    else
                    {
                        ConsoleHelper.PlayErrorSound();
                        WriteLineColorized("Unknown id!", ConsoleColor.Red);
                    }
                    Console.WriteLine("\t\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    var descrViewModel = new DescriptionViewModel();
                    Console.Write("Information: ");
                    descrViewModel.Information = Console.ReadLine();
                    descrViewModel.ProductId = ParseIntInput("Product ID = ", ParseMode.MinZero);
                    _service.AddDescription(descrViewModel);
                    ConsoleHelper.PlaySuccessSound();
                    WriteLineColorized("Success", ConsoleColor.Green);
                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    id = ParseIntInput("Id = ", ParseMode.MinZero);
                    if (_service.GetIsDescriptionExists(id))
                    {
                        descrViewModel = _service.GetDescription(id);
                        Console.WriteLine("Current product info:");
                        ConsoleHelper.ShowDescription(descrViewModel);
                        Console.WriteLine("\nNew product info:");

                        Console.Write("Information: ");
                        descrViewModel.Information = Console.ReadLine();
                        descrViewModel.ProductId = ParseIntInput("Product ID = ", ParseMode.MinZero);
                        _service.EditDescription(descrViewModel);
                        ConsoleHelper.PlaySuccessSound();
                        WriteLineColorized("Success", ConsoleColor.Green);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        ConsoleHelper.PlayErrorSound();
                        WriteLineColorized("Unknown id!", ConsoleColor.Red);
                        Console.WriteLine("\t\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    id = ParseIntInput("Id = ", ParseMode.MinZero);
                    if (_service.GetIsDescriptionExists(id))
                    {
                        _service.DeleteDescription(id);
                        ConsoleHelper.PlaySuccessSound();
                        WriteLineColorized("Success", ConsoleColor.Green);
                    }
                    else
                    {
                        ConsoleHelper.PlayErrorSound();
                        WriteLineColorized("Unknown id!", ConsoleColor.Red);
                    }
                    Console.WriteLine("\t\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.Escape:
                    IsDone = true;
                    break;
                default:
                    WriteLineColorized("Wrong key!", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    break;
            }
            Console.Clear();
        }
    }
}
