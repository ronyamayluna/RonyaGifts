using UnityEngine;

public class Endings : MonoBehaviour
{
    [SerializeField] private GameObject goodEndingUI;
    [SerializeField] private GameObject badEndingUI;
    [SerializeField] private GameObject neutralEndingUI;
    [SerializeField] ShowUi ShowUi;
    public void Ending()
    {
        if (ShowUi.coin >= 6)
        {
            goodEndingUI.SetActive(true);
        }
        else if (ShowUi.coin <= 3)
        {
            badEndingUI.SetActive(true);
        }
        else
        {
            neutralEndingUI.SetActive(true);
        }
    }

    public void End()
    {
        Application.Quit();
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SceneZero");
    }
}
