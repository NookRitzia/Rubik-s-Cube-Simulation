using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    private int redValue;
    private int greenValue;
    private int blueValue;

    public Color(int r, int g, int b)
    {
        redValue = r;
        greenValue = g;
        blueValue = b;
    }

    public int getRed()
    {
        return redValue;
    }

    public int getGreen()
    {
        return greenValue;
    }

    public int getBlue()
    {
        return blueValue;
    }

    public string toHex()
    {
        string output = "#";
        output += hexFormat(redValue / 16);
        output += hexFormat(redValue % 16);
        output += hexFormat(greenValue / 16);
        output += hexFormat(greenValue % 16);
        output += hexFormat(blueValue / 16);
        output += hexFormat(blueValue % 16);
        return output;
    }

    private string hexFormat(int n) // returns 0-9 if n is 0-9 and returns A-F for 10-15
    {
        if (n <= 9)
            return n.ToString();
        switch (n)
        {
            case 10:
                return "A";
            case 11:
                return "B";
            case 12:
                return "C";
            case 13:
                return "D";
            case 14:
                return "E";
            case 15:
                return "F";
            default:
                return "Hex Conversion Error";
        }

    }

    public string ToString()
    {
        return "(" + redValue + ", " + greenValue + ", " + blueValue + ")";
    }
}
