using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TriviaGame.Models;
using TriviaGame.ViewModels;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.AccessCache;

namespace TriviaGame.Data
{
    public class DataPersister
    {
        public static ObservableCollection<QuestionViewModel> GetQuestions(Category category)
        {
            string categoryStr = "";
            switch (category)
            {
                case Category.Movies:
                    categoryStr = "movies";
                    break;
                case Category.Songs:
                    categoryStr = "songs";
                    break;
            }

            IEnumerable<QuestionViewModel> questions = GetQuestions(categoryStr);
            ObservableCollection<QuestionViewModel> questionsObservable = 
                new ObservableCollection<QuestionViewModel>();

            foreach (var question in questions)
            {
                questionsObservable.Add(question);
            }

            return questionsObservable;
        }

        private static IEnumerable<QuestionViewModel> GetQuestions(string category)
        {
            var path = Path.Combine(Package.Current.InstalledLocation.Path, "Assets\\trivia-questionaire.xml");
            var categoriesRoot = XDocument.Load(path).Root;
            var questions = from questionQuery in categoriesRoot.Element(category).Elements("question")
                            select new QuestionViewModel()
                            {
                                Content = questionQuery.Element("content").Value,
                                Answers = from queryAnswers in questionQuery.Element("answers").Elements("answer")
                                          select new Answer
                                          {
                                              Content = queryAnswers.Element("content").Value,
                                              IsCorrect = queryAnswers.Element("isCorrect").Value.Trim() == "true" ? true : false
                                          }
                            };
            return questions;
        }
    }
}
