using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Calculator : MonoBehaviour
{
    public Text resultText;
    public float num1 = 0f;
    public float num2 = 0f;
    public string operation;
    
    public AudioClip errorSound;
    private AudioSource audioSource;
    private bool isQuitting = false;

    void Start()
    {
        //checks if there is AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); //adds AudioSource component
        }
        
        audioSource.playOnAwake = false; //prevents audio from playing when starting calc
        audioSource.loop = false; //prevents audio from looping
        
        Debug.Log("Calculator audio ready. Sound assigned: " + (errorSound != null));
    }

    private void CheckForCloseCondition() //checks if the input or the output is 67. AYOKO SA 67 MGA HATDOG KAYONG LAHAT!!!
    {
        if (isQuitting) return;
        
        if (float.TryParse(resultText.text, out float currentValue))
        {
            if (Mathf.Approximately(currentValue, 67f))
            {
                Debug.Log("67 detected! AYOKO SAINYO!!!!!");
                PlayErrorSoundAndQuit();
            }
        }
    }

    private void PlayErrorSoundAndQuit() //function for quitting if there is no sound
    {
        isQuitting = true;
        
        if (errorSound == null)
        {
            Debug.LogError("NO SOUND ASSIGNED! Please read step-by-step below:");
            Debug.LogError("1. Select Calculator GameObject");
            Debug.LogError("2. In Inspector, find Calculator script");
            Debug.LogError("3. Drag your error.mp3 to 'Error Sound' field");
            QuitApplication();
            return;
        }
        
        Debug.Log("Playing error sound...");
        audioSource.PlayOneShot(errorSound);
        
        StartCoroutine(QuitAfterSound(errorSound.length));
    }

    private IEnumerator QuitAfterSound(float soundLength) //waits for the sound to finish before quitting
    {
        yield return new WaitForSeconds(soundLength);
        QuitApplication();
    }

    private void QuitApplication() //quits the application
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void iAddition() //adds
    {
        CheckForCloseCondition();
        num1 = float.Parse(resultText.text);
        operation = "+";
        resultText.text = "";
    }

    public void iSubtraction() //subtracts
    {
        CheckForCloseCondition();
        num1 = float.Parse(resultText.text);
        operation = "-";
        resultText.text = "";
    }

    public void iMultiplication() //multiplies
    {
        CheckForCloseCondition();
        num1 = float.Parse(resultText.text);
        operation = "*";
        resultText.text = "";
    }

    public void iDivision() //divides
    {
        CheckForCloseCondition();
        num1 = float.Parse(resultText.text);
        operation = "/";
        resultText.text = "";
    }

    public void btndigit1()
    {
        if(resultText.text == "0")
        {
            resultText.text = "1";
        }
        else
        {
            resultText.text = resultText.text + "1";
        }
        CheckForCloseCondition();
    }

    public void btndigit2()
    {
        if(resultText.text == "0")
        {
            resultText.text = "2";
        }
        else
        {
            resultText.text = resultText.text + "2";
        }
        CheckForCloseCondition();
    }

    public void btndigit3()
    {
        if(resultText.text == "0")
        {
            resultText.text = "3";
        }
        else
        {
            resultText.text = resultText.text + "3";
        }
        CheckForCloseCondition();
    }

    public void btndigit4()
    {
        if(resultText.text == "0")
        {
            resultText.text = "4";
        }
        else
        {
            resultText.text = resultText.text + "4";
        }
        CheckForCloseCondition();
    }

    public void btndigit5()
    {
        if(resultText.text == "0")
        {
            resultText.text = "5";
        }
        else
        {
            resultText.text = resultText.text + "5";
        }
        CheckForCloseCondition();
    }

    public void btndigit6()
    {
        if(resultText.text == "0")
        {
            resultText.text = "6";
        }
        else
        {
            resultText.text = resultText.text + "6";
        }
        CheckForCloseCondition();
    }

    public void btndigit7()
    {
        if(resultText.text == "0")
        {
            resultText.text = "7";
        }
        else
        {
            resultText.text = resultText.text + "7";
        }
        CheckForCloseCondition();
    }

    public void btndigit8()
    {
        if(resultText.text == "0")
        {
            resultText.text = "8";
        }
        else
        {
            resultText.text = resultText.text + "8";
        }
        CheckForCloseCondition();
    }

    public void btndigit9()
    {
        if(resultText.text == "0")
        {
            resultText.text = "9";
        }
        else
        {
            resultText.text = resultText.text + "9";
        }
        CheckForCloseCondition();
    }

    public void btndigit0()
    {
        if(resultText.text == "0")
        {
            resultText.text = "0";
        }
        else
        {
            resultText.text = resultText.text + "0";
        }
        CheckForCloseCondition();
    }

    public void EqualsOp()
    {
        float answer = 0f;
        num2 = float.Parse(resultText.text);

        if (operation == "+")
        {
            answer = num1 + num2;
            resultText.text = answer.ToString();
        }

        if (operation == "-")
        {
            answer = num1 - num2;
            resultText.text = answer.ToString();
        }

        if (operation == "*")
        {
            answer = num1 * num2;
            resultText.text = answer.ToString();
        }

        if (operation == "/")
        {
            if (num2 != 0)
            {
                answer = num1 / num2;
                resultText.text = answer.ToString();
            }
            else
            {
                resultText.text = "Infinity";
            }
        }
        
        CheckForCloseCondition();
    }

    public void btnClear()
    {
        resultText.text = "0";
    }

    public void btnEClear()
    {
        resultText.text = "0";
        num1 = 0f;
        num2 = 0f;
        operation = "";
    }

    public void btnBackspace()
    {
        if(resultText.text.Length > 0 && resultText.text != "0")
        {
            resultText.text = resultText.text.Remove(resultText.text.Length - 1, 1);
        }
        
        if(resultText.text == "")
        {
            resultText.text = "0";
        }
        
        CheckForCloseCondition();
    }

    public void plusMinus()
    {
        if (float.TryParse(resultText.text, out float q))
        {
            resultText.text = (-q).ToString();
            CheckForCloseCondition();
        }
    }

    public void btnDec()
    {
        if (!resultText.text.Contains("."))
        {
            resultText.text = resultText.text + ".";
        }
        CheckForCloseCondition();
    }

        public void DebugSoundTest() //for debugging
    {
        if (errorSound == null)
        {
            Debug.LogError("ERROR: No sound assigned! Drag MP3 to Inspector.");
        }
        else if (audioSource == null)
        {
            Debug.LogError("ERROR: No AudioSource!");
        }
        else
        {
            Debug.Log("Testing sound... should hear it now!");
            audioSource.PlayOneShot(errorSound);
        }
    }
}

