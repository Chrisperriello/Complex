using System;


public class Cnumber{
    protected int real;
    protected int imaginary;

    public int Re{
        get {return real;}
        set {real = value;}
    }

    public int Im{
        get {return imaginary;}
        set {imaginary = value;}
    }


    public override string ToString()
    {
        if(Im > 0){
        return $"{real} + {imaginary}i";
        }
        else if(Re == 0){
            return $"{imaginary}i";
        }
    }
}