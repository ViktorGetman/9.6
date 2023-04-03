using static NumberReader;

class Program
{
    static void Main(string[] args)
    {

        NumberReader numberReader = new NumberReader();
        numberReader.NumberEnteredEvent += ShowNames;

        while(true)
        {
            try
            {
                numberReader.Read();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Введено неверное значение.");
                return;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Аргумент, передаваемый в метод, не может быть пустым.");
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Аргумент, передаваемый в метод, является недопустимым.");
                return;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Индекс находится за пределами границ массива или коллекции.");
                return;
            }
        }
    }
    static void ShowNames(int number)
    {
        string[] names = { "Виктор", "Плюша", "Таисия", "Олеся", "Теодор" };
        switch (number)
        {

            case 1:
                Array.Sort(names);

                Console.WriteLine(String.Join(", ", names));
                break;
            case 2:
                Array.Sort(names);
                Array.Reverse(names);
                Console.WriteLine(String.Join(", ", names));
                break;
        }
    }
}
class NumberReader
{
    public delegate void NumberEnteredeDelegate(int number);
    public event NumberEnteredeDelegate NumberEnteredEvent;

    public void Read()
    {
        Console.WriteLine("Введите значение: 1 или 2");
        int number = Convert.ToInt32(Console.ReadLine());
        
        if (number != 1 && number !=2) throw new FormatException();

        NumberEntered(number);

    }
    protected virtual void NumberEntered(int number)
    {
        NumberEnteredEvent.Invoke(number);
    }
}


