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

    // Start is called before the first frame update
    void OnMouseDown()
    {
            if (!isOpen)
            {
            if (isMine) tile.sprite = prefabs[0];
            else if (count == 1) tile.sprite = prefabs[1];
                isOpen = true;
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
