using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPicker : MonoBehaviour
{
    [HideInInspector]
    public const int ORANGE = 0;
    private const string hOrange = "#F3AA16";
    public static Color cOrange = new Color32(243, 170, 22, 255);

    [HideInInspector]
    public const int RED = 1;
    private const string hRED = "#C8444B";
    public static Color cRED = new Color32(200, 68, 75, 255);

    [HideInInspector]
    public const int PURPLE = 2;
    private const string hPURPLE = "#9837A5";
    public static Color cPURPLE = new Color32(152, 55, 165, 255);

    [HideInInspector]
    public const int BLUE = 3;
    private const string hBLUE = "#24B3DF";
    public static Color cBLUE = new Color32(36, 179, 223, 255);

    [HideInInspector]
    public const int VIOLET = 4;
    private const string hVIOLET = "#2B1653";
    public static Color cVIOLET = new Color32(43, 22, 83, 255);

    Color[] colors = { cOrange, cRED, cPURPLE, cBLUE, cVIOLET };
    ArrayList arrayListColors = new ArrayList() { cOrange, cRED, cPURPLE, cBLUE, cVIOLET };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Color PickAColor()
    {
        int i = UnityEngine.Random.Range(0, arrayListColors.Count) ;
        Color color = (Color)arrayListColors[i];
        arrayListColors.Remove(color);
        // TODO
        return color;
    }

    public void RepopulateColors()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            arrayListColors.Add(colors[i]);
        }
    }
}
