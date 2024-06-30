using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Button[,] _buttons;
    private Image[] _images;
    private Lines _lines;

    private void Start()
    {
        _lines = new(ShowBox, PlayCat);

        InitButtons();
        InitImages();
        _lines.StartGame();        
    }

    public void ShowBox(int x, int y, int ball)
    {
        _buttons[x, y].GetComponent<Image>().sprite = _images[ball].sprite;
    }

    public void PlayCat()
    {
        _audio.Play();
    }

    public void Click()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        int number = GetNumber(name);
        int x = number % Lines.Size;
        int y = number / Lines.Size;

        Debug.Log("Clicked " + x + " / " + y);

        _lines.Click(x, y);
    }

    private void InitButtons()
    {
        _buttons = new Button[Lines.Size, Lines.Size];

        for (int i = 0; i < Lines.Size * Lines.Size; i++)
        {
            _buttons[i % Lines.Size, i / Lines.Size] = GameObject.Find($"Button ({i})").GetComponent<Button>();
        }
    }

    private void InitImages()
    {
        _images = new Image[Lines.Balls];

        for (int i = 0; i < Lines.Balls; i++)
        {
            _images[i] = GameObject.Find($"Image ({i})").GetComponent<Image>();
        }
    }

    private int GetNumber(string name)
    {
        Regex regex = new Regex("\\((\\d+)\\)");
        Match match = regex.Match(name);

        if (match.Success == false)
            throw new System.Exception("Unrecognized object name");

        Group group = match.Groups[1];

        string number = group.Value;

        return Convert.ToInt32(number);
    }
}