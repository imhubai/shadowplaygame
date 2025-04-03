using UnityEngine;
using UnityEngine.Serialization;

public class Level2 : LevelController
{
    [FormerlySerializedAs("FightPlayer")] public FightPlayer fightPlayer;
    [FormerlySerializedAs("FightEnemy")] public FightEnemy fightEnemy;

    public Level2GameOver gameOverHandle;

    private bool isover = false;
    void Start()
    {
        fightPlayer.enabled = false;
        fightEnemy.enabled = false;
    }

    void Update()
    {
        if (isStart)
        {
            if (!fightPlayer.enabled && !fightEnemy.enabled && !isover)
            {
                fightPlayer.enabled = true;
                fightEnemy.enabled = true;
            }
        }
    }
    
    public void GameOver(bool win)
    {
        isover = true;
        gameOverHandle.gameOverPage.SetActive(true);

        gameOverHandle.Init(win, false, 0, 0, false, null);
    }
}