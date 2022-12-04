using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    //canvas:
    public Canvas resultCanvas;
    public float duration = 0.4f;
    private CanvasGroup canvGroup;
    //paper images:
    public GameObject[] paper;
    //slider:
    public Slider progressSlider;
    public float progress = 0;
    // time text:
    public Text timeText;
    public float delay = 0.1f;
    public float timeInSeconds;
    private string timeFullText;
    //level text:
    public Text levelText;
    public int level;
    private string levelFullText;
    //stamp:
    public GameObject failedStampImage;
    

    private void Start()
    {
        canvGroup = resultCanvas.GetComponent<CanvasGroup>();
        failedStampImage.SetActive(false);
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(ShowPaper());
            StartCoroutine(CanvasFading(canvGroup, canvGroup.alpha, 1));
        }
    }
    IEnumerator ShowPaper()
    {
        for (int i = 0; i < paper.Length; i++)
        {
            paper[i].SetActive(true);
            yield return new WaitForSeconds(0.025f);
            if (paper[i] != paper[paper.Length - 1])
            {
                paper[i].SetActive(false);
            }
        }
    }
    IEnumerator CanvasFading(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
        StartCoroutine(FillSlider());
    }
    IEnumerator FillSlider()
    {
        yield return new WaitForSeconds(1f);
        while (progressSlider.value < progress)
        {
            
            progressSlider.value += 0.5f;
            yield return new WaitForSeconds(0.01f);

        }
        StartCoroutine(ShowTimeText());
    }
    IEnumerator ShowTimeText()
    {
        yield return new WaitForSeconds(0.5f);

        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        timeFullText = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds) + " ";
        for (int i = 0; i < timeFullText.Length; i++)
        {
            timeText.text = timeFullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(ShowLevelText());
    }
    IEnumerator ShowLevelText()
    {
        yield return new WaitForSeconds(0.5f);
        levelFullText = "Level: " + level.ToString() + " ";
        for(int i = 0; i < levelFullText.Length; i++)
        {
            levelText.text = levelFullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(FailedStamp());
    }
    IEnumerator FailedStamp()
    {
        yield return new WaitForSeconds(1);
        failedStampImage.SetActive(true);

    }
}
