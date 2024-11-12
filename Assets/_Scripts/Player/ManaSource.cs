using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSource : MonoBehaviour {

    public event System.Action<float> OnManaFill;
    public event System.Action<float> OnManaDrain;

    public event System.Action OnManaCollapse;

    public float MaxMana { get; private set; }

    private float mana;
    public float Mana {
        get => mana;
        private set {
            mana = Mathf.Clamp(value, 0, MaxMana);
            if (mana <= 0) OnManaCollapse?.Invoke();
        }
    }

    public void Init(float maxMana) {
        MaxMana = maxMana;
        Mana = MaxMana;
    }

    public void Drain(float amount) {
        float absAmount = Mathf.Abs(amount);
        Mana -= absAmount;
        OnManaDrain?.Invoke(absAmount);
    }

    public void Fill(float amount) {
        float absAmount = Mathf.Abs(amount);
        Mana += absAmount;
        OnManaFill?.Invoke(absAmount);
    }
}