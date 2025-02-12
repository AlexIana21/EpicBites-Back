namespace Entities;
public class ReviewDto
{
    public string Text { get; set; }
    public DateTime Date {get;set;}
    public int Score {get;set;}
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public ReviewDto(){}
}