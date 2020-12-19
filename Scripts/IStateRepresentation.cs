using System;
using System.Collections.Generic;

namespace JBStateMachine
{
    public interface IStateRepresentation<TState, TTrigger>
    {
        TState state { get; }
        IStateRepresentation<TState, TTrigger> superState { get; set; }
        IDictionary<TTrigger, TState> transitions { get; }
        ICollection<TTrigger> permittedTriggers { get; }
        
        IStateController Controller { get; }

        bool CanHandle(TTrigger trigger);
        void AddTransition(TTrigger trigger, TState state);
        TState GetTransitionState(TTrigger trigger);
        void OnEnter(ITransition<TState, TTrigger> transition);
        void OnExit(ITransition<TState, TTrigger> transition);
        void AddEntryAction(Action action);
        void AddExitAction(Action action);
        void SetEntryStateData(StateDataDelegate<ITransition<TState, TTrigger>> action);
        void SetExitData(Action<ITransition<TState, TTrigger>> action);
        
        /// <summary>
        /// Returns true if <paramref name="state"/> is equal to this state or
        /// to any of its sub-states.
        /// </summary>
        /// <param name="state">State to check for.</param>
        /// <returns>True if this state or any of its sub-states are equal to
        /// <paramref name="state"/>, false otherwise.</returns>
        bool Includes(TState state);
    }
}
