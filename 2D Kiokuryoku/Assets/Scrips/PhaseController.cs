using UnityEngine;
using System.Collections;

public  class PhaseController : MonoBehaviour {

    Phase phase = Phase.Wait;


    public void SetPhase(Phase presentPhase)
    {
        this.phase = presentPhase;
    }


    public Phase GetPhase()
    {
        return this.phase;
    }

}
