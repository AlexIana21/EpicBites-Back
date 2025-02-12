namespace Entities;
public class FavoriteDto
{
    public DateTime Date {get;set;}
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public FavoriteDto (){}
}