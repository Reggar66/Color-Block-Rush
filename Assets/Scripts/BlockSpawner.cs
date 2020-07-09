using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockSpawner : MonoBehaviour
{
    [Header("Spawning Blocks")] public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public GameObject blockPointPrefab;
    public float spawnRate = 2f;
    private float spawnTime = 2f;
    [HideInInspector] public ArrayList lastSpawnedBlocks = new ArrayList();

    [Header("Color Picker")] public SpriteRenderer playerSpriteRenderer;
    private ColourPicker colourPicker;

    private int gameMode = 0;

    [Header("PowerUps")] public GameObject heal;
    public float timeLeftToHeal = 3f;
    public float timeToHeal = 3f;
    public TextMeshProUGUI healTimerText;

    // Singleton
    private static BlockSpawner instance;

    public static BlockSpawner Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        colourPicker = GetComponent<ColourPicker>();
    }

    // Update is called once per frame
    private void Update()
    {
        GameModePicker();

        if (Time.time >= spawnTime)
        {
            GameModeHandler();
            spawnTime = Time.time + spawnRate;
        }

        SpawnHeal();
    }

    private void GameModePicker()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameMode = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameMode = 1;
        }
    }

    private void GameModeHandler()
    {
        switch (gameMode)
        {
            case 0:
                SpawnBlocks();
                break;
            case 1:
                SpawnColorBlocks();
                break;
        }
    }

    private void SpawnBlocks()
    {
        int randomIdx = Random.Range(0, spawnPoints.Length);

        lastSpawnedBlocks.Clear();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIdx != i)
            {
                GameObject block = Instantiate(blockPrefab, spawnPoints[i].transform);
                lastSpawnedBlocks.Add(block);
            }
            else if (randomIdx == i)
            {
                Instantiate(blockPointPrefab, spawnPoints[i].transform);
            }
        }
    }

    private void SpawnColorBlocks()
    {
        int randomIdx = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIdx != i)
            {
                GameObject block = Instantiate(blockPrefab, spawnPoints[i].transform);
                block.GetComponent<SpriteRenderer>().color = colourPicker.PickAColor();
            }
            else if (randomIdx == i)
            {
                GameObject blockPoint = Instantiate(blockPointPrefab, spawnPoints[i].transform);
                SpriteRenderer spriteRenderer = blockPoint.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
                spriteRenderer.color = colourPicker.PickAColor();
                playerSpriteRenderer.color = spriteRenderer.color;
            }
        }

        colourPicker.RepopulateColors();
    }

    private void SpawnHeal()
    {
        if (timeLeftToHeal <= 0f)
        {
            float x = Random.Range(-5.5f, 5.5f);
            Instantiate(heal, new Vector3(x, 10f), Quaternion.identity);
            timeLeftToHeal = timeToHeal;
        }
        else
        {
            timeLeftToHeal -= Time.deltaTime;
            if (timeLeftToHeal < 0)
            {
                timeLeftToHeal = 0;
            }

            //Debug.Log(timeLeftToHeal);
        }

        float minutes = Mathf.Floor(timeLeftToHeal / 60);
        float seconds = Mathf.Floor(timeLeftToHeal % 60);
        healTimerText.SetText(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }
}