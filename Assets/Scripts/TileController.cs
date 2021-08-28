using UnityEngine;

public class TileController : MonoBehaviour
{
    public bool isMine;
    public int count = 0;
    public bool isOpen = false;
    public int x;
    public int y;
    public GameManager manager;
    public bool isFlag = false;

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            if (!isOpen)
            {
                if (isMine) manager.Loose();
                else {
                    manager.Open_all_none(x, y);
                    isOpen = true;
                }
            }
        } else if (Input.GetMouseButtonDown(1) && !isOpen)
        {
            if (!isFlag)
            {
                manager.PutFlag(x, y);
            }
            else
            {
                manager.CancelFlag(x, y);
            }
            isFlag = !isFlag;
            
        }
    }
}
