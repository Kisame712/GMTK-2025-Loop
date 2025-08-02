using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class TutorialDialogManager : MonoBehaviour
{
    private const string INSTRUCTOR_NAME = "INSTRUCTOR";
    private const string PLAYER_NAME = "PLAYER";
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private TMP_Text charName;
    [SerializeField] private Image charImage;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject startButton;

    [SerializeField] private float typeSpeed;
    public AudioClip[] audioClips;

    AudioSource audioSource;

    private int eventCount = 0;
    string currText = "";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Type(string sentence)
    {
        foreach(char letter in sentence)
        {
            textArea.text += letter;
            currText += letter;
            if(charName.text == INSTRUCTOR_NAME)
            {
                audioSource.PlayOneShot(audioClips[0], 0.2f);
            }
            else if(charName.text == PLAYER_NAME)
            {
                audioSource.PlayOneShot(audioClips[1], 0.4f);
            }
            yield return new WaitForSeconds(typeSpeed);
        }
    }


    private void Start()
    {
        StartCoroutine(FirstDialog());
    }

    IEnumerator FirstDialog()
    {
        continueButton.SetActive(false);
        charName.text = INSTRUCTOR_NAME;
        charImage.sprite = sprites[0];
        textArea.text = "";
        currText = "";
        string sentence = "Soldier! It has been a long time.. I know, I shall go over the basics with you!";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator SecondDialog()
    {
        continueButton.SetActive(false);
        textArea.text = "";
        currText = "";
        string sentence = "The airplane is an old model as you can see. Use Left Shift to throttle and Left Control to hit the brakes.";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator ThirdDialog()
    {
        continueButton.SetActive(false);
        textArea.text = "";
        currText = "";
        string sentence = "Now comes the important part. The rotation is along all three directions. The lift up and down is performed by W/S";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator FourthDialog()
    {
        continueButton.SetActive(false);
        textArea.text = "";
        currText = "";
        string sentence = "The tilt left to right is performed by A/D. Lastly the turning left and right is done by Q/E..";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator FifthDialog()
    {
        continueButton.SetActive(false);
        textArea.text = "";
        currText = "";
        string sentence = "Any questions???";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator SixthDialog()
    {
        continueButton.SetActive(false);
        charImage.sprite = sprites[1];
        charName.text = PLAYER_NAME;
        textArea.text = "";
        currText = "";
        string sentence = ".... I would understand better when I ride.. Sir!";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator SeventhDialog()
    {
        continueButton.SetActive(false);
        charImage.sprite = sprites[0];
        charName.text = INSTRUCTOR_NAME;
        textArea.text = "";
        currText = "";
        string sentence = "Ah yes surely. Before you enter the real world, let's practice for some time. Fly around this ocean and collect all the rings!";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        continueButton.SetActive(true);
        eventCount++;
    }

    IEnumerator EighthDialog()
    {
        continueButton.SetActive(false);
        charImage.sprite = sprites[1];
        charName.text = PLAYER_NAME;
        textArea.text = "";
        currText = "";
        string sentence = "Sir! Yes, Sir!";
        StartCoroutine(Type(sentence));
        yield return new WaitUntil(() => currText == sentence);
        startButton.SetActive(true);
        eventCount++;
    }

    public void ContinueButton()
    {
        switch (eventCount)
        {
            case 0:
                StartCoroutine(FirstDialog());
                break;
            case 1:
                StartCoroutine(SecondDialog());
                break;
            case 2:
                StartCoroutine(ThirdDialog());
                break;
            case 3:
                StartCoroutine(FourthDialog());
                break;
            case 4:
                StartCoroutine(FifthDialog());
                break;
            case 5:
                StartCoroutine(SixthDialog());
                break;
            case 6:
                StartCoroutine(SeventhDialog());
                break;
            case 7:
                StartCoroutine(EighthDialog());
                break;
        }

    }
}
