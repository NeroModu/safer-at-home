using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public static MusicController instance;

    private AudioSource audioSrc;

    private float playerVol = .25f;

    private float musicVolume = .25f;
    // Start is called before the first frame update'


    private void Awake()
    {
        if (instance == null)
        {  
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        PlayerPrefs.SetFloat("Volume", .25f);
        DontDestroyOnLoad(this);
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("Volume",vol*.25f);
    }
}
