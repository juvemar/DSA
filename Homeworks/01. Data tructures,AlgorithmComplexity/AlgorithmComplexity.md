##Data Structures, Algorithms and Complexity Homework

1. ######What is the expected running time of the following C# code?
```
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else 
                end--;
    }
    return count;
}
```
"Compute" method complexity is quadratic(O(n^2)). The reason is that both the 'for-loop' and the 'while-loop' will iterate 'n' times.

2. What is the expected running time of the following C# code?

```
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```
* Worst case: All numbers in the matrix are even and the complexity is quadratic (O(n^2)).
* Best case: All numbers are odd and the complexity is linear(O(n)).
* Average case: Half of  the numbers are even and the complexity is quadratic (O(m*n)).

3. What is the expected running time of the following C# code?
```
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++) 
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1)) 
        sum += CalcSum(matrix, row + 1);
    return sum;
}
Console.WriteLine(CalcSum(matrix, 0));
```
The CalcSum method iterates n times and it is called recursivly m times so its complexity is quadratic(O(n*m)).
There is a best case where the matrix.GetLength(0) is 1 and the matrix.GetLength(1) is 1 too so the 'for-loop' iterates only ones.