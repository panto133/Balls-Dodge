using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public int highscore;
    public int pentagons;
    public int tetrahedrons;
    public int selectedIndex;
    public int selectedIndexTrail;
    public int equipedIndex;
    public int equipedIndexTrail;
    public int previouslyEquipedIndexTrail;

    public int missileUpgraded;
    public int fortuneUpgraded;
    public int missileBounceUpgraded;
    public int boosterUpgraded;

    public bool[] ballsBought = new bool[12];
    public bool[] trailsBought = new bool[12];

    public bool bossKilled;
    public bool shieldBoosterBought;
    public bool slowTimeBoosterBought;
    public bool convertMissileBoosterBought;
    public bool noAds;

    public PlayerSaveData(GameLogic gameLogic, Ball ball, Customize customize, Spawning spawning)
    {
        highscore = gameLogic.highscore;
        pentagons = gameLogic.pentagons;
        tetrahedrons = gameLogic.tetrahedrons;
        selectedIndex = customize.selectedIndex;
        selectedIndexTrail = customize.selectedIndexTrail;
        equipedIndex = customize.equipedIndex ;
        equipedIndexTrail = customize.equipedIndexTrail;
        previouslyEquipedIndexTrail = customize.previouslyEquipedTrailIndex;

        missileUpgraded = ball.missileUpgraded;
        fortuneUpgraded = ball.fortuneUpgraded;
        missileBounceUpgraded = ball.missileBounceUpgraded;
        boosterUpgraded = ball.boosterUpgraded;

        for (int i = 0; i < ballsBought.Length; i ++)
        {
            ballsBought[i] = customize.ballsBought[i];
            trailsBought[i] = customize.trailsBought[i];
        }

        bossKilled = spawning.bossKilled;
        shieldBoosterBought = ball.shieldBoosterBought;
        slowTimeBoosterBought = ball.slowTimeBoosterBought;
        convertMissileBoosterBought = ball.convertMissileBoosterBought;
        noAds = ball.noAds;
    }
}
