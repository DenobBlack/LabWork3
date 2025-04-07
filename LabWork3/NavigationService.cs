using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using LabWork3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork3
{
    public class NavigationService
    {
        private readonly Stack<ObservableObject> _navigationStack = new Stack<ObservableObject>();

        public ObservableObject? CurrentViewModel { get; private set; }

        public event EventHandler<ObservableObject?>? CurrentViewModelChanged;

        public void NavigateTo<T>(T viewModel, Action<T>? action = null) where T : ObservableObject
        {
            if (CurrentViewModel != null)
            {
                _navigationStack.Push(CurrentViewModel);
            }

            action?.Invoke(viewModel);

            CurrentViewModel = viewModel;
            OnCurrentViewModelChanged(viewModel);
        }

        public void GoBack(int steps = 1)
        {
            if (steps <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(steps), "The number of steps must be greater than zero.");
            }

            for (int i = 0; i < steps; i++)
            {
                if (_navigationStack.Count > 0)
                {
                    CurrentViewModel = _navigationStack.Pop();
                }
                else
                {
                    CurrentViewModel = null;
                    break;
                }
            }

            OnCurrentViewModelChanged(CurrentViewModel);
        }

        protected virtual void OnCurrentViewModelChanged(ObservableObject? viewModel)
        {
            Dispatcher.UIThread.Post(() =>
            {
                CurrentViewModelChanged?.Invoke(this, viewModel);
            });
        }
    }
}
