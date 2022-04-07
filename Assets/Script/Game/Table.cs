using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Table : MonoBehaviour
{
    private int second = 0;
    private float startTime;
    public Text timeDisplay;
    public Text turnsDisplay;
    [SerializeField] private ClearUI clearUI;
    [SerializeField] private GameObject canvas;

    [SerializeField] private Poles poles;
    public Pole polePrefab;
    public Ball[] ballPrefabs;

    public MoveHistory history;

    public int Turns
    {
        get { return history.Count; }
    }

    public void Undo()
    {
        history.Undo();
        UpdateTurnsDisplay();
    }

    public void ResetTable()
    {
        history.Reset();
        UpdateTurnsDisplay();
    }


    private void Start()
    {
        poles.DefinePolesSize((byte)(Config.BallTypes + Config.EmptyPoles));
        CreateGame();
        timeDisplay.text = "00:00";
        turnsDisplay.text = "0";
        history = new MoveHistory(poles);
        startTime = Time.time;
    }
    private void Update()
    {
        DisplayTime();
    }

    public void CreateGame()
    {
        float space = 2.5f;

        byte ballTypes = Config.BallTypes;
        byte emptyPoles = Config.EmptyPoles;
        byte[] balls = new byte[ballTypes];
        for(int i = 0; i < ballTypes; i++)
        {
            balls[i] = Pole.capacity;
        }

        if (ballTypes + emptyPoles > 6)
        {
            float scale = 0.7f;
            poles.transform.localScale = new Vector3(scale, scale, 1);
            space = space*scale;
        }
        float poleX = -(float)(ballTypes + emptyPoles - 1) / 2f * space;

        for(int i = 0; i < ballTypes; i++)
        {
            Pole pole = Instantiate(polePrefab, poles.transform);
            pole.transform.Translate(new Vector3(poleX, 0, 0));
            poleX += space;
            poles.PushPole(pole);
            pole.SetPoles(poles);

            //fill balls
            for (int j = 0; j < Pole.capacity; j++)
            {
                byte index = (byte)Random.Range(0f, balls.Length);
                while (balls[index] == 0)
                {
                    index = (byte)Random.Range(0f, balls.Length);
                }
                Ball ball = Instantiate(ballPrefabs[index], new Vector3(0, 0, 0), Quaternion.identity);
                balls[index]--;
                pole.Recieve(ball);
                ball.transform.localPosition = new Vector3(0, 0, 0);
                ball.transform.localScale = new Vector3(3.5f, 3.5f, 1);
            }
        }

        for(int i = 0; i < emptyPoles; i++)
        {
            Pole pole = Instantiate(polePrefab, poles.transform);
            pole.transform.Translate(new Vector3(poleX, 0, 0));
            poleX += space;
            poles.PushPole(pole);
            pole.SetPoles(poles);
        }


    }

    public void ClearGame()
    {
        ClearUI clear = Instantiate(clearUI, canvas.transform);
        clear.table = this;
    }

    private void DisplayTime()
    {
        if (Time.time - startTime >= second + 1)
        {
            second++;
            timeDisplay.text = (second / 60).ToString("00") + ":" + (second % 60).ToString("00");
        }
    }

    public void UpdateTurnsDisplay()
    {
        turnsDisplay.text = history.Count.ToString();
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("Title");
    }
}
