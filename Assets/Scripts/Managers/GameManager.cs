using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] int levelCount;
    [SerializeField] int randomLevelLowerLimit;

    public int Level
    {
        get
        {
            if (PlayerPrefs.GetInt(Constants.Prefs.LEVEL) == 0)
            {
                PlayerPrefs.SetInt(Constants.Prefs.LEVEL, 1);
                return PlayerPrefs.GetInt(Constants.Prefs.LEVEL);
            }
            else if (PlayerPrefs.GetInt(Constants.Prefs.LEVEL) > levelCount)
            {
                return Random.Range(randomLevelLowerLimit, levelCount);
            }
            else
            {
                return PlayerPrefs.GetInt(Constants.Prefs.LEVEL);
            }
        }
        set { PlayerPrefs.SetInt(Constants.Prefs.LEVEL, value); }
    }

    private void Awake()
    {
        Singleton(true);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayGame();
        }
    }

    private void Update()
    {

    }

    public void NextLevel()
    {
        Level++;
        SceneManager.LoadScene(Level);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(Level);
    }
}
