using System;
using UnityEngine;

namespace LittleBigFun.ActionSender
{
    public static class ActionSender
    {

        #region Action
        private static void SendActionToInterfaces<T>(T[] interfaces, Action<T> action)
        {
            for (int i = 0; i < interfaces.Length; i++)
            {
                var t = interfaces[i];
                action(t);
            }
        }

        /// <summary>
        /// Run action(t) on every Component in this game object that implements T.
        /// </summary>
        public static void SendAction<T>(this GameObject go, Action<T> action)
        {
            SendActionToInterfaces(go.GetComponents<T>(), action);
        }

        /// <summary>
        /// See GameObject.SendAction.
        /// </summary>
        public static void SendAction<T>(this Component c, Action<T> action)
        {
            c.gameObject.SendAction(action);
        }

        /// <summary>
        /// Run action(t) on every Component in this game object or any of its children that implements T.
        /// </summary>
        public static void BroadcastAction<T>(this GameObject go, Action<T> action)
        {
            SendActionToInterfaces(go.GetComponentsInChildren<T>(), action);
        }

        /// <summary>
        /// See GameObject.BroadcastAction.
        /// </summary>
        public static void BroadcastAction<T>(this Component c, Action<T> action)
        {
            c.gameObject.BroadcastAction(action);
        }

        /// <summary>
        /// Run action(t) on every Component in this game object and on every ancestor of the behaviour that implements T.
        /// </summary>
        public static void SendActionUpwards<T>(this GameObject go, Action<T> action)
        {
            SendActionToInterfaces(go.GetComponentsInParent<T>(), action);
        }

        /// <summary>
        /// See GameObject.SendActionUpwards.
        /// </summary>
        public static void SendActionUpwards<T>(this Component c, Action<T> action)
        {
            c.gameObject.SendActionUpwards(action);
        }
        #endregion Action

        #region Action with result
        private static TResult[] SendActionToInterfaces<T, TResult>(T[] interfaces, Func<T, TResult> func)
        {
            var results = new TResult[interfaces.Length];
            for (int i = 0; i < interfaces.Length; i++)
            {
                var t = interfaces[i];
                results[i] = func(t);
            }
            return results;
        }

        /// <summary>
        /// Run func(t) on every Component in this game object that implements T, return TResult[].
        /// </summary>
        public static TResult[] SendAction<T, TResult>(this GameObject go, Func<T, TResult> func)
        {
            return SendActionToInterfaces(go.GetComponents<T>(), func);
        }

        /// <summary>
        /// See GameObject.SendAction.
        /// </summary>
        public static TResult[] SendAction<T, TResult>(this Component c, Func<T, TResult> func)
        {
            return c.gameObject.SendAction(func);
        }

        /// <summary>
        /// Run func(t) on every Component in this game object or any of its children that implements T, return TResult[].
        /// </summary>
        public static TResult[] BroadcastAction<T, TResult>(this GameObject go, Func<T, TResult> func)
        {
            return SendActionToInterfaces(go.GetComponentsInChildren<T>(), func);
        }

        /// <summary>
        /// See GameObject.BroadcastActrion.
        /// </summary>
        public static TResult[] BroadcastAction<T, TResult>(this Component c, Func<T, TResult> func)
        {
            return c.gameObject.BroadcastAction(func);
        }

        /// <summary>
        /// Run action(t) on every Component in this game object and on every ancestor of the behaviour that implements T, return TResult[].
        /// </summary>
        public static TResult[] SendActionUpwards<T, TResult>(this GameObject go, Func<T, TResult> func)
        {
            return SendActionToInterfaces(go.GetComponentsInParent<T>(), func);
        }

        /// <summary>
        /// See GameObject.SendActionUpwards.
        /// </summary>
        public static TResult[] SendActionUpwards<T, TResult>(this Component c, Func<T, TResult> func)
        {
            return c.gameObject.SendActionUpwards(func);
        }
        #endregion Action with result

    }

}
