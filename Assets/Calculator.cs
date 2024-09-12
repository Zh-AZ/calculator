using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text DisplayText;

    private bool isSecondOperand = true;
    private bool isMathOperation;
    private bool isEquals;
    private bool isDivision;
    private bool isMultiply;
    private bool isMinus;
    private bool isPlus;
    private bool isResultPersentage;
    private bool isNextOperation;
    private bool isUserZero;
    private bool isErased;

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
            if (!DisplayText.text.Contains(",")) { DisplayText.text += ","; }
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
                }

                DisplayText.text += num;
                secondOperand = Convert.ToDouble(DisplayText.text.Replace(" ", ""));

                if (secondOperand == 0) { isUserZero = true; }
            }
            else if (isEquals)
            {
                DisplayText.text = string.Empty;
                isEquals = false;
                DisplayText.text += num;
                firstOperand = Convert.ToDouble(DisplayText.text.Replace(" ", ""));
            }
            else
            {
                DisplayText.text += num;
                firstOperand = Convert.ToDouble(DisplayText.text.Replace(" ", ""));
            }

            isErased = false;
        }
        else
        {
            DisplayText.text = num.ToString();
            firstOperand = Convert.ToDouble(DisplayText.text.Replace(" ", ""));
        }

        Format();
    }

    public void ResultPercentage()
    {
        if (isMathOperation) 
        { 
            isResultPersentage = true;
            Equals();
        }
    }

    private void GetResultPersentagePlusAndMinus()
    {
        if (isResultPersentage && isMathOperation)
        {
            string tempSecondOperand = secondOperand.ToString();
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
    }

    public void Division() 
    {
        if (isNextOperation) Equals();
        Operator(ref isDivision);
    }

    public void Multiply() 
    {
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
        if (DisplayText.text != string.Empty && DisplayText.text != 0.ToString())
        {
            double numState = Convert.ToDouble(DisplayText.text.Replace(" ", ""));

            if (numState < 0) { numState = Math.Abs(numState); }
            else { numState = -numState; }

            if (isMathOperation) { secondOperand = numState; }
            else { firstOperand = numState; }
            DisplayText.text = numState.ToString();
        }    
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
        }
    }

    public void Equals()
    {
        if (DisplayText.text != string.Empty)
        {
            if (!isMathOperation) { result = Convert.ToDouble(DisplayText.text.Replace(" ", "")); }

            if (isDivision)
            {
                GetResultPersentageMultiplyAndDivision();

                if (!isUserZero && secondOperand == 0)
                {
                    secondOperand = 1;
                    isUserZero = false;
                }

                result = firstOperand / secondOperand;
                isDivision = false;
            }
            else if (isMultiply)
            {
                GetResultPersentageMultiplyAndDivision();

                if (!isUserZero && secondOperand == 0)
                {
                    secondOperand = 1;
                    isUserZero = false;
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

            Format();
        }      
    }

    public void EraseByOne()
    {
        if (DisplayText.text != string.Empty && DisplayText.text != 0.ToString())
        {
            char[] displayNumbers = new char[DisplayText.text.Length - 1];

            for (int i = 0; i < displayNumbers.Length; i++) { displayNumbers[i] = DisplayText.text[i]; }

            DisplayText.text = string.Join("", displayNumbers);

            if (DisplayText.text == string.Empty || string.IsNullOrWhiteSpace(DisplayText.text))
            {
                DisplayText.text = "0";
                isErased = true;
            }

            if (!isMathOperation) { firstOperand = Convert.ToDouble(DisplayText.text.Replace(" ", "")); }
            else { secondOperand = Convert.ToDouble(DisplayText.text.Replace(" ", "")); }
        }
    }

    private void Format()
    {
        if (DisplayText.text != string.Empty && DisplayText.text != 0.ToString())
        {
            double format = Convert.ToDouble(DisplayText.text.Replace(" ", ""));
            DisplayText.text = format.ToString("### ### ### ##0.############"); //12
        }

        while (DisplayText.text.Length >= 18)
        {
            char[] copyNums = new char[DisplayText.text.Length - 1];

            Array.Copy(DisplayText.text.ToCharArray(), copyNums, copyNums.Length);
            DisplayText.text = string.Join("", copyNums);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
