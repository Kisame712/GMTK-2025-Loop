using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameDialogManager : MonoBehaviour
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
        foreach (char letter in sentence)
        {
            textArea.text += letter;
            currText += letter;
            if (charName.text == INSTRUCTOR_NAME)
            {
                audioSource.PlayOneShot(audioClips[0], 0.2f);
            }
            else if (charName.text == PLAYER_NAME)
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
        string sentence = "Well Done! I am impressed!";
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
        string sentence = "I thought you were going to crash... Here is your final task. You must practice the air loop for the parade!!";
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
        string sentence = "Don't worry. The ring formation this time is the exact same as the air loop.";
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
        string sentence = "In other words, complete the ring collection to learn this trick!!";
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
        string sentence = "I just have to collect the rings.. Right sir?";
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
        string sentence = "Yes. Try to do this task as soon as possible. I will meet you at the base!";
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
