using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject characterSelectScreen;
    public GameObject levelSelectScreen;
    public GameObject gameOverScreen;
    public GameObject gameStart;
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public GameObject optionspauseScreen;
    public GameObject player1Check;
    public GameObject player2Check;

    public Light myLight;

    public ParticleSystem rainP1;
    public ParticleSystem rainP2;
    public Toggle toggleRain1;
    public Toggle toggleRain2;

    public TMP_InputField inputPlayer1;
    public TMP_InputField inputPlayer2;
    public GameObject Player1Name;
    public GameObject Player2Name;
    public Slider volumeSlider;
    public AudioSource audioSource;
    bool gamestartedcheck = false;
    bool player1Ready = false;
    bool player2Ready = false;
    public TextMeshProUGUI winnerlabel;
    private float timePassed = 0f;
    public TextMeshProUGUI timerText;
    void Start()
    {
        
        volumeSlider.value = 0.3f;
        Player1Name.name = "Player1";
        Player2Name.name = "Player2";
        player1Check.SetActive(false);
        player2Check.SetActive(false);
        Time.timeScale = 0;
        menuScreen.SetActive(true);
        characterSelectScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameStart.SetActive(false);
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        optionspauseScreen.SetActive(false);

    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.Escape)) && gamestartedcheck) ShowPauseScreen();
        timePassed += Time.deltaTime;
        string minutes = ((int)timePassed / 60).ToString();  // convert the elapsed time to minutes
        string seconds = (timePassed % 60).ToString("f2");  // convert the remaining time to seconds

        timerText.text = "Time: " + minutes + ":" + seconds;  // update the UI Text element
    }
    
    public void openOptions()
    {
        menuScreen.SetActive(false);
        optionsScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void openOptionsPause()
    {
        menuScreen.SetActive(false);
        optionspauseScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void ShowMenuScreen()
    {
        characterSelectScreen.SetActive(false);
        optionsScreen.SetActive(false);
        optionspauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        menuScreen.SetActive(true);
    }
    public void ShowPauseScreen()
    {
        Time.timeScale = 0;
        gamestartedcheck = false;
        menuScreen.SetActive(false);
        characterSelectScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameStart.SetActive(false);
        pauseScreen.SetActive(true);
        optionspauseScreen.SetActive(false);
    }
    public void resume()
    {
        optionspauseScreen.SetActive(false);
        Time.timeScale = 1;
        gamestartedcheck = true;
        levelSelectScreen.SetActive(false);
        gameStart.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void ShowCharacterSelectScreen()
    {
        player1Ready = false;
        player1Ready = false;
        optionspauseScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        player1Check.SetActive(false);
        player2Check.SetActive(false);
        menuScreen.SetActive(false);
        characterSelectScreen.SetActive(true);
    }

    public void p1Ready()
    {
        if (player1Ready == false)
        {
            player1Ready = true;
            player1Check.SetActive(true);
        }
        else {
            player1Ready = false;
            player1Check.SetActive(false);
        }

    }
    public void p2Ready()
    {
        if (player2Ready == false)
        {
            player2Ready = true;
            player2Check.SetActive(true);
        }
        else
        {
            player2Ready = false;
            player2Check.SetActive(false);
        }

    }

    public void ShowLevelSelectScreen()
    {
        gameOverScreen.SetActive(false);
        if (player1Ready && player2Ready)
        {
            characterSelectScreen.SetActive(false);
            levelSelectScreen.SetActive(true);
        } else {
            ShowCharacterSelectScreen();
            player1Ready = false;
            player2Ready = false;
        }
    }
    public void StartGame()
    {
        
        Time.timeScale = 1;
        gamestartedcheck = true;
        levelSelectScreen.SetActive(false);
        gameStart.SetActive(true);
    }
    public void ShowGameOverScreen()
    {
        gameStart.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        gamestartedcheck = false;
    }

    public void FinishLineHit()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateText(string input)
    {
        winnerlabel.text = input;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }

    public void UpdateName()
    {
        if (inputPlayer1.text != "") Player1Name.name = inputPlayer1.text; else Player1Name.name = "Player1";
        if (inputPlayer2.text != "") Player2Name.name = inputPlayer2.text; else Player2Name.name = "Player2";
        Debug.Log(Player1Name);
        Debug.Log(Player2Name);
    }
    public void SetVolume()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void ToggleRain1()
    {
        if (toggleRain1.isOn) {
            rainP1.Play(); rainP2.Play(); toggleRain2.isOn = true; myLight.color = HexToColor("747474"); 
        } else { 
            rainP1.Stop(); rainP2.Stop(); toggleRain2.isOn = false;  myLight.color = HexToColor("B4AA8C"); }
    }
    public void ToggleRain2()
    {
        if (toggleRain2.isOn)
        {
            rainP1.Play(); rainP2.Play(); toggleRain1.isOn = true; myLight.color = HexToColor("747474");
        } else {
            rainP1.Stop(); rainP2.Stop(); toggleRain1.isOn = false; myLight.color = HexToColor("B4AA8C");
        }

    }
    Color HexToColor(string hex)
    {
        hex = hex.Replace("0x", "");
        hex = hex.Replace("#", "");
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
