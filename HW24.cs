
public sealed class Vehicle
{
    public string Name {get; set;} = string.Empty;
    public string Company {get; set;} = string.Empty;
    public string Color {get; set;} = string.Empty;
    public string MaxSpeed {get; set;} = string.Empty;


    private readonly List<DetailParts> _detailList = new();


    public DetailParts this[string name]
    {
        get => _detailList.Find(e => e.Name == name)!;
        set
        {
            DetailParts detail = _detailList.Find(e => e.Name == name)!;
            detail.Name = value.Name;
            detail.Weight = value.Weight;
            detail.Description = value.Description;
        }
    }

     public void AddDetail(string name, string weight, string description)
    {
        _detailList.Add(new DetailParts() { Name = name, Weight = weight, Description = description });
    }

    public DetailParts? GetDetailInfo(string name)
    {
        return _detailList.Find(e => e.Name == name);
    }

    public bool RemoveDetail(string name)
    {
        int detail = _detailList.FindIndex(e => e.Name.Equals(name));
        if (detail < 0)
        return false;
        _detailList.Clear();
        return true;
    }

     public bool EditDetail(string name, string newWeight, string newDescrition)
    {
        DetailParts? detail = _detailList.Find(e => e.Name == name);
        if (detail is null)
        return false;
        detail.Weight = newWeight;
        detail.Description = newDescrition;
        return true;
    }

    public IEnumerator<DetailParts> GetEnumerator()
    {
        foreach (DetailParts detail in _detailList)
        {
            yield return detail;
        }
    }
}

public sealed class DetailParts
{
    public string Name {get; set;} = string.Empty;
    public string Weight {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;

}
