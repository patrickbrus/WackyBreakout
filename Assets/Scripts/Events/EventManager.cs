using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager {

    // add fields for the freezer effect event
    static PickupBox invokerFreezerEffect;
    static UnityAction<float> listenerFreezerEffect;

    // add fields for the speed up effect event
    static PickupBox invokerSpeedupEffect;
    static List<UnityAction<float, float>> listenerSpeedupEffect = new List<UnityAction<float, float>>();

    // add fields for Destroyed Blocks event
    static Box invokerBoxesDestroyed;
    static UnityAction listenerBoxesDestroyed;
    

    // methods for the freezer effect event
    public static void AddInvokerFreezerEffect(PickupBox script)
    {
        invokerFreezerEffect = script;
        if(listenerFreezerEffect != null)
        {
            invokerFreezerEffect.AddFreezerEffectListener(listenerFreezerEffect);
        }
    }

    public static void AddListenerFreezerEffect(UnityAction<float> script)
    {
        listenerFreezerEffect = script;
        if(invokerFreezerEffect != null)
        {
            invokerFreezerEffect.AddFreezerEffectListener(listenerFreezerEffect);
        }
    }

    //methods for speed up effect event
    public static void AddInvokerSpeedupEffect(PickupBox script)
    {
        invokerSpeedupEffect = script;
       
        foreach(UnityAction<float,float> listener in listenerSpeedupEffect)
        {
            invokerSpeedupEffect.AddSpeedupEffectListener(listener);
        }
    }

    public static void AddListenerSpeedupEffect(UnityAction<float,float> script)
    {
        listenerSpeedupEffect.Add(script);
        if (invokerSpeedupEffect != null)
        {
            foreach (UnityAction<float, float> listener in listenerSpeedupEffect)
            {
                invokerSpeedupEffect.AddSpeedupEffectListener(listener);
            }
        }
    }

    public static void AddInvokerBoxesDestroyed(Box script)
    {
        invokerBoxesDestroyed = script;
        if(listenerBoxesDestroyed != null)
        {
            invokerBoxesDestroyed.AddNoArgumentListener(listenerBoxesDestroyed);
        }
    }

    public static void AddListenerBoxesDestroyed(UnityAction script)
    {
        listenerBoxesDestroyed = script;
        if(invokerBoxesDestroyed != null)
        {
            invokerBoxesDestroyed.AddNoArgumentListener(listenerBoxesDestroyed);
        }
    }
	
}
