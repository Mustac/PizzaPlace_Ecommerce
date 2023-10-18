namespace PizzaPlace.BlazorServer.Shared.Component.ConfirmationModalPackage
{
    public class ConfirmationModal
    {
        // Delegate and event to trigger modal
        internal delegate Task<bool> ShowModalDelegate(string text);
        internal event ShowModalDelegate OnShowModal;

        public async Task<bool> ShowAsync(string text)
        {
            // Ensure that OnShowModal is not null before invoking
            return OnShowModal is null? false: await OnShowModal.Invoke(text);
        }
    }
}
