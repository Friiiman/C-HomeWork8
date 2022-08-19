// ------------- ЗАДАЧИ -------------
// ----------------------------------

void Task1(){

    // Задайте двумерный массив. Напишите программу, 
    // которая упорядочит по убыванию элементы каждой строки двумерного массива.

    Console.Write("Задайте количество строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Задайте количество столбцов: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[rows, columns];
    FillArray(array);
    PrintArray(array);
    Console.WriteLine();
    Console.WriteLine("Отсортированный по убыванию элементов каждой строки массив");
    for(int i = 0; i < rows; i++){
        for(int j = 0; j < columns - 1; j++){
            for(int k = j + 1; k < columns; k++){
                if(array[i, k] > array[i, j]){
                    int temporary = array[i, j];
                    array[i, j] = array[i, k];
                    array[i, k] = temporary;
                }
            }
        }
    }
    PrintArray(array);
}

void Task2(){

    // Задайте прямоугольный двумерный массив. 
    // Напишите программу, которая будет находить строку с наименьшей суммой элементов.

    Console.Write("Задайте количество строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Задайте количество столбцов: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[rows, columns];
    FillArray(array);
    PrintArray(array);

    int minSum = 0;
    for(int j = 0; j < columns; j++){
        minSum += array[0, j];
    }
    int sum = 0;
    int minRow = 0;
    for(int i = 1; i < rows; i++){
        for(int j = 0; j < columns; j++){
            sum += array[i, j];
        }
        if(sum < minSum){
            minSum = sum;
            minRow = i;
        }
        sum = 0;
    }
    Console.WriteLine($"Строка с наименьшей суммой элементов - {minRow + 1}");
}

void Task3(){

    // Заполните спирально массив 4 на 4.

    Console.Write("Задайте количество строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Задайте количество столбцов: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[rows, columns];

    //------МЕГА-КОСТЫЛЬ------

    int count = 1;
    for(int i = 0; i < columns; i++){
        array[0, i] = count++;
        if(i == columns - 1){
            for(int j = 1; j < rows; j++){
                array[j, i] = count++;
                if(j == rows - 1){
                    for(int k = columns - 2; k != -1; k--){
                        array[j, k] = count++;
                        if(k == 0){
                            for(int l = rows - 2; l != 0; l--){
                                array[l, k] = count++;
                            }
                        }
                    }
                }
            }
        }
    }
    for(int i = 1; i < columns - 1; i++){
        array[1, i] = count++;
        if(i == columns - 2){
            for(int j = 2; j < rows - 1; j++){
                array[j, i] = count++;
                if(j == rows - 2){
                    for(int k = columns - 3; k != 0; k--){
                        array[j, k] = count++;
                    }
                }
            }
        }
    }
    PrintArray(array);
}

// ------------- МЕТОДЫ -------------
// ----------------------------------

void FillArray(int [,] array, int startNumber = 0, int finishNumber = 100){
    finishNumber++;
    Random random = new Random();
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    for(int i = 0; i < rows; i++){
        for(int j = 0; j < columns; j++){
            array[i, j] = random.Next(startNumber, finishNumber);
        }
    }
}

void PrintArray(int [,] array){
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    for(int i = 0; i < rows; i++){
        for(int j = 0; j < columns; j++){
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

// ------------- ВЫВОД РЕШЕНИЯ ЗАДАЧ -------------
// -----------------------------------------------

// Task1();
// Task2();
Task3();