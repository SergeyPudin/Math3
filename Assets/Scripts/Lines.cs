using System;

public delegate void ShowBox(int x, int y, int ball);
public delegate void PlayCat();

public class Lines 
{
    public const int Size = 9;

    ShowBox showBox;
    PlayCat playCat;

    public Lines(ShowBox showBox, PlayCat playCat)
    {
        this.showBox = showBox;
        this.playCat = playCat;
    }

    public void StartGame()
    {

    }

    public void Click(int x, int y)
    {
            
    }
}