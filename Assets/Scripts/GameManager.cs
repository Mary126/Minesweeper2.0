using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private int flagCount = 0;
    private int winning = 0;
    public Text Flag;
    public Button MenuButton;
    public Canvas LooseScreen;
    public Canvas WinScreen;

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
        if (flagCount > 0)
        {
            grid[x, y].GetComponent<SpriteRenderer>().sprite = flag;
            if (grid[x, y].GetComponent<TileController>().isMine && !grid[x, y].GetComponent<TileController>().isOpen)
            {
                winning++;
                if (winning == board.mines) Win();
            }
            flagCount--;
            Flag.text = "Flags left: " + flagCount.ToString();
        }
    }
    public void CancelFlag(int x, int y)
    {
        if (grid[x, y].GetComponent<TileController>().isFlag)
        {
            grid[x, y].GetComponent<SpriteRenderer>().sprite = field;
            if (grid[x, y].GetComponent<TileController>().isMine)
            {
                winning--;
            }
            flagCount++;
            Flag.text = "Flags left: " + flagCount.ToString();
        }
    }
    void OpenField()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (grid[x, y].GetComponent<TileController>().isMine) grid[x, y].GetComponent<SpriteRenderer>().sprite = mine;
                else grid[x, y].GetComponent<SpriteRenderer>().sprite = prefabs[grid[x, y].GetComponent<TileController>().count];
                grid[x, y].GetComponent<TileController>().isOpen = true;
            }
        }
    }
    public void Win()
    {
        OpenField();
        Instantiate(WinScreen);
    }
    public void Loose()
    {
        OpenField();
        Instantiate(LooseScreen);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    void Start()
    {
        grid = board.grid;
        columns = board.columns;
        rows = board.rows;
        flagCount = board.mines;
        Flag.text = "Flags left: " + flagCount.ToString();
        Button btn = MenuButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadMainMenu);
    }
}
