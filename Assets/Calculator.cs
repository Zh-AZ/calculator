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

    private bool isUserZero = false;

    //private bool isAgainPressing = true;
    private bool isExistSecondOperand = false;
    private bool isEnterNumber = false;
    private bool isErased;

    private double firstOperand;
    private double secondOperand;
    private double result;

    private int lastOperation;
    private double lastSecondOperand;
    private int countRepeatEqual;
    




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
        if (DisplayText.text != string.Empty && (DisplayText.text != 0.ToString() || isErased))
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
                    isExistSecondOperand = false;
                }

                DisplayText.text += num;
                secondOperand = Convert.ToDouble(DisplayText.text);

                if (secondOperand == 0) { isUserZero = true; }

                isExistSecondOperand = true;
            }
            else if (isEquals)
            {
                DisplayText.text = string.Empty;
                isEquals = false;
                isExistSecondOperand = false;
                DisplayText.text += num;
                firstOperand = Convert.ToDouble(DisplayText.text);
            }
            else
            {
                DisplayText.text += num;
                firstOperand = Convert.ToDouble(DisplayText.text);
                isExistSecondOperand = false;
            }

            isErased = false;
        }
        else
        {
            DisplayText.text = num.ToString();
            firstOperand = Convert.ToDouble(DisplayText.text);
            //firstOperand = num;
        }

        countRepeatEqual = 0;

        isEnterNumber = true;
        //isAgainPressing = true;
    }

    public void ResultPercentage()
    {
        if (isMathOperation) 
        { 
            isResultPersentage = true;
            Equals();
        }
        //isResultPersentage = true;
        //Equals();
    }

    private void GetResultPersentagePlusAndMinus()
    {
        if (isResultPersentage && isMathOperation)
        {
            string tempSecondOperand = secondOperand.ToString();

            //if (tempSecondOperand.Contains(",")) { secondOperand /= 100; }
            //else { secondOperand = (secondOperand / 100) * firstOperand; }
            secondOperand = (secondOperand / 100) * firstOperand;
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
        isNextOperation = false;
        firstOperand = 0;
        secondOperand = 0;
        result = 0;

        firstOperand = 0;
        secondOperand = 0;
        lastOperation = 0;
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

        if (isMathOperation) { secondOperand = numState; }
        else { firstOperand = numState; }
        //secondOperand = numState;
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
            //isExistSecondOperand = false;
            //firstOperand = Convert.ToDouble(DisplayText.text);
            //isEnterNumber = false;
            countRepeatEqual = 0;

            //secondOperand = Convert.ToDouble(DisplayText.text);
        }
    }

    public void Equals()
    {
        //if (!isExistSecondOperand) { secondOperand = firstOperand; }
        //if (!isEnterNumber) { secondOperand = firstOperand; }
        //else { secondOperand = 0; }

        if (!isMathOperation) { result = Convert.ToDouble(DisplayText.text); }

        if (isDivision)
        {
            GetResultPersentageMultiplyAndDivision();
            
            if (!isUserZero && secondOperand == 0)
            {
                secondOperand = 1;
                isUserZero = false;
            }
            //if (firstOperand == secondOperand) secondOperand = 1;

            result = firstOperand / secondOperand;
            isDivision = false;
            lastOperation = 1;
        }
        else if (isMultiply)
        {
            GetResultPersentageMultiplyAndDivision();

            if (!isUserZero && secondOperand == 0)
            {
                secondOperand = 1;
                isUserZero = false;
            }
            //if (firstOperand == secondOperand) secondOperand = 1;

            result = firstOperand * secondOperand;
            isMultiply = false;
            lastOperation = 2;
        }
        else if (isMinus)
        {
            GetResultPersentagePlusAndMinus();

            //if (firstOperand == secondOperand)
            //{
            //    secondOperand = 0;
            //    isUserZero = false;
            //}

            result = firstOperand - secondOperand;
            isMinus = false;
            lastOperation = 3;
        }
        else if (isPlus)
        {
            GetResultPersentagePlusAndMinus();

            //if (firstOperand == secondOperand)
            //{
            //    secondOperand = 0;
            //    isUserZero = false;
            //}

            result = firstOperand + secondOperand;
            isPlus = false;
            lastOperation = 4;
        }

        
        firstOperand = result;
        isExistSecondOperand = true;

        if (secondOperand != 0) { lastSecondOperand = secondOperand; }
        
        secondOperand = 0;

        //RepeatLastOperation();

        DisplayText.text = result.ToString();
        isEquals = true;
        isMathOperation = false;
        isSecondOperand = false;
        isNextOperation = false;
        //firstOperand = 0;
        //secondOperand = 0;
    }

    private void RepeatLastOperation()
    {
        if (countRepeatEqual >= 1)
        {
            //lastSecondOperand = Convert.ToDouble(DisplayText.text);

            switch (lastOperation)
            {
                case 1:
                    result = firstOperand / lastSecondOperand;
                    break;
                case 2:
                    result = firstOperand * lastSecondOperand;
                    break;
                case 3:
                    result = firstOperand - lastSecondOperand;
                    break;
                case 4:
                    result = firstOperand + lastSecondOperand;
                    break;
            }

            firstOperand = result;
        }

        countRepeatEqual++;
    }

    public void EraseByOne()
    {
        char[] displayNumbers = new char[DisplayText.text.Length - 1];

        for (int i = 0; i < displayNumbers.Length; i++)
        {
            displayNumbers[i] = DisplayText.text[i];
        }

        DisplayText.text = string.Join("", displayNumbers);

        if (DisplayText.text == string.Empty) 
        {
            DisplayText.text = "0";
            isErased = true;
        }

        if (!isMathOperation) { firstOperand = Convert.ToDouble(DisplayText.text); }
        else { secondOperand = Convert.ToDouble(DisplayText.text); }

        //firstOperand = Convert.ToDouble(DisplayText.text);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
 