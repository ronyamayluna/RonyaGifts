using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Oznalomlenie oznalomlenie;
    public void OnYesButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SceneOne");
        
    }
    public void OnNoButtonPressed()
    {
        Application.Quit();
    }
    public void OnComputerButtonPressed()
        {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SceneThree");
    }

}
