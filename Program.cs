namespace COMPLEX;

class Program
{
    static void Main(string[] args)
    {
        Cnumber c1 = new Cnumber(2, 5);
        Cnumber c2 = new Cnumber(2, -1);
        Cnumber c3 = Cnumber.Conjugate(Cnumber.Conjugate(c1));
        Cnumber c4 = new Cnumber(-3, 3);
        Console.WriteLine($"{c1} and {c2}");
        Console.WriteLine(Cnumber.Add(c1,c2));
        Console.WriteLine(Cnumber.Sub(c1,c2));
        Console.WriteLine(Cnumber.Multiply(c1,c2));
        Console.WriteLine(Cnumber.Conjugate(c1));
        

       
        c4.print_exp();
      
}
}