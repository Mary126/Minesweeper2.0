using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardGenerator : MonoBehaviour
{
    public int columns = 8;
    public int rows = 8;
    public int mines = 4;
    public GameObject tile;
    private Transform boardHolder;
    public GameObject[,] grid;
    public GameManager manager;

    public class Tile
    {
        public bool isMine;
        public bool isOpen;
        public int count;

        public Tile(bool mine, bool open, int c)
        {
            isMine = mine;
            isOpen = open;
            count = c;
        }
    }
    void LoadGrid()
    {
        grid = new GameObject[columns, rows];
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void PlaceMines()
    {
        for (int i = 0; i < mines; i++)
        {
            bool check = false;
            while (!check)
            {
                int mineX = Random.Range(0, columns - 1);
                int mineY = Random.Range(0, rows - 1);
                TileController controller = grid[mineX, mineY].GetComponent<TileController>();
                if (controller.isMine == false)
                {
                    controller.isMine = true;
                    check = true;
                    if (mineY != rows - 1 && mineX != columns - 1) grid[mineX + 1, mineY + 1].GetComponent<TileController>().count += 1;
                    if (mineY != 0 && mineX != 0) grid[mineX - 1, mineY - 1].GetComponent<TileController>().count += 1;
                    if (mineY != rows - 1 && mineX != 0) grid[mineX - 1, mineY + 1].GetComponent<TileController>().count += 1;
                    if (mineY != 0 && mineX != columns - 1) grid[mineX + 1, mineY - 1].GetComponent<TileController>().count += 1;
                    if (mineX != columns - 1) grid[mineX + 1, mineY].GetComponent<TileController>().count += 1;
                    if (mineY != rows - 1) grid[mineX, mineY + 1].GetComponent<TileController>().count += 1;
                    if (mineX != 0) grid[mineX - 1, mineY].GetComponent<TileController>().count += 1;
                    if (mineY != 0) grid[mineX, mineY - 1].GetComponent<TileController>().count += 1;
                }
            }
        }
    }
    void GenerateTile(int x, int y)
    {
        GameObject Tile = Instantiate(tile);
        Tile.transform.position = new Vector2(x, y);
        Tile.name = "Tile";
        Tile.transform.SetParent(boardHolder);
        TileController controller = Tile.GetComponent<TileController>();
        controller.isMine = false;
        controller.count = 0;
        controller.x = x;
        controller.y = y;
        controller.manager = manager;
        grid[x, y] = Tile;

    }
    // Start is called before the first frame update
    void Awake()
    {
        boardHolder = new GameObject("Canvas").transform;
        LoadGrid();
        PlaceMines();
    }

    
    void Update()
    {
        
    }
}
