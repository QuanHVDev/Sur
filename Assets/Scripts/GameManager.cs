using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private GamePlayUI gamePlayUI;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Player player;

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

    private void Start()
    {
        StartCoroutine(GameLoops());
    }

    [SerializeField] private Transform spawnPlayer;
    [SerializeField]  private List<Transform> spawnPoints;
    
    public bool IsBossDead = false;
    
    
    private List<Enemy> enemies;
    public Player Player { get; private set; }
    private IEnumerator GameLoops()
    {
        enemies = new List<Enemy>();
        Player = Instantiate(player, spawnPlayer);
        for (int i = 0; i < 10; i++)
        {
            var e = Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Count)]);
            e.Init(Player.transform);
            enemies.Add(e);
        }

        yield return new WaitUntil(() =>
        {
            return player.IsDead || IsBossDead;
        });
        Debug.Log("GameOver");
    }
}

public enum StateActor{
    
}