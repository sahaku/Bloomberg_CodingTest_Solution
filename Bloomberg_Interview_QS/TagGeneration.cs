using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bloomberg_Interview_QS
{
    public static class TagGenerator
    {
        // Basic stopwords list (expand as needed)
        //    private static readonly HashSet<string> Stopwords = new HashSet<string>
        //{
        //    "a","an","the","and","or","but","of","to","in","on","at","for","with",
        //    "over","under","from","into","by","is","are","was","were","be","being",
        //    "been","that","this","these","those"
        //};

        static HashSet<string> wordStops = new HashSet<string>
        {
            "a","an","and","or", "but","of","to","in","with","over", "under","from","under",
            "with","into","is","are","was","were","be","being","been","that","this","these","those"
        };

        public static string GenerateTag(string caption, int maxWords = 3)
        {
            if (string.IsNullOrWhiteSpace(caption))
                return string.Empty;

            // 1. Lowercase
            //caption = caption.ToLowerInvariant();
            caption = caption.ToLowerInvariant();

            // 2. Remove punctuation
            caption = Regex.Replace(caption, @"[^\w\s]", "");
            //caption = Regex.Replace(caption, @"[^\w\s]", "");


            // 3. Split into words
            var words = caption.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //var words = caption.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // 4. Remove stopwords
            var filtered = words.Where(w => !wordStops.Contains(w)).ToList();
            //var filtered = words.Where(w => !wordStops.Contains(w)).ToList();

            //var filtered = words.Where(w => !Stopwords.Contains(w)).ToList();

            if (filtered.Count == 0)
                return string.Empty;

            // 5. Optional heuristic: prefer words that look like nouns/verbs
            // Simple heuristic: keep words longer than 2 chars
            var meaningful = filtered.Where(w => w.Length > 2).ToList();
            if (meaningful.Count == 0)
                meaningful = filtered;

            // 6. Take first N words
            var selected = meaningful.Take(maxWords);

            // 7. Join with hyphens
            return string.Join("-", selected);
        }
    }

}
