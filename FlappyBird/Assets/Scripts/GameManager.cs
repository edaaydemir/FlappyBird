using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float limitVerticalPosition = 3;
    [SerializeField] private float distanceHorizontal = 3;
    [SerializeField] private float distanceVertical = 1.5f;
    [SerializeField] private List<BlockController> listBlock = new List<BlockController>();
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameOverScreen gameOverScreen;

    private readonly Queue<Transform> _queue = new Queue<Transform>();

    public bool IsGameOver { get; private set; }

    private int _count;
    public int score {  get;  set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        playerController.transform.position = Vector3.zero;
        foreach (var item in listBlock)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        IsGameOver = false;
        Spawn();
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;
       // Debug.Log("GAME OVER..");
        gameOverScreen.Setup(score);
       // Debug.Log("GameOverScreen Aktif mi? " + gameOverScreen.gameObject.activeSelf);
    }

    public void OnPlayerPass()
    {
        score++;
        //Debug.Log("Score : " + score);
        _count++;
        if (_count < 3)
            return;

        var first = _queue.Dequeue();
        var last = _queue.Last();

        float y = Random.Range(-limitVerticalPosition, limitVerticalPosition);
        float x = last.position.x + distanceHorizontal;

        first.position = new Vector3(x, y, 0);
        _queue.Enqueue(first);
    }

    [ContextMenu(nameof(Spawn))]
    private void Spawn()
    {
        var playerPosition = playerController.transform.position.x;
        for (var i = 0; i < listBlock.Count; i++)
        {
            var block = listBlock[i];
            float y = Random.Range(-limitVerticalPosition, limitVerticalPosition);
            block.transform.position = new Vector3((i + 1) * distanceHorizontal + playerPosition + 5, y, 0);
            block.Setup(distanceVertical);
            block.gameObject.SetActive(true);

            _queue.Enqueue(block.transform);
        }
    }
}
