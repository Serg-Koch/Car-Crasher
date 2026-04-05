using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static event Action <int> ScoreChange;
    public int CountRound {get; private set;} = 0;
    public int CountCommon {get; private set;} = 0;
    public int BonusPoints {get; private set;} = 100;
    
    public void AddRoundPoints(GameObject gameObject)
    {
        var properties = gameObject.GetComponent<ObjectProperties>();
        CountRound += properties.Points;
        ScoreChange?.Invoke(CountRound);
    }
    public void AddBonusPoints()
    {
        CountRound += BonusPoints;
        ScoreChange?.Invoke(CountRound);
    }
    public void AddCommonPoints()
    {
        CountCommon += CountRound;
    }
    private void OnEnable()
    {
        ObjectDestroy.DestroyFromMouse += AddRoundPoints;
        //ObjectDestroy.DestroyFromFloor += AddRoundPoints(gameObject);
        ObjectDestroy.DestroyFromGoodCar += AddBonusPoints;
        //ObjectDestroy.DestroyFromBadCar += AddRoundPoints(gameObject);
    }
        private void OnDisable()
    {
        ObjectDestroy.DestroyFromMouse -= AddRoundPoints;
        //ObjectDestroy.DestroyFromFloor -= AddRoundPoints(gameObject);
        ObjectDestroy.DestroyFromGoodCar -= AddBonusPoints;
        //ObjectDestroy.DestroyFromBadCar -= AddRoundPoints(gameObject);
    }
}