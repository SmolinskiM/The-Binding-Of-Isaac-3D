using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtension
{
    public static T Last<T>(this List<T> elements)
    {
        return elements[elements.Count - 1];
    }
}
