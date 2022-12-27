﻿using Serilog;

namespace LibWithLogging;

public class MyClass
{
    public static void Hello()
    {
        Log.ForContext<MyClass>().Warning("Tohle je warning z {typeFullName}", typeof(MyClass).FullName);
    }
}