using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static GameMode instance;

    public List<Box> boxes = new List<Box>();
    public bool boxControllEnabled = true;
    public AudioClip moveClip;

    public AudioSource winSound;
    public bool gameIsEnd = false;

    [Header ("Stars")]
    public byte stars = 0;
    public byte minCompleteTime = 10;
    public bool starIsTaked = false;

    public delegate void MoveMox(Vector2 dir); 
    public event MoveMox MoveBoxEvent;

    void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        #endregion

    }

    private void Start()
    {
        MenuManager.instance.SwitchActivePanel(null);

        // Find all boxes.
        boxes.AddRange(FindObjectsOfType<Box>());
    }

    public bool MoveAllBoxes(Vector2 dir)
    {
        if (boxControllEnabled)
        {
            bool canMove = true;

            foreach (Box i in boxes)
            {
                if (i.isMove)
                {
                    canMove = false;
                    return canMove;
                }
            }

            foreach (Box i in boxes)
            {
                if (canMove)
                    i.MoveBox(dir);
            }

            SoundManager.instance.PlaySound(moveClip);
            if (MoveBoxEvent != null) { MoveBoxEvent.Invoke(dir); }

            return canMove;
        }
        else
        {
            return false;
        }  
    }

    public IEnumerator PlayerWon()
    {
        // Open the next level.
        int currentLevel = DataManager.instance.data.lastLevel;

        if (currentLevel < DataManager.instance.data.levelsData.Count)
            DataManager.instance.data.levelsData[currentLevel].isOpen = true;

        winSound.Play();

        gameIsEnd = true;
        stars++;

        if (Mathf.Floor(Time.timeSinceLevelLoad) <= minCompleteTime)
            stars++;

        if (starIsTaked)
            stars++;

        // Set stars.
        if (DataManager.instance.data.levelsData[currentLevel - 1].numberOfStars < stars)
            DataManager.instance.data.levelsData[currentLevel - 1].numberOfStars = stars;

        // Save Game.
        DataManager.instance.SaveGame();

        // Wait.
        yield return new WaitForSeconds(.5f);

        boxControllEnabled = false;
        MenuManager.instance.OpenWinPanel();
    }
}