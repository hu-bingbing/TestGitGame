using UnityEngine;
using System.Collections;

public class DiscreteGesture : FingerGesture { }

public abstract class DiscreteGestureRecognizer<T> : GestureRecognizerTS<T> where T : DiscreteGesture, new()
{
    protected override void OnStateChanged( FingerGesture sender )
    {
        base.OnStateChanged( sender );

        T gesture = (T)sender;

        if( gesture.State == GestureRecognitionState.Recognized )
            RaiseEvent( gesture );
    }
}
