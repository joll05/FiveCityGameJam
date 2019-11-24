using System;
using System.Collections.Generic;
[Serializable]
public class Response
{
    public List<Scorepost> posts;
}

[Serializable]
public class Scorepost
{
    public string name;
    public string score;
}
