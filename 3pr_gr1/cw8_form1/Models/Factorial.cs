using System;

namespace cw8_form1.Models;

public class Factorial
{
    public static long Run(int n)
    {
        if (n <= 1) return 1;
        return Run(n - 1) * n;
    }

}
