using Markdig;

using Markdig.Extensions.AutoIdentifiers;
using Microsoft.AspNetCore.Html;
public static class Markdown
{
    public static string Parse(string markdown)
    {
        var builder = new MarkdownPipelineBuilder();
        builder.UseAbbreviations()
            .UseAutoIdentifiers(AutoIdentifierOptions.GitHub)
            .UseCitations()
            .UseDefinitionLists()
            .UseEmphasisExtras()
            .UseFigures()
            .UseFooters()
            .UseFootnotes()
            .UseGridTables()
            .UseAdvancedExtensions()
            .UsePragmaLines()
            .UsePreciseSourceLocation()
            .UseYamlFrontMatter()
            .UseEmojiAndSmiley()
            .UseMathematics()
            .UseMediaLinks()
            .UsePipeTables()
            .UseListExtras()
            .UseTaskLists()
            .UseDiagrams()
            .UseAutoLinks()
            .UseGenericAttributes()
            .UseCitations()
            .UseCustomContainers()
            .UseDefinitionLists()
            .UseEmphasisExtras()
            .UseFigures()
            .UseFooters()
            .UseFootnotes()
            .UseGridTables()
            .UseMathematics()
            .UseMediaLinks()
            .UsePipeTables()
            .UseListExtras()
            .UseTaskLists()
            .UseDiagrams()
            .UseAutoLinks()
            .UseGenericAttributes();


        var mdPipeline = builder.Build();
        if(markdown != null)
        {
            return Markdig.Markdown.ToHtml(markdown, mdPipeline);
        }
        return markdown;
    }

    public static HtmlString ParseHtmlString(string markdown)
    {
        return new HtmlString(Parse(markdown));
    }
}