namespace backend;

public class Task
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status {get; set;}

    public Task() { }

    public Task(int id, string title, string description, string status)
    {
        ID = id;
        Title = title;
        Description = description;
        Status = status;
    }
}
