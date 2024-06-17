using UnityEngine;
using UnityEngine.UI;

public class FBS_Script : MonoBehaviour
{
    public Text rannumtxt, infotext;
    public Button fizzbtn, buzzbtn, fizzbuzzbtn, normnumbtn, newnumbtn;
    private int randnum, fizz = 3, buzz = 5;
    private string[] Antworten;
    public Image background, ColorPad;
    public AudioSource correct, incorrect;
    public Image DaumenHoch, DaumenRunter, NormalAller;

    private void Start()
    {
        background.color = Color.white;
        Antworten = new string[7];
        Antworten[0] = "Attention! Your number is only divisible by 3 and 5 if its sum is divisible by 3 and if the last number is a 5 or 0.";
        Antworten[1] = "Attention! Your number is only divisible by 3 if their sum is divisible by 3.";
        Antworten[2] = "Attention! Your number is only divisible by 5 if your last number is a 5 or a 0.";
        Antworten[3] = "Attention! Your number is divisible by 3 and 5";
        Antworten[4] = "Attention! Your number is divisible by 3";
        Antworten[5] = "Attention! Your number is only divisible by 5";
        Antworten[6] = "";
        NormalAller.gameObject.SetActive(true);
        DaumenHoch.gameObject.SetActive(false);
        DaumenRunter.gameObject.SetActive(false);
        ColorPad.color = Color.clear;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckFizzBuzz();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckNorm();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckFizz();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckBuzz();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomNumber();
        }
    }

    public void incorrect_answer()
    {
        ColorPad.color = new Color(1, 0, 0, 0.5f);
        incorrect.Play();
        DaumenRunter.gameObject.SetActive(true);
        DaumenHoch.gameObject.SetActive(false);
        NormalAller.gameObject.SetActive(false);

    }
    public void correct_answer()
    {
        ColorPad.color = new Color (0, 1, 0, 0.5f);
        correct.Play();
        DaumenHoch.IsActive();
        DaumenRunter.gameObject.SetActive(false);
        DaumenHoch.gameObject.SetActive(true);
        NormalAller.gameObject.SetActive(false);
    }

    public void RandomNumber()
    {
        randnum = Random.Range(0, 1001);
        rannumtxt.text = randnum.ToString();
        ColorPad.color = Color.clear;
        infotext.text = Antworten[6];
        DaumenRunter.gameObject.SetActive(false);
        DaumenHoch.gameObject.SetActive(false);
        NormalAller.gameObject.SetActive(true);
    }

    public void CheckFizzBuzz()
    {
        if (randnum % fizz == 0 && randnum % buzz == 0)
        {
            correct_answer();
        }
        else
        {
            infotext.text = Antworten[0];
            incorrect_answer();
        }
    }

    public void CheckFizz()
    {
        if (randnum % fizz == 0 && randnum % buzz != 0)
        {
            correct_answer();
        }
        else
        {
            incorrect_answer();
            infotext.text = Antworten[1];
        }
    }

    public void CheckBuzz()
    {
        if (randnum % buzz == 0 && randnum % fizz != 0)
        {
            correct_answer();
        }
        else
        {
            incorrect_answer();
            infotext.text = Antworten[2];
        }
    }

    public void CheckNorm()
    {
        if (randnum % fizz != 0 && randnum % buzz != 0)
        {
            correct_answer();
        }
        else
        {
            incorrect_answer();

            if (randnum % fizz == 0 && randnum % buzz == 0)
            {
                infotext.text = Antworten[3];
            }

            else if (randnum % fizz == 0 && randnum % buzz != 0)
            {
                infotext.text = Antworten[4];
            }
            else if (randnum % buzz == 0 && randnum % fizz != 0)
            {
                infotext.text = Antworten[5];
            }
        }
    }
}
