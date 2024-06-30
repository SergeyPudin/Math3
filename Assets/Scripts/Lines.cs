using System;

public delegate void ShowBox(int x, int y, int ball);
public delegate void PlayCat();

public class Lines 
{
    public const int Size = 9;
    public const int Balls = 7;

    ShowBox showBox;
    PlayCat playCat;

    public Lines(ShowBox showBox, PlayCat playCat)
    {
        this.showBox = showBox;
        this.playCat = playCat;
    }

    public void StartGame()
    {
        playCat();
    }

    public void Click(int x, int y)
    {
        showBox(x, y, (x + y) % Balls);
    }
}