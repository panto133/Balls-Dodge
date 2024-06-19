using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private GameLogic gameLogic;
    private Customize customize;
    public GameObject ballGO;
    private Ball ball;

    //PlayerSaveData data;

    public TextMeshProUGUI pentagonsEarned;
    public TextMeshProUGUI tetrahedronsEarned;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    public Slider slider;

    public int pickedUpTetrahedrons;

    private void Awake()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        customize = GameObject.Find("GameLogic").GetComponent<Customize>();
        ball = ballGO.GetComponent<Ball>();       
    }
    private void Update()
    {
        if(slider.value < gameLogic.score)
        {
            slider.value += Time.deltaTime * 5;
        }
    }
    public void GetData()
    {
        LoadProgress();
        score.text = "Score:\n" + gameLogic.score;
        pentagonsEarned.text = "" + Mathf.Round(gameLogic.score / 1.75f);
        gameLogic.pentagons += (int)Mathf.Round(gameLogic.score / 1.75f);
        tetrahedronsEarned.text = "" + pickedUpTetrahedrons;
        //highscore.text = "" + data.highscore;
        //SavingSystem.SavePlayer(customize, gameLogic, ball);
    }

    public void ResetCounter()
    {
        slider.value = 0;
    }
    public void PickedTetrahedron()
    {
        pickedUpTetrahedrons++;
    }
    public void LoadProgress()
    {
        //data = SavingSystem.LoadPlayer();
    }
}
