using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

public class ShowUi : MonoBehaviour
{
    [SerializeField] private GameObject uiElement;
    [SerializeField] private GameObject[] persons; 
    [SerializeField] private GameObject[] itemIcons; 
    [SerializeField] private GameObject evinrovement;
    [SerializeField] private GameObject chooseGift;
    [SerializeField] private GameObject uiApp;

    [SerializeField] private GameObject rightUI;
    [SerializeField] private GameObject wrongUI;

    [SerializeField] private GameObject currentCharacter;

    private Dictionary<GameObject, GameObject> characterToItemIcons = new Dictionary<GameObject, GameObject>();

    private List<GameObject> characters = new List<GameObject>();

    private bool isRightButtonPressed = false; 
    private bool isWrongButtonPressed = false;

    [SerializeField] GameObject supriseGift;
    [SerializeField] private GameObject supriseGiftOpenedCat;
    public int coin = 0;

    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject endBackground;
    [SerializeField] private GameObject endImage;

    [SerializeField] private GameObject startImage;

    [SerializeField] Endings Endings;


    private void Awake()
    {
        // Инициализация списка персонажей
        characters = new List<GameObject>(persons);

        // Проверка на соответствие размеров массивов
        if (persons.Length != itemIcons.Length)
        {
            Debug.LogError("Количество персонажей и объектов с иконками предметов не совпадает!");
            return;
        }

        // Заполнение словаря
        for (int i = 0; i < persons.Length; i++)
        {
            characterToItemIcons[persons[i]] = itemIcons[i];
        }
    }

    public void OnRightButtonPressed()
    {
        if (isRightButtonPressed) return; 

        rightUI.SetActive(true);
        isRightButtonPressed = true;
        // Деактивируем все иконки предметов при нажатии правильной кнопки
        foreach (var itemIcon in itemIcons)
        {
            itemIcon.SetActive(false);
        }

        coin += 1;

        if (isWrongButtonPressed) return;

        // if coin equals 3, show supriseGiftOpenedCat 
        if (coin == 3)
        {
            supriseGift.SetActive(true);
            
        }

    }

    public void OnKorobkaButtonPressed()
    {
        supriseGiftOpenedCat.SetActive(true);
        supriseGift.SetActive(false);

    }
    public void OnCatButtonPressed()
        {
        OnRightButtonPressed();
        supriseGiftOpenedCat.SetActive(false);
    }

    public void OnWrongButtonPressed()
    {
        if (isWrongButtonPressed) return; 

        wrongUI.SetActive(true);
        isWrongButtonPressed = true;
        // Деактивируем все иконки предметов при нажатии правильной кнопки
        foreach (var itemIcon in itemIcons)
        {
            itemIcon.SetActive(false);
        }

        if (isRightButtonPressed) return;
        

    }

    public void OnCloseButtonPressed()
    {
        rightUI.SetActive(false);
        wrongUI.SetActive(false);
        evinrovement.SetActive(true);
        chooseGift.SetActive(false);
        uiApp.SetActive(true);


        isRightButtonPressed = false;
        isWrongButtonPressed = false;
    }

    public void OnAppButtonPressed()
    {
        // Проверяем, активен ли evinrovement
        

        uiElement.SetActive(true);
        GetRandomCharacter();

        isRightButtonPressed = false;
        isWrongButtonPressed = false;
    }

    public void OnPristepitButtonPressed()
    {
        evinrovement.SetActive(false);
        chooseGift.SetActive(true);
        uiElement.SetActive(false);
        uiApp.SetActive(false);

        if (currentCharacter != null)
        {
            // Деактивируем текущего персонажа
            currentCharacter.SetActive(false);

            // Активируем соответствующий объект с иконками
            if (characterToItemIcons.ContainsKey(currentCharacter))
            {
                characterToItemIcons[currentCharacter].SetActive(true);
            }

            currentCharacter = null;
        }
    }

    public GameObject GetRandomCharacter()
    {
        if (characters.Count == 0)
        {
            startImage.SetActive(false);
            GameOver(); // Завершаем игру, если все персонажи были показаны
            return null;
        }

        int index = Random.Range(0, characters.Count);
        GameObject character = characters[index];
        characters.RemoveAt(index);
        character.SetActive(true);

        currentCharacter = character;

        return character;
    }

    public void GameOver()
    {
        rightUI.SetActive(false);
        wrongUI.SetActive(false);
        evinrovement.SetActive(false);
        chooseGift.SetActive(false);
        uiApp.SetActive(false);

        elf.SetActive(true);
        endBackground.SetActive(true);
        endImage.SetActive(true);


        Endings.Ending();
    }

    
}
