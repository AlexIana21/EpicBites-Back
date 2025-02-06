namespace Entities;
public class Review
{
    public int Id { get;  set; }
    public string Text { get; set; }
    public DateTime Date {get;set;}
    public int Score {get;set;}
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public Review(){
    }
}