using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityInfo
{
    public int KingID { get; set; }
    public int Prefect { get; set; }
    public int Population { get; set; }
    public int Money { get; set; }
    public int Reservist { get; set; }
    public int ReservistMax { get; set; }
    public int Defense { get; set; }

    private List<int> objects;
    private List<GeneralInfo> generals;
    private List<GeneralInfo> prisons;
}
