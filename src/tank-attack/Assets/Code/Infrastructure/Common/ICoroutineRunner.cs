using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.Common
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator load);
    }
}