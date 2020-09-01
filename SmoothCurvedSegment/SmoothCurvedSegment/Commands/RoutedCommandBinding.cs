using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace SmoothCurvedSegment.Commands
{
    public class RoutedCommandBinding : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
          nameof(Command),
          typeof(ICommand),
          typeof(RoutedCommandBinding),
          new PropertyMetadata(default(ICommand)));

        /// <summary> The command that should be executed when the RoutedCommand fires. </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        /// <summary> The command that triggers <see cref="ICommand"/>. </summary>
        public ICommand RoutedCommand { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            var binding = new CommandBinding(RoutedCommand, HandleExecuted, HandleCanExecute);
            AssociatedObject.CommandBindings.Add(binding);
        }

        /// <summary> Proxy to the current Command.CanExecute(object). </summary>
        private void HandleCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = Command?.CanExecute(args) == true;
            args.Handled = true;
        }

        /// <summary> Proxy to the current Command.Execute(object). </summary>
        private void HandleExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            Command?.Execute(args);
            args.Handled = true;
        }
    }
}
