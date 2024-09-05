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
    private bool isMultiply = false;
    private bool isMinus = false;
    private bool isPlus = false;
    private bool isResultPersentage = false;

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
        //bool isPointExist = false;

        if (DisplayText.text != string.Empty)
        {
            if (!DisplayText.text.Contains(","))
            {
                DisplayText.text += ",";
            }

            //foreach (char letter in DisplayText.text)
            //{
            //    if(letter == ',')    
            //    {
            //        isPointExist = false;
            //        break; 
            //    }
            //    else
            //    {
            //        isPointExist = true;                   
            //    }
            //}

            //if (isPointExist) { DisplayText.text += ","; }
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
        isResultPersentage = true;

        Equals();

        //if(isMathOperation)
        //{
        //    string tempSecondOperand = secondOperand.ToString();

        //    if(tempSecondOperand.Contains(","))
        //    {
        //        secondOperand /= 100;
        //    }
        //    else
        //    {             
        //        secondOperand = (secondOperand / 100) * firstOperand;
        //    }

        //    //secondOperand = (secondOperand / 100) * firstOperand;
        //    //secondOperand = secondOperand / 100;
        //}
    }

    private void GetResultPersentagePlusAndMinus()
    {
        if (isResultPersentage && isMathOperation)
        {
            string tempSecondOperand = secondOperand.ToString();

            if (tempSecondOperand.Contains(",")) { secondOperand /= 100; }
            else { secondOperand = (secondOperand / 100) * firstOperand; }
        }

        isResultPersentage = false;
    }

    private void GetResultPersentageMultiplyAndDivision()
    {
        if (isResultPersentage && isMathOperation) { secondOperand /= 100; }

        isResultPersentage = false;
    }

    public void OnOrReset() 
    {
        DisplayText.text = "0";
        isSecondOperand = true;
        isMathOperation = false;
    }

    public void Division() { Operator(ref isDivision); }

    public void Multiply() { Operator(ref isMultiply); }

    public void Minus() { Operator(ref isMinus); }

    public void Plus() { Operator(ref isPlus); }

    public void PositiveOrNegative()
    {
        double numState = Convert.ToDouble(DisplayText.text);
        
        if (numState < 0) { numState = Math.Abs(numState); }
        else { numState = -numState; }

        secondOperand = numState;
        DisplayText.text = numState.ToString();
    }

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
            GetResultPersentageMultiplyAndDivision();
            result = firstOperand / secondOperand;
            isDivision = false;
        }
        else if (isMultiply)
        {
            GetResultPersentageMultiplyAndDivision();
            result = firstOperand * secondOperand;
            isMultiply = false;
        }
        else if (isMinus)
        {
            GetResultPersentagePlusAndMinus();
            result = firstOperand - secondOperand;
            isMinus = false;
        }
        else if (isPlus)
        {
            GetResultPersentagePlusAndMinus();
            result = firstOperand + secondOperand;
            isPlus = false;
        }
        
        DisplayText.text = result.ToString();
        isEquals = true;
        isMathOperation = true;
        isSecondOperand = false;

        
    }

    public void EraseByOne()
    {
        char[] displayNumbers = new char[DisplayText.text.Length - 1];

        for (int i = 0; i < displayNumbers.Length; i++)
        {
            displayNumbers[i] = DisplayText.text[i];
        }

        DisplayText.text = string.Join("", displayNumbers);
        //DisplayText.text = displayNumbers.ToString();

        if (DisplayText.text == string.Empty) { DisplayText.text = "0"; }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
 