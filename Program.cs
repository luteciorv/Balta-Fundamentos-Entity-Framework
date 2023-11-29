using Blog.Data;
using Blog.Models;

using var context = new BlogDataContext();

Console.WriteLine("| TAGS |");
foreach (var tag in context.Tags)
{
    Console.WriteLine($"- Id: {tag.Id} \n" +
                      $"- Nome: {tag.Name} \n" +
                      $"- Url: {tag.Slug}");

    Console.WriteLine();
}