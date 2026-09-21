using cw4;

//deklaracja obiektu s1 typu Student
Student s1;
//utworzenie obiektu s1 typu Student
s1 = new Student();
//zainicjalizowanie pól obiektu s1 typu Student
s1.firstname = "Jan";
s1.lastname = "Kowalski";
s1.age = 22;
Console.WriteLine(s1);
Console.WriteLine(s1.GetHashCode());
Console.WriteLine(s1.ToString());
Console.WriteLine(s1.GetType());