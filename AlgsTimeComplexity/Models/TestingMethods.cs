using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace AlgsTimeComplexity.Models;

public static class TestingMethods
{
    public static TimeSpan Const(List<int> list, int size)
    {
        var watch = Stopwatch.StartNew();
        if (list.Count != 0)
        {
            var a = list[0];
        }
        watch.Stop();

        return watch.Elapsed;
    }
    
    public static TimeSpan Sum(List<int> list, int size)
    {
        long sum = 0;
        var watch = Stopwatch.StartNew();
        for(var i = 0; i < size; i++)
        {
            sum += list[i];
        }
        watch.Stop();

        return watch.Elapsed;
    }
    

    
    public static TimeSpan Product(List<int> list, int size)
    {
        long sum = 0;
        var watch = Stopwatch.StartNew();
        for(var i = 0; i < size; i++)
        {
            sum *= list[i];
        }
        watch.Stop();

        return watch.Elapsed;
    }
    
    

    public static TimeSpan BubbleSort(List<int> list, int size)
    {
        var cpList = new List<int>(list);

        var watch = Stopwatch.StartNew();
        
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size - 1; j++)
            {
                if (cpList[j] > cpList[j + 1])
                {
                    (cpList[j + 1], cpList[j]) = (cpList[j], cpList[j + 1]);
                }
            }
        }

        watch.Stop();
        return watch.Elapsed;
    }
    

    
    public static double Horner(List<int> list, int size)
    {
        double resualt = list[0];
        var x = 1.5f;

        var watch = Stopwatch.StartNew();
        for (int i = 1; i < size; i++)
        {
            resualt = resualt * x + list[i];
        }
        watch.Stop();

        return watch.Elapsed.TotalMilliseconds;
    }
 
    
    
    
    public static TimeSpan QuickSort(List<int> list, int size)
    {

        var watch = Stopwatch.StartNew();
        var result = QuickSortArray(list, 0, size - 1);
        watch.Stop();

        return watch.Elapsed;
    }

    private static List<int> QuickSortArray(List<int> list, int lIndex, int rIndex)
    {
        var cpList = new List<int>(list);
        var i = lIndex;
        var j = rIndex;
        var pivot = cpList[lIndex];

        while (i <= j)
        {
            while (cpList[i] < pivot)
                i++;
            while (cpList[j] > pivot)
                j--;

            if (i <= j)
            {
                (cpList[i], cpList[j]) = (cpList[j], cpList[i]);
                i++;
                j--;
            }
        }

        if (lIndex < j)
            QuickSortArray(cpList, lIndex, j);
        if (i < rIndex)
            QuickSortArray(cpList, i, rIndex);

        return cpList;
    }
    
    
    
    public static TimeSpan ShakerSort(List<int> list, int size)
    {

        var watch = Stopwatch.StartNew();
        var result = ShakerSortArray(list);
        watch.Stop();

        return watch.Elapsed;
    } // Включение в отображаемый список и функцию отсчета времени
    
    private static List<int> ShakerSortArray(List<int> list)
    {
        for (var i = 0; i < list.Count / 2; i++)
        {
            var swapFlag = false;
            //проход слева направо
            for (var j = i; j < list.Count - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    var temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    swapFlag = true;
                }
            }

            //проход справа налево
            for (var j = list.Count - 2 - i; j > i; j--)
            {
                if (list[j - 1] > list[j])
                {
                    var temp = list[j - 1];
                    list[j - 1] = list[j];
                    list[j] = temp;

                    swapFlag = true;
                }
            }

            //если обменов не было выходим
            if (!swapFlag)
            {
                break;
            }
        }
        return list;
    }
    
    
    
    public static TimeSpan ShellSort(List<int> list, int size)
    {

        var watch = Stopwatch.StartNew();
        var result = ShellSortArray(list);
        watch.Stop();

        return watch.Elapsed;
    }
    private static List<int> ShellSortArray(List<int> list)
    {
        int j;
        int step = list.Count / 2;
        while (step > 0)
        {
            for (int i = 0; i < (list.Count - step); i++)
            {
                j = i;
                while ((j >= 0) && (list[j] > list[j + step]))
                {
                    int swap = list[j];
                    list[j] = list[j + step];
                    list[j + step] = swap;
                    j -= step;
                }
            }
            step = step / 2;
        }
        return list;
    }
    
    
    public static TimeSpan HeapSort(List<int> list, int size)
    {

        var watch = Stopwatch.StartNew();
        var result = HeapSortArray(list, size);
        watch.Stop();

        return watch.Elapsed;
    }
    private static List<int> HeapSortArray(List<int> list, int size)
    {
        if (size <= 1)
            return list;
        for (int i = size / 2 - 1; i >= 0; i--)
        {
            Heapify(list, size, i);
        }
        for (int i = size - 1; i >= 0; i--)
        {
            var tempVar = list[0];
            list[0] = list[i];
            list[i] = tempVar;
            Heapify(list, i, 0);
        }
        return list;
    }
    static void Heapify(List<int> list, int size, int index)
    {
        var largestIndex = index;
        var leftChild = 2 * index + 1;
        var rightChild = 2 * index + 2;

        if (leftChild < size && list[leftChild] > list[largestIndex])
        {
            largestIndex = leftChild;
        }

        if (rightChild < size && list[rightChild] > list[largestIndex])
        {
            largestIndex = rightChild;
        }

        if (largestIndex != index)
        {
            var tempVar = list[index];
            list[index] = list[largestIndex];
            list[largestIndex] = tempVar;

            Heapify(list, size, largestIndex);
        }
    }

}