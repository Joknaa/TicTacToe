using Model;
using UnityEngine;

namespace View{
    public class InputView : MonoBehaviour
    {
        public Signal signal;
        
        public void OnMouseDown()
        {
            print("Input view : Clicked !! :D");
            signal.Raise();
        }
    }
}