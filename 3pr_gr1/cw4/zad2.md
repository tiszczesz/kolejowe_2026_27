### Zadanie: Wyniki drużyn

Napisz program w C#, który przechowuje wyniki kilku drużyn w tablicy postrzępionej `int[][]`. Każda drużyna może mieć inną liczbę wyników, np.:

```csharp
int[][] wyniki =
{
    new int[] { 12, 8, 15 },
    new int[] { 10, 14 },
    new int[] { 7, 11, 9, 13 }
};
```

Program ma dla każdej drużyny:

- wypisać wszystkie jej wyniki,
- obliczyć i wypisać sumę punktów,
- znaleźć najwyższy wynik.

Na końcu wypisz numer drużyny z największą sumą punktów. **Nie zakładaj, że wszystkie wiersze tablicy mają tę samą długość.**
