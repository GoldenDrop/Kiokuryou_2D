using UnityEngine;
using System.Collections;

public class PhaseController { // : MonoBehaviour {

    Phase presentPhase = Phase.Wait;

    public void SetPhase(Phase phase)
    {
        this.presentPhase = phase;
    }

    public Phase GetPhase()
    {
        return this.presentPhase;
    }
}
