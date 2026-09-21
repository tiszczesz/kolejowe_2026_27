using System;

namespace cw4;

public class Student
{
    //pola klasy - właściwości obiektu
    //pola publiczne czyli dostępne z każdego miejsca
    //  w programie
    public string firstname;
    public string lastname;
    public int age;

    //metody klasy Student - zachowanie obiektu
    //nadpisujemy metodę ToString z klasy Object
    public override string ToString()
    {
        return $"typ: {base.ToString()} zawartość: {firstname}"
        + $" {lastname} {age}";
    }
}
