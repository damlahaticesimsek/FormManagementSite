public class Field
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }
    public bool Required { get; set; }
    public virtual FormModel Form { get; set; }
}
