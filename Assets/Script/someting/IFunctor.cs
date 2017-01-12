using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFunctor<A, B, FB>{
    FB fmap(Func<A, B> fn);
}
