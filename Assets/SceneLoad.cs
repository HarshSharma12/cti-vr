using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
	public CanvasGroup myCG;
    public Text step;
    public AudioSource audSrc;
    public AudioClip[] audioClips;
    Animator anim;
    // called zero
    void Awake()
    {
        Debug.Log("Awake");
    }

    // called first
    void OnEnable(){
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // called third
    void Start()
    {
        if (PlayerPrefs.HasKey("SceneReloaded") && PlayerPrefs.GetInt("SceneReloaded") > 0)
        {
            if (PlayerPrefs.HasKey("CurrentAudio"))
            {
                audSrc.clip = audioClips[PlayerPrefs.GetInt("CurrentAudio")];
                audSrc.Play();
                PlayerPrefs.DeleteKey("CurrentAudio");
            }
            PlayerPrefs.DeleteKey("SceneReloaded");
            step.text = "Wrong Step. Restart from Step: 1";
        }
        else
        {
            step.text = "Begin the simulation by grabbing the marker";
        }
            
        myCG.alpha = 0.7f;
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update() 
    {
        //Debug.Log("myCG.alpha: " + myCG.alpha);
    	myCG.alpha = myCG.alpha - 0.3f*(Time.deltaTime);
        if (myCG.alpha <= 0)
        {
            myCG.alpha = 0;
        }
    }



}