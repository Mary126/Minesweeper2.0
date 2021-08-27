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
    public GameObject buttn;
    private Transform boardHolder;
    private Tile[,] grid;

    public class Tile
    {
        public bool isMine;
        public bool isOpen;
        public int count;
        //public int y;

        public Tile(bool mine, bool open, int c)
        {
            isMine = mine;
            isOpen = open;
            count = c;
        }
    }
    void LoadGrid()
    {
        grid = new Tile[columns, rows];
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Tile tile = new Tile(false, false, 0);
                grid[x, y] = tile;
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
                if (grid[mineX, mineY].isMine == false)
                {
                    grid[mineX, mineY].isMine = true;
                    check = true;
                    if (mineY != rows - 1 && mineX != columns - 1) grid[mineX + 1, mineY + 1].count += 1;
                    if (mineY != 0 && mineX != 0) grid[mineX - 1, mineY - 1].count += 1;
                    if (mineY != rows - 1 && mineX != 0) grid[mineX + 1, mineY - 1].count += 1;
                    if (mineY != 0 && mineX != columns - 1) grid[mineX - 1, mineY + 1].count += 1;
                    if (mineX != columns - 1) grid[mineX + 1, mineY].count += 1;
                    if (mineY != rows - 1) grid[mineX, mineY + 1].count += 1;
                    if (mineX != 0) grid[mineX - 1, mineY].count += 1;
                    if (mineY != 0) grid[mineX, mineY - 1].count += 1;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        boardHolder = new GameObject("Canvas").transform;
        LoadGrid();
        PlaceMines();
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject butt = Instantiate(buttn);
                butt.transform.position = new Vector2(x, y);
                butt.name = "Tile";
                butt.transform.SetParent(boardHolder);
                TileController controller = butt.GetComponent<TileController>();
                controller.isMine = grid[x, y].isMine;
                controller.count = grid[x, y].count;
            }
        }
    }
}
