using System;
using System.Collections.Generic;

public class DoublyNode<T>
{
    public DoublyNode(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public DoublyNode<T> Previous { get; set; }
    public DoublyNode<T> Next { get; set; }
}

public class Deque<T> where T : IEquatable<T>
{
    private DoublyNode<T> head;
    private DoublyNode<T> tail;
    private int count;

    public int Count => count;

    public bool IsEmpty => count == 0;

    public void AddFirst(T data)
    {
        DoublyNode<T> node = new DoublyNode<T>(data);

        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            node.Next = head;
            head.Previous = node;
            head = node;
        }
        count++;
        Console.WriteLine($"ok (added to the end: {data})");
    }

    public void AddLast(T data)
    {
        DoublyNode<T> node = new DoublyNode<T>(data);

        if (tail == null)
        {
            head = tail = node;
        }
        else
        {
            node.Previous = tail;
            tail.Next = node;
            tail = node;
        }
        count++;
        Console.WriteLine($"ok (added to thee nd: {data})");
    }

    public T RemoveFirst()
    {
        if (count == 0)
            throw new InvalidOperationException("Deque is empty");

        T result = head.Data;

        if (count == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Previous = null;
        }
        count--;
        return result;
    }

    public T RemoveLast()
    {
        if (count == 0)
            throw new InvalidOperationException("Deque is empty");

        T result = tail.Data;

        if (count == 1)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Previous;
            tail.Next = null;
        }
        count--;
        return result;
    }

    public bool Remove(T data)
    {
        DoublyNode<T> current = head;
        bool removed = false;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                count--;
                removed = true;
                break; 
            }
            current = current.Next;
        }
        return removed;
    }

    public List<int> FindPositions(T data)
    {
        List<int> positions = new List<int>();
        DoublyNode<T> current = head;
        int position = 0;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                positions.Add(position);
            }
            current = current.Next;
            position++;
        }
        return positions;
    }

    public T PeekFirst()
    {
        if (count == 0)
            throw new InvalidOperationException("Deque is empty");
        return head.Data;
    }

    public T PeekLast()
    {
        if (count == 0)
            throw new InvalidOperationException("Deque is empty");
        return tail.Data;
    }

    public void Print()
    {
        if (count == 0)
        {
            Console.WriteLine("Deque is empty");
            return;
        }

        DoublyNode<T> current = head;
        Console.Write("Deque: ");
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine($"(There is: {count} elements)");
    }

    public void Clear()
    {
        head = tail = null;
        count = 0;
        Console.WriteLine("ok (deque cleared)");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter nums: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine($"Divs {number} from 2 to 10:");

        for (int divisor = 2; divisor <= 10; divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine($"{number} is devided by {divisor}");
            }
        }

        Console.Write("Enter start: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("And end: ");
        int end = int.Parse(Console.ReadLine());

        int count3 = 0;
        int count5 = 0;
        int count9 = 0;

        for (int num = start; num <= end; num++)
        {
            if (num % 3 == 0) count3++;
            if (num % 5 == 0) count5++;
            if (num % 9 == 0) count9++;
        }

        Console.WriteLine($"\nFrom {start} to {end}:");
        Console.WriteLine($"Divided by 3: {count3}");
        Console.WriteLine($"Divided by 5: {count5}");
        Console.WriteLine($"Divided by 9: {count9}");

        int heads = 0;
        int tails = 0;

        Random random = new Random();

        Console.WriteLine("\nFlipping a coin...");

        for (int i = 0; i < 100; i++)
        {
            int result = random.Next(0, 2);

            if (result == 0)
                tails++;
            else
                heads++;
        }

        Console.WriteLine("\nResult:");
        Console.WriteLine($"Heads: {heads} ");
        Console.WriteLine($"Tails: {tails} ");

        Console.WriteLine("\nStack");
        StackDemo();

        Console.WriteLine("\nQueue");
        QueueDemo();

        Console.WriteLine("\nBrackets check");
        CheckBrackets();

        Console.WriteLine("\nDeque");
        DequeDemo();
    }

    static void StackDemo()
    {
        Stack<int> stack = new Stack<int>();

        Console.WriteLine("Commands: push n, pop, back, size, clear, exit");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            switch (parts[0])
            {
                case "push":
                    int n = int.Parse(parts[1]);
                    stack.Push(n);
                    Console.WriteLine("ok");
                    break;

                case "pop":
                    Console.WriteLine(stack.Pop());
                    break;

                case "back":
                    Console.WriteLine(stack.Peek());
                    break;

                case "size":
                    Console.WriteLine(stack.Count);
                    break;

                case "clear":
                    stack.Clear();
                    Console.WriteLine("ok");
                    break;

                case "exit":
                    Console.WriteLine("bye");
                    return;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }

    static void QueueDemo()
    {
        Queue<int> queue = new Queue<int>();

        Console.WriteLine("Commands: push n, pop, front, size, clear, exit");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            switch (parts[0])
            {
                case "push":
                    int n = int.Parse(parts[1]);
                    queue.Enqueue(n);
                    Console.WriteLine("ok");
                    break;

                case "pop":
                    if (queue.Count > 0)
                        Console.WriteLine(queue.Dequeue());
                    else
                        Console.WriteLine("error");
                    break;

                case "front":
                    if (queue.Count > 0)
                        Console.WriteLine(queue.Peek());
                    else
                        Console.WriteLine("error");
                    break;

                case "size":
                    Console.WriteLine(queue.Count);
                    break;

                case "clear":
                    queue.Clear();
                    Console.WriteLine("ok");
                    break;

                case "exit":
                    Console.WriteLine("bye");
                    return;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }

    static void CheckBrackets()
    {
        Console.WriteLine("\nCheck Brackets");

        while (true)
        {
            Console.WriteLine("\nEnter and expressiion or 'exit':");
            Console.Write("expression> ");
            string expression = Console.ReadLine();

            if (expression?.ToLower() == "exit")
                return;

            if (string.IsNullOrEmpty(expression))
                continue;

            int balance = 0;
            int firstExtraClosing = -1;
            Stack<int> openBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == '(')
                {
                    balance++;
                    openBrackets.Push(i); 
                }
                else if (c == ')')
                {
                    if (balance > 0)
                    {
                        balance--;
                        openBrackets.Pop(); 
                    }
                    else
                    {
                        if (firstExtraClosing == -1)
                        {
                            firstExtraClosing = i;
                        }
                    }
                }
            }

            Console.WriteLine($"Expression: {expression}");

            if (balance == 0 && firstExtraClosing == -1)
            {
                Console.WriteLine("Correct");
            }
            else if (firstExtraClosing != -1)
            {
                Console.WriteLine("Wrong");
                Console.WriteLine($"Extra closing brackets: {firstExtraClosing + 1}");
            }
            else if (balance > 0)
            {
                Console.WriteLine("Wrong");
                Console.WriteLine($"Extra opening brackets: {balance}");
                if (openBrackets.Count > 0)
                {
                    var positions = openBrackets.ToArray();
                    Array.Reverse(positions);
                    var readablePositions = Array.ConvertAll(positions, p => p + 1);
                    Console.WriteLine($"Extra bracket(s) position(s): {string.Join(", ", readablePositions)}");
                }
            }
        }
    }

    static void DequeDemo()
    {
        Deque<int> deque = new Deque<int>();

        Console.WriteLine("\nDeque");
        Console.WriteLine("Command list:");
        Console.WriteLine("addfirst n - add n in the begining");
        Console.WriteLine("addlast n - add n in the end");
        Console.WriteLine("removefirst - remove first el");
        Console.WriteLine("removelast - remove last el");
        Console.WriteLine("remove n - remove first founded num n");
        Console.WriteLine("find n - found position(s) of n");
        Console.WriteLine("peekfirst - check first el");
        Console.WriteLine("peeklast - check last el");
        Console.WriteLine("size - size of the deque");
        Console.WriteLine("clear - clear the deque");
        Console.WriteLine("print - show all elements");
        Console.WriteLine("exit - bye");

        while (true)
        {
            Console.Write("\ndeque> ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            string[] parts = input.Split(' ');

            try
            {
                switch (parts[0].ToLower())
                {
                    case "addfirst":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Error: type smthng");
                            break;
                        }
                        int n1 = int.Parse(parts[1]);
                        deque.AddFirst(n1);
                        break;

                    case "addlast":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Error: type smthng");
                            break;
                        }
                        int n2 = int.Parse(parts[1]);
                        deque.AddLast(n2);
                        break;

                    case "removefirst":
                        if (!deque.IsEmpty)
                            Console.WriteLine($"Deleted from the begining: {deque.RemoveFirst()}");
                        else
                            Console.WriteLine("error (deque is empty)");
                        break;

                    case "removelast":
                        if (!deque.IsEmpty)
                            Console.WriteLine($"Deleted from the end: {deque.RemoveLast()}");
                        else
                            Console.WriteLine("error (deque is empty)");
                        break;

                    case "remove":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Error: type smthng");
                            break;
                        }
                        int n3 = int.Parse(parts[1]);
                        if (deque.Remove(n3))
                            Console.WriteLine($"ok (deleted el: {n3})");
                        else
                            Console.WriteLine($"error (el {n3} not found)");
                        break;

                    case "find":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Error: type smthng");
                            break;
                        }
                        int n4 = int.Parse(parts[1]);
                        var positions = deque.FindPositions(n4);
                        if (positions.Count > 0)
                            Console.WriteLine($"El {n4} have founded on positions: {string.Join(", ", positions)} ");
                        else
                            Console.WriteLine($"El {n4} not found");
                        break;

                    case "peekfirst":
                        if (!deque.IsEmpty)
                            Console.WriteLine($"First el: {deque.PeekFirst()}");
                        else
                            Console.WriteLine("error (deque is empty)");
                        break;

                    case "peeklast":
                        if (!deque.IsEmpty)
                            Console.WriteLine($"Last el: {deque.PeekLast()}");
                        else
                            Console.WriteLine("error (deque is empty)");
                        break;

                    case "size":
                        Console.WriteLine($"Deque size: {deque.Count}");
                        break;

                    case "clear":
                        deque.Clear();
                        break;

                    case "print":
                        deque.Print();
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Check your gramma pls");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erer: {ex.Message}");
            }
        }
    }
}