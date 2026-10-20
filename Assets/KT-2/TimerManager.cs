using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public Image clockImage;
    public Button startButton;
    public TMP_Text launchCountText;
    public float mainTimerDuration = 5f;
    private float mainTimer;
    private bool isMainTimerRunning = false;
    private int launchCount = 0;

    public Image resourceBar;
    public TMP_Text resourceText;
    public float resourceTimerDuration = 3f;

    private float resourceTimer = 0f;
    private int resources = 0;

    void Start()
    {
        clockImage.fillAmount = 1f;
        resourceBar.fillAmount = 0f;
        launchCountText.text = "Launches: 0";
        resourceText.text = "Resources: 0";
        startButton.onClick.AddListener(StartMainTimer);
        UpdateButtonState();
    }

    void Update()
    {
        if (isMainTimerRunning)
        {
            mainTimer -= Time.deltaTime;
            clockImage.fillAmount = mainTimer / mainTimerDuration;

            if (mainTimer <= 0f)
            {
                isMainTimerRunning = false;
                clockImage.fillAmount = 1f;
                launchCount++;
                launchCountText.text = ("Launches: " + launchCount);
            }
        }

        resourceTimer += Time.deltaTime;
        resourceBar.fillAmount = resourceTimer / resourceTimerDuration;

        if (resourceTimer >= resourceTimerDuration)
        {
            resourceTimer -= resourceTimerDuration;
            resources += 3;
            resourceText.text = ("Resources: " + resources);
        }

        UpdateButtonState();
    }

    void StartMainTimer()
    {
        if (resources < 5 || isMainTimerRunning)
            return;
        resources -= 5;
        resourceText.text = ("Resources: " + resources);
        mainTimer = mainTimerDuration;
        isMainTimerRunning = true;
    }

    void UpdateButtonState()
    {
        startButton.interactable = resources >= 5 && !isMainTimerRunning;
    }
}