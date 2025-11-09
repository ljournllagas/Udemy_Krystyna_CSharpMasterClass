//List<string> todos = new();

//DisplayOptions();


//void DisplayOptions()
//{
//    string userChoice = string.Empty;

//    do
//    {
//        Console.WriteLine("Hello!");
//        Console.WriteLine("What do you want to do?");
//        Console.WriteLine("[S]ee all TODOs");
//        Console.WriteLine("[A]dd a TODO");
//        Console.WriteLine("[R]emove a TODO");
//        Console.WriteLine("[E]xit");
//        Console.WriteLine("\n");

//        userChoice = Console.ReadLine();

//        HandleUserChoice(userChoice);

//    } while (!userChoice.ToUpper().Equals("E"));


//}


//void HandleUserChoice(string userChoice)
//{
//    switch (userChoice.ToUpper())
//    {
//        case "S":
//            ListAllTodos();
//            break;
//        case "A":
//            AddTodo();
//            break;
//        case "R":
//            RemoveTodo();
//            break;
//        case "E":
//            Console.WriteLine("Exit");
//            break;
//        default:
//            Console.WriteLine("Incorrect input");
//            break;
//    }
//}

//void ListAllTodos()
//{
//    if (todos.Count == 0) Console.WriteLine("No TODOs have been added yet.");

//    for (int i = 0; i < todos.Count; i++)
//    {
//        Console.WriteLine($"{i + 1}. {todos[i]}");
//    }
//}

//void AddTodo()
//{
//    Console.WriteLine("Enter the TODO description: ");

//    var toAddTodo = Console.ReadLine();

//    if (HasAValidInput(toAddTodo))
//    {
//        todos.Add(toAddTodo);
//    }

//    DisplayOptions();
//}
//bool HasAValidInput(string toAddTodo)
//{
//    if (string.IsNullOrEmpty(toAddTodo))
//    {
//        Console.WriteLine("The description cannot be empty.");
//        return false;
//    }


//    if (todos.Contains(toAddTodo))
//    {
//        Console.WriteLine("The description must be unique.");
//        return false;
//    }

//    return true;
//}

//void RemoveTodo()
//{
//    while (true)
//    {
//        Console.WriteLine("Select the index of the TODO you want to remove:");

//        ListAllTodos();

//        if (int.TryParse(Console.ReadLine(), out int selectedIndex))
//        {
//            if (!ValidRemovalOfTodo(selectedIndex)) continue;

//            Console.WriteLine($"TODO removed: {todos[selectedIndex - 1]}");

//            todos.RemoveAt(selectedIndex - 1);

//            DisplayOptions();
//            break;
//        }
//    }

//}

//bool ValidRemovalOfTodo(int index)
//{
//    if (index == 0)
//    {
//        Console.WriteLine("Empty Index");
//        return false;
//    }

//    if (todos.Count < index)
//    {
//        Console.WriteLine("Invalid selected index");
//        return false;
//    }

//    return true;
//}



using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        TodoApp app = new();
        app.Run();
    }
}

class TodoApp
{
    private readonly List<string> todos = new();

    public void Run()
    {
        string userChoice;

        do
        {
            DisplayMenu();
            userChoice = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
            HandleUserChoice(userChoice);

        } while (userChoice != "E");

        Console.WriteLine("Exiting TODO App. Goodbye!");
    }

    private void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("===== TODO LIST APP =====");
        Console.WriteLine("[S] See all TODOs");
        Console.WriteLine("[A] Add a TODO");
        Console.WriteLine("[R] Remove a TODO");
        Console.WriteLine("[E] Exit");
        Console.Write("\nEnter your choice: ");
    }

    private void HandleUserChoice(string choice)
    {
        switch (choice)
        {
            case "S":
                ListAllTodos();
                Pause();
                break;

            case "A":
                AddTodo();
                Pause();
                break;

            case "R":
                RemoveTodo();
                Pause();
                break;

            case "E":
                // Exit handled in loop
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Pause();
                break;
        }
    }

    private void ListAllTodos()
    {
        Console.WriteLine("\n=== Your TODOs ===");

        if (todos.Count == 0)
        {
            Console.WriteLine("No TODOs have been added yet.");
            return;
        }

        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }

    private void AddTodo()
    {
        Console.Write("\nEnter the TODO description: ");
        string? description = Console.ReadLine()?.Trim();

        if (!HasValidInput(description)) return;

        todos.Add(description!);
        Console.WriteLine($"TODO added: {description}");
    }

    private bool HasValidInput(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("The description cannot be empty.");
            return false;
        }

        if (todos.Contains(input))
        {
            Console.WriteLine("The description must be unique.");
            return false;
        }

        return true;
    }

    private void RemoveTodo()
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("\nNo TODOs to remove.");
            return;
        }

        ListAllTodos();
        Console.Write("\nEnter the index of the TODO to remove: ");

        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        if (index < 1 || index > todos.Count)
        {
            Console.WriteLine("Invalid index selected.");
            return;
        }

        Console.WriteLine($"TODO removed: {todos[index - 1]}");
        todos.RemoveAt(index - 1);
    }

    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

