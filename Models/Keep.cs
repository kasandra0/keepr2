namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public string Img { get; set; }
    public int IsPrivate { get; set; } = 0;
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
  }
}