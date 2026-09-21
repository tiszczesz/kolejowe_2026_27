using System;

namespace cw3;

public class Person
{
    //pola czyli właściwości klasy
    public string firstname;
    public string lastname;
    public int age;

    //metody czyli zachwania klasy 
    //nadpiszemy metodę ToString z Object
    public override string ToString()
    {
        return $"typ: {base.ToString()}\t"
        +$"imie: {firstname} nazwisko: {lastname} wiek: {age}";
    }
}
