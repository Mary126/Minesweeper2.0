using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int columns = 8;
    private int rows = 8;
    public BoardGenerator board;
    public GameObject[,] grid;
    public Sprite[] prefabs;
    public Sprite mine;
    public Sprite flag;
    public Sprite field;
    private int flagCount;
    private int winning = 0;
    public void Open_all_none(int x_pos, int y_pos)
    {
        if (y_pos == rows || x_pos == columns || x_pos == -1 || y_pos == -1) return;
        if (grid[x_pos, y_pos].GetComponent<TileController>().isOpen) return;
        if (grid[x_pos, y_pos].GetComponent<TileController>().count != 0)
        {
            grid[x_pos, y_pos].GetComponent<SpriteRenderer>().sprite = prefabs[grid[x_pos, y_pos].GetComponent<TileController>().count];
            grid[x_pos, y_pos].GetComponent<TileController>().isOpen = true;
            return;
        }
        grid[x_pos, y_pos].GetComponent<TileController>().isOpen = true;
        grid[x_pos, y_pos].GetComponent<SpriteRenderer>().sprite = prefabs[0];
        Open_all_none(x_pos + 1, y_pos + 1);
        Open_all_none(x_pos - 1, y_pos - 1);
        Open_all_none(x_pos + 1, y_pos - 1);
        Open_all_none(x_pos - 1, y_pos + 1);
        Open_all_none(x_pos, y_pos + 1);
        Open_all_none(x_pos + 1, y_pos);
        Open_all_none(x_pos, y_pos - 1);
        Open_all_none(x_pos - 1, y_pos);
    }
    public void PutFlag(int x, int y)
    {
        grid[x, y].GetComponent<SpriteRenderer>().sprite = flag;
        if (grid[x, y].GetComponent<TileController>().isMine)
        {
            winning++;
            if (winning == board.mines) Win();
        }
        flagCount--;
    }
    public void CancelFlag(int x, int y)
    {
        grid[x, y].GetComponent<SpriteRenderer>().sprite = field;
        if (grid[x, y].GetComponent<TileController>().isMine)
        {
            winning--;
        }
        flagCount++;
    }
    public void Win()
    {

    }
    void Start()
    {
        grid = board.grid;
        columns = board.columns;
        rows = board.rows;
        flagCount = board.mines;
    }
}
