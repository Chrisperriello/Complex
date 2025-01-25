
namespace COMPLEX;


using LiveCharts;

public class Cnumber
{
    // Static variables for common mathmatical expressions
    private static readonly double _pi = Math.PI;
    private static readonly double _e = Math.E;
    
    //The modulus or magnitude of the Complex number vector
    private double Modulus
    {
        get;
        set;
    }

    private double _theta;
    // The angle that the Complex Number makes with the Real axis
    public double Theta
    {
        get => _theta;
        set{
            if (Re < 0)
            {
                _theta = value + _pi;
            }
            else
            {
                _theta = value;
            }
        }
    }
/// <summary>
/// The constructor for the Complex number class
/// </summary>
/// <param name="arg1">
/// This is either the Real part of the complex number or the Modulus of the complex number depending on flag var</param>
/// <param name="arg2">This is either the imaginary or the angle(theta) of the complex number depending on flag var</param>
/// <param name="flag">Decides how to construct the complex number, either in component for (flag = 0) or Polar form (flag = 1)</param>
/// <exception cref="Exception">Flag must equal either 0 or 1</exception>
    public Cnumber(double arg1, double arg2,int flag =0)
    {
        if (flag == 0)
        {
            Re = arg1;
            Im = arg2;
            Modulus = Math.Sqrt(Math.Pow(arg1, 2) + Math.Pow(arg2, 2));
            Theta = Math.Atan(arg2 / arg2);
        }
        else if (flag == 1)
        {
            Modulus = arg1;
            Theta = arg2;
            Re = arg1 * Math.Cos(arg2);
            Im = arg1 * Math.Sin(arg2);

        }
        else
        {
            throw new Exception("Flag needs to be either 0(Component form) or 1(Exp/Polar form)");
        }
    }
    ///Real component 
    private double Re
    {
        get;
        set;
    }
    ///Imaginary Component
    private double Im
    {
        get;
        set;
    }

    /// <summary>
    /// To string method for printing the complex number
    /// </summary>
    /// <returns>The string to be printed</returns>
    public override string ToString()
    {

        if (Re == 0)
        {
            return $"{Im}i";
        }
        else if (Im == 0)
        {
            return $"{Re}";
        }
        else if (Im < 0)
        {
            return $"{Re} - {-1 * Im}i";
        }
        else
        {
            return $"{Re} + {Im}i";
        }


    }
    /// <summary>
    ///  Coordinate representation 
    /// </summary>
    /// <returns>String of the Coordinate rep</returns>
    public String Coord()
    {
        return $"({Re}), ({Im})";
    }
/// <summary>
/// Static method to add two complex numbers
/// </summary>
/// <param name="c1">First Complex number</param>
/// <param name="c2">Second Complex number</param>
/// <returns>New Complex number that is the sum of c1 and c2</returns>
    public static Cnumber Add(Cnumber c1, Cnumber c2)
    {
        double x = c1.Re + c2.Re;
        double y = c1.Im + c2.Im;
        return new Cnumber(x, y);
    }
/// <summary>
/// Negates the Complex number
/// </summary>
/// <returns>new complex number that is negated</returns>
    private Cnumber Negate()
    {
        return new Cnumber(-this.Re, -this.Im);
    }
/// <summary>
/// Static method to subtract two complex numbers
/// </summary>
/// <param name="c1">First Complex number</param>
/// <param name="c2">Second Complex number</param>
/// <returns>New Complex number that is the difference of c1 and c2</returns>
    public static Cnumber Sub(Cnumber c1, Cnumber c2)
    {
        return Add(c1, c2.Negate());
    }
/// <summary>
/// Makes the complex number the conjugate of itself
/// </summary>
    public void make_conjugate()
    {
        Im *= -1;
    }
/// <summary>
/// Makes a new complex number that is the conjugate of the given Complex number
/// </summary>
/// <param name="c1">Complex Number</param>
/// <returns>Complex number conjugate</returns>
    public static Cnumber Conjugate(Cnumber c1)
    {
        return new Cnumber(c1.Re, -1 * c1.Im);
    }

/// <summary>
/// Multiplies two complex numbers together 
/// </summary>
/// <param name="c1">First Complex number</param>
/// <param name="c2">Second Complex number</param>
/// <returns>New Complex number that is the product of c1 and c2</returns>
    public static Cnumber Multiply(Cnumber c1, Cnumber c2)
    {
        return new Cnumber(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);
    }
    /// <summary>
    /// Divides two complex numbers together 
    /// </summary>
    /// <param name="c1">Numerator Complex number</param>
    /// <param name="c2">Denominator Complex number</param>
    /// <returns>New Complex number that is the quotient of c1 over c2</returns>
    public static Cnumber Divide(Cnumber c1, Cnumber c2)
    {
        Cnumber bottom = Cnumber.Conjugate(c2);
        Cnumber top = Cnumber.Multiply(c1, bottom);
        bottom = Cnumber.Multiply(c2, bottom);
        double num = bottom.Re;
        return new Cnumber(top.Re / num, top.Im / num);

    }
/// <summary>
/// Returns the Modulus of the complex number
/// </summary>
/// <returns>Modulus of the complex number</returns>
    public double Mod()
    {
        return Modulus;
    }
    /// <summary>
    /// Static method that returns the Modulus of the complex number
    /// </summary>
    /// <returns>Modulus of the complex number</returns>
    public static double Mod(Cnumber c)
    {
        return c.Mod();
    }
/// <summary>
/// Determines if the Complex number is equal to another Complex number 
/// </summary>
/// <param name="c2">Complex number to be compared to</param>
/// <returns>True (is equal) or False (not equal)</returns>
    public bool Equal(Cnumber c2)
    {
        return (Re.Equals(c2.Re) && Im.Equals(c2.Im));
    }
/// <summary>
/// Static method that determines if the Complex number is equal to another Complex number 
/// </summary>
/// <param name="c1">First Complex number</param>
/// <param name="c2">Second Complex number</param>
/// <returns>True (is equal) or False (not equal)</returns>
    public static bool Equal(Cnumber c1, Cnumber c2)
    {
        return ((c1.Re).Equals(c2.Re) && (c1.Im).Equals(c2.Im));
    }

    public void print_polar()
    {
        Console.WriteLine($"{Math.Round(Modulus,3)}(cos({Math.Round(Theta,3)}) + i sin({Math.Round(Theta,3)}))");
    }

    public void print_exp()
    {
        Console.WriteLine($"{Math.Round(Modulus, 3)}e^{Math.Round(Theta,3)}i");
    }


}


