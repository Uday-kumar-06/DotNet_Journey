using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Behaviour_Pattern.observer_pattern
{
    public class NewsPublisher
    {
        public event Action<string> OnNewsPublished;

        public void PublishNews(string news)
        {
            OnNewsPublished?.Invoke(news);
        }
    }
}
