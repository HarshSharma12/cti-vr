using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stepRecord : MonoBehaviour
{

    public Text step;
    public Text timer;
    public Text timer2;
    public GameObject resetBody;

    public GameObject afterGameObjs;
    public GameObject inGameObjs;
    public GameObject helpObjs;

    public AudioSource audSrc;
    public AudioClip[] audioClips;

    public Image helpImage;

    public static GameObject currentBody;
    public static int stepNum = 1;
    public static bool wrongStep = false;

    public static GameObject currentIntrument;
    public static Vector3 currentIntrumentOriginalPos;

    public static int currentStepNum = 1;
    public static int lastStepCompleted = 0;

    const int maxTime = 5*60;
    float startTime;
    int timeLeft;
    bool simOver = false;

    private static bool isActionCompleted = false;
    private static bool isStepCompleted = false;
    public Texture2D[] helpImages;

    public static bool IsStepCompleted
    {
        get
        {
            return isStepCompleted;
        }

        set
        {
            isStepCompleted = value;
        }
    }

    public static bool IsActionCompleted
    {
        get
        {
            return isActionCompleted;
        }

        set
        {
            isActionCompleted = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        simOver = false;
        lastStepCompleted = 0;
        currentStepNum = 0;
        startTime = Time.time;
        timeLeft = maxTime;
        helpImages = Resources.LoadAll<Texture2D>("help");
        Debug.Log(helpImages.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = maxTime - (int)(Time.time - startTime);
        if (timeLeft == 60)
        {
            audSrc.clip = audioClips[0];
            audSrc.Play();
        }
        else if (timeLeft == 12)
        {
            audSrc.clip = audioClips[1];
            audSrc.Play();
        }
        timer.text = "Time Left: " + FormatTime(timeLeft);
        if (!simOver && (wrongStep || timeLeft <= 0))
        {
            if (wrongStep)
                PlayerPrefs.SetInt("CurrentAudio", 0);
            else
                PlayerPrefs.SetInt("CurrentAudio", 1);

            lastStepCompleted = 0;
            currentStepNum = 0;
            wrongStep = false;
            LoadScene(1);
            
        }
        else if (currentStepNum > 0)
        {
            Debug.Log(currentStepNum);
            step.text = "Step: " + currentStepNum;
            if (lastStepCompleted == 5)
            {
                audSrc.clip = audioClips[2];
                audSrc.Play();
                simOver = true;
                inGameObjs.SetActive(false);
                afterGameObjs.SetActive(true);
                timer2.text = "Time Taken: " + FormatTime((int)(Time.time - startTime));
                Animator anim = afterGameObjs.GetComponent<Animator>();
                anim.SetTrigger("simOver");
            }
        }
    }

    string FormatTime(int seconds)
    {
        int hours = seconds / 3600;
        int mins = (seconds % 3600) / 60;
        int secs = seconds % 60;
        return string.Format("{0:D2}:{1:D2}", mins, secs);
    }

    public void LoadScene(int src)
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.name);
        PlayerPrefs.SetInt("SceneReloaded", src);
        simOver = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowHelp()
    {
        Animator anim = helpImage.GetComponent<Animator>();
        helpObjs.SetActive(true);
        inGameObjs.SetActive(false);
        helpImage.gameObject.SetActive(true);
        anim.SetTrigger("showHelp");
        int imgIndex = currentStepNum - 1 >= 0 ? currentStepNum - 1 : 0;
        Texture2D texture = helpImages[imgIndex];
        Rect rec = new Rect(0, 0, texture.width, texture.height);
        Sprite imgSprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        helpImage.sprite = imgSprite;
    }

    public void HideHelp()
    {
        inGameObjs.SetActive(true);
        helpObjs.SetActive(false);
        //anim.SetTrigger("showHelp");
        //Texture2D texture = helpImages[currentStepNum];
        //Rect rec = new Rect(0, 0, texture.width, texture.height);
        //Sprite imgSprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        //helpImage.sprite = imgSprite;
    }
}
