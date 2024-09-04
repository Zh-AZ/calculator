using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text DisplayText;

    private bool isSecondOperand = true;
    private bool isMathOperation = false;
    private bool isEquals = false;
    private bool isDivision = false;
    private bool isMinus = false;
    private bool isPlus = false;

    private double firstOperand;
    private double secondOperand;
    private double result;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonClickZero() { EnterNumbers(0); }

    public void OnButtonClickOne() { EnterNumbers(1); }

    public void OnButtonClickTwo() { EnterNumbers(2); }

    public void OnButtonClickThree() { EnterNumbers(3); }

    public void OnButtonClickFour() { EnterNumbers(4); }

    public void OnButtonClickFive() {EnterNumbers(5);}

    public void OnButtonClickSix() {EnterNumbers(6);}

    public void OnButtonClickSeven() {EnterNumbers(7);}

    public void OnButtonClickEight() {EnterNumbers(8);}

    public void OnButtonClickNine() {EnterNumbers(9);} 

    public void OnButtonClickFloatingPoint()
    {
        bool isPointExist = false;

        if (DisplayText.text != string.Empty)
        {
            foreach (char letter in DisplayText.text)
            {
                if(letter == ',')    
                {
                    isPointExist = false;
                    break; 
                }
                else
                {
                    isPointExist = true;                   
                }
            }

            if (isPointExist) { DisplayText.text += ","; }
        }
        else
        {
            DisplayText.text = "0,";
        }

        //CheckFloatingPoint();
    }

    //private void CheckFloatingPoint()
    //{
    //    if(DisplayText.text != string.Empty)
    //    {
    //        char[] arrayLetters = DisplayText.text.ToCharArray();

    //        for (int i = 0; i < arrayLetters.Length; i++)
    //        {
    //            if (arrayLetters[i] == ',')
    //            {
    //                arrayLetters[i] = '.';
    //            }
    //        }

    //        DisplayText.text = arrayLetters.ToString();
    //    }
    //}

    private void EnterNumbers(int num)
    {
        if (DisplayText.text != string.Empty && DisplayText.text != 0.ToString())
        {
            if (isMathOperation)
            {
                if (isSecondOperand)
                {
                    DisplayText.text = string.Empty;
                    isSecondOperand = false;
                }
                if (isEquals)
                {
                    DisplayText.text = string.Empty;
                    isEquals = false;
                }

                DisplayText.text += num;
                secondOperand = Convert.ToDouble(DisplayText.text);
            }
            else
            {
                DisplayText.text += num;
                firstOperand = Convert.ToDouble(DisplayText.text);
            }
        }
        else
        {
            DisplayText.text = num.ToString();
        }
    }

    public void ResultPercentage()
    {
        if(isMathOperation)
        {
            string tempSecondOperand = secondOperand.ToString();

            if(tempSecondOperand.Contains(","))
            {
                secondOperand /= 100;
            }
            else
            {             
                secondOperand = (secondOperand / 100) * firstOperand;
            }

            //secondOperand = (secondOperand / 100) * firstOperand;
            //secondOperand = secondOperand / 100;
        }
    }

    public void OnOrReset() 
    {
        DisplayText.text = "0";
        isSecondOperand = true;
        isMathOperation = false;
    }

    public void Division() { Operator(ref isDivision); }

    public void Minus() { Operator(ref isMinus); }

    public void Plus() { Operator(ref isPlus); }

    private void Operator(ref bool isOperatorDone)
    {
        if (DisplayText.text != string.Empty)
        {
            isMathOperation = true;
            isOperatorDone = true;
            isSecondOperand = true;
            firstOperand = Convert.ToDouble(DisplayText.text);
        }
    }

    public void Equals()
    {
        if (isDivision)
        {
            result = firstOperand / secondOperand;
            isDivision = false;
        }
        else if (isMinus)
        {
            result = firstOperand - secondOperand;
            isMinus = false;
        }
        else if (isPlus)
        {
            result = firstOperand + secondOperand;
            isPlus = false;
        }
        
        DisplayText.text = result.ToString();
        isEquals = true;
        isMathOperation = true;
        isSecondOperand = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 