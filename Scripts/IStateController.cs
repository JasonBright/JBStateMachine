using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JBStateMachine
{
    public interface IStateController
    {
        void OnEntered(EnterDataBase data);
        ExitDataBase OnExited();
    }

    public class EnterDataBase
    {
    }

    public class ExitDataBase
    {
    
    }
}