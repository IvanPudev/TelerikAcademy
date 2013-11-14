using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TriviaGame.Data;
using TriviaGame.Models;
using TriviaGame.Commands;
using Windows.UI.Xaml.Controls;

namespace TriviaGame.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private ObservableCollection<QuestionViewModel> questions;
        private ICommand startGame;
        private ICommand selectCategory;
        private ICommand showSelectedQuestionAnswers;
        private ICommand checkAnswer;
        private bool isActive;
        private Category triviaCategory;
        private QuestionViewModel currentQuestion;
        private string message;

        public bool Active
        {
            get
            {
                return this.isActive;
            }
            set
            {
                this.isActive = value;
                this.OnPropertyChanged("Active");
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set 
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public QuestionViewModel CurrentQuestion
        {
            get
            {
                return this.currentQuestion;
            }
            set
            {
                this.currentQuestion = value;
                this.OnPropertyChanged("CurrentQuestion");
            }

        }

        public Category TriviaCategory
        {
            get
            {
                return this.triviaCategory;
            }
            set
            {
                this.triviaCategory = value;
                this.OnPropertyChanged("TriviaCategory");
            }
        }

        public ICommand ShowSelectedQuestionAnswers
        {
            get
            {
                if (this.showSelectedQuestionAnswers == null)
                {
                    this.showSelectedQuestionAnswers = new DelegateCommand<SelectionChangedEventArgs>(this.HandleShowAnswers);
                }
                return this.showSelectedQuestionAnswers;
            }
        }

        public ICommand CheckAnswer
        {
            get
            {
                if (this.checkAnswer==null)
                {
                    this.checkAnswer = new DelegateCommand<SelectionChangedEventArgs>(this.HandleCheckAnswerCommand);
                }
                return this.checkAnswer;
            }
        }

        private void HandleCheckAnswerCommand(SelectionChangedEventArgs parameter)
        {
            var isCorectArg = parameter.AddedItems.FirstOrDefault() as Answer;
            if (isCorectArg!=null)
            {
                if (isCorectArg.IsCorrect)
                {
                    this.Message = "Correct";
                }
                else
                {
                    this.Message = "Sorry, you`re wrong!";
                }
            }
        }

        private void HandleShowAnswers(SelectionChangedEventArgs parameter)
        {
            this.CurrentQuestion = parameter.AddedItems.FirstOrDefault() as QuestionViewModel;
        }

        public GameViewModel()
        {
            this.Active = false;
        }

        public IEnumerable<QuestionViewModel> Questions
        {
            get
            {
                if (this.questions == null)
                {
                    this.questions = new ObservableCollection<QuestionViewModel>();
                }
                return this.questions;
            }
            set
            {
                if (this.questions == null)
                {
                    this.questions = new ObservableCollection<QuestionViewModel>();
                }
                this.SetObservableValues<QuestionViewModel>(this.questions, value);
            }
        }

        public ICommand StartGame
        {
            get
            {
                if (this.startGame == null)
                {
                    this.startGame = new DelegateCommand<string>(this.HandleStartGameCommand);
                }
                return this.startGame;
            }

        }

        public ICommand SetCategory
        {
            get
            {
                if (this.selectCategory == null)
                {
                    this.selectCategory = new DelegateCommand<string>(this.HandleSelectCategoryCommand);
                }
                return this.selectCategory;
            }
        }

        private void HandleSelectCategoryCommand(string parameter)
        {
            switch (parameter)
            {
                case "Songs": this.TriviaCategory = Category.Songs;
                    break;
                case "Movies": this.TriviaCategory = Category.Movies;
                    break;
            }

            this.Questions = DataPersister.GetQuestions(this.TriviaCategory);
        }

        private void HandleStartGameCommand(string parameter)
        {
            this.Active = true;
        }

        private void SetObservableValues<T>(ObservableCollection<T> observableCollection, IEnumerable<T> values)
        {
            if (observableCollection != values)
            {
                observableCollection.Clear();
                foreach (var item in values)
                {
                    observableCollection.Add(item);
                }
            }
        }
    }
}
