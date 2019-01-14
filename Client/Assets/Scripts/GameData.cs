using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public bool isLost = false;
    public bool isShake = true;
    public bool isMusic = true;
    public bool isBloodSplash = false;

    public float protectPower = 0;
    public float protectRotateSpeed = 0;
    public float protectRotateInnerSpeed = 0;
    public float JGBRotateSpeed = 0;
    public float JGBPower = 0;

    public int diamonds = 0;
    //碰撞奖励数
    public int rewardNum = 0;
    public int rewardDiamond = 0;
    //血点数
    public int bloodNum = 0;
    //累计碰撞点数
    public float collidePoint = 100.0f;
    //通过的关卡数
    public int passedStageNum = 0;

    public StageState curStageState = StageState.OrderState;

    public string allPirceStr = "";

    public Vector3 protectPos;
    public List<GameObject> colliderList = new List<GameObject>();

    private static GameData instance = new GameData();
    public static GameData Instance {
        get {
            return instance;
        }
    }




}


public enum StageState
{
    OrderState,
    RandomState,
    GhostState,
    SkeletonState,
}