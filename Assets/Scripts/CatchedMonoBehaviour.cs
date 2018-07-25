using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchedMonoBehaviour : MonoBehaviour {

    SpriteRenderer thisSpriteRender;

    public SpriteRenderer CatchedSpriteRender {
        get {
            if (thisSpriteRender == null)
                thisSpriteRender = GetComponent<SpriteRenderer>();
            return thisSpriteRender;
        }
    }
    GameController thisGameController;

    public GameController CatchedGameController {
        get {
            GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (gameControllerObject != null)
                thisGameController = gameControllerObject.GetComponent<GameController>();
            else
                Logger.LogError("Game Controller doesen't exists");
            return thisGameController;
        }
    }

    Rigidbody2D thisRB2D;

    public Rigidbody2D CatchedRigidBody2D {
        get {
            if (thisRB2D == null)
                thisRB2D = GetComponent<Rigidbody2D>();
            return thisRB2D;
        }
    }

    ObjectPooler thisObjectPooler;

    public ObjectPooler CatchedObjectPooler {
        get {
            if(thisObjectPooler == null)
                thisObjectPooler = ObjectPooler.Instance;
            return thisObjectPooler;
        }
    }

    Animator thisAnimator;

    public Animator CatchedAnimator {
        get {
            if (thisAnimator == null)
                thisAnimator = GetComponent<Animator>();
            return thisAnimator;
        }
    }

    StatsController thisStats;

    public StatsController CatchedStats {
        get {
            if (thisStats == null)
                thisStats = GetComponent<StatsController>();
            return thisStats;
        }
    }
}
