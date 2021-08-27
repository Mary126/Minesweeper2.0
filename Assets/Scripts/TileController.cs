using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public bool isMine;
    public int count = 0;
    public bool isOpen = false;
    public int x;
    public int y;
    private SpriteRenderer tile;
    public Sprite[] prefabs;
    public Sprite mine;
    public GameManager manager;
    private bool flag = false;

    // Start is called before the first frame update
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            if (!isOpen)
            {
                manager.Open_all_none(x, y);
                if (isMine) tile.sprite = mine;
                else if (!isMine) tile.sprite = prefabs[count];
                isOpen = true;
            }
        } else if (Input.GetMouseButtonDown(1))
        {
            if (!flag)
            {
                manager.PutFlag(x, y);
            }
            else
            {
                manager.CancelFlag(x, y);
            }
            flag = !flag;
            
        }
    }
    void Start()
    {
        tile = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
