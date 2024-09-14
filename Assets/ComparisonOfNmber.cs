using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text Sign;
    public Text Result;
    public InputField LeftInputField;
    public InputField RightInputField;


    public void CompareButton()
    {
        if (double.TryParse(LeftInputField.text, out double leftNum) && double.TryParse(RightInputField.text, out double rightNum))
        {
            if (leftNum == rightNum)
            {
                Sign.text = "=";
                Result.text = "Числа равны";
            }
            else if (leftNum > rightNum)
            {
                Sign.text = ">";
                Result.text = leftNum.ToString();
            }
            else
            {
                Sign.text = "<";
                Result.text = rightNum.ToString();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
