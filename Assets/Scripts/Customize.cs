using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customize : MonoBehaviour
{
    public GameObject[] customizeCost;
    public GameObject[] boughtCheckmark;
    public GameObject[] customizeTrailCost;
    public GameObject[] boughtTrailCheckmark;
    public GameObject[] selected;
    public GameObject[] equiped;
    public GameObject[] trails;
    public GameObject[] selectedTrails;
    public GameObject[] equipedTrails;

    public GameObject ball;
    public GameObject spawningGO;
    public GameObject shop;
    public GameObject previewScene;

    private GameObject previouslySelected;
    private GameObject previouslyEquiped;
    private GameObject previouslySelectedTrail;
    private GameObject previouslyEquipedTrail;

    public Sprite[] customizeSprites;
    public Button[] customizeButtons;

    public Button buyButton;
    public Button buyButtonTrail;
    public Button previewButton;

    private GameLogic gameLogic;
    private Ball ballScript;

    public int selectedIndex = 0;
    public int equipedIndex = 0;
    public int selectedIndexTrail;
    public int equipedIndexTrail;
    public int previouslyEquipedTrailIndex;
    private int previewTrailIndex;

    [HideInInspector]
    public bool[] ballsBought = new bool[12];
    [HideInInspector]
    public bool[] trailsBought = new bool[12];

    private void Awake()
    {
        gameLogic = gameObject.GetComponent<GameLogic>();
        ballScript = ball.GetComponent<Ball>();

        previouslySelected = selected[0];
        previouslyEquiped = equiped[0];

        ballsBought[0] = true;
        trailsBought[0] = false;

        for(int i = 1; i < ballsBought.Length; i ++)
        {
            ballsBought[i] = false;
            trailsBought[i] = false;
        }
    }

    private void Start()
    {
        LoadProgress();
    }
    public void Orange()
    {
        previouslySelected.SetActive(false);
        previouslySelected = selected[0];
        selected[0].SetActive(true);
        selectedIndex = 0;
        ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[0];
        previouslyEquiped.SetActive(false);
        previouslyEquiped = equiped[0];
        equiped[0].SetActive(true);
        equipedIndex = 0;
        buyButton.interactable = false;
    }
    public void Green()
    {
        if (!ballsBought[1])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[1];
        selected[1].SetActive(true);
        selectedIndex = 1;
        if (ballsBought[1])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[1];
            equiped[1].SetActive(true);
            equipedIndex = 1;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[1];
        }

    }
    public void Purple()
    {
        if (!ballsBought[2])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[2];
        selected[2].SetActive(true);
        selectedIndex = 2;
        if (ballsBought[2])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[2];
            equiped[2].SetActive(true);
            equipedIndex = 2;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[2];
        }

    }
    public void Red()
    {
        if (!ballsBought[3])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[3];
        selected[3].SetActive(true);
        selectedIndex = 3;
        if (ballsBought[3])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[3];
            equiped[3].SetActive(true);
            equipedIndex = 3;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[3];
        }
    }
    public void Pink()
    {
        if (!ballsBought[4])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[4];
        selected[4].SetActive(true);
        selectedIndex = 4;
        if (ballsBought[4])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[4];
            equiped[4].SetActive(true);
            equipedIndex = 4;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[4];
        }
    }
    public void Blue()
    {
        if (!ballsBought[5])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[5];
        selected[5].SetActive(true);
        selectedIndex = 5;
        if (ballsBought[5])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[5];
            equiped[5].SetActive(true);
            equipedIndex = 5;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[5];
        }
    }
    public void Smiley()
    {
        if (!ballsBought[6])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[6];
        selected[6].SetActive(true);
        selectedIndex = 6;
        if (ballsBought[6])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[6];
            equiped[6].SetActive(true);
            equipedIndex = 6;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[6];
        }
    }
    public void Marble()
    {
        if (!ballsBought[7])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[7];
        selected[7].SetActive(true);
        selectedIndex = 7;
        if (ballsBought[7])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[7];
            equiped[7].SetActive(true);
            equipedIndex = 7;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[7];
        }
    }
    public void Rainbow()
    {
        if (!ballsBought[8])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[8];
        selected[8].SetActive(true);
        selectedIndex = 8;
        if (ballsBought[8])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[8];
            equiped[8].SetActive(true);
            equipedIndex = 8;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[8];
        }
    }
    public void Football()
    {
        if (!ballsBought[9])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[9];
        selected[9].SetActive(true);
        selectedIndex = 9;
        if (ballsBought[9])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[9];
            equiped[9].SetActive(true);
            equipedIndex = 9;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[9];
        }
    }
    public void Tennisball()
    {
        if (!ballsBought[10])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[10];
        selected[10].SetActive(true);
        selectedIndex = 10;
        if (ballsBought[10])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[10];
            equiped[10].SetActive(true);
            equipedIndex = 10;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[10];
        }
    }
    public void Basketball()
    {
        if (!ballsBought[11])
            buyButton.interactable = true;
        previouslySelected.SetActive(false);
        previouslySelected = selected[11];
        selected[11].SetActive(true);
        selectedIndex = 11;
        if (ballsBought[11])
        {
            previouslyEquiped.SetActive(false);
            previouslyEquiped = equiped[11];
            equiped[11].SetActive(true);
            equipedIndex = 11;
            buyButton.interactable = false;
            ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[11];
        }
    }

    public void OrangeTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[0])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[0];
        selectedTrails[0].SetActive(true);
        selectedIndexTrail = 1;
        if (trailsBought[0])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[0];
            equipedTrails[0].SetActive(true);
            equipedIndexTrail = 1;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[0].SetActive(true);
            previouslyEquipedTrailIndex = 0;
        }
    }
    public void GreenTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[1])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[1];
        selectedTrails[1].SetActive(true);
        selectedIndexTrail = 2;
        if (trailsBought[1])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[1];
            equipedTrails[1].SetActive(true);
            equipedIndexTrail = 2;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[1].SetActive(true);
            previouslyEquipedTrailIndex = 1;
        }
    }
    public void PurpleTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[2])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[2];
        selectedTrails[2].SetActive(true);
        selectedIndexTrail = 3;
        if (trailsBought[2])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[2];
            equipedTrails[2].SetActive(true);
            equipedIndexTrail = 3;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[2].SetActive(true);
            previouslyEquipedTrailIndex = 2;
        }
    }
    public void RedTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[3])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[3];
        selectedTrails[3].SetActive(true);
        selectedIndexTrail = 4;
        if (trailsBought[3])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[3];
            equipedTrails[3].SetActive(true);
            equipedIndexTrail = 4;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[3].SetActive(true);
            previouslyEquipedTrailIndex = 3;
        }
    }
    public void PinkTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[4])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[4];
        selectedTrails[4].SetActive(true);
        selectedIndexTrail = 5;
        if (trailsBought[4])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[4];
            equipedTrails[4].SetActive(true);
            equipedIndexTrail = 5;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[4].SetActive(true);
            previouslyEquipedTrailIndex = 4;
        }
    }
    public void BlueTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[5])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[5];
        selectedTrails[5].SetActive(true);
        selectedIndexTrail = 6;
        if (trailsBought[5])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[5];
            equipedTrails[5].SetActive(true);
            equipedIndexTrail = 6;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[5].SetActive(true);
            previouslyEquipedTrailIndex = 5;
        }
    }
    public void SmileyTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[6])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[6];
        selectedTrails[6].SetActive(true);
        selectedIndexTrail = 7;
        if (trailsBought[6])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[6];
            equipedTrails[6].SetActive(true);
            equipedIndexTrail = 7;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[6].SetActive(true);
            previouslyEquipedTrailIndex = 6;
        }
    }
    public void MarbleTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[6])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[7];
        selectedTrails[7].SetActive(true);
        selectedIndexTrail = 8;
        if (trailsBought[7])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[7];
            equipedTrails[7].SetActive(true);
            equipedIndexTrail = 8;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[7].SetActive(true);
            previouslyEquipedTrailIndex = 7;
        }
    }
    public void RainbowTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[8])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[8];
        selectedTrails[8].SetActive(true);
        selectedIndexTrail = 9;
        if (trailsBought[8])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[8];
            equipedTrails[8].SetActive(true);
            equipedIndexTrail = 9;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[8].SetActive(true);
            previouslyEquipedTrailIndex = 8;
        }
    }
    public void FootballTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[9])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[9];
        selectedTrails[9].SetActive(true);
        selectedIndexTrail = 10;
        if (trailsBought[9])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[9];
            equipedTrails[9].SetActive(true);
            equipedIndexTrail = 10;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[9].SetActive(true);
            previouslyEquipedTrailIndex = 9;
        }
    }
    public void TennisballTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[10])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[10];
        selectedTrails[10].SetActive(true);
        selectedIndexTrail = 11;
        if (trailsBought[10])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[10];
            equipedTrails[10].SetActive(true);
            equipedIndexTrail = 11;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[10].SetActive(true);
            previouslyEquipedTrailIndex = 10;
        }
    }
    public void BasketballTrail()
    {
        previewButton.interactable = true;
        if (!trailsBought[11])
            buyButtonTrail.interactable = true;
        if (previouslySelectedTrail != null)
            previouslySelectedTrail.SetActive(false);
        previouslySelectedTrail = selectedTrails[11];
        selectedTrails[11].SetActive(true);
        selectedIndexTrail = 12;
        if (trailsBought[11])
        {
            if (previouslyEquipedTrail != null)
                previouslyEquipedTrail.SetActive(false);
            previouslyEquipedTrail = equipedTrails[11];
            equipedTrails[11].SetActive(true);
            equipedIndexTrail = 12;
            buyButtonTrail.interactable = false;
            trails[previouslyEquipedTrailIndex].SetActive(false);
            trails[11].SetActive(true);
            previouslyEquipedTrailIndex = 11;
        }
    }

    public void BuyButtonTrail()
    {
        switch (selectedIndexTrail)
        {
            case 1:
                if (!trailsBought[0] && gameLogic.pentagons >= 500)
                {
                    customizeTrailCost[0].SetActive(false);
                    boughtTrailCheckmark[0].SetActive(true);
                    trailsBought[0] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 500;
                }
                OrangeTrail();
                break;
            case 2:
                if (!trailsBought[1] && gameLogic.pentagons >= 500)
                {
                    customizeTrailCost[1].SetActive(false);
                    boughtTrailCheckmark[1].SetActive(true);
                    trailsBought[1] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 500;
                }
                GreenTrail();
                break;
            case 3:
                if (!trailsBought[2] && gameLogic.pentagons >= 500)
                {
                    customizeTrailCost[2].SetActive(false);
                    boughtTrailCheckmark[2].SetActive(true);
                    trailsBought[2] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 500;
                }
                PurpleTrail();
                break;
            case 4:
                if (!trailsBought[3] && gameLogic.pentagons >= 500)
                {
                    customizeTrailCost[3].SetActive(false);
                    boughtTrailCheckmark[3].SetActive(true);
                    trailsBought[3] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 500;
                }
                RedTrail();
                break;
            case 5:
                if (!trailsBought[4] && gameLogic.pentagons >= 500)
                {
                    customizeTrailCost[4].SetActive(false);
                    boughtTrailCheckmark[4].SetActive(true);
                    trailsBought[4] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 500;
                }
                PinkTrail();
                break;
            case 6:
                if (!trailsBought[5] && gameLogic.pentagons >= 500)
                {
                    customizeTrailCost[5].SetActive(false);
                    boughtTrailCheckmark[5].SetActive(true);
                    trailsBought[5] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 500;
                }
                BlueTrail();
                break;
            case 7:
                if (!trailsBought[6] && gameLogic.tetrahedrons >= 20)
                {
                    customizeTrailCost[6].SetActive(false);
                    boughtTrailCheckmark[6].SetActive(true);
                    trailsBought[6] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 20;
                }
                SmileyTrail();
                break;
            case 8:
                if (!trailsBought[7] && gameLogic.tetrahedrons >= 20)
                {
                    customizeTrailCost[7].SetActive(false);
                    boughtTrailCheckmark[7].SetActive(true);
                    trailsBought[7] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 20;
                }
                MarbleTrail();
                break;
            case 9:
                if (!trailsBought[8] && gameLogic.tetrahedrons >= 20)
                {
                    customizeTrailCost[8].SetActive(false);
                    boughtTrailCheckmark[8].SetActive(true);
                    trailsBought[8] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 20;
                }
                RainbowTrail();
                break;
            case 10:
                if (!trailsBought[9] && gameLogic.tetrahedrons >= 20)
                {
                    customizeTrailCost[9].SetActive(false);
                    boughtTrailCheckmark[9].SetActive(true);
                    trailsBought[9] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 20;
                }
                FootballTrail();
                break;
            case 11:
                if (!trailsBought[10] && gameLogic.tetrahedrons >= 20)
                {
                    customizeTrailCost[10].SetActive(false);
                    boughtTrailCheckmark[10].SetActive(true);
                    trailsBought[10] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 20;
                }
                TennisballTrail();
                break;
            case 12:
                if (!trailsBought[11] && gameLogic.tetrahedrons >= 20)
                {
                    customizeTrailCost[11].SetActive(false);
                    boughtTrailCheckmark[11].SetActive(true);
                    trailsBought[11] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 20;
                }
                BasketballTrail();
                break;
        }
        SaveProgress();
    }
    public void BuyButton()
    {
        switch (selectedIndex)
        {
            case 0:
                buyButton.interactable = false;
                Orange();
                break;
            case 1:
                if (!ballsBought[1] && gameLogic.pentagons >= 100)
                {
                    customizeCost[1].SetActive(false);
                    boughtCheckmark[1].SetActive(true);
                    ballsBought[1] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 100;
                }
                Green();
                break;
            case 2:
                if (!ballsBought[2] && gameLogic.pentagons >= 100)
                {
                    customizeCost[2].SetActive(false);
                    boughtCheckmark[2].SetActive(true);
                    ballsBought[2] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 100;
                }
                Purple();
                break;
            case 3:
                if (!ballsBought[3] && gameLogic.pentagons >= 100)
                {
                    customizeCost[3].SetActive(false);
                    boughtCheckmark[3].SetActive(true);
                    ballsBought[3] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 100;
                }
                Red();
                break;
            case 4:
                if (!ballsBought[4] && gameLogic.pentagons >= 100)
                {
                    customizeCost[4].SetActive(false);
                    boughtCheckmark[4].SetActive(true);
                    ballsBought[4] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 100;
                }
                Pink();
                break;
            case 5:
                if (!ballsBought[5] && gameLogic.pentagons >= 100)
                {
                    customizeCost[5].SetActive(false);
                    boughtCheckmark[5].SetActive(true);
                    ballsBought[5] = true;
                    buyButton.interactable = false;
                    gameLogic.pentagons -= 100;
                }
                Blue();
                break;
            case 6:
                if (!ballsBought[6] && gameLogic.tetrahedrons >= 10)
                {
                    customizeCost[6].SetActive(false);
                    boughtCheckmark[6].SetActive(true);
                    ballsBought[6] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 10;
                }
                Smiley();
                break;
            case 7:
                if (!ballsBought[7] && gameLogic.tetrahedrons >= 10)
                {
                    customizeCost[7].SetActive(false);
                    boughtCheckmark[7].SetActive(true);
                    ballsBought[7] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 10;
                }
                Marble();
                break;
            case 8:
                if (!ballsBought[8] && gameLogic.tetrahedrons >= 10)
                {
                    customizeCost[8].SetActive(false);
                    boughtCheckmark[8].SetActive(true);
                    ballsBought[8] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 10;
                }
                Rainbow();
                break;
            case 9:
                if (!ballsBought[9] && gameLogic.tetrahedrons >= 10)
                {
                    customizeCost[9].SetActive(false);
                    boughtCheckmark[9].SetActive(true);
                    ballsBought[9] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 10;
                }
                Football();
                break;
            case 10:
                if (!ballsBought[10] && gameLogic.tetrahedrons >= 10)
                {
                    customizeCost[10].SetActive(false);
                    boughtCheckmark[10].SetActive(true);
                    ballsBought[10] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 10;
                }
                Tennisball();
                break;
            case 11:
                if (!ballsBought[11] && gameLogic.tetrahedrons >= 10)
                {
                    customizeCost[11].SetActive(false);
                    boughtCheckmark[11].SetActive(true);
                    ballsBought[11] = true;
                    buyButton.interactable = false;
                    gameLogic.tetrahedrons -= 10;
                }
                Basketball();
                break;
        }
        SaveProgress();
    }
    public void PreviewButton()
    {
        trails[equipedIndexTrail-1].SetActive(false);
        previewScene.SetActive(true);
        shop.SetActive(false);
        ball.transform.position = new Vector3(0, 0, 0);
        ball.GetComponent<SpriteRenderer>().enabled = false;
        ball.SetActive(true);
        switch (selectedIndexTrail-1)
        {
            case 0:
                trails[0].SetActive(true);
                previewTrailIndex = 0;
                break;
            case 1:
                trails[1].SetActive(true);
                previewTrailIndex = 1;
                break;
            case 2:
                trails[2].SetActive(true);
                previewTrailIndex = 2;
                break;
            case 3:
                trails[3].SetActive(true);
                previewTrailIndex = 3;
                break;
            case 4:
                trails[4].SetActive(true);
                previewTrailIndex = 4;
                break;
            case 5:
                trails[5].SetActive(true);
                previewTrailIndex = 5;
                break;
            case 6:
                trails[6].SetActive(true);
                previewTrailIndex = 6;
                break;
            case 7:
                trails[7].SetActive(true);
                previewTrailIndex = 7;
                break;
            case 8:
                trails[8].SetActive(true);
                previewTrailIndex = 8;
                break;
            case 9:
                trails[9].SetActive(true);
                previewTrailIndex = 9;
                break;
            case 10:
                trails[10].SetActive(true);
                previewTrailIndex = 10;
                break;
            case 11:
                trails[11].SetActive(true);
                previewTrailIndex = 11;
                break;
        }
    }
    public void FromPreviewToShop()
    {
        previewScene.SetActive(false);
        shop.SetActive(true);
        ball.GetComponent<SpriteRenderer>().enabled = true;
        ball.SetActive(false);
        trails[previewTrailIndex].SetActive(false);
        trails[equipedIndexTrail - 1].SetActive(true);
    }
    public void LoadProgress()
    {
        PlayerSaveData data = SavingSystem.LoadPlayer();
        if (data != null)
        {
            selectedIndex = data.selectedIndex;
            selectedIndexTrail = data.selectedIndexTrail;
            equipedIndex = data.equipedIndex;
            equipedIndexTrail = data.equipedIndexTrail;
            previouslyEquipedTrailIndex = data.previouslyEquipedIndexTrail;

            for (int i = 0; i < ballsBought.Length; i++)
            {
                ballsBought[i] = data.ballsBought[i];
                trailsBought[i] = data.trailsBought[i];
            }
            CheckIfBought();
        }
    }
    public void CheckIfBought()
    {
        //If first ball isn't equipped unequip it bcs after exiting game it will return to default
        if(selectedIndex != 0)
        {
            selected[0].SetActive(false);
        }
        if(equipedIndex != 0)
        {
            equiped[0].SetActive(false);
        }

        //Checking which ball is bought and setting up shop
        for (int i = 0; i < 12; i++) 
        {
            if(ballsBought[i])
            {
                customizeCost[i].SetActive(false);
                boughtCheckmark[i].SetActive(true);
            }
        }

        //Checking which trail is bought and setting up shop
        for (int i = 0; i < 12; i++)
        {
            if(trailsBought[i])
            {
                customizeTrailCost[i].SetActive(false);
                boughtTrailCheckmark[i].SetActive(true);
            }
        }

        //Checking which ball is selected
        for (int i = 0; i < 12; i++) 
        {
            if (i == selectedIndex)
            {
                selected[i].SetActive(true);
                previouslySelected = selected[i];
            }
        }

        //Checking which ball is equiped
        for (int i = 0; i < 12; i++) 
        {
            if (i == equipedIndex)
            {
                equiped[i].SetActive(true);
                previouslyEquiped = equiped[i];
                ball.GetComponent<SpriteRenderer>().sprite = customizeSprites[i];
            }
        }

        //Checking which trail is selected
        for (int i = 1; i <= 12; i++)
        {
            if(i == selectedIndexTrail)
            {
                selectedTrails[i-1].SetActive(true);
                previouslySelectedTrail = selectedTrails[i-1];
            }
        }

        //Checking which trail is equiped
        for (int i = 1; i <= 12; i++)
        {
            if(i == equipedIndexTrail)
            {
               
                equipedTrails[i-1].SetActive(true);
                previouslyEquipedTrail = equipedTrails[i-1];
                trails[i-1].SetActive(true);
            }
        }
    }
    public void SaveProgress()
    {
        SavingSystem.SavePlayer(gameLogic, ballScript, this, spawningGO.GetComponent<Spawning>());
    }
}
