using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true); 
        scoreText.text = "Score: " + score.ToString(); 
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
