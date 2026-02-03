using UnityEngine;

public class Datenmodell : MonoBehaviour
{   
    public bool[] Eingabezeilen = new bool[7];
    public bool[,] Raster = new bool[10, 7];

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
                ApplyFifoShift();
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Eingabezeilen[0] == true)
            {
                Eingabezeilen[0] = false;
            }
            else if (Eingabezeilen[0] == false)
            {
                Eingabezeilen[0] = true;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Eingabezeilen[1] == true)
            {
                Eingabezeilen[1] = false;
            }
            else if (Eingabezeilen[1] == false)
            {
                Eingabezeilen[1] = true;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Eingabezeilen[2] == true)
            {
                Eingabezeilen[2] = false;
            }
            else if (Eingabezeilen[2] == false)
            {
                Eingabezeilen[2] = true;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Eingabezeilen[3] == true)
            {
                Eingabezeilen[3] = false;
            }
            else if (Eingabezeilen[3] == false)
            {
                Eingabezeilen[3] = true;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Eingabezeilen[4] == true)
            {
                Eingabezeilen[4] = false;
            }
            else if (Eingabezeilen[4] == false)
            {
                Eingabezeilen[4] = true;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Eingabezeilen[5] == true)
            {
                Eingabezeilen[5] = false;
            }
            else if (Eingabezeilen[5] == false)
            {
                Eingabezeilen[5] = true;
            }
        }
 
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Eingabezeilen[6] == true)
            {
                Eingabezeilen[6] = false;
            }
            else if (Eingabezeilen[6] == false)
            {
                Eingabezeilen[6] = true;
            }
        }
 
    }

    void ApplyFifoShift()
    {
    // 1. Raster nach oben schieben
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                Raster[row, col] = Raster[row + 1, col];
            }
        }

        // 2. Eingabezeile unten einfügen (Zeile 9)
        for (int col = 0; col < 7; col++)
        {
            Raster[9, col] = Eingabezeilen[col];
        }

        // 3. Eingabezeile zurücksetzen
        for (int i = 0; i < 7; i++)
        {
            Eingabezeilen[i] = false;
        }
    }

 
    
}
