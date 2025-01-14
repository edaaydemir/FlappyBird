using UnityEngine;
using TMPro;

public class StartScreen : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public Canvas startScreenCanvas;
    private bool isGameStarted = false;

    private void Start()
    {
        isGameStarted = false;
        startText.text = "Click on the screen to get started";
        startScreenCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isGameStarted = true;
        startScreenCanvas.gameObject.SetActive(false);
        GameManager.Instance.StartGame();
    }
}
