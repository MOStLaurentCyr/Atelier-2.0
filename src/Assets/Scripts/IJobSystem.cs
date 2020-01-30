using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJobSystem
{
    void SetJob(Job jobToGive);
    void ChangeJob();
}

