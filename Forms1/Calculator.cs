using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorForm
{
    internal class Calculator
    {
        private List<string> calcList;

        public Calculator()
        { }

        public string Calculate(string calculationInput)
        {
            string tempString = "0";

            calcList = new List<string>();

            try
            {
                LoadList(calculationInput);
                CalculatePower();
                CalculateDivideMultiplyModulus();
                CalculateAddSubtract();
                tempString = calcList.ElementAt(0);
            }
            catch (FormatException)
            {
                tempString = "Invalid input format";
            }
            catch (DivideByZeroException)
            {
                tempString = "Divide by Zero";
            }
            catch (OverflowException)
            {
                tempString = "Out of range";
            }
            catch (Exception)
            {
                tempString = "Unexpected";
            }

            return tempString;
        }

        private void CalculatePower()
        {
            double previousInt, nextInt, result = 0;
            string currentStr;

            for (int i = 0; i < calcList.Count; i++)
            {
                currentStr = calcList.ElementAt(i);

                if (isCaret(currentStr))
                {
                    previousInt = Double.Parse(calcList.ElementAt(i - 1));
                    nextInt = Double.Parse(calcList.ElementAt(i + 1));

                    result = checked(Math.Pow(previousInt, nextInt));

                    AddResultToList(i, result);
                    i--;
                }
            }
        }

        private void CalculateDivideMultiplyModulus()
        {
            double previousInt, nextInt, result = 0;
            string currentStr;

            for (int i = 0; i < calcList.Count; i++)
            {
                currentStr = calcList.ElementAt(i);

                if (isDivideMultiplyModulus(currentStr))
                {
                    previousInt = Double.Parse(calcList.ElementAt(i - 1));
                    nextInt = Double.Parse(calcList.ElementAt(i + 1));

                    if (isMultiply(currentStr))
                        result = checked(previousInt * nextInt);
                    else if (isDivide(currentStr))
                        result = checked(previousInt / nextInt);
                    else if (isModulus(currentStr))
                        result = checked(previousInt % nextInt);

                    AddResultToList(i, result);
                    i--;
                }
            }
        }

        private void CalculateAddSubtract()
        {
            double previousInt, nextInt, result = 0;
            string currentStr;

            for (int i = 0; i < calcList.Count; i++)
            {
                currentStr = calcList.ElementAt(i);

                if (isAddSubtract(currentStr))
                {
                    previousInt = Double.Parse(calcList.ElementAt(i - 1));
                    nextInt = Double.Parse(calcList.ElementAt(i + 1));

                    if (isAdd(currentStr))
                        result = checked(previousInt + nextInt);
                    else if (isSubtract(currentStr))
                        result = checked(previousInt - nextInt);

                    AddResultToList(i, result);
                    i--;
                }
            }
        }

        private void LoadList(string calculationInput)
        {
            string tempString = "";

            for (int i = 0; i < calculationInput.Length; i++)
            {
                string character = calculationInput.ElementAt(i) + "";

                if (tempString == "" || !isOperator(character))
                {
                    tempString += character;
                }
                else
                {
                    calcList.Add(tempString);
                    tempString = "";
                    calcList.Add("" + character);
                }
            }
            // Final List.Add to add last string to list
            calcList.Add(tempString);
        }

        private void AddResultToList(int index, double result)
        {
            calcList.RemoveAt(index);
            calcList.Insert(index, result.ToString());
            calcList.RemoveAt(index + 1);
            calcList.RemoveAt(index - 1);
        }

        private bool isOperator(string inputString)
        {
            return isDivideMultiplyModulus(inputString) || isAddSubtract(inputString) || isCaret(inputString);
        }

        private bool isDivideMultiplyModulus(string inputString)
        {
            return isDivide(inputString) || isMultiply(inputString) || isModulus(inputString);
        }

        private bool isAddSubtract(string inputString)
        {
            return isAdd(inputString) || isSubtract(inputString);
        }

        private bool isDivide(string inputString)
        {
            return inputString == "/";
        }

        private bool isMultiply(string inputString)
        {
            return inputString == "*";
        }

        private bool isModulus(string inputString)
        {
            return inputString == "%";
        }

        private bool isAdd(string inputString)
        {
            return inputString == "+";
        }

        private bool isSubtract(string inputString)
        {
            return inputString == "-";
        }

        private bool isCaret(string inputString)
        {
            return inputString == "^";
        }
    }
}