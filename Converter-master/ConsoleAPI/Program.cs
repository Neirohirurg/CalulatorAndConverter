using ConverterLib;
using System;

Manager cm = new Manager();
List<string> array = new List<string> { };


while (Checked())
{
    //
    // Начало работы выводит список категорий
    //
    ValueList(array, cm);
    //
    // Работа с единицами измерения
    //
    string ValueName = GetValueName(array);
    double num = 0;
    MeasureList(array, cm, ValueName);
    string from = GetValueName(array);
    Console.WriteLine("\n" + from + " - Выбрано, теперь выберите во что конвертировать - \n");
    GetElementsOfArray(array);
    string to = GetValueName(array);
    Console.WriteLine("\n" + from + " - в - " + to + "\n");
    Console.WriteLine("Введите значение:\n");
    num = InputNumber();
    Console.WriteLine("\n\n" + num + "  --------->  " + cm.GetConvertedValue(num, ValueName, from, to).ToString());

}
//
// Выводит элементы из списка
//
static void GetElementsOfArray(List<string> list)
{
    Console.WriteLine("");
    for(int i = 0; i < list.Count(); i++)
    {
        Console.WriteLine($"    {i+1} " + list[i]);
    }
    Console.WriteLine("");
}
//
// Возращает введеную цифру
//
static double InputNumber()
{ 
    try
    {
        double num = Convert.ToDouble(Console.ReadLine());
        return num;
    }
    catch (FormatException)
    {
        Console.WriteLine("Введите числовое значение!\n");
        return InputNumber();
    }
}
//
// Получает выбранную категорию
//
string GetValueName(List<string> array)
{
   try
    {
        int i = Convert.ToInt32(InputNumber());
        return array[i - 1];
    }
    catch (Exception)
    {
        Console.WriteLine("\nСлишком большое значение\n");
        return GetValueName(array);
    } 
}
//
// Проверка для работы цикла while
//
static bool Checked()
{
    Console.WriteLine("\nНажмите любую кнопку чтобы запустить" +
    "\nНажмите q, чтобы выйти \n");
    string? action = Console.ReadLine();
    if (action == "q" | action == "й") return false;
    else
    {
        return true;
    }
}
//
// Список категорий
//
void ValueList(List<string> list, Manager  cm)
{
    Console.Clear();
    list.Clear();
    list.AddRange(cm.GetPhysicValuesList().ToArray());
    GetElementsOfArray(list);
}
//
// Список единиц измерения
//
void MeasureList(List<string> list, Manager cm, string ValueName)
{
    Console.Clear();
    list.Clear();
    list.AddRange(cm.GetMeasureList(ValueName).ToArray());
    GetElementsOfArray(list);
}
