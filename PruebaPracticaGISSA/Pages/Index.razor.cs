using PruebaPracticaGISSA.Shared;

namespace PruebaPracticaGISSA.Pages
{
    public partial class Index
    {
        private Login loginComponent;
        private bool messageShown = false;
        private string messageTitle = string.Empty;
        private string messageBody = string.Empty;
        private string messageImage = string.Empty;
        private MessageWindow.MessageType messageType;

        private async void ButtonClick()
        {
            showMessage("Login", "Usuario logueado correctamente.", "", MessageWindow.MessageType.Success);
        }

        private void showMessage(string title, string message, string imgUrl, MessageWindow.MessageType type)
        {
            messageTitle = title;
            messageBody = message;
            messageType = type;
            messageShown = true;
            messageImage = imgUrl;
        }

        private void hideMessage()
        {
            messageShown = false;
        }
    }
}