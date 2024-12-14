using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField] private GameObject musicPlayer;
    [SerializeField] public AudioSource _AudioSource1;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(musicPlayer);
        // only need one music player
        if (GameObject.Find("Music") != null && GameObject.Find("Music") != musicPlayer)
        {
            Destroy(musicPlayer);
        }
        _AudioSource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
