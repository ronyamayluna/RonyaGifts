using UnityEngine;

public class Oznalomlenie : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
  

    public void ShowText()
    {
        textObject.SetActive(true);
    }
}
