namespace COMPLEX;

class Program
{
    static void Main(string[] args)
    {
        Cnumber c1 = new Cnumber(2, 1);
        Cnumber c2 = new Cnumber(0, 2);
        Cnumber ans = new Cnumber(0,0);
        ans = Cnumber.Sub(Cnumber.Pow(c1, 2), Cnumber.Conjugate(c1));
        ans = Cnumber.Divide(ans, c2);
        Console.WriteLine(ans.ToString());
    }
}