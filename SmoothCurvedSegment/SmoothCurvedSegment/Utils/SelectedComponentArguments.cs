using SmoothCurvedSegment.Model;
using System.Windows;

namespace SmoothCurvedSegment.Utils
{
    internal sealed class SelectedComponentArguments
    {
        public Component Model { get; }
        public IInputElement Sender { get; }

        public SelectedComponentArguments(Component model, IInputElement sender)
        {
            Model = model;
            Sender = sender;
        }
    }
}
