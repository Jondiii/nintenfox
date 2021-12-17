using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GroundGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint; //Point from where ground tiles will start
    public PlatformTile tilePrefab;
    public float movingSpeed = 12;
    public int tilesToPreSpawn = 15; //How many tiles should be pre-spawned
    public int tilesWithoutObstacles = 3; //How many tiles at the beginning should not have obstacles, good for warm-up
    public MyGameManager gameManager;

    List<PlatformTile> spawnedTiles = new List<PlatformTile>();

    [HideInInspector]
    public bool gameOver = false;
    static bool gameStarted = false;
    public float score = 0;

    public static GroundGenerator instance;

    public int fontSize = 20;

    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;
        int tilesWithNoObstaclesTmp = tilesWithoutObstacles;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            PlatformTile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity) as PlatformTile;
            if (tilesWithNoObstaclesTmp > 0)
            {
                spawnedTile.DeactivateAllObstacles();
                tilesWithNoObstaclesTmp--;
            }
            else
            {
                spawnedTile.ActivateRandomObstacle();
            }

            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object upward in world space x unit/second.
        //Increase speed the higher score we get
        if (!gameOver && gameStarted)
        {
            transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (movingSpeed + (score / 500)), Space.World);
        }

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < 0)
        {
            //Move the tile to the front if it's behind the Camera
            PlatformTile tileTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTmp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
            tileTmp.ActivateRandomObstacle();
            spawnedTiles.Add(tileTmp);
        }

        if (gameOver || !gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameOver)
                {
                    gameManager.player.nMonedas = gameManager.player.nMonedas + score;
                    gameManager.SaveGame();
                    Debug.Log("Ahora tienes " + gameManager.player.nMonedas + " monedas");
                    //Ir a la escena de RA
                    SceneManager.LoadScene(1);
                }
                else
                {
                    //Start the game
                    gameStarted = true;
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;

        if (gameOver)
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Game Over\nYour score is: "
                + ((int)score) + "\nPress 'Space' to end the minigame.");
        }
        else
        {
            if (!gameStarted)
            {
                GUI.color = Color.black;
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Press 'Space' to start");
            }
        }
        GUI.color = Color.green;
        GUI.Label(new Rect(5, 5, 200000, 25000), "Score: " + ((int)score));
    }
}