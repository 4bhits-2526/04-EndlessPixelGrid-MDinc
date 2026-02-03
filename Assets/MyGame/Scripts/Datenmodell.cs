using UnityEngine;
using UnityEngine.UI;

public class Datenmodell : MonoBehaviour
{
   
    public bool[] Eingabezeilen = new bool[7];
    public bool[,] Raster = new bool[10, 7];

    
    public Image[] inputLineImages;      // 7 Stück
    public Image[] gridImagesFlat;       // 70 Stück (oben links → unten rechts)

    private Image[,] gridImages = new Image[10, 7];
    void Start()
    {
        // Flat-Array (70) in 2D-Array (10×7) umwandeln
        int index = 0;
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                gridImages[row, col] = gridImagesFlat[index];
                index++;
            }
        }

        RenderAll();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ApplyFifoShift();
            RenderAll();
        }

        if (Input.GetKeyDown(KeyCode.W)) ToggleInput(0);
        if (Input.GetKeyDown(KeyCode.A)) ToggleInput(1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) ToggleInput(2);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ToggleInput(3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ToggleInput(4);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ToggleInput(5);
        if (Input.GetKeyDown(KeyCode.S)) ToggleInput(6);
    }

    void ToggleInput(int index)
    {
        Eingabezeilen[index] = !Eingabezeilen[index];
        RenderInputLine();
    }

        void ApplyFifoShift()
    {
        // Raster nach oben schieben
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                Raster[row, col] = Raster[row + 1, col];
            }
        }

        // Eingabezeile unten einfügen
        for (int col = 0; col < 7; col++)
        {
            Raster[9, col] = Eingabezeilen[col];
        }

        // Eingabezeile zurücksetzen
        for (int i = 0; i < 7; i++)
        {
            Eingabezeilen[i] = false;
        }
    }

    void RenderAll()
    {
        RenderGrid();
        RenderInputLine();
    }

    void RenderGrid()
    {
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                gridImages[row, col].color =
                    Raster[row, col] ? Color.white : Color.black;
            }
        }
    }

    void RenderInputLine()
    {
        for (int i = 0; i < 7; i++)
        {
            inputLineImages[i].color =
                Eingabezeilen[i] ? Color.white : Color.black;
        }
    }
}
