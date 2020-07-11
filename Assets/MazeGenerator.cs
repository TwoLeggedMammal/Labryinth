using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public Texture2D mazeTexture;
    public GameObject wallPrefab;
    public GameObject player1;
    public GameObject player2;
    public GameObject goalPrefab;

    void Start()
    {
        Color wallColor = new Color(0f, 0f, 0f);
        Color startColor = new Color(0f, 1f, 0f);
        Color endColor = new Color(1f, 0f, 0f);
        int texWidth = mazeTexture.width;
        int texHeight = mazeTexture.height;
        var floorWidth = gameObject.transform.localScale.x * 10;
        var floorHeight = gameObject.transform.localScale.z * 10;
        int step = 15;

        for(int x = 0; x < texWidth; x += step)
        {
            for (int y = 0; y < texHeight; y += step)
            {
                var color = mazeTexture.GetPixel(x, y);

                // black means walls
                if (color.Equals(wallColor) || color.Equals(startColor) || color.Equals(endColor))
                {
                    var xPct = (float)x / (float)texWidth;
                    var yPct = (float)y / (float)texHeight;
                    var realPosition = new Vector3((floorWidth * xPct) - (floorWidth / 2), 0, (floorHeight * yPct) - (floorHeight / 2));
                    var obj = Instantiate(wallPrefab, realPosition, Quaternion.identity);
                }
            }
        }

        // Place players in the start position
        bool found = false;
        for (int x = 0; x < texWidth && !found; x++)
        {
            for (int y = 0; y < texHeight; y++)
            {
                var color = mazeTexture.GetPixel(x, y);

                // green means starting spot
                if (color.Equals(startColor))
                {
                    var xPct = (float)x / (float)texWidth;
                    var yPct = (float)y / (float)texHeight;
                    var realPosition = new Vector3((floorWidth * xPct) - (floorWidth / 2), 20, (floorHeight * yPct) - (floorHeight / 2));

                    if (player1 != null)
                    {
                        player1.transform.position = realPosition;
                    }
                    if (player2 != null)
                    {
                        player2.transform.position = realPosition;
                        player1.transform.Translate(new Vector3(-2, 0, 0));
                        player2.transform.Translate(new Vector3(2, 0, 0));
                    }

                    found = true;
                    break;
                }
            }
        }

        // Place the end position
        found = false;
        for (int x = 0; x < texWidth && !found; x++)
        {
            for (int y = 0; y < texHeight; y++)
            {
                var color = mazeTexture.GetPixel(x, y);

                // red means ending spot
                if (color.Equals(endColor))
                {
                    var xPct = (float)x / (float)texWidth;
                    var yPct = (float)y / (float)texHeight;
                    var realPosition = new Vector3((floorWidth * xPct) - (floorWidth / 2), 15, (floorHeight * yPct) - (floorHeight / 2));

                    var obj = Instantiate(goalPrefab, realPosition, Quaternion.identity);

                    found = true;
                    break;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
