using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

/// <summary>
/// A means of generating audio clips of text to speech. Requires an API Key from voicerss.org
/// </summary>
[RequireComponent(typeof(AudioSource))]
[HelpURL("http://www.voicerss.org/")]
public class VoiceRSSTextToSpeech : MonoBehaviour
{
    [Header("Setup")]
    public string APIKey;
    [TextArea]
    public string Info = "You need an API key to get this to work. " +
        "You can get one at http://www.voicerss.org/ or by clicking on the help icon on this component. " +
        "Once you have one, paste it in the field above. You have 350 requests per day on a given API key. " +
        "If you see errors, it's likely because you've exceeded this limit.";

    public string words = "Hello";
    public bool EnableGUIDemo = false;
    public AudioClip clip;

    private AudioSource audSrc;
    private GameObject client;
    private string clientMessage;

    void Awake()
    {
        audSrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Get AudioClip Async & Play ASAP
    /// </summary>
    /// <returns></returns>
    IEnumerator RenderAndPlay()
    {
        Regex rgx = new Regex("\\s+");
        string result = rgx.Replace(words, "%20");
#if (UNITY_ANDROID || UNITY_IOS)
        string url = "http://api.voicerss.org/?key=" + APIKey + "&hl=en-us&src=" + result + "&c=MP3&f=48khz_16bit_mono";
        WWW www = new WWW(url);
        yield return www;
        clip = WWWAudioExtensions.GetAudioClip(www, false, false, AudioType.MPEG);
#else
        string url = "http://api.voicerss.org/?key=" + APIKey + "&hl=en-us&src=" + result + "&c=OGG&f=48khz_16bit_mono";
        WWW www = new WWW(url);
        yield return www;
        clip = WWWAudioExtensions.GetAudioClip(www, false, false, AudioType.OGGVORBIS);
#endif
        audSrc.clip = clip;
        audSrc.Play();
    }


    /// <summary>
    /// Demo GUI
    /// </summary>
    void OnGUI()
    {
        if (!EnableGUIDemo) return;
        words = GUI.TextField(new Rect(Screen.width / 2 - 200 / 2, 10, 200, 30), words);
        if (GUI.Button(new Rect(Screen.width / 2 - 150 / 2, 40, 150, 50), "speak"))
        {
            StartCoroutine(RenderAndPlay());
        }
    }

    /// <summary>
    /// Async for rendering an AudioClip
    /// </summary>
    /// <returns></returns>
    IEnumerator RenderClip(GameObject theClient, string wordsToSpeak, string recieptMessage)
    {
        Regex rgx = new Regex("\\s+");
        string result = rgx.Replace(wordsToSpeak, "%20");
#if (UNITY_ANDROID || UNITY_IOS)
        string url = "http://api.voicerss.org/?key=" + APIKey + "&hl=en-us&src=" + result + "&c=MP3&f=48khz_16bit_mono";
        WWW www = new WWW(url);
        yield return www;
        clip = WWWAudioExtensions.GetAudioClip(www, false, false, AudioType.MPEG);
#else
        string url = "http://api.voicerss.org/?key=" + APIKey + "&hl=en-us&src=" + result + "&c=OGG&f=48khz_16bit_mono";
        WWW www = new WWW(url);
        yield return www;
        clip = WWWAudioExtensions.GetAudioClip(www, false, false, AudioType.OGGVORBIS);
#endif
        theClient.SendMessage(recieptMessage, clip);
    }

    /// <summary>
    /// Method to render an audio clip
    /// </summary>
    /// <param name="theClient">The GameObject requesting the clip. Usually just "gameObject"</param>
    /// <param name="wordsToSpeak">The words you want rendered into a clip</param>
    /// <param name="recieptMessage">The function you want called when the clip is done. It needs to be in a script that's on the client & take an AudioClip as a parameter</param>
    public void GetClip(GameObject theClient, string wordsToSpeak, string recieptMessage)
    {
        StartCoroutine(RenderClip(theClient, wordsToSpeak, recieptMessage));
    }
}