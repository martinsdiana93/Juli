using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contar_Pontos : MonoBehaviour
{
    private static int rightAnswers = 0;
    private static int wrongAnswers = 0;
    private static int roundCount = 0;
    private static int roundMax = 3;
    public static bool lastCorrect = false;
    public static bool lastWrong = false;
    public static void IncrementRightAnswer()
    {
        rightAnswers++;
        roundCount++;
        lastCorrect = true;
        lastWrong = false;
    }
    public static void IncrementWrongAnswer()
    {
        wrongAnswers++;
        roundCount++;
        lastCorrect = false;
        lastWrong = true;
    }

    public static int GetRightAnswer()
    {
        return rightAnswers;
    }
    public static int GetWrongAnswer()
    {
        return wrongAnswers;
    }

    public static bool CheckGameEnd()
    {
        return roundCount >= roundMax;
    }

    public static void Reset()
    {
        rightAnswers = 0;
        wrongAnswers = 0;
        roundCount = 0;
        lastCorrect = false;
        lastWrong = false;
    }

}
