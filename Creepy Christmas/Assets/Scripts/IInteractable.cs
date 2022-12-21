public interface IInteractable
{
    public void Interact();

    public bool needItem { get; set; }
    public string neededItemName { get; set; } 
    public string description { get; set; } 
    public bool interacted { get; set; }
}