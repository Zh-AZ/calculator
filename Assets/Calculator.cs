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
    private bool isNextOperation = false;

    private bool isZero = false;

    private bool isAgainPressing = true;

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
        if (DisplayText.text != string.Empty)
        {
            if (!DisplayText.text.Contains(","))
            {
                DisplayText.text += ",";
            }
        }
        else
        {
            DisplayText.text = "0,";
        }
    }

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

                if (secondOperand == 0) { isZero = true; }
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

        isAgainPressing = true;
    }

    public void ResultPercentage()
    {
        isResultPersentage = true;

        Equals();
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
        firstOperand = 0;
        secondOperand = 0;
        result = 0;
    }

    public void Division() 
    {
        if (isNextOperation) Equals();
        Operator(ref isDivision);

        //if (isAgainPressing)
        //{
        //    if (isNextOperation) Equals();
        //    Operator(ref isDivision);
        //    isAgainPressing = false;
        //}
        //else if (!isAgainPressing)
        //{
        //    isDivision = false;
        //    isNextOperation = false;
        //}
    }

    public void Multiply() 
    {
        //if (isAgainPressing)
        //{
        //    if (isNextOperation) Equals();
        //    Operator(ref isMultiply);
        //    isAgainPressing = false;
        //}
        //else if (!isAgainPressing)
        //{
        //    isMultiply = false;
        //    isNextOperation = false;
        //}

        if (isNextOperation) Equals();
        Operator(ref isMultiply);

    }

    public void Minus() 
    {
        if (isNextOperation) Equals();
        Operator(ref isMinus);
    }

    public void Plus() 
    {
        if (isNextOperation) Equals();
        Operator(ref isPlus);
    }

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
            isDivision = false;
            isMultiply = false;
            isPlus = false;
            isMinus = false;
            
            isMathOperation = true;
            isOperatorDone = true;
            isSecondOperand = true;
            isNextOperation= true;
            //firstOperand = Convert.ToDouble(DisplayText.text);
        }
    }

    public void Equals()
    {
        if (isDivision)
        {
            GetResultPersentageMultiplyAndDivision();
            
            if (!isZero && secondOperand == 0)
            {
                secondOperand = 1;
                isZero = false;
            }

            result = firstOperand / secondOperand;
            isDivision = false;
        }
        else if (isMultiply)
        {
            GetResultPersentageMultiplyAndDivision();

            if (!isZero && secondOperand == 0)
            {
                secondOperand = 1;
                isZero = false;
            }

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

        firstOperand = result;
        secondOperand = 0;
        
        DisplayText.text = result.ToString();
        isEquals = true;
        isMathOperation = false;
        isSecondOperand = false;
        isNextOperation = false;
    }

    public void EraseByOne()
    {
        char[] displayNumbers = new char[DisplayText.text.Length - 1];

        for (int i = 0; i < displayNumbers.Length; i++)
        {
            displayNumbers[i] = DisplayText.text[i];
        }

        DisplayText.text = string.Join("", displayNumbers);

        if (DisplayText.text == string.Empty) { DisplayText.text = "0"; }

        firstOperand = Convert.ToDouble(DisplayText.text);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
 