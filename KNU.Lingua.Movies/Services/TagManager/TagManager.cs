using KNU.Lingua.Movies.Models.Tag;
using KNU.Lingua.Movies.Services.PorterStemmerFilter;
using KNU.Lingua.Movies.Services.StopWordsFilter;
using KNU.Lingua.Movies.Services.TagService;
using System.Collections.Generic;
using System.Linq;

namespace KNU.Lingua.Movies.Services.TagManager
{
    public class TagManager : ITagManager
    {
        private readonly IPorterStemmerFilter porterStemmerFilter;
        private readonly IStopWordsFilter stopWordsFilter;
        private readonly ITagService tagService;

        public TagManager(IPorterStemmerFilter porterStemmerFilter, IStopWordsFilter stopWordsFilter,
            ITagService tagService)
        {
            this.porterStemmerFilter = porterStemmerFilter;
            this.stopWordsFilter = stopWordsFilter;
            this.tagService = tagService;
        }

        public List<Tag> GetProcessedTags(string text)
        {
            // Removing stop words and normalizing the words
            var proccessedStopwords = stopWordsFilter.Process(text);
            var filteredItem = porterStemmerFilter.Process(proccessedStopwords);

            // Get top 10 tags from article
            var tags = tagService.GetTopTagsForNewsItem(filteredItem);

            return tags.OrderByDescending(t => t.NormCount).ToList();
        }
    }
}
