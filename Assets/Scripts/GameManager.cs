using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private GamePlayUI gamePlayUI;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private ActorSO playerDataSO;
    [SerializeField] private ActorSO enemyDataSO;

    [SerializeField] private float gameTimeDuring = 15f;

    private void Start()
    {
        StartCoroutine(GameLoops());
    }

    [SerializeField] private Transform spawnPlayer;
    [SerializeField]  private List<Transform> spawnPoints;
    [SerializeField]  private List<Transform> spawnExps;
    
    public bool IsBossDead = false;
    
    
    private List<Enemy> enemies;
    public Player Player { get; private set; }

    private float startTime;
    private IEnumerator GameLoops()
    {
        startTime = Time.time;
        enemies = new List<Enemy>();
        Player = Instantiate(playerPrefab, spawnPlayer);
        Player.Init(playerDataSO);
        for (int i = 0; i < 10; i++) {
            var e = Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)]);
            e.Init(enemyDataSO);
            e.SetTarget(Player.transform);
            e.name = "enemy_" + i;
            enemies.Add(e);
            
        }

        StartCoroutine(SpawnExpAsync());
        yield return new WaitUntil(() => {
            if (Player.IsDead || IsBossDead || IsOverTime) {
                return true;
            }

            return false;
        });
        
        isSpawnExp = false;
        if (Player.IsDead) {
            foreach (var e in enemies) {
                e.SetCanMove(false);
            }
        }
    }

    private bool isSpawnExp = false;
    [SerializeField] private Exp exp;
    IEnumerator SpawnExpAsync()
    {
        float nextTimeSpawn = 0;
        float deltaTime = 1f;
        isSpawnExp = true;
        while (isSpawnExp)
        {
            yield return new WaitForSeconds(deltaTime);
            Instantiate(exp, spawnExps[Random.Range(0, spawnExps.Count)]);
        }
    }

    
    
    
    
    public Vector3 GetTouchDir()
    {
        if (gamePlayUI.TouchDir != Vector3.zero)
        {
            return gamePlayUI.TouchDir;
        }

        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            dir.x = -1;
        }

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            dir.y = 1;
        }

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            dir.y = -1;
        }

        return dir.normalized;
    }

    public bool IsOverTime => startTime + gameTimeDuring < Time.time;

}

public enum StateActor{
    
}