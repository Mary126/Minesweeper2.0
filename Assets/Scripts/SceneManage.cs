using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public void LoadSimple()
    {
        SceneManager.LoadScene("SimpleScene");
    }
    public void LoadMedium()
    {
        SceneManager.LoadScene("MediumScene");
    }
    public void LoadHard()
    {
        SceneManager.LoadScene("HardScene");
    }
    public void ExitScene()
    {
        Application.Quit();
    }
    void Start()
    {
        Button simple = Button1.GetComponent<Button>();
        simple.onClick.AddListener(LoadSimple);
        Button medium = Button2.GetComponent<Button>();
        medium.onClick.AddListener(LoadMedium);
        Button hard = Button3.GetComponent<Button>();
        hard.onClick.AddListener(LoadHard);
        Button exit = Button4.GetComponent<Button>();
        exit.onClick.AddListener(ExitScene);
    }
}
