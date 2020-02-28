using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    [SerializeField] private Sprite spriteWhenIsOpen;
    [SerializeField] private Sprite spriteWhenIsClose;
    [SerializeField] private Image lockSprite;

    [SerializeField] private Text numberTextComp;

    public List<GameObject> starObjects = new List<GameObject>();
    [SerializeField] private GameObject starsParent;

    [SerializeField]
    private bool isOpen = false;

    [SerializeField]
    private int number = 1;

    private Image imgComp;
    private Button btn;

    private bool started = false;

    private void Awake()
    {
        imgComp = GetComponent<Image>();
        btn = GetComponent<Button>();
    }

    private void Start()
    {
        SetIsOpen(isOpen);
        started = true;

        // Bad guy.
        transform.localScale = new Vector3(1, 1, 1);

        UpdateStars();
    }

    private void OnEnable()
    {
        // If number is ready.
        if (started)
            UpdateStars();
    }

    public void SetIsOpen(bool open)
    {
        isOpen = open;
        imgComp.sprite = open ? spriteWhenIsOpen : spriteWhenIsClose;
        btn.enabled = open;
        
        if (open)
        {
            numberTextComp.text = number.ToString();
            lockSprite.enabled = false;
            starsParent.SetActive(true);
        }
        else
        {
            numberTextComp.text = " ";
            lockSprite.enabled = true;
            starsParent.SetActive(false);
        }
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(number);
        DataManager.instance.data.lastLevel = number;
    }

    private void UpdateStars()
    {
        int stars = DataManager.instance.data.levelsData[number - 1].numberOfStars;
        for (int i = 0; i < stars; i++)
        {
            starObjects[i].SetActive(true);
        }
    }
}
