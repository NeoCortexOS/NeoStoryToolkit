using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Collections;


public class StoryController : MonoBehaviour
{
    public Story story;
    public Story defaultStory;

    public GameObject speaker;

    [SerializeField]
    private UnityEvent afterDelayEvent;

    private int activeLineIndex;
    private bool conversationStarted = false;
    private SpeakerUIController storyUI;

    private AudioSource audioNarrator;


    public void ChangeConversation(Story nextStory)
    {
        conversationStarted = false;
        story = nextStory;
        AdvanceLine();
    }

    private void Start()
    {
        storyUI = speaker.GetComponent<SpeakerUIController>();
        audioNarrator = this.gameObject.GetComponent<AudioSource>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //        AdvanceLine();
    //    else if (Input.GetKeyDown("x"))
    //        EndConversation();
    //}

    private void EndConversation()
    {
        story = defaultStory;
        conversationStarted = false;
        storyUI.Hide();
    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
    }

    private void AdvanceLine()
    {
        if (story == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < story.lines.Length)
            DisplayLine();
        else
            AdvanceConversation();
    }

    private void DisplayLine()
    {
        Line line = story.lines[activeLineIndex];
        SetDialog(storyUI, line);
        activeLineIndex += 1;
    }
    public void DisplayLineNumber(int index)
    {
        if (index > story.lines.Length || index < 0)
        {
            return;
        }
        Line line = story.lines[index];
        audioNarrator.PlayOneShot(line.Clip);
        SetDialog(storyUI, line);
        activeLineIndex = index;
    }

    private void AdvanceConversation()
    {
        // These are really three types of dialog tree node
        // and should be three different objects with a standard interface
        if (story.nextStory != null)
            ChangeConversation(story.nextStory);
        else
            EndConversation();
    }

    private void SetDialog(
        SpeakerUIController activeSpeakerUI,
        Line line
    )
    {
        activeSpeakerUI.Show();

        activeSpeakerUI.Dialog = "";

        StopAllCoroutines();
        StartCoroutine(EffectTypewriter(line.text, activeSpeakerUI));
        StartCoroutine(AutoHide(line.duration, activeSpeakerUI));
    }

    private IEnumerator EffectTypewriter(string text, SpeakerUIController controller)
    {
        foreach (char character in text.ToCharArray())
        {
            controller.Dialog += character;
            yield return new WaitForSeconds(0.05f);
            // yield return null;
        }
    }
    private IEnumerator AutoHide(float delay, SpeakerUIController controller)
    {
        yield return new WaitForSeconds(delay);
        controller.Hide();
        afterDelayEvent.Invoke();
    }
}
