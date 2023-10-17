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
    

    
    public static TimeSpan Gorner(List<int> list, int size)
    {

        var watch = Stopwatch.StartNew();
        var result = GornerArray(list, 0, size - 1);
        watch.Stop();

        return watch.Elapsed;
    }
    private static int GornerArray(List<int> list, int lIndex, int rIndex)
    {
        return 0;
        int x;
        int i;
        return list[lIndex] + x * GornerArray(list, x, i + 1);
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
    }
    
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

}